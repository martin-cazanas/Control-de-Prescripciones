using CTRL_Prescripciones.Modelos;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace CTRL_Prescripciones
{
    public partial class Turno : UserControl
    {
        public Turno()
        {
            InitializeComponent();
        }

        private void LoadCatalogos()
        {
            try
            {
                Turnos tur = new Turnos();
                cmbAnos.Items.AddRange(tur.getAnos().ToArray());
                cmbAnos.SelectedItem = DateTime.Now.Year;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void Turnos_Load(object sender, EventArgs e)
        {
            try 
            {
                LoadCatalogos();
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void cmbAnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Turnos tur = new Turnos();
                List<string> divisiones = tur.getDivisionesXAno();
                cmbBusqueda.Items.Clear();
                cmbBusqueda.Items.Add("TODOS");
                cmbBusqueda.Items.AddRange(divisiones.ToArray());
                cmbBusqueda.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chrTurnos.Series.Clear();
                chrTurnos.AxisY.Clear();
                Turnos tur = new Turnos();
                Analistas ana = new Analistas();
                tur.division = ana.getDivisionID(cmbBusqueda.Text);
                tur.ano = cmbAnos.Text;
                DataTable dt = tur.ConsultarAnalistasTurnos();
                List<string> analistas = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    ana.id = Convert.ToInt32(row[0]);
                    analistas.Add(ana.getNombre());
                }
                chrTurnos.AxisY.Add(new Axis
                {
                    Title = "Analistas",
                    Labels = analistas.ToArray()
                });
                List<int[]> valores = new List<int[]>();
                foreach(string analista in analistas)
                {
                    DataTable turnos = tur.ConsultarTurnos(analista);
                    int conteo = 0, desc = Convert.ToInt32(turnos.Rows[0][4]);
                    for(int i = 0; i < turnos.Rows.Count; i++)
                    {
                        conteo++;
                        if (i != turnos.Rows.Count - 1)
                        {
                            if (desc != Convert.ToInt32(turnos.Rows[i + 1][4]))
                            {
                                valores.Add(new int[] { conteo, desc, Convert.ToInt32(turnos.Rows[i][2]), 0 });
                                desc = Convert.ToInt32(turnos.Rows[i + 1][4]);
                                conteo = 0;
                            }
                        }
                        else
                        {
                            valores.Add(new int[] { conteo, desc, Convert.ToInt32(turnos.Rows[i][2]), 0 });
                        }

                    }
                }
                int series = 0;
                foreach(var val in valores)
                {
                    int temp = valores.Count(v => v[2] == val[2]);
                    if(temp > series)
                        series = temp;
                }
                var anas = valores.Select(v => v[2]).Distinct().ToList();
                for(int i = 0; i < series; i++)
                {
                    ChartValues<int> turnos = new ChartValues<int>();
                    int anterior = 2;
                    foreach(var an in anas)
                    {
                        var item = valores.Where(v => v[2] == an && v[3] == 0).FirstOrDefault();
                        if (item != null && (anterior == 2 || anterior == item[1]))
                        {
                            anterior = item[1];
                            turnos.Add(item[0]);
                            item[3] = 1;
                        }
                        else
                            turnos.Add(0);
                    }
                    chrTurnos.Series.Add(new StackedRowSeries
                    {
                        Values = turnos,
                        Fill = anterior > 0 ? new SolidColorBrush(Color.FromRgb(0,0,255)) : new SolidColorBrush(Color.FromRgb(255,0,0))
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
