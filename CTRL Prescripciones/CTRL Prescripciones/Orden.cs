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
    public partial class Orden : UserControl
    {
        string division = string.Empty;
        public Orden()
        {
            InitializeComponent();
        }

        private void LoadAnos()
        {
            try
            {
                cmbAno.Items.Clear();
                Ordenes ord = new Ordenes();
                List<int> anos = ord.getAnos();
                if(anos.Count > 0)
                {
                    foreach(int ano in anos)
                        cmbAno.Items.Add(ano);
                    cmbAno.SelectedItem = DateTime.Now.Year;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvProperties()
        {
            dgvOrden.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrden.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrden.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrden.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrden.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }
        private void Limpiar()
        {
            txtAnalista.Text = string.Empty;
            txtID.Text = string.Empty;
            label5.Visible = false;
            cmbEstatus.Visible = false;
            btnAsignar.Visible = true;
            btnOmitir.Visible = true;
            btnProximo.Text = "Próximo turno";
        }
        private void Orden_Load(object sender, EventArgs e)
        {
            LoadAnos();
            cmbEstatus.Items.Add("INACTIVO");
            cmbEstatus.Items.Add("ACTIVO");
            cmbEstatus.Items.Add("CONGELADO");
        }
        private void dgvOrden_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            try
            {
                int row = e.RowIndex;
                if (row >= 0)
                {
                    txtID.Text = dgvOrden.Rows[row].Cells[0].Value.ToString();
                    txtAnalista.Text = dgvOrden.Rows[row].Cells[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ordenes ord = new Ordenes();
            ord.ano = cmbAno.Text;
            dgvOrden.DataSource = ord.VistaPrevia();
            dgvProperties();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if(DialogResult.OK == MessageBox.Show("Ests a punto de crear un nuevo orden para el año en curso, si ya existe un orden designado, " +
                    "sobreescribirás dicho orden.\n¿Estás seguro de crear un orden nuevo?", "Orden nuevo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    Ordenes ord = new Ordenes();
                    ord.ano = DateTime.Now.Year.ToString();
                    ord.CrearOrden();
                    LoadAnos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOmitir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtAnalista.Text))
                {
                    Ordenes ord = new Ordenes();
                    if (ord.ActualizarSiguiente(Convert.ToInt32(txtID.Text)))
                    {
                        Turnos tur = new Turnos();
                        Analistas ana = new Analistas();
                        tur.analista = ana.getDivisionID(txtAnalista.Text);
                        for(int i = 0; i < dgvOrden.Rows.Count; i++)
                        {
                            if (dgvOrden.Rows[i].Cells[2].Value.ToString().Equals(txtAnalista.Text))
                            {
                                tur.division = ana.getDivisionID(dgvOrden.Rows[i].Cells[3].Value.ToString());
                                break;
                            }
                        }
                        tur.descripcion = false;
                        tur.Insertar();
                    }
                    Limpiar();
                    LoadAnos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnProximo_Click(object sender, EventArgs e)
        {
            try
            {
                Ordenes ord = new Ordenes();
                switch (btnProximo.Text)
                {
                    case "Próximo turno":
                        txtAnalista.Text = ord.enTurno();
                        txtID.Text = ord.id.ToString();
                        break;
                    case "Aceptar":
                        if(cmbEstatus.SelectedIndex == 0)
                        {
                            MessageBox.Show("No puedes inactivar a un analista desde esta ventana.\nPara inactivar a un analista, debes hacerlo desde \"Editar Registro\".", "No puedes inactivar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        ord.id = Convert.ToInt32(txtID.Text);
                        ord.estatus = cmbEstatus.SelectedIndex;
                        ord.ActualizarEstatus();
                        LoadAnos();
                        Limpiar();
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                Notificacion not = new Notificacion();
                not.texto = "¿En dónde desea realizar la asignación?";
                not.confirm = "SIDEC";
                not.cancel = "SANC";
                not.ShowDialog();
                if (not.resultado)
                {
                    Nuevo_Registro sid = new Nuevo_Registro();
                    foreach (DataGridViewRow row in dgvOrden.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(txtID.Text))
                        {
                            sid.division = row.Cells[3].Value.ToString();
                            break;
                        }
                    }
                    sid.analista = txtAnalista.Text;
                    sid.turno = Convert.ToInt32(txtID.Text);
                    sid.ShowDialog();
                    Form1 frm = new Form1();
                    frm.cargarSIDEC();
                }
                else
                {
                    Nuevo_SANC san = new Nuevo_SANC();
                    foreach (DataGridViewRow row in dgvOrden.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(txtID.Text))
                        {
                            san.division = row.Cells[3].Value.ToString();
                            break;
                        }
                    }
                    san.analista = txtAnalista.Text;
                    san.turno = Convert.ToInt32(txtID.Text);
                    san.ShowDialog();
                    Form1 frm = new Form1();
                    frm.cargarSANC();
                }
                LoadAnos();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvOrden_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                if (row >= 0)
                {
                    if (Utilidades.Utilidades.quitarEspeciales(dgvOrden.Rows[row].Cells[4].Value.ToString()).Equals("SI"))
                    {
                        MessageBox.Show("No puedes cambiar el estatus del analista en turno.\nPara cambiar su estatus asiganle un expediente u omite su turno.", "No puedes inactivar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    txtID.Text = dgvOrden.Rows[row].Cells[0].Value.ToString();
                    txtAnalista.Text = dgvOrden.Rows[row].Cells[2].Value.ToString();
                    cmbEstatus.SelectedItem = dgvOrden.Rows[row].Cells[5].Value;
                    if (cmbEstatus.SelectedIndex == 0)
                        cmbEstatus.Enabled = false;
                    else 
                        cmbEstatus.Enabled = true;
                    btnAsignar.Visible = false;
                    btnOmitir.Visible = false;
                    label5.Visible = true;
                    cmbEstatus.Visible = true;
                    btnProximo.Text = "Aceptar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
