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
    public partial class Notificacion : Form
    {
        public string titulo { get; set; } = "";
        public string texto { get; set; } = "";
        public string confirm { get; set; } = "";
        public string cancel { get; set; } = "";
        public bool resultado { get; set; }
        public Notificacion()
        {
            InitializeComponent();
        }

        private void Notificacion_Load(object sender, EventArgs e)
        {
            lblTexto.Text = texto;
            btnConfirmar.Text = confirm;
            btnCancel.Text = cancel;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "btnCancel":
                    resultado = false;
                    break;
                case "btnConfirmar":
                    resultado = true;
                    break;
                default:
                    break;
            }
            this.Close();
        }
    }
}
