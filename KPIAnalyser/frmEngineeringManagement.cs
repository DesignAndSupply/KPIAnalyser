using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Data.SqlClient;

namespace KPIAnalyser
{
    public partial class frmEngineeringManagement : Form
    {
        public frmEngineeringManagement()
        {
            InitializeComponent();
            drawStackedLatenessChartWeekly();
        }

        private void FrmEngineeringManagement_Load(object sender, EventArgs e)
        {

        }


        private void drawStackedLatenessChartMonthly()
        {

            string n1 = "";
            string n2 = "";
            string n3 = "";
            string n4 = "";
            string n5 = "";
            string n6 = "";
            string n7 = "";
            string n8 = "";
            string n9 = "";
            string n10 = "";
            string n11 = "";
            string n12 = "";

            int l1 = 0;
            int l2 = 0;
            int l3 = 0;
            int l4 = 0;
            int l5 = 0;
            int l6 = 0;
            int l7 = 0;
            int l8 = 0;
            int l9 = 0;
            int l10 = 0;
            int l11 = 0;
            int l12 = 0;

            int o1 = 0;
            int o2 = 0;
            int o3 = 0;
            int o4 = 0;
            int o5 = 0;
            int o6 = 0;
            int o7 = 0;
            int o8 = 0;
            int o9 = 0;
            int o10 = 0;
            int o11 = 0;
            int o12 = 0;



            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_engineering_manager", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Monthly";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                n1 = reader[0].ToString();
                n2 = reader[3].ToString();
                n3 = reader[6].ToString();
                n4 = reader[9].ToString();
                n5 = reader[12].ToString();
                n6 = reader[15].ToString();
                n7 = reader[18].ToString();
                n8 = reader[21].ToString();
                n9 = reader[24].ToString();
                n10 = reader[27].ToString();
                n11 = reader[30].ToString();
                n12 = reader[33].ToString();

                l1 = Convert.ToInt32(reader[1]);
                l2 = Convert.ToInt32(reader[4]);
                l3 = Convert.ToInt32(reader[7]);
                l4 = Convert.ToInt32(reader[10]);
                l5 = Convert.ToInt32(reader[13]);
                l6 = Convert.ToInt32(reader[16]);
                l7 = Convert.ToInt32(reader[19]);
                l8 = Convert.ToInt32(reader[22]);
                l9 = Convert.ToInt32(reader[25]);
                l10 = Convert.ToInt32(reader[28]);
                l11 = Convert.ToInt32(reader[31]);
                l12 = Convert.ToInt32(reader[34]);

                o1 = Convert.ToInt32(reader[2]);
                o2 = Convert.ToInt32(reader[5]);
                o3 = Convert.ToInt32(reader[8]);
                o4 = Convert.ToInt32(reader[11]);
                o5 = Convert.ToInt32(reader[14]);
                o6 = Convert.ToInt32(reader[17]);
                o7 = Convert.ToInt32(reader[20]);
                o8 = Convert.ToInt32(reader[23]);
                o9 = Convert.ToInt32(reader[26]);
                o10 = Convert.ToInt32(reader[29]);
                o11 = Convert.ToInt32(reader[32]);
                o12 = Convert.ToInt32(reader[35]);
            }


            conn.Close();



            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            cartesianChart1.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> { o12, o11, o10, o9, o8, o7, o6, o5, o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true
                },
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> { l12, l11, l10, l9, l8, l7, l6, l5, l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                }
            };


            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Date Range",
                Labels = new[] { n12,n11,n10,n9,n8,n7,n6,n5,n4,n3,n2,n1},
                Separator = DefaultAxes.CleanSeparator
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Output",
                LabelFormatter = value => value + " Doors"
            });
        }
        private void drawStackedLatenessChartWeekly()
        {


            DateTime ws1 = DateTime.Today;
            DateTime ws2 = DateTime.Today;
            DateTime ws3 = DateTime.Today;
            DateTime ws4 = DateTime.Today;
            int l1 = 0;
            int l2 = 0;
            int l3 = 0;
            int l4 = 0;
            int o1 =0;
            int o2 = 0;
            int o3 = 0;
            int o4 = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_engineering_manager", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Weekly";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
               ws1 = Convert.ToDateTime(reader[0]);
               ws2 = Convert.ToDateTime(reader[3]);
               ws3 = Convert.ToDateTime(reader[6]);
               ws4 = Convert.ToDateTime(reader[9]);

               l1 = Convert.ToInt32(reader[1]); 
               l2 = Convert.ToInt32(reader[4]);
               l3 = Convert.ToInt32(reader[7]);
               l4 = Convert.ToInt32(reader[10]);

               o1 = Convert.ToInt32(reader[2]);
               o2 = Convert.ToInt32(reader[5]);
               o3 = Convert.ToInt32(reader[8]);
               o4 = Convert.ToInt32(reader[11]);
            }


            conn.Close();



            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            cartesianChart1.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true
                },
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                }
            };


            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Date Range",
                Labels = new[] { "Week Commencing " + ws4.ToShortDateString() , "Week Commencing " + ws3.ToShortDateString(), "Week Commencing " + ws2.ToShortDateString(), "Week Commencing " + ws1.ToShortDateString() },
                Separator = DefaultAxes.CleanSeparator
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Output",
                LabelFormatter = value => value + " Doors"
            });
        }

        private void drawLatenessPieCart()
        {
            
     
        }

        private void RdoWeekly_Click(object sender, EventArgs e)
        {
            drawStackedLatenessChartWeekly();
        }

        private void RdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            drawStackedLatenessChartMonthly();
        }
    }
}
