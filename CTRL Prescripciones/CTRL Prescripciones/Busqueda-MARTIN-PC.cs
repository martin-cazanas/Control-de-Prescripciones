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
        const int distancia = 70;
        private int ylc = 19;
        private int ylv = 53;
        private int ycc = 18;
        private int ytv = 52;
        private int conteo = 1;
        public Busqueda()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Definición de los controles a agregar
            Label lblCri = new Label();
            Label lblVal = new Label();
            ComboBox cmbCri = new ComboBox();
            TextBox txtVal = new TextBox();

            ylc += distancia;
            ylv += distancia;
            ycc += distancia;
            ytv += distancia;
            //Propiedades de Labels
            lblCri.Height = 20;
            lblCri.Width = 288;
            lblCri.Font = new Font("Microsoft Sans Serif", 10);
            lblCri.Location = new Point(12, ylc);
            lblCri.Name = "lblCri" + conteo;
            lblCri.Text = "Criterio de busqueda #" + (conteo + 1) + ":";

            lblVal.Height = 20;
            lblVal.Width = 288;
            lblVal.Font = new Font("Microsoft Sans Serif", 10);
            lblVal.Location = new Point(122, ylv);
            lblVal.Name = "lblVal" + conteo;
            lblVal.Text = "Valor:";
            //Propiedades de los controles
            cmbCri.Height = 21;
            cmbCri.Width = 288;
            cmbCri.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCri.Location = new Point(171, ycc);
            cmbCri.Name = "cmbCri" + conteo;

            txtVal.Height = 20;
            txtVal.Width = 288;
            txtVal.Location = new Point(171, ytv);
            txtVal.Name = "txtVal" + conteo;
            txtVal.Text = string.Empty;
            conteo++;
            //Añadimos los controles
            pnlBody.Controls.Add(lblCri);
            pnlBody.Controls.Add(lblVal);
            pnlBody.Controls.Add(cmbCri);
            pnlBody.Controls.Add(txtVal);
        }
    }
}
