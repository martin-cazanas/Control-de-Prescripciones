using CTRL_Prescripciones.Modelos;
using CTRL_Prescripciones.Utilidades;
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
    public partial class Editar_registro : Form
    {
        public DataRow registro { get; set; }
        public Editar_registro()
        {
            InitializeComponent();
        }
        //Métodos creados
        private void LoadCatalogos()
        {
            Analistas ana = new Analistas();
            Clasificaciones cla = new Clasificaciones();
            Estatus est = new Estatus();
            Tipos tip = new Tipos();
            DataTable catalogo;
            //Limpiado de DropDownList
            cmbMesConclu.Items.Clear();
            cmbAnoConclu.Items.Clear();
            cmbDivision.Items.Clear();
            cmbEstatus.Items.Clear();
            cmbClasificacion.Items.Clear();
            cmbTipo.Items.Clear();
            //LLenado del DropDownList de fecha de conclusión
            cmbMesConclu.Items.Add("--SELECCIONAR");
            cmbMesConclu.Items.Add("ENERO");
            cmbMesConclu.Items.Add("FEBRERO");
            cmbMesConclu.Items.Add("MARZO");
            cmbMesConclu.Items.Add("ABRIL");
            cmbMesConclu.Items.Add("MAYO");
            cmbMesConclu.Items.Add("JUNIO");
            cmbMesConclu.Items.Add("JULIO");
            cmbMesConclu.Items.Add("AGOSTO");
            cmbMesConclu.Items.Add("SEPTIEMBRE");
            cmbMesConclu.Items.Add("OCTUBRE");
            cmbMesConclu.Items.Add("NOVIEMBRE");
            cmbMesConclu.Items.Add("DICIEMBRE");
            cmbAnoConclu.Items.Add("--SELECCIONAR");
            for (int i = 2010/*DateTime.Today.Year - 10*/; i <= DateTime.Today.Year; i++)
                cmbAnoConclu.Items.Add(i);
            //Llenado del DropDownList de Divisiones
            cmbDivision.Items.Add("--SELECCIONAR");
            catalogo = ana.getDivisiones();
            foreach (DataRow division in catalogo.Rows)
                cmbDivision.Items.Add(division[0].ToString());
            //Llenado del DropDownList de Estatus
            catalogo = est.getEstatus();
            cmbEstatus.Items.Add("--SELECCIONAR");
            foreach (DataRow estatus in catalogo.Rows)
                cmbEstatus.Items.Add(estatus[1]);
            cmbEstatus.Items.Add("--EDITAR REGISTROS");
            //Llenado del DropDownList de Clasificaciones
            cmbClasificacion.Items.Add("--SELECCIONAR");
            catalogo = cla.getClasificaciones();
            foreach (DataRow clasificacion in catalogo.Rows)
                cmbClasificacion.Items.Add(clasificacion[1]);
            cmbClasificacion.Items.Add("--EDITAR REGISTROS");
            //Llenado del DropDownList de Tipos
            cmbTipo.Items.Add("--SELECCIONAR");
            catalogo = tip.getTipos();
            foreach (DataRow tipo in catalogo.Rows)
                cmbTipo.Items.Add(tipo[1]);
            cmbTipo.Items.Add("--EDITAR REGISTROS");
        }

        private void CargarCatalogos()
        {
            cmbDivision.SelectedItem = registro[9].ToString();
            cmbAnalista.SelectedItem = registro[8].ToString();
            cmbEstatus.SelectedItem = registro[10].ToString();
            cmbClasificacion.SelectedItem = registro[12].ToString();
            cmbTipo.SelectedItem = registro[13].ToString();
            cmbMesConclu.SelectedIndex = string.IsNullOrEmpty(registro[14].ToString()) ? 0 : Convert.ToInt32(registro[14].ToString().Split('/')[0]);
            cmbAnoConclu.SelectedItem = string.IsNullOrEmpty(registro[14].ToString()) ? 0 : Convert.ToInt32(registro[14].ToString().Split('/')[1]);
            if (!cmbEstatus.SelectedItem.ToString().Contains("CAPTACION") && !cmbEstatus.SelectedItem.ToString().Contains("INVESTIGACION") && !cmbEstatus.SelectedItem.ToString().Contains("--"))
            {
                cmbAnoConclu.Enabled = true;
                cmbMesConclu.Enabled = true;
            }
            else
            {
                cmbAnoConclu.Enabled = false;
                cmbMesConclu.Enabled = false;
            }
        }

        //Métodos automaticos
        private void Nuevo_Registro_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCatalogos();
                txtPieza.Text = registro[1].ToString();
                txtExpediente.Text = registro[5].ToString();
                txtFolio.Text = registro[6].ToString();
                txtClave.Text = registro[7].ToString();
                dtpRecepcion.Value = Convert.ToDateTime(registro[2]);
                txtPromovente.Text = registro[3].ToString();
                txtDenunciado.Text = registro[4].ToString();
                txtNarracion.Text = registro[11].ToString();
                dtpUltimo.Value = Convert.ToDateTime(registro[15]);
                CargarCatalogos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPieza.Text.Trim()) || string.IsNullOrEmpty(txtExpediente.Text.Trim()) || string.IsNullOrEmpty(txtFolio.Text.Trim()) || string.IsNullOrEmpty(txtClave.Text.Trim()) ||
                    cmbDivision.SelectedIndex == 0 || cmbAnalista.SelectedIndex == 0 || string.IsNullOrEmpty(txtPromovente.Text.Trim()) || string.IsNullOrEmpty(txtDenunciado.Text.Trim()) ||
                    string.IsNullOrEmpty(txtNarracion.Text.Trim()) || cmbEstatus.SelectedIndex == 0 || cmbClasificacion.SelectedIndex == 0 || cmbTipo.SelectedIndex == 0 ||
                    (cmbMesConclu.Enabled && (cmbMesConclu.SelectedIndex == 0 || cmbAnoConclu.SelectedIndex == 0)))
                {
                    MessageBox.Show("Por favor llene todos los campos antes de continuar", "Faltan campos por llenar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Analistas ana = new Analistas();
                Clasificaciones cla = new Clasificaciones();
                Estatus est = new Estatus();
                Tipos tip = new Tipos();
                SIDEC sid = new SIDEC();
                sid.id = Convert.ToInt32(registro[0]);
                sid.pieza = txtPieza.Text.Trim();
                sid.expediente = txtExpediente.Text.Trim();
                sid.folio = txtFolio.Text.Trim();
                sid.clave = txtClave.Text.Trim();
                sid.analista = ana.getDivisionID(cmbAnalista.Text);
                sid.division = ana.getDivisionID(cmbDivision.Text);
                sid.recepcion = dtpRecepcion.Value;
                sid.promovente = Utilidades.Utilidades.quitarAcentos(txtPromovente.Text);
                sid.denunciado = Utilidades.Utilidades.quitarAcentos(txtDenunciado.Text);
                sid.narrativa = Utilidades.Utilidades.quitarAcentos(txtNarracion.Text);
                est.descripcion = Utilidades.Utilidades.quitarAcentos(cmbEstatus.Text);
                sid.estatus = est.getID();
                sid.concluido = (est.descripcion.Contains("CAPTACION") || est.descripcion.Contains("INVESTIGACION")) ? false : true;
                cla.descripcion = Utilidades.Utilidades.quitarAcentos(cmbClasificacion.Text);
                sid.clasificacion = cla.getID();
                tip.descripcion = Utilidades.Utilidades.quitarAcentos(cmbTipo.Text);
                sid.tipo = tip.getID();
                sid.conclusion = cmbMesConclu.SelectedIndex.ToString() + "/" + cmbAnoConclu.Text;
                if (!sid.concluido)
                    sid.conclusion = "NULL";
                sid.ultimo = dtpUltimo.Value;
                if (sid.Editar())
                {
                    MessageBox.Show("Se edito el registro NO. " + sid.id + " exitosamente", "Registro exitoso");
                    this.Close();
                }
                else
                    MessageBox.Show("Ocurrio un error al añadir el registro", "Registro fallido");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un eror al agregar la información\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbAnalista.Items.Clear();
            cmbAnalista.Items.Add("--SELECCIONAR"); 
            if (cmbDivision.SelectedIndex != 0)
            {
                Analistas ana = new Analistas();
                ana.division = ana.getDivisionID(cmbDivision.Text);
                DataTable analistas = ana.getAnalistas();
                if (analistas.Rows.Count > 0)
                {
                    foreach (DataRow analista in analistas.Rows)
                    {
                        cmbAnalista.Items.Add(analista[1]);
                    }
                    cmbAnalista.SelectedIndex = 0;
                    cmbAnalista.Enabled = true;
                }
            }
            else
            {
                cmbAnalista.SelectedIndex = 0;
                cmbAnalista.Enabled = false;
            }
        }

        private void txtPieza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Este campo sólo acepta números", "Cáracter invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbEstatus.SelectedItem.ToString() == "--EDITAR REGISTROS")
            {
                Catalogos cat = new Catalogos();
                cat.tabla = "ESTI";
                cat.ShowDialog();
                LoadCatalogos();
                CargarCatalogos();
                cmbEstatus.SelectedIndex = 0;
            }
            if (!cmbEstatus.SelectedItem.ToString().Contains("CAPTACION") && !cmbEstatus.SelectedItem.ToString().Contains("INVESTIGACION") && !cmbEstatus.SelectedItem.ToString().Contains("--"))
            {
                cmbAnoConclu.Enabled = true;
                cmbMesConclu.Enabled = true;
            }
            else
            {
                cmbAnoConclu.Enabled = false;
                cmbMesConclu.Enabled = false;
            }
        }

        private void cmbClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClasificacion.SelectedItem.ToString() == "--EDITAR REGISTROS")
            {
                Catalogos cat = new Catalogos();
                cat.tabla = "CLA";
                cat.ShowDialog();
                LoadCatalogos();
                CargarCatalogos();
                cmbClasificacion.SelectedIndex = 0;
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem.ToString() == "--EDITAR REGISTROS")
            {
                Catalogos cat = new Catalogos();
                cat.tabla = "TIP";
                cat.ShowDialog();
                LoadCatalogos();
                CargarCatalogos();
                cmbTipo.SelectedIndex = 0;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == MessageBox.Show(string.Format("Esta acción eliminará toda la información del registro: {0} y no podrá recuperarla o acceder nuevamente a ella a menos que la vuelva" +
                    " a registrar\n¿Está seguro de querer eliminar el registro?", registro[0]), "Eliminar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    SIDEC sid = new SIDEC();
                    sid.id = Convert.ToInt32(registro[0]);
                    if (sid.Eliminar())
                    {
                        MessageBox.Show(string.Format("Se elimino el registro {0} exitosamente", registro[0]), "Registro eliminado", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                        MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
