using CTRL_Prescripciones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTRL_Prescripciones
{
    public partial class Catalogos : Form
    {
        public string tabla { get; set; }
        public string nextID { get; set; }
        public Catalogos()
        {
            InitializeComponent();
        }

        private void Catalogos_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDGV();
                txtID.Text = nextID;
                dgvRegistros.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvRegistros.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Regresar")
                this.Close();
            else
                Limpiar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnAdd.Text == "Agregar")
            {
                switch (tabla)
                {
                    case "TIP":
                        Tipos tip = new Tipos();
                        tip.descripcion = Utilidades.Utilidades.quitarAcentos(txtDescripcion.Text);
                        tip.Insertar();
                        break;
                    case "ESTI":
                        Estatus esti = new Estatus();
                        esti.descripcion = Utilidades.Utilidades.quitarAcentos(txtDescripcion.Text);
                        esti.tipo = false;
                        esti.Insertar();
                        break;
                    case "ESTA":
                        Estatus esta = new Estatus();
                        esta.descripcion = Utilidades.Utilidades.quitarAcentos(txtDescripcion.Text);
                        esta.tipo = true;
                        esta.Insertar();
                        break;
                    case "CLA":
                        Clasificaciones cla = new Clasificaciones();
                        cla.descripcion = Utilidades.Utilidades.quitarAcentos(txtDescripcion.Text);
                        cla.Insertar();
                        break;
                    case "ORI":
                        Origenes ori = new Origenes();
                        ori.descripcion = Utilidades.Utilidades.quitarAcentos(txtDescripcion.Text);
                        ori.Insertar();
                        break;
                    default:
                        break;
                }
            }
            else if(btnAdd.Text == "Modificar")
            {
                switch (tabla)
                {
                    case "TIP":
                        Tipos tip = new Tipos();
                        tip.id = Convert.ToInt32(txtID.Text);
                        tip.descripcion = Utilidades.Utilidades.quitarAcentos(txtDescripcion.Text);
                        tip.Actualizar();
                        break;
                    case "ESTI":
                        Estatus esti = new Estatus();
                        esti.id = Convert.ToInt32(txtID.Text);
                        esti.descripcion = Utilidades.Utilidades.quitarAcentos(txtDescripcion.Text);
                        esti.tipo = false;
                        esti.Actualizar();
                        break;
                    case "ESTA":
                        Estatus esta = new Estatus();
                        esta.id = Convert.ToInt32(txtID.Text);
                        esta.descripcion = Utilidades.Utilidades.quitarAcentos(txtDescripcion.Text);
                        esta.tipo = true;
                        esta.Actualizar();
                        break;
                    case "CLA":
                        Clasificaciones cla = new Clasificaciones();
                        cla.id = Convert.ToInt32(txtID.Text);
                        cla.descripcion = Utilidades.Utilidades.quitarAcentos(txtDescripcion.Text);
                        cla.Actualizar();
                        break;
                    case "ORI":
                        Origenes ori = new Origenes();
                        ori.id = Convert.ToInt32(txtID.Text);
                        ori.descripcion = Utilidades.Utilidades.quitarAcentos(txtDescripcion.Text);
                        ori.Actualizar();
                        break;
                    default:
                        break;
                }
            }
            LoadDGV();
            Limpiar();
        }

        private void LoadDGV()
        {
            try
            {
                //dgvRegistros.Rows.Clear();
                DataTable registros = new DataTable();
                switch (tabla)
                {
                    case "TIP":
                        Tipos tip = new Tipos();
                        registros = tip.getTipos();
                        label1.Text = "Agregar tipo";
                        break;
                    case "ESTI":
                        Estatus esti = new Estatus();
                        esti.tipo = false;
                        registros = esti.getEstatus();
                        label1.Text = "Agregar estatus";
                        break;
                    case "ESTA":
                        Estatus esta = new Estatus();
                        esta.tipo = true;
                        registros = esta.getEstatus();
                        label1.Text = "Agregar estatus";
                        break;
                    case "CLA":
                        Clasificaciones clas = new Clasificaciones();
                        registros = clas.getClasificaciones();
                        label1.Text = "Agregar clasificación";
                        break;
                    case "ORI":
                        Origenes ori = new Origenes();
                        registros = ori.getOrigenes();
                        label1.Text = "Agregar origen";
                        break;
                    default:
                        break;
                }
                dgvRegistros.DataSource = registros;
                dgvRegistros.Sort(dgvRegistros.Columns["ID"], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            button1.Text = "Regresar";
            btnAdd.Text = "Agregar";
            txtDescripcion.Text = string.Empty;
            txtID.Text = nextID;
        }

        private void dgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != 0)
            {
                DataGridViewRow row = dgvRegistros.Rows[e.RowIndex];
                btnAdd.Text = "Modificar";
                button1.Text = "Cancelar";
                txtDescripcion.Text = row.Cells[e.ColumnIndex].Value.ToString();
                txtID.Text = row.Cells[0].Value.ToString();
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
