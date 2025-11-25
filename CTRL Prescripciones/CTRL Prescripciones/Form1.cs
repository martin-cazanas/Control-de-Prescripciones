using CTRL_Prescripciones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTRL_Prescripciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Eventos creados
        public void cargarSIDEC()
        {
            try
            {
                SIDEC sid = new SIDEC();
                dgvSIDEC.DataSource = sid.VistaPrevia();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargarSANC()
        {
            try
            {
                SANC san = new SANC();
                dgvSANC.DataSource = san.VistaPrevia();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProperties()
        {
            dgvSIDEC.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvSIDEC.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSIDEC.Columns[3].Width = 150;
            dgvSIDEC.Columns[4].Width = 150;
            dgvSIDEC.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSIDEC.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvSIDEC.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSIDEC.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSIDEC.Columns[11].Width = 400;
            dgvSIDEC.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvSIDEC.Columns[14].Width = 120;
            dgvSIDEC.Columns[15].Width = 110;

            dgvSANC.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvSANC.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSANC.Columns[4].Width = 150;
            dgvSANC.Columns[5].Width = 150;
            dgvSANC.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSANC.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvSANC.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSANC.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvSANC.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSANC.Columns[13].Width = 400;
            dgvSANC.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvSANC.Columns[15].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        //Eventos del formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cargarSIDEC();
                cargarSANC();
                dgvProperties();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewSIDEC_Click(object sender, EventArgs e)
        {
            try
            {
                Nuevo_Registro nue = new Nuevo_Registro();
                nue.ShowDialog();
                cargarSIDEC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewAnalista_Click(object sender, EventArgs e)
        {
            Nuevo_Analista nue = new Nuevo_Analista();
            nue.ShowDialog();
        }

        private void btnSearchSIDEC_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnSearchSIDEC.Text.Equals("Limpiar"))
                {
                    Busqueda bus = new Busqueda(true);
                    bus.ShowDialog();
                    DataTable busqueda = bus.busqueda;
                    if (busqueda.Rows.Count > 0)
                    {
                        dgvSIDEC.DataSource = busqueda;
                        dgvProperties();
                        btnSearchSIDEC.Text = "Limpiar";
                    }
                }
                else
                {
                    cargarSIDEC();
                    btnSearchSIDEC.Text = "Busqueda rápida";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewSIDEC_Click(object sender, EventArgs e)
        {
            try
            {
                Editar_registro edi = new Editar_registro();
                int row = dgvSIDEC.CurrentCell.RowIndex;
                edi.registro = (dgvSIDEC.Rows[row].DataBoundItem as DataRowView).Row;
                edi.ShowDialog();
                cargarSIDEC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnNewSANC_Click(object sender, EventArgs e)
        {
            Nuevo_SANC san = new Nuevo_SANC();
            san.ShowDialog();
            cargarSANC();
        }
            
        private void btnEditarSANC_Click(object sender, EventArgs e)
        {
            try
            {
                Editar_SANC edi = new Editar_SANC();
                int row = dgvSANC.CurrentCell.RowIndex;
                edi.registro = (dgvSANC.Rows[row].DataBoundItem as DataRowView).Row;
                edi.ShowDialog();
                cargarSANC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchSANC_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnSearchSANC.Text.Equals("Limpiar"))
                {
                    Busqueda bus = new Busqueda(false);
                    bus.ShowDialog();
                    DataTable busqueda = bus.busqueda;
                    if (busqueda.Rows.Count > 0)
                    {
                        dgvSANC.DataSource = busqueda;
                        dgvProperties();
                        btnSearchSANC.Text = "Limpiar";
                    }
                }
                else
                {
                    cargarSANC();
                    btnSearchSANC.Text = "Busqueda rápida";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Divisiones ana = new Divisiones();
            ana.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.I | Keys.Alt))
            {
                Importar imp = new Importar();
                imp.Show();
            }
        }
    }
}
