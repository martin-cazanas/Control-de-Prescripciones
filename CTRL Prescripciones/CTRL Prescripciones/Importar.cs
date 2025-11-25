using ExcelDataReader;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CTRL_Prescripciones.Modelos;
using System.Windows.Forms.DataVisualization.Charting;

namespace CTRL_Prescripciones
{
    public partial class Importar : Form
    {
        public Importar()
        {
            InitializeComponent();
        }

        public void abrirArchivo(string titulo = "", string fileName = "")
        {
            ofdImportar.Title = string.IsNullOrEmpty(titulo) ? "Abrir archivo" : titulo;
            ofdImportar.FileName = string.IsNullOrEmpty(titulo) ? "archivo" : fileName;
            ofdImportar.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            ofdImportar.ShowDialog();
        }

        public string obtenerHoja(string titulo = "", string fileName = "")
        {
            bool continuar;
            string nombre;
            abrirArchivo(titulo, fileName);
            if (ofdImportar.FileName == fileName || ofdImportar.FileName == "archivo")
            {
                MessageBox.Show("Selecciona un archivo antes de cntinuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }
            do
            {
                nombre = Interaction.InputBox("Ingrese el nombre de la hoja de donde desea importar los datos:", "Nombre de hoja");
                if (string.IsNullOrEmpty(nombre))
                {
                    continuar = MessageBox.Show("No ingreso el nombre de ninguna hoja, se tomará por default la primaera hoja del libro\n¿Desea continuar?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel;
                    nombre = "OK";
                }
                else
                    continuar = false;
            } while (continuar);
            return nombre;
        }

        private void btnImpAnalistas_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = string.Empty;
                while (string.IsNullOrEmpty(nombre))
                    nombre = obtenerHoja("Importar Analistas", "analistas");

                using (var stream = File.Open(ofdImportar.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        DataTable dt = nombre.Equals("OK") ? result.Tables[0] : result.Tables[nombre];
                        int col = -1;
                        string columna = Interaction.InputBox("Ingrese el nombre de la columna de los analistas tal cuál está escrito en el libro");
                        if (dt == null)
                            throw new Exception("El nombre de hoja ingresado no se encuentra en el libro cargado.\nAsegurese de ingresar el nombre tal cual está escrito");
                        foreach(DataRow row in dt.Rows)
                        {
                            col = Array.IndexOf(row.ItemArray, columna);
                            if (col > -1)
                                break;
                        }
                        if(col > -1)
                        {
                            pgbProgreso.Maximum = dt.Rows.Count;
                            bool start = false;
                            foreach(DataRow row in dt.Rows)
                            {
                                string analista = Utilidades.Utilidades.quitarAcentos(row[col].ToString());
                                if(!start)
                                    start = analista == columna;
                                if (start && !string.IsNullOrEmpty(analista) && !analista.Equals(columna))
                                {
                                    Analistas ana = new Analistas();
                                    ana.nombre = analista;
                                    ana.jefe = false;
                                    ana.division = 0;
                                    ana.Insertar();
                                    pgbProgreso.Increment(1);
                                }
                            }
                            if (DialogResult.OK == MessageBox.Show("Se completo la importación de los analistas", "Importación finalizada"))
                                pgbProgreso.Value = 0;

                        }
                        else
                            throw new Exception(string.Format("El nombre de la columna \"{0}\" no se encuentró en el libro.\nAsegurese de haberlo escrito correctamente y vuelva a intentarlo", columna));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEstatus_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = string.Empty;
                while (string.IsNullOrEmpty(nombre))
                    nombre = obtenerHoja("Importar Estatus", "estatus");
                using (var stream = File.Open(ofdImportar.FileName, FileMode.Open, FileAccess.Read))
                {
                    using(var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        DataTable dt = nombre.Equals("OK") ? result.Tables[0] : result.Tables[nombre] ??
                            throw new Exception("El nombre de hoja ingresado no se encuentra en el libro cargado.\nAsegurese de ingresar el nombre tal cual está escrito");
                        int col = -1;
                        string columna = Interaction.InputBox("Ingrese el nombre de la columna de los estatus tal cual está escrito en el libro");
                        foreach (DataRow row in dt.Rows)
                        {
                            col = Array.IndexOf(row.ItemArray, columna);
                            if (col > -1)
                                break;
                        }
                        if(col > -1)
                        {
                            pgbProgreso.Maximum = dt.Rows.Count;
                            bool start = false;
                            Notificacion not = new Notificacion();
                            not.texto = "¿A qué sistema desea importar los estatus?";
                            not.confirm = "SANC";
                            not.cancel = "SIDEC";
                            not.ShowDialog();
                            Estatus est = new Estatus();
                            foreach (DataRow row in dt.Rows)
                            {
                                string estatus = Utilidades.Utilidades.quitarAcentos(row[col].ToString());
                                if (!start)
                                    start = estatus == columna;
                                if (start && !estatus.Equals("ESTATUS"))
                                {
                                    est.descripcion = string.IsNullOrEmpty(estatus) ? "(VACIO)" : estatus;
                                    est.tipo = not.resultado;
                                    est.Insertar();
                                }
                                pgbProgreso.Increment(1);
                            }
                            if (DialogResult.OK == MessageBox.Show("Se completo la importación de los estatus", "Importación finalizada"))
                                pgbProgreso.Value = 0;
                        }
                        else
                            throw new Exception(string.Format("El nombre de la columna \"{0}\" no se encuentró en el libro.\nAsegurese de haberlo escrito correctamente y vuelva a intentarlo", columna));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClasificaciones_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = string.Empty;
                while (string.IsNullOrEmpty(nombre))
                    nombre = obtenerHoja("Importar clasificaciones", "clasificaciones");
                using(var stream = File.Open(ofdImportar.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        DataTable dt = nombre.Equals("OK") ? result.Tables[0] : result.Tables[nombre] ??
                            throw new Exception("El nombre de hoja ingresado no se encuentra en el libro cargado.\nAsegurese de ingresar el nombre tal cual está escrito");
                        int col = -1;
                        string columna = Interaction.InputBox("Ingrese el nombre de la columna de las calisificaciones tal cual está escrito en el libro:");
                        foreach (DataRow row in dt.Rows)
                        {
                            col = Array.IndexOf(row.ItemArray, columna);
                            if (col > -1)
                                break;
                        }
                        if (col > -1)
                        {
                            pgbProgreso.Maximum = dt.Rows.Count;
                            Clasificaciones cla = new Clasificaciones();
                            bool start = false;
                            foreach (DataRow row in dt.Rows)
                            {
                                string clasificacion = Utilidades.Utilidades.quitarAcentos(row[col].ToString());
                                if (!start)
                                    start = clasificacion.Equals(columna);
                                if (start && !clasificacion.Equals(columna))
                                {
                                    cla.descripcion = string.IsNullOrEmpty(clasificacion) ? "(VACIO)" : clasificacion;
                                    cla.Insertar();
                                }
                                pgbProgreso.Increment(1);
                            }
                            if (DialogResult.OK == MessageBox.Show("Se completo la importación de las clasificaciones", "Importación finalizada"))
                                pgbProgreso.Value = 0;
                        }
                        else
                            throw new Exception(string.Format("El nombre de la columna \"{0}\" no se encuentró en el libro.\nAsegurese de haberlo escrito correctamente y vuelva a intentarlo", columna));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTipos_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = string.Empty;
                while (string.IsNullOrEmpty(nombre))
                    nombre = obtenerHoja("Importar Tipos", "tipos");
                using (var stream = File.Open(ofdImportar.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        DataTable dt = nombre.Equals("OK") ? result.Tables[0] : result.Tables[nombre] ?? throw new Exception("El nombre de hoja ingresado no se encuentra en el libro cargado.\nAsegurese de ingresar el nombre tal cuál está escrito");
                        int col = -1;
                        string columna = Interaction.InputBox("Ingrese el nombre de la columna de los tipos tal cuál está escrito en el libro");
                        foreach(DataRow row in dt.Rows)
                        {
                            col = Array.IndexOf(row.ItemArray, columna);
                            if (col > -1)
                                break;
                        }
                        if(col > -1)
                        {
                            pgbProgreso.Maximum = dt.Rows.Count;
                            Tipos tip = new Tipos();
                            bool start = false;
                            foreach(DataRow row in dt.Rows)
                            {
                                string tipo = Utilidades.Utilidades.quitarAcentos(row[col].ToString());
                                if (!start)
                                    start = tipo.Equals(columna);
                                if(start && !tipo.Equals(columna))
                                {
                                    tip.descripcion = string.IsNullOrEmpty(tipo) ? "(VACIO)" : tipo;
                                    tip.Insertar();
                                }
                                pgbProgreso.Increment(1);
                            }
                            if (DialogResult.OK == MessageBox.Show("Se completo la importación de los analistas", "Importación finalizada"))
                                pgbProgreso.Value = 0;
                        }
                        else
                            throw new Exception(string.Format("El nombre de la columna \"{0}\" no se encuentró en el libro.\nAsegurese de haberlo escrito correctamente y vuelva a intentarlo", columna));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrigenes_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = string.Empty;
                while (string.IsNullOrEmpty(nombre))
                    nombre = obtenerHoja("Importar Origenes", "origenes");
                using (var stream = File.Open(ofdImportar.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        DataTable dt = nombre.Equals("OK") ? result.Tables[0] : result.Tables[nombre] ?? throw new Exception("El nombre de hoja ingresado no se encuentra en el libro cargado.\nAsegurese de ingresar el nombre tal cuál está escrito");
                        int col = -1;
                        string columna = Interaction.InputBox("Ingrese el nombre de la colllumna de los origenes tal ciál está escrito en el libro");
                        foreach(DataRow row in dt.Rows)
                        {
                            col = Array.IndexOf(row.ItemArray, columna);
                            if (col > -1)
                                break;
                        }
                        if(col > -1)
                        {
                            pgbProgreso.Maximum = dt.Rows.Count;
                            Origenes ori = new Origenes();
                            bool start = false;
                            foreach(DataRow row in dt.Rows)
                            {
                                string origen = Utilidades.Utilidades.quitarAcentos(row[col].ToString());
                                if (!start)
                                    start = origen.Equals(columna);
                                if(start && !origen.Equals(columna))
                                {
                                    ori.descripcion = string.IsNullOrEmpty(origen) ? "(VACIO)" : origen;
                                    ori.Insertar();
                                }
                                pgbProgreso.Increment(1);
                            }
                            MessageBox.Show("Se completo la importación de los analistas", "Importación finalizada");
                            pgbProgreso.Value = 0;
                        }
                        else
                            throw new Exception(string.Format("El nombre de la columna \"{0}\" no se encuentró en el libro.\nAsegurese de haberlo escrito correctamente y vuelva a intentarlo", columna));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSIDEC_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = string.Empty;
                while (string.IsNullOrEmpty(nombre))
                    nombre = obtenerHoja("Importar Registros SIDEC");
                using (var stream = File.Open(ofdImportar.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        DataTable dt = string.IsNullOrEmpty(nombre) ? result.Tables[0] : result.Tables[nombre] ?? throw new Exception("El nombre de hoja ingresado no se encuentra en el libro cargado.\nAsegurese de ingresar el nombre tal cuál está escrito");
                        SIDEC sid = new SIDEC();
                        pgbProgreso.Maximum = dt.Rows.Count;
                        foreach(DataRow row in dt.Rows)
                        {
                            if (row.ItemArray.Where(c => c.ToString().Length > 50).Count() > 0)
                            {
                                sid.pieza = row[1].ToString();
                                sid.recepcion = Convert.ToDateTime(row[2]);
                                sid.promovente = row[3].ToString();
                                sid.denunciado = row[4].ToString();
                                sid.expediente = row[5].ToString();
                                sid.folio = row[6].ToString();
                                sid.clave = row[7].ToString();
                                sid.analista = new Analistas().getDivisionID(Utilidades.Utilidades.quitarAcentos(row[8].ToString()));
                                sid.division = new Analistas().getDivisionID(Utilidades.Utilidades.quitarAcentos(row[9].ToString()));
                                sid.estatus = new Estatus().getID(row[10].ToString());
                                sid.narrativa = row[11].ToString();
                                sid.clasificacion = new Clasificaciones().getID(row[14].ToString());
                                sid.tipo = new Tipos().getID(row[15].ToString());
                                sid.concluido = !string.IsNullOrEmpty(row[16].ToString());
                                sid.conclusion = sid.concluido ?
                                    row[16].ToString().Length == 10/*< 5 /*? new DateTime(Convert.ToInt32(row[16]), 1, 1).ToShortDateString().Substring(3)
                                        :  && row[16].ToString().Length < 11 */? row[16].ToString().Substring(3) : Convert.ToDateTime(row[17]).ToShortDateString().Substring(3)
                                    : "NULL";
                                sid.ultimo = string.IsNullOrEmpty(row[17].ToString()) || row[17] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row[17]);
                                sid.registro = string.IsNullOrEmpty(row[18].ToString()) || row[18] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row[18]);
                                if (!sid.Insertar())
                                    MessageBox.Show(sid.expediente);
                            }
                            pgbProgreso.Increment(1);
                        }
                        MessageBox.Show("Se completo la importación de los analistas", "Importación finalizada");
                        pgbProgreso.Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
