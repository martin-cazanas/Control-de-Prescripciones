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
    public partial class Divisiones : Form
    {
        public Divisiones()
        {
            InitializeComponent();
        }

        #region Eventos creados

        private void userControls()
        {
            editar_Analista1.Visible = false;
            turnos1.Visible = false;
            orden1.Visible = false;
        }

        #endregion

        #region Estilo

        private void btn_MouseHover(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.Gray;
                btn.ForeColor = Color.White;
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }
        }

        #endregion

        #region Eventos automaticos

        private void Divisiones_Load(object sender, EventArgs e)
        {
            userControls();
        }

        private void btnEditarRegistros_Click(object sender, EventArgs e)
        {
            userControls();
            editar_Analista1.Visible = true;
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            userControls();
            turnos1.Visible = true;
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            userControls();
            orden1.Visible = true;
        }
    }
}
