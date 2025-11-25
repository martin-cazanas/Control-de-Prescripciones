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
    public partial class Busqueda : Form
    {
        public bool procedencia { get; set; }
        public DataTable busqueda { get; set; }
        private List<string> criterios = new List<string>();
        private List<string> valores = new List<string>();
        const int distancia = 65;
        private int yc = 19;
        private int yv = 46;
        private int conteo = 1;
        string[] catalogo;
        public Busqueda(bool proc)
        {
            InitializeComponent();
            busqueda = new DataTable();
            procedencia = proc;
            if (procedencia)
                catalogo = new string[] { "--Seleccionar", "Pieza", "Ciudadano", "Denunciado", "Expediente", "Folio ciudadano", "Analista", "Narrativa" };
            else
                catalogo = new string[] { "--Seleccionar", "Pieza", "Denunciante", "Denunciado", "Expediente", "Expediente de origen", "Analista", "Narracion", "Procedimiento administrativo" };
        }

        private void Busqueda_Load(object sender, EventArgs e)
        {
            cmbCri0.Items.AddRange(catalogo);
            cmbCri0.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Definición de los controles a agregar
            Label lblCri = new Label();
            Label lblVal = new Label();
            ComboBox cmbCri = new ComboBox();
            TextBox txtVal = new TextBox();

            yc += distancia;
            yv += distancia;

            //Propiedades de Labels
            lblCri.Height = 17;
            lblCri.Width = 164;
            lblCri.Font = new Font("Microsoft Sans Serif", 10);
            lblCri.Location = new Point(11, yc);
            lblCri.Name = "lblCri" + conteo;
            lblCri.Text = "Criterio de busqueda #" + (conteo + 1) + ":";

            lblVal.Height = 17;
            lblVal.Width = 45;
            lblVal.Font = new Font("Microsoft Sans Serif", 10);
            lblVal.Location = new Point(130, yv);
            lblVal.Name = "lblVal" + conteo;
            lblVal.Text = "Valor:";
            //Propiedades de los controles
            cmbCri.Height = 20;
            cmbCri.Width = 275;
            cmbCri.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCri.Location = new Point(181, yc);
            cmbCri.Name = "cmbCri" + conteo;

            txtVal.Height = 20;
            txtVal.Width = 275;
            txtVal.Location = new Point(181, yv);
            txtVal.Name = "txtVal" + conteo;
            txtVal.Text = string.Empty;
            //Llenamos los DropDownList
            cmbCri.Items.AddRange(catalogo);
            cmbCri.SelectedIndex = 0;

            conteo++;
            //Añadimos los controles
            pnlBody.Controls.Add(lblCri);
            pnlBody.Controls.Add(lblVal);
            pnlBody.Controls.Add(cmbCri);
            pnlBody.Controls.Add(txtVal);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                criterios.Clear();
                valores.Clear();
                foreach(Control control in pnlBody.Controls)
                {
                    string tipo = control.GetType().ToString();
                    if (!tipo.Contains("Label"))
                    {
                        if (tipo.Contains("ComboBox"))
                        {
                            if (control.Text.Equals("--Seleccionar"))
                            {
                                MessageBox.Show("Por favor llene todos los campos antes de continuar", "Criterio invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                                criterios.Add(Utilidades.Utilidades.quitarAcentos(control.Text));
                        }
                        else if (tipo.Contains("TextBox"))
                        {
                            if (string.IsNullOrEmpty(control.Text))
                            {
                                MessageBox.Show("Por favor llene todos los campos antes de continuar", "Valor faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                                valores.Add(Utilidades.Utilidades.quitarAcentos(control.Text));
                        }
                    }
                }
                if (procedencia)
                {
                    SIDEC sid = new SIDEC();
                    busqueda = sid.Buscar(criterios, valores);
                    this.Close();
                }
                else
                {
                    SANC san = new SANC();
                    busqueda = san.Buscar(criterios, valores);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
