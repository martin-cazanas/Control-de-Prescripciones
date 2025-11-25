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
    public partial class Nuevo_Registro : Form
    {
        public string division { get; set; }
        public string analista { get; set; }
        public int turno { get; set; }
        public Nuevo_Registro()
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
            est.tipo = false;
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

            cmbMesConclu.SelectedIndex = 0;
            cmbAnoConclu.SelectedIndex = 0;
            cmbDivision.SelectedIndex = 0;
            cmbEstatus.SelectedIndex = 0;
            cmbClasificacion.SelectedIndex = 0;
            cmbTipo.SelectedIndex = 0;
        }


        //Métodos automaticos
        private void Nuevo_Registro_Load(object sender, EventArgs e)
        {
            LoadCatalogos();
            if (!string.IsNullOrEmpty(division))
                cmbDivision.SelectedItem = division;
            if (!string.IsNullOrEmpty(analista))
                cmbAnalista.SelectedItem = analista;
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
                if (sid.Insertar())
                {
                    Ordenes ord = new Ordenes();
                    if (ord.ActualizarSiguiente(turno))
                    {
                        Turnos tur = new Turnos();
                        tur.analista = sid.analista;
                        tur.division = sid.division;
                        tur.descripcion = true;
                        if (tur.Insertar())
                        {
                            MessageBox.Show("Se añadió el registro exitosamente", "Registro exitoso");
                            this.Close();
                        }
                    }
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
                cmbEstatus.SelectedIndex = 0;
            }
            if(!cmbEstatus.SelectedItem.ToString().Contains("CAPTACION") && !cmbEstatus.SelectedItem.ToString().Contains("INVESTIGACION") && !cmbEstatus.SelectedItem.ToString().Contains("--"))
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
                cmbTipo.SelectedIndex = 0;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            try
            {
                Analistas ana = new Analistas();
                Notificacion not = new Notificacion();
                Ordenes ord = new Ordenes();
                string actual = ord.enTurno();
                not.texto = "Es turno de " + actual + "\n¿Deseas continuar?";
                not.confirm = "Asignar";
                not.cancel = "Omitir";
                not.ShowDialog();
                if (not.resultado)
                {
                    cmbDivision.SelectedItem = ana.getDivision(actual);
                    cmbAnalista.SelectedItem = actual;
                }
                else
                {
                    ord.ActualizarSiguiente(ord.id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un eror al agregar la información\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
