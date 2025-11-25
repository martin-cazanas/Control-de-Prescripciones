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
    public partial class Nuevo_Analista : Form
    {
        public Nuevo_Analista()
        {
            InitializeComponent();
        }

        private void Nuevo_Analista_Load(object sender, EventArgs e)
        {
            Analistas ana = new Analistas();
            DataTable divisiones = ana.getDivisiones();
            cmbDivision.Items.Add("--Seleccionar");
            if(divisiones.Rows.Count > 0)
            {
                foreach(DataRow division in divisiones.Rows)
                {
                    cmbDivision.Items.Add(division[0].ToString());
                }
            }
            cmbDivision.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) || !(cmbDivision.SelectedIndex != 0 || ckbBoss.Checked))
                    MessageBox.Show("Por favor llene todos los campos requeridos antes de continuar", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    Analistas ana = new Analistas();
                    ana.nombre = txtName.Text.ToUpper();
                    ana.usuario = txtUser.Text;
                    ana.jefe = ckbBoss.Checked;
                    ana.division = ana.getDivisionID(cmbDivision.Text);
                    if (ana.Insertar())
                        MessageBox.Show("Se agregó al analista exitosamente", "Analista añadido");
                    else
                        MessageBox.Show("Ocurrió un error al añadir al analista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckbBoss_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbBoss.Checked)
            {
                cmbDivision.SelectedIndex = 0;
                cmbDivision.Enabled = false;
            }
            else
                cmbDivision.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
