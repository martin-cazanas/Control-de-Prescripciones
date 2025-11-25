using CTRL_Prescripciones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTRL_Prescripciones
{
    public partial class Editar_Analista : UserControl
    {
        public bool jefe { get; set; }
        public Editar_Analista()
        {
            InitializeComponent();
        }

        private void dgvProperties()
        {
            dgvAnalistas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAnalistas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAnalistas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvAnalistas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAnalistas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }
        private void Limpiar()
        {
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            cmbDivision.SelectedIndex = 0;
            cmbDivision.Enabled = true;
            ckbJefe.Checked = false;
            rbtActivo.Checked = false;
            rbtInactivo.Checked = false;
            LoadCatalogos();
        }
        private bool Editar()
        {
            try
            {
                Analistas ana = new Analistas();
                ana.id = Convert.ToInt32(txtID.Text);
                ana.nombre = Utilidades.Utilidades.quitarAcentos(txtNombre.Text);
                ana.usuario = txtUsuario.Text;
                ana.jefe = ckbJefe.Checked;
                ana.estatus = rbtActivo.Checked;
                if (ana.estatus)
                {
                    if (!ana.jefe)
                        ana.division = ana.getDivisionID(cmbDivision.Text);
                    else
                        ana.division = ana.id;
                }
                else
                    ana.division = 0;
                if (ana.Editar())
                {
                    Ordenes ord = new Ordenes();
                    ord.analista = Convert.ToInt32(txtID.Text);
                    ord.ano = DateTime.Now.Year.ToString();
                    ord.id = ord.GetID();
                    if (ord.id > 0)
                    {
                        ord.estatus = Convert.ToInt32(ana.estatus);
                        return ord.ActualizarEstatus();
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private void LoadCatalogos()
        {
            cmbDivision.Items.Clear();
            cmbBusqueda.Items.Clear();
            Analistas ana = new Analistas();
            DataTable divisiones = ana.getDivisiones();
            cmbBusqueda.Items.Add("ACTIVOS");
            cmbBusqueda.Items.Add("JEFES");
            cmbBusqueda.Items.Add("INACTIVOS");
            cmbDivision.Items.Add("--SELECCIONAR");
            foreach (DataRow row in divisiones.Rows)
            {
                cmbBusqueda.Items.Add(row[0]);
                cmbDivision.Items.Add(row[0]);
            }
        }
        private void Editar_Analista_Load(object sender, EventArgs e)
        {
            LoadCatalogos();
            cmbBusqueda.SelectedIndex = 0;
            cmbBusqueda.SelectedIndex = 0;
        }
        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Analistas ana = new Analistas();
                string condicion = "";
                switch (cmbBusqueda.SelectedIndex)
                {
                    case 0:
                        condicion = "WHERE Estatus = 'ACTIVO'";
                        dgvAnalistas.DataSource = ana.VistaPrevia(condicion);
                        break;
                    case 1:
                        condicion = "WHERE División = 'JEFE DE DIVISIÓN'";
                        dgvAnalistas.DataSource = ana.VistaPrevia(condicion);
                        break;
                    case 2:
                        condicion = "WHERE Estatus = 'INACTIVO'";
                        dgvAnalistas.DataSource = ana.VistaPrevia(condicion);
                        break;
                    default:
                        condicion = "WHERE División = '" + cmbBusqueda.Text + "'";
                        dgvAnalistas.DataSource = ana.VistaPrevia(condicion);
                        break;

                }
                dgvProperties();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvAnalistas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    Limpiar();
                    cmbDivision.Items.Remove(dgvAnalistas.Rows[e.RowIndex].Cells[1].Value);
                    txtID.Text = dgvAnalistas.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtNombre.Text = dgvAnalistas.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtUsuario.Text = dgvAnalistas.Rows[e.RowIndex].Cells[2].Value.ToString();
                    ckbJefe.Checked = jefe = dgvAnalistas.Rows[e.RowIndex].Cells[3].Value.ToString().Equals("JEFE DE DIVISIÓN");
                    if (!ckbJefe.Checked)
                    {
                        cmbDivision.SelectedItem = dgvAnalistas.Rows[e.RowIndex].Cells[3].Value.ToString();
                        if (cmbDivision.SelectedItem == null)
                            cmbDivision.SelectedIndex = 0;
                    }
                    if (dgvAnalistas.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("ACTIVO"))
                        rbtActivo.Checked = true;
                    else
                        rbtInactivo.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
            cmbBusqueda.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool resultado = false;
                Analistas ana = new Analistas();
                DataTable analistas;
                if (!rbtActivo.Checked)
                {
                    ana.division = Convert.ToInt32(txtID.Text);
                    analistas = ana.getAnalistas();
                    if (analistas.Rows.Count > 1)
                    {
                        MessageBox.Show("El analista que está intentando inactivar tiene analistas a su cargo, por lo que deberá cambiar la división de dichos analistas antes de inactivarlo", "No se puede desactivar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    analistas = ana.ConsultarExpedientes();
                    if (analistas.Rows.Count > 0)
                    {
                        MessageBox.Show("El analista que está intentando inactivar tiene expedientes activos, por lo que deberá concluir o reasignar dichos expedientes antes de inactivarlo", "No se puede desactivar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Editar())
                    {
                        MessageBox.Show("Se desactivo correctamente al analista: " + txtNombre.Text.ToUpper(), "Analista desactivado", MessageBoxButtons.OK);
                        Limpiar();
                        cmbBusqueda.SelectedIndex = 0;
                        return;
                    }
                }
                if (jefe)
                {
                    if (ckbJefe.Checked != jefe)
                    {
                        ana.division = Convert.ToInt32(txtID.Text);
                        analistas = ana.getAnalistas();
                        if (analistas.Rows.Count > 1)
                        {
                            MessageBox.Show("No fue posible retirar el cargo de \"Jefe de División\" al analista: " + txtNombre.Text.ToUpper() + " debido a que cuenta con analistas a su cargo.\nCambie la divisón de dichos analistas para poder editar la información", "No se pudo editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            if ((cmbDivision.SelectedIndex == 0 && !ckbJefe.Checked) || string.IsNullOrEmpty(txtNombre.Text))
                            {
                                MessageBox.Show("Por favor llena todos los campos antes de continuar", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                                resultado = Editar();
                        }
                    }
                    else
                        resultado = Editar();
                }
                else
                {
                    if ((cmbDivision.SelectedIndex == 0 && !ckbJefe.Checked) || string.IsNullOrEmpty(txtNombre.Text))
                    {
                        MessageBox.Show("Por favor llena todos los campos antes de continuar", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                        resultado = Editar();
                }
                if (resultado)
                    MessageBox.Show("Se edito la información del analista: " + txtNombre.Text.ToUpper() + " correctamente", "Registro modificado");
                else
                    MessageBox.Show("Ocurrio un error al modificar la información", "Registro modificado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
                cmbBusqueda.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ckbJefe_CheckedChanged(object sender, EventArgs e)
        {
            cmbDivision.Enabled = !ckbJefe.Checked;
        }
    }
}
