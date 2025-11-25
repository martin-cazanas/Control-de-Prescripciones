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
    public partial class Editar_SANC : Form
    {
        public DataRow registro { get; set; }
        public Editar_SANC()
        {
            InitializeComponent();
        }
        //Métodos creados
        private void LoadCatalogos()
        {
            Analistas ana = new Analistas();
            Estatus est = new Estatus();
            Origenes ori = new Origenes();
            DataTable catalogo;
            //Limpiado de DropDownList
            cmbMesConclu.Items.Clear();
            cmbAnoConclu.Items.Clear();
            cmbDivision.Items.Clear();
            cmbEstatus.Items.Clear();
            cmbOrigen.Items.Clear();
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
            //Llenado del DropDownList de Analistas
            cmbDivision.Items.Add("--SELECCIONAR");
            catalogo = ana.getDivisiones();
            foreach (DataRow division in catalogo.Rows)
                cmbDivision.Items.Add(division[0].ToString());
            //Llenado del DropDownList de Estatus
            est.tipo = true;
            catalogo = est.getEstatus();
            cmbEstatus.Items.Add("--SELECCIONAR");
            foreach (DataRow estatus in catalogo.Rows)
                cmbEstatus.Items.Add(estatus[1]);
            cmbEstatus.Items.Add("--EDITAR REGISTROS");
            //Llenado del DropDownList de Origenes
            cmbOrigen.Items.Add("--SELECCIONAR");
            catalogo = ori.getOrigenes();
            foreach (DataRow origen in catalogo.Rows)
                cmbOrigen.Items.Add(origen[1]);
            cmbOrigen.Items.Add("--EDITAR REGISTROS");

            cmbMesConclu.SelectedIndex = 0;
            cmbAnoConclu.SelectedIndex = 0;
            cmbDivision.SelectedIndex = 0;
            cmbEstatus.SelectedIndex = 0;
            cmbOrigen.SelectedIndex = 0;
        }

        //Métodos automaticos
        private void Nuevo_Registro_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCatalogos();
                txtPieza.Text = registro[1].ToString();
                dtpRecepcion.Value = Convert.ToDateTime(registro[3]);
                txtPromovente.Text = registro[4].ToString();
                txtDenunciado.Text = registro[5].ToString();
                cmbOrigen.SelectedItem = registro[6];
                txtDepOrg.Text = registro[7].ToString();
                txtExpOrg.Text = registro[8].ToString();
                txtExpediente.Text = registro[9].ToString();
                cmbDivision.SelectedItem = registro[11];
                cmbAnalista.SelectedItem = registro[10];
                cmbEstatus.SelectedItem = registro[12];
                txtNarracion.Text = registro[13].ToString();
                cmbMesConclu.SelectedIndex = string.IsNullOrEmpty(registro[14].ToString()) ? 0 : Convert.ToInt32(registro[14].ToString().Split('/')[0]);
                cmbAnoConclu.SelectedItem = string.IsNullOrEmpty(registro[14].ToString()) ? 0 : Convert.ToInt32(registro[14].ToString().Split('/')[1]);
                txtPA.Text = registro[15].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (string.IsNullOrEmpty(txtPieza.Text.Trim()) || string.IsNullOrEmpty(txtExpediente.Text.Trim()) /*|| string.IsNullOrEmpty(txtExpOrg.Text.Trim())*/ || string.IsNullOrEmpty(txtDepOrg.Text.Trim()) ||
                    cmbDivision.SelectedIndex == 0 || cmbAnalista.SelectedIndex == 0 || string.IsNullOrEmpty(txtPromovente.Text.Trim()) || string.IsNullOrEmpty(txtDenunciado.Text.Trim()) ||
                    string.IsNullOrEmpty(txtNarracion.Text.Trim()) || cmbEstatus.SelectedIndex == 0 || cmbOrigen.SelectedIndex == 0 || 
                    (cmbMesConclu.Enabled && !ckbNoSANC.Checked && (cmbMesConclu.SelectedIndex == 0 || cmbAnoConclu.SelectedIndex == 0)))
                {
                    MessageBox.Show("Por favor llene todos los campos antes de continuar", "Faltan campos por llenar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Analistas ana = new Analistas();
                Estatus est = new Estatus();
                Origenes ori = new Origenes();
                SANC san = new SANC();
                san.id = Convert.ToInt32(registro[0]);
                san.pieza = txtPieza.Text;
                san.expediente = Utilidades.Utilidades.quitarAcentos(txtExpediente.Text);
                san.exp_origen = Utilidades.Utilidades.quitarAcentos(txtExpOrg.Text);
                san.dep_origen = Utilidades.Utilidades.quitarAcentos(txtDepOrg.Text);
                san.analista = ana.getDivisionID(cmbAnalista.Text);
                san.division = ana.getDivisionID(cmbDivision.Text);
                san.denunciante = Utilidades.Utilidades.quitarAcentos(txtPromovente.Text);
                san.denunciado = Utilidades.Utilidades.quitarAcentos(txtDenunciado.Text);
                san.narracion = Utilidades.Utilidades.quitarAcentos(txtNarracion.Text);
                san.pa = Utilidades.Utilidades.quitarAcentos(txtPA.Text);
                est.descripcion = cmbEstatus.Text;
                san.estatus = est.getID();
                ori.descripcion = cmbOrigen.Text;
                san.origen = ori.getID();
                san.conclusion = cmbAnoConclu.Enabled ? ckbNoSANC.Checked ? "NO SANC" : san.conclusion = cmbMesConclu.SelectedIndex + "/" + cmbAnoConclu.Text : "NULL";
                san.recepcion = dtpRecepcion.Value;
                if (san.Editar())
                {
                    MessageBox.Show("Se modificó el registro No. " + registro[0] + " exitosamente", "Registro modificado");
                    this.Close();
                }
                else
                    MessageBox.Show("Ocurrio un error al modificar el registro", "Registro fallido");
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
                cat.tabla = "ESTA";
                cat.ShowDialog();
                LoadCatalogos();
            }
            if (!cmbEstatus.SelectedItem.ToString().Contains("CAPTACION") && !cmbEstatus.SelectedItem.ToString().Contains("INVESTIGACION") && !cmbEstatus.SelectedItem.ToString().Contains("--"))
            {
                cmbAnoConclu.Enabled = true;
                cmbMesConclu.Enabled = true;
                ckbNoSANC.Enabled = true;
            }
            else
            {
                cmbAnoConclu.Enabled = false;
                cmbMesConclu.Enabled = false;
                ckbNoSANC.Enabled = false;
            }
        }

        private void cmbClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedItem.ToString() == "--EDITAR REGISTROS")
            {
                Catalogos cat = new Catalogos();
                cat.tabla = "ORI";
                cat.ShowDialog();
                LoadCatalogos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == MessageBox.Show(string.Format("Esta acción eliminará toda la información del registro: {0} y no podrá recuperarla o acceder nuevamente a ella a menos que la vuelva" +
                    " a registrar\n¿Está seguro de querer eliminar el registro?", registro[0]), "Eliminar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    SANC san = new SANC();
                    san.id = Convert.ToInt32(registro[0]);
                    if (san.Eliminar())
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
