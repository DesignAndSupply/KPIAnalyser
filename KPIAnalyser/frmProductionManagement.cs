using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LiveCharts;
using LiveCharts.Wpf;
using System.Drawing.Printing;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace KPIAnalyser
{
    public partial class frmProductionManagement : Form
    {
        List<string> tempData = new List<string>();
        public string customerAccRef { get; set; }
        public frmProductionManagement()
        {
            InitializeComponent();
            customerAccRef = "";

            //fill the combobox of customers
            string sql = "SELECT [NAME] FROM dbo.[sales_ledger] ";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbCustomer.Items.Add(reader["NAME"].ToString());
                    }
                    conn.Close();
                }
            }

        }

        private void rdoWeekly_Click(object sender, EventArgs e)
        {
            tempData.Clear();
            if (1 == 1)
            {
                DateTime ws1 = DateTime.Today;
                DateTime ws2 = DateTime.Today;
                DateTime ws3 = DateTime.Today;
                DateTime ws4 = DateTime.Today;
                int l1 = 0;
                int l2 = 0;
                int l3 = 0;
                int l4 = 0;
                int o1 = 0;
                int o2 = 0;
                int o3 = 0;
                int o4 = 0;
                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;
                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;



                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_manager", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Weekly";
                cmd.Parameters.Add("@customerAccRef", SqlDbType.NVarChar).Value = customerAccRef;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ws1 = Convert.ToDateTime(reader[0]);
                    ws2 = Convert.ToDateTime(reader[3]);
                    ws3 = Convert.ToDateTime(reader[6]);
                    ws4 = Convert.ToDateTime(reader[9]);

                    tempData.Add(reader[0].ToString());
                    tempData.Add(reader[3].ToString());
                    tempData.Add(reader[6].ToString());
                    tempData.Add(reader[9].ToString());
                    tempData.Reverse();

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

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);

                cartesianChart1.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "On Time",
                    Values = new ChartValues<double> {o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true
                },
                new StackedColumnSeries
                {
                    Title = "Late",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },

                new LineSeries
                {
                    Title = "Trend",
                    Values = new ChartValues<double> { p4, p3, p2, p1 },
                    ScalesYAt = 1
                },
            };


                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { "Week Commencing " + ws4.ToShortDateString(), "Week Commencing " + ws3.ToShortDateString(), "Week Commencing " + ws2.ToShortDateString(), "Week Commencing " + ws1.ToShortDateString() },
                    Separator = DefaultAxes.CleanSeparator
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });



                cartesianChart1.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100


                });
            }
            if (1 == 1)
            {
                DateTime ws1 = DateTime.Today;
                DateTime ws2 = DateTime.Today;
                DateTime ws3 = DateTime.Today;
                DateTime ws4 = DateTime.Today;
                int l1 = 0;
                int l2 = 0;
                int l3 = 0;
                int l4 = 0;
                int o1 = 0;
                int o2 = 0;
                int o3 = 0;
                int o4 = 0;
                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;
                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;



                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_absenteeism", conn);
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

                    //o1 = Convert.ToInt32(reader[2]);
                    //o2 = Convert.ToInt32(reader[5]);
                    //o3 = Convert.ToInt32(reader[8]);
                    //o4 = Convert.ToInt32(reader[11]);
                }


                conn.Close();



                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();

                p1 = l1;//Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = l2;// Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = l3;// Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = l4;// Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);

                cartesianChart2.Series = new SeriesCollection
            {
                //new StackedColumnSeries
                //{
                //    Title = "On Time",
                //    Values = new ChartValues<double> {o4, o3, o2, o1},
                //    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                //    DataLabels = true
                //},
                new StackedColumnSeries
                {
                    Title = "Absent",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },

                //new LineSeries
                //{
                //    Title = "Trend",
                //    Values = new ChartValues<double> { p4, p3, p2, p1 },
                //    ScalesYAt = 1
                //},
            };


                cartesianChart2.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { "Week Commencing " + ws4.ToShortDateString(), "Week Commencing " + ws3.ToShortDateString(), "Week Commencing " + ws2.ToShortDateString(), "Week Commencing " + ws1.ToShortDateString() },
                    Separator = DefaultAxes.CleanSeparator
                });

                cartesianChart2.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });



                //cartesianChart2.AxisY.Add(new Axis
                //{
                //    Foreground = System.Windows.Media.Brushes.Orange,
                //    Title = "Trend %",
                //    Position = AxisPosition.RightTop,
                //    LabelFormatter = value => value + " % Late",
                //    MinValue = 0,
                //    MaxValue = 100


                //});
            }
            if (1 == 1) //repaints
            {

                DateTime ws1 = DateTime.Today;
                DateTime ws2 = DateTime.Today;
                DateTime ws3 = DateTime.Today;
                DateTime ws4 = DateTime.Today;
                int l1 = 0;
                int l2 = 0;
                int l3 = 0;
                int l4 = 0;
                int o1 = 0;
                int o2 = 0;
                int o3 = 0;
                int o4 = 0;
                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;
                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;



                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("[usp_kpi_production_manager_repaints]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Weekly";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ws1 = Convert.ToDateTime(reader[0]);
                    ws2 = Convert.ToDateTime(reader[3]);
                    ws3 = Convert.ToDateTime(reader[6]);
                    ws4 = Convert.ToDateTime(reader[9]);

                    tempData.Add(reader[0].ToString());
                    tempData.Add(reader[3].ToString());
                    tempData.Add(reader[6].ToString());
                    tempData.Add(reader[9].ToString());
                    tempData.Reverse();

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



                cartesianChart3.Series.Clear();
                cartesianChart3.AxisX.Clear();
                cartesianChart3.AxisY.Clear();

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);

                cartesianChart3.Series = new SeriesCollection
            {

                new LineSeries
                {
                    Title = "Late",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    DataLabels = true
                },
            };

                cartesianChart3.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { "Week Commencing " + ws4.ToShortDateString(), "Week Commencing " + ws3.ToShortDateString(), "Week Commencing " + ws2.ToShortDateString(), "Week Commencing " + ws1.ToShortDateString() },
                    Separator = DefaultAxes.CleanSeparator
                });

                cartesianChart3.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });



                cartesianChart3.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100

                });
            }
            fillPaintingGrid();
        }

        private void rdoMonthly_Click(object sender, EventArgs e)
        {
            tempData.Clear();
            if (1 == 1)
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



                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;
                int r5 = 0;
                int r6 = 0;
                int r7 = 0;
                int r8 = 0;
                int r9 = 0;
                int r10 = 0;
                int r11 = 0;
                int r12 = 0;


                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;
                double p5 = 0f;
                double p6 = 0f;
                double p7 = 0f;
                double p8 = 0f;
                double p9 = 0f;
                double p10 = 0f;
                double p11 = 0f;
                double p12 = 0f;




                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_manager", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Monthly";
                cmd.Parameters.Add("@customerAccRef", SqlDbType.NVarChar).Value = customerAccRef;

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

                    tempData.Add(reader[0].ToString());
                    tempData.Add(reader[3].ToString());
                    tempData.Add(reader[6].ToString());
                    tempData.Add(reader[9].ToString());
                    tempData.Add(reader[12].ToString());
                    tempData.Add(reader[15].ToString());
                    tempData.Add(reader[18].ToString());
                    tempData.Add(reader[21].ToString());
                    tempData.Add(reader[24].ToString());
                    tempData.Add(reader[27].ToString());
                    tempData.Add(reader[30].ToString());
                    tempData.Add(reader[33].ToString());
                    tempData.Reverse();

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



                    //r1 = Convert.ToInt32(reader[36]);
                    //r2 = Convert.ToInt32(reader[37]);
                    //r3 = Convert.ToInt32(reader[38]);
                    //r4 = Convert.ToInt32(reader[39]);
                    //r5 = Convert.ToInt32(reader[40]);
                    //r6 = Convert.ToInt32(reader[41]);
                    //r7 = Convert.ToInt32(reader[42]);
                    //r8 = Convert.ToInt32(reader[43]);
                    //r9 = Convert.ToInt32(reader[44]);
                    //r10 = Convert.ToInt32(reader[45]);
                    //r11 = Convert.ToInt32(reader[46]);
                    //r12 = Convert.ToInt32(reader[47]);
                }

                conn.Close();

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);
                p5 = Math.Round((Convert.ToDouble(l5) / (Convert.ToDouble(o5) + Convert.ToDouble(l5)) * 100), 2);
                p6 = Math.Round((Convert.ToDouble(l6) / (Convert.ToDouble(o6) + Convert.ToDouble(l6)) * 100), 2);
                p7 = Math.Round((Convert.ToDouble(l7) / (Convert.ToDouble(o7) + Convert.ToDouble(l7)) * 100), 2);
                p8 = Math.Round((Convert.ToDouble(l8) / (Convert.ToDouble(o8) + Convert.ToDouble(l8)) * 100), 2);
                p9 = Math.Round((Convert.ToDouble(l9) / (Convert.ToDouble(o9) + Convert.ToDouble(l9)) * 100), 2);
                p10 = Math.Round((Convert.ToDouble(l10) / (Convert.ToDouble(o10) + Convert.ToDouble(l10)) * 100), 2);
                p11 = Math.Round((Convert.ToDouble(l11) / (Convert.ToDouble(o11) + Convert.ToDouble(l11)) * 100), 2);
                p12 = Math.Round((Convert.ToDouble(l12) / (Convert.ToDouble(o12) + Convert.ToDouble(l12)) * 100), 2);


                cartesianChart1.Series.Clear();
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();

                cartesianChart1.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "On Time",
                    Values = new ChartValues<double> { o12, o11, o10, o9, o8, o7, o6, o5, o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true,

                },
                new StackedColumnSeries
                {
                    Title = "Late",
                    Values = new ChartValues<double> { l12, l11, l10, l9, l8, l7, l6, l5, l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },


                new LineSeries
                {
                    Title = "Trend",
                    Values = new ChartValues<double> { p12, p11, p10, p9, p8, p7, p6, p5, p4, p3, p2, p1 },
                    ScalesYAt = 1
                },
            };






                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { n12, n11, n10, n9, n8, n7, n6, n5, n4, n3, n2, n1, },
                    Separator = DefaultAxes.CleanSeparator

                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });


                cartesianChart1.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100


                });
            }
            //monthly for the acknowledged on time
            if (1 == 1)
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



                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;
                int r5 = 0;
                int r6 = 0;
                int r7 = 0;
                int r8 = 0;
                int r9 = 0;
                int r10 = 0;
                int r11 = 0;
                int r12 = 0;


                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;
                double p5 = 0f;
                double p6 = 0f;
                double p7 = 0f;
                double p8 = 0f;
                double p9 = 0f;
                double p10 = 0f;
                double p11 = 0f;
                double p12 = 0f;




                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_absenteeism", conn);
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



                    //r1 = Convert.ToInt32(reader[36]);
                    //r2 = Convert.ToInt32(reader[37]);
                    //r3 = Convert.ToInt32(reader[38]);
                    //r4 = Convert.ToInt32(reader[39]);
                    //r5 = Convert.ToInt32(reader[40]);
                    //r6 = Convert.ToInt32(reader[41]);
                    //r7 = Convert.ToInt32(reader[42]);
                    //r8 = Convert.ToInt32(reader[43]);
                    //r9 = Convert.ToInt32(reader[44]);
                    //r10 = Convert.ToInt32(reader[45]);
                    //r11 = Convert.ToInt32(reader[46]);
                    //r12 = Convert.ToInt32(reader[47]);
                }

                conn.Close();


                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();

                cartesianChart2.Series = new SeriesCollection
            {
                //new StackedColumnSeries
                //{
                //    Title = "On Time",
                //    Values = new ChartValues<double> { o12, o11, o10, o9, o8, o7, o6, o5, o4, o3, o2, o1},
                //    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                //    DataLabels = true,

                //},
                new StackedColumnSeries
                {
                    Title = "Absent",
                    Values = new ChartValues<double> { l12, l11, l10, l9, l8, l7, l6, l5, l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },



            };






                cartesianChart2.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { n12, n11, n10, n9, n8, n7, n6, n5, n4, n3, n2, n1, },
                    Separator = DefaultAxes.CleanSeparator

                });

                cartesianChart2.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });


                //cartesianChart2.AxisY.Add(new Axis
                //{
                //    Foreground = System.Windows.Media.Brushes.Orange,
                //    Title = "Trend %",
                //    Position = AxisPosition.RightTop,
                //    LabelFormatter = value => value + " % Late",
                //    MinValue = 0,
                //    MaxValue = 100


                //});
            }
            //repaints
            if (1==1)
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



                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;
                int r5 = 0;
                int r6 = 0;
                int r7 = 0;
                int r8 = 0;
                int r9 = 0;
                int r10 = 0;
                int r11 = 0;
                int r12 = 0;


                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;
                double p5 = 0f;
                double p6 = 0f;
                double p7 = 0f;
                double p8 = 0f;
                double p9 = 0f;
                double p10 = 0f;
                double p11 = 0f;
                double p12 = 0f;




                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_manager_repaints", conn);
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



                    //r1 = Convert.ToInt32(reader[36]);
                    //r2 = Convert.ToInt32(reader[37]);
                    //r3 = Convert.ToInt32(reader[38]);
                    //r4 = Convert.ToInt32(reader[39]);
                    //r5 = Convert.ToInt32(reader[40]);
                    //r6 = Convert.ToInt32(reader[41]);
                    //r7 = Convert.ToInt32(reader[42]);
                    //r8 = Convert.ToInt32(reader[43]);
                    //r9 = Convert.ToInt32(reader[44]);
                    //r10 = Convert.ToInt32(reader[45]);
                    //r11 = Convert.ToInt32(reader[46]);
                    //r12 = Convert.ToInt32(reader[47]);
                }

                conn.Close();


                cartesianChart3.Series.Clear();
                cartesianChart3.AxisX.Clear();
                cartesianChart3.AxisY.Clear();

                cartesianChart3.Series = new SeriesCollection
            {
                //new StackedColumnSeries
                //{
                //    Title = "On Time",
                //    Values = new ChartValues<double> { o12, o11, o10, o9, o8, o7, o6, o5, o4, o3, o2, o1},
                //    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                //    DataLabels = true,

                //},
                new LineSeries
                {
                    Title = "Repaint",
                    Values = new ChartValues<double> { l12, l11, l10, l9, l8, l7, l6, l5, l4, l3, l2, l1},
                    DataLabels = true
                },

            };

                cartesianChart3.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { n12, n11, n10, n9, n8, n7, n6, n5, n4, n3, n2, n1, },
                    Separator = DefaultAxes.CleanSeparator

                });

                cartesianChart3.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });

            }
            fillPaintingGrid();
        }

        private void rdoQuaterly_Click(object sender, EventArgs e)
        {
            tempData.Clear();
            if (1 == 1)
            {
                string n1 = "";
                string n2 = "";
                string n3 = "";
                string n4 = "";
                int l1 = 0;
                int l2 = 0;
                int l3 = 0;
                int l4 = 0;
                int o1 = 0;
                int o2 = 0;
                int o3 = 0;
                int o4 = 0;
                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;

                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;

                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_manager", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Quaterly";
                cmd.Parameters.Add("@customerAccRef", SqlDbType.NVarChar).Value = customerAccRef;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    n1 = reader[0].ToString();
                    n2 = reader[3].ToString();
                    n3 = reader[6].ToString();
                    n4 = reader[9].ToString();
                    tempData.Add(reader[0].ToString());
                    tempData.Add(reader[3].ToString());
                    tempData.Add(reader[6].ToString());
                    tempData.Add(reader[9].ToString());
                    tempData.Reverse();

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

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);




                cartesianChart1.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "On Time",
                    Values = new ChartValues<double> {o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true
                },
                new StackedColumnSeries
                {
                    Title = "Late",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                }
                ,

                new LineSeries
                {
                    Title = "Trend",
                    Values = new ChartValues<double> {p4, p3, p2, p1 },
                    ScalesYAt = 1
                },
            };



                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { "Q" + n4, "Q" + n3, "Q" + n2, "Q" + n1 },
                    Separator = DefaultAxes.CleanSeparator
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100

                });
            }
            if (1 == 1)
            {

                string n1 = "";
                string n2 = "";
                string n3 = "";
                string n4 = "";
                int l1 = 0;
                int l2 = 0;
                int l3 = 0;
                int l4 = 0;
                int o1 = 0;
                int o2 = 0;
                int o3 = 0;
                int o4 = 0;
                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;

                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;

                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_absenteeism", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Quaterly";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    n1 = reader[0].ToString();
                    n2 = reader[3].ToString();
                    n3 = reader[6].ToString();
                    n4 = reader[9].ToString();

                    l1 = Convert.ToInt32(reader[1]);
                    l2 = Convert.ToInt32(reader[4]);
                    l3 = Convert.ToInt32(reader[7]);
                    l4 = Convert.ToInt32(reader[10]);

                    //o1 = Convert.ToInt32(reader[2]);
                    //o2 = Convert.ToInt32(reader[5]);
                    //o3 = Convert.ToInt32(reader[8]);
                    //o4 = Convert.ToInt32(reader[11]);


                }


                conn.Close();

                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);




                cartesianChart2.Series = new SeriesCollection
            {
                //new StackedColumnSeries
                //{
                //    Title = "On Time",
                //    Values = new ChartValues<double> {o4, o3, o2, o1},
                //    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                //    DataLabels = true
                //},
                new StackedColumnSeries
                {
                    Title = "Late",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                }
                ,


            };



                cartesianChart2.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { "Q" + n4, "Q" + n3, "Q" + n2, "Q" + n1 },
                    Separator = DefaultAxes.CleanSeparator
                });

                cartesianChart2.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });


            }
            if (1 == 1)
            {
                string n1 = "";
                string n2 = "";
                string n3 = "";
                string n4 = "";
                int l1 = 0;
                int l2 = 0;
                int l3 = 0;
                int l4 = 0;
                int o1 = 0;
                int o2 = 0;
                int o3 = 0;
                int o4 = 0;
                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;

                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;

                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_manager_repaints", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Quaterly";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    n1 = reader[0].ToString();
                    n2 = reader[3].ToString();
                    n3 = reader[6].ToString();
                    n4 = reader[9].ToString();

                    l1 = Convert.ToInt32(reader[1]);
                    l2 = Convert.ToInt32(reader[4]);
                    l3 = Convert.ToInt32(reader[7]);
                    l4 = Convert.ToInt32(reader[10]);

                    //o1 = Convert.ToInt32(reader[2]);
                    //o2 = Convert.ToInt32(reader[5]);
                    //o3 = Convert.ToInt32(reader[8]);
                    //o4 = Convert.ToInt32(reader[11]);


                }


                conn.Close();

                cartesianChart3.Series.Clear();
                cartesianChart3.AxisX.Clear();
                cartesianChart3.AxisY.Clear();

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);




                cartesianChart3.Series = new SeriesCollection
            {
                //new StackedColumnSeries
                //{
                //    Title = "On Time",
                //    Values = new ChartValues<double> {o4, o3, o2, o1},
                //    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                //    DataLabels = true
                //},
                new LineSeries
                {
                    Title = "Late",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    DataLabels = true
                }
                ,


            };



                cartesianChart3.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { "Q" + n4, "Q" + n3, "Q" + n2, "Q" + n1 },
                    Separator = DefaultAxes.CleanSeparator
                });

                cartesianChart3.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });

            }
            fillPaintingGrid();
        }

        private void rdoYearly_Click(object sender, EventArgs e)
        {
            tempData.Clear();
            if (1 == 1)
            {
                string n1 = "";
                string n2 = "";
                string n3 = "";
                string n4 = "";
                int l1 = 0;
                int l2 = 0;
                int l3 = 0;
                int l4 = 0;
                int o1 = 0;
                int o2 = 0;
                int o3 = 0;
                int o4 = 0;
                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;

                int r1 = 0; //not needed
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;



                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_manager", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Yearly";
                cmd.Parameters.Add("@customerAccRef", SqlDbType.NVarChar).Value = customerAccRef;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    n1 = reader[0].ToString();
                    n2 = reader[3].ToString();
                    n3 = reader[6].ToString();
                    n4 = reader[9].ToString();

                    tempData.Add(reader[0].ToString());
                    tempData.Add(reader[3].ToString());
                    tempData.Add(reader[6].ToString());
                    tempData.Add(reader[9].ToString());

                    tempData.Reverse();

                    l1 = Convert.ToInt32(reader[1]);
                    l2 = Convert.ToInt32(reader[4]);
                    l3 = Convert.ToInt32(reader[7]);
                    l4 = Convert.ToInt32(reader[10]);

                    o1 = Convert.ToInt32(reader[2]);
                    o2 = Convert.ToInt32(reader[5]);
                    o3 = Convert.ToInt32(reader[8]);
                    o4 = Convert.ToInt32(reader[11]);

                    //r1 = Convert.ToInt32(reader[12]);
                    //r2 = Convert.ToInt32(reader[13]);
                    //r3 = Convert.ToInt32(reader[14]);
                    //r4 = Convert.ToInt32(reader[15]);
                }


                conn.Close();



                cartesianChart1.Series.Clear();
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();


                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);


                cartesianChart1.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "On Time",
                    Values = new ChartValues<double> {o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true
                },
                new StackedColumnSeries
                {
                    Title = "Late",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },

                 new LineSeries
                {
                    Title = "Trend",
                    Values = new ChartValues<double> { p4, p3, p2, p1 },
                    ScalesYAt = 1
                },
            };



                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { n4, n3, n2, n1 },
                    Separator = DefaultAxes.CleanSeparator
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });


                cartesianChart1.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100
                });
            }
            if (1 == 1)
            {

                string n1 = "";
                string n2 = "";
                string n3 = "";
                string n4 = "";
                int l1 = 0;
                int l2 = 0;
                int l3 = 0;
                int l4 = 0;
                int o1 = 0;
                int o2 = 0;
                int o3 = 0;
                int o4 = 0;
                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;

                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;



                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_absenteeism", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Yearly";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    n1 = reader[0].ToString();
                    n2 = reader[3].ToString();
                    n3 = reader[6].ToString();
                    n4 = reader[9].ToString();

                    l1 = Convert.ToInt32(reader[1]);
                    l2 = Convert.ToInt32(reader[4]);
                    l3 = Convert.ToInt32(reader[7]);
                    l4 = Convert.ToInt32(reader[10]);

                    //o1 = Convert.ToInt32(reader[2]);
                    //o2 = Convert.ToInt32(reader[5]);
                    //o3 = Convert.ToInt32(reader[8]);
                    //o4 = Convert.ToInt32(reader[11]);

                    //r1 = Convert.ToInt32(reader[12]);
                    //r2 = Convert.ToInt32(reader[13]);
                    //r3 = Convert.ToInt32(reader[14]);
                    //r4 = Convert.ToInt32(reader[15]);
                }


                conn.Close();



                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();


                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);


                cartesianChart2.Series = new SeriesCollection
            {
                //new StackedColumnSeries
                //{
                //    Title = "On Time",
                //    Values = new ChartValues<double> {o4, o3, o2, o1},
                //    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                //    DataLabels = true
                //},
                new StackedColumnSeries
                {
                    Title = "Late",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },


            };





                cartesianChart2.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { n4, n3, n2, n1 },
                    Separator = DefaultAxes.CleanSeparator
                });

                cartesianChart2.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });



            }
            if (1 == 1)
            {
                string n1 = "";
                string n2 = "";
                string n3 = "";
                string n4 = "";
                int l1 = 0;
                int l2 = 0;
                int l3 = 0;
                int l4 = 0;
                int o1 = 0;
                int o2 = 0;
                int o3 = 0;
                int o4 = 0;
                double p1 = 0f;
                double p2 = 0f;
                double p3 = 0f;
                double p4 = 0f;

                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;



                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_production_manager_repaints", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Yearly";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    n1 = reader[0].ToString();
                    n2 = reader[3].ToString();
                    n3 = reader[6].ToString();
                    n4 = reader[9].ToString();

                    l1 = Convert.ToInt32(reader[1]);
                    l2 = Convert.ToInt32(reader[4]);
                    l3 = Convert.ToInt32(reader[7]);
                    l4 = Convert.ToInt32(reader[10]);

                    //o1 = Convert.ToInt32(reader[2]);
                    //o2 = Convert.ToInt32(reader[5]);
                    //o3 = Convert.ToInt32(reader[8]);
                    //o4 = Convert.ToInt32(reader[11]);

                    //r1 = Convert.ToInt32(reader[12]);
                    //r2 = Convert.ToInt32(reader[13]);
                    //r3 = Convert.ToInt32(reader[14]);
                    //r4 = Convert.ToInt32(reader[15]);
                }


                conn.Close();



                cartesianChart3.Series.Clear();
                cartesianChart3.AxisX.Clear();
                cartesianChart3.AxisY.Clear();


                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);


                cartesianChart3.Series = new SeriesCollection
            {
                //new StackedColumnSeries
                //{
                //    Title = "On Time",
                //    Values = new ChartValues<double> {o4, o3, o2, o1},
                //    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                //    DataLabels = true
                //},
                new LineSeries
                {
                    Title = "Late",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    DataLabels = true
                },


            };

                cartesianChart3.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { n4, n3, n2, n1 },
                    Separator = DefaultAxes.CleanSeparator
                });

                cartesianChart3.AxisY.Add(new Axis
                {
                    Title = "Output",
                    LabelFormatter = value => value + ""
                });


            }
            fillPaintingGrid();
        }

        private void frmProductionManagement_Shown(object sender, EventArgs e)
        {
            rdoWeekly.PerformClick();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnPrintLateness_Click(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\temp.jpg");

                printImage();
            }
            catch
            {

            }
        }
        private void printImage()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    System.Drawing.Image i = System.Drawing.Image.FromFile(@"C:\temp\temp.jpg");
                    Point p = new Point(100, 100);
                    args.Graphics.DrawImage(i, args.MarginBounds);

                };

                pd.DefaultPageSettings.Landscape = true;
                Margins margins = new Margins(50, 50, 50, 50);
                pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            {

            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_TextChanged(object sender, EventArgs e)
        {
            //find the acc ref based on name
            string sql = "SELECT ACCOUNT_REF FROM dbo.[sales_ledger] WHERE NAME = '" + cmbCustomer.Text + "'";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var getdata = cmd.ExecuteScalar();
                    if (getdata != null)
                    {
                        customerAccRef = cmd.ExecuteScalar().ToString();
                        if (rdoWeekly.Checked == true)
                            rdoWeekly.PerformClick();
                        if (rdoMonthly.Checked == true)
                            rdoMonthly.PerformClick();
                        if (rdoQuaterly.Checked == true)
                            rdoQuaterly.PerformClick();
                        if (rdoYearly.Checked == true)
                            rdoYearly.PerformClick();
                    }
                    else
                        customerAccRef = "";
                    conn.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e) //because wiping the box is a pain when doing it manually and unreliable 
        {
            cmbCustomer.Text = "";
            if (rdoWeekly.Checked == true) //reload the chart in the background
                rdoWeekly.PerformClick();
            if (rdoMonthly.Checked == true)
                rdoMonthly.PerformClick();
            if (rdoQuaterly.Checked == true)
                rdoQuaterly.PerformClick();
            if (rdoYearly.Checked == true)
                rdoYearly.PerformClick();
        }



        private void cartesianChart2_DataClick(object sender, ChartPoint p)
        {
            //var asPixels = cartesianChart2.Base.ConvertToPixels(p.AsPoint());
            //MessageBox.Show("[EVENT] You clicked ([EVENT] You clicked (" + p.X + ", " + p.Y + ") in pixels (" +
            //            asPixels.X + ", " + asPixels.Y + ")");
            //MessageBox.Show(Convert.ToInt32(p.X).ToString());
            //MessageBox.Show(tempData[Convert.ToInt32(p.X)].ToString());

            //vvvv use this to get the current datatype tom uses for the chart 
            tempData[Convert.ToInt32(p.X)].ToString();
            int today = 0;

            //because the data types are so inconsistent we need to check which type it is
            DateTime dateStart = DateTime.Today;
            DateTime dateEnd = DateTime.Today;
            if (rdoWeekly.Checked == true) //weekly is the only nice format 
            {
                dateStart = Convert.ToDateTime(tempData[Convert.ToInt32(p.X)].ToString());
                if (Convert.ToInt32(p.X) != 3)
                    dateEnd = dateStart.AddDays(7);
                else
                    today = -1;
            }
            else if (rdoMonthly.Checked == true)
            {
                int monthsToRemove = tempData.IndexOf(tempData[Convert.ToInt32(p.X)].ToString()) + 1; //add one because list stars at 0
                monthsToRemove = monthsToRemove - tempData.Count(); //remove the current pos from the  list total to get the amount of jumps back we take
                dateStart = Convert.ToDateTime(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/01");
                dateStart = dateStart.AddMonths(monthsToRemove);
                if (Convert.ToInt32(p.X) != 11)
                    dateEnd = dateStart.AddMonths(1);
                else
                    today = -1;
            }
            else if (rdoQuaterly.Checked == true)
            {
                // find out what is the start month of the quater we are currently in (this should always be the final quater on the graph
                //after we have that take away 3 months for every position away from the final quater
                int quarterNumber = (dateStart.Month - 1) / 3 + 1;
                dateStart = new DateTime(dateStart.Year, (quarterNumber - 1) * 3 + 1, 1);

                int monthsToRemove = tempData.IndexOf(tempData[Convert.ToInt32(p.X)].ToString()) + 1; //add one because list stars at 0
                monthsToRemove = monthsToRemove - tempData.Count();
                monthsToRemove = monthsToRemove * 3; //each quater is 3 months so this should take away the exact number of months to remove
                dateStart = dateStart.AddMonths(monthsToRemove);
                if (Convert.ToInt32(p.X) != 3)
                    dateEnd = dateEnd.AddMonths(3);
                else
                    today = -1;
            }
            else if (rdoYearly.Checked == true)
            {
                //this one should be fairly easy as the output is the year
                dateStart = Convert.ToDateTime(tempData[Convert.ToInt32(p.X)].ToString() + "/01/01");
                if (Convert.ToInt32(p.X) != 3)
                    dateEnd = dateStart.AddYears(1);
                else
                    today = -1;
            }
            frmAbsenteeism frm = new frmAbsenteeism(dateStart, dateEnd,today);
            frm.ShowDialog();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        { 
            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\Chart.jpg");


            }
            catch
            {

            }


            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "";
            mailItem.To = "";
            string imageSrc = @"C:\Temp\Chart.jpg"; // Change path as needed

            var attachments = mailItem.Attachments;
            var attachment = attachments.Add(imageSrc);
            attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
            attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
            mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);

            // Set body format to HTML

            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            mailItem.Attachments.Add(imageSrc);
            string msgHTMLBody = "";
            mailItem.HTMLBody = msgHTMLBody;
            mailItem.Display(true);
        }

        private void fillPaintingGrid()
        {
            // front of list and end
            // tempData[0].ToString();
            //tempData[tempData.Count()].ToString();
            DateTime endDate = DateTime.Now;
            DateTime startDate = DateTime.Now;


            if (rdoWeekly.Checked == true) //weekly is the only nice format 
            {
                //MessageBox.Show(tempData[tempData.Count() - 1].ToString());
                endDate = Convert.ToDateTime(tempData[tempData.Count() - 1].ToString());
                startDate = Convert.ToDateTime(tempData[0].ToString());
                endDate = endDate.AddDays(7); //because its the START of the week
                //IF THE SELECT IS NOT < THEN WE NEED TO ADD 6 DAYS BECAUSE RIGHT NOW ITS ADDING THE FIRST DAY OF THE NEXT WEEK
            }
            else if (rdoMonthly.Checked == true)
            {

                endDate = Convert.ToDateTime(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/01"); //THE FINAL ENTRY IS ALWAYS THIS CURRENT MONTH
                endDate = endDate.AddMonths(1); //we need to include this months data so if its januray its everything < feb
                startDate = endDate.AddYears(-1);
            }
            else if (rdoQuaterly.Checked == true)
            {
                // find out what is the start month of the quater we are currently in (this should always be the final quater on the graph
                //after we have that take away 3 months for every position away from the final quater
                endDate = DateTime.Now;
                int quarterNumber = (endDate.Month - 1) / 3 + 1;
                endDate = new DateTime(endDate.Year, (quarterNumber - 1) * 3 + 1, 1); //get the current quarter because thats final quater on the graph <<<<<<<<<<<<<<<<<<<<<<<
                startDate = endDate.AddMonths(-9);
                endDate = endDate.AddMonths(3);

            }
            else if (rdoYearly.Checked == true)
            {
                //this one should be fairly easy as the output is the year
                //MessageBox.Show( tempData[tempData.Count() -1].ToString());
                endDate = Convert.ToDateTime(tempData[tempData.Count() - 1].ToString() + "/01/01");
                startDate = endDate.AddYears(-3);
                endDate = endDate.AddYears(1);

                //startDate = Convert.ToDateTime(tempData[tempData.Count() - 1].ToString());
            }

            //fill the department dgv
            string sql = "select COALESCE(max(u_painter_name.forename) + ' ' + max(u_painter_name.surname),'') as [Painter Name],count(painter_name) as [Number of Repaints],'£' + CAST(round(sum(repaint_cost),2) as nvarchar(max)) as [Total Cost]  from dbo.repaints " +
                "left join[user_info].dbo.[user] u_painter_name on u_painter_name.id = painter_name WHERE date_painted >= '" + startDate.ToString("yyyy-MM-dd") + "' AND date_painted < '" + endDate.ToString("yyyy-MM-dd") + "' group by painter_name order by count(painter_name) desc";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStaff.DataSource = dt;
                    dgvStaff.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvStaff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvStaff.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvStaff.ClearSelection();
                }
                sql = "select d.department_name as [Department],count(painter_name) as [Number of Repaints],'£' + CAST(round(sum(repaint_cost),2) as nvarchar(max)) as [Total Cost]  from dbo.repaints left join[dsl_kpi].dbo.department d on d.id = repaints.department " +
                    "WHERE date_painted >= '" + startDate.ToString("yyyy-MM-dd") + "' AND date_painted <= '" + endDate.ToString("yyyy-MM-dd") + "' group by d.department_name order by count(painter_name) desc";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DataRow toInsert = dt.NewRow();
                    // insert in the desired place
                    dt.Rows.InsertAt(toInsert, dt.Rows.Count);
                    dt.Rows[dt.Rows.Count - 1][0] = "Totals:";
                    double totalCost = 0;
                    int totalRemake = 0;
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        string temp = dt.Rows[i][2].ToString().Substring(1);
                        totalRemake = totalRemake + Convert.ToInt32(dt.Rows[i][1]);
                        totalCost = totalCost + Convert.ToDouble(temp);
                    }

                    dt.Rows[dt.Rows.Count - 1][1] = totalRemake;
                    dt.Rows[dt.Rows.Count - 1][2] = "£" + totalCost.ToString();
                    dgvDepartment.DataSource = dt;
                    dgvDepartment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvDepartment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvDepartment.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvDepartment.ClearSelection();
                }
                conn.Close();
            }
        }

        private void tabEngineering_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEngineering.SelectedIndex == 2)
            {
                dgvDepartment.Visible = true;
                dgvStaff.Visible = true;
            }
            else
            {
                dgvDepartment.Visible = false;
                dgvStaff.Visible = false;
            }
        }

        private void dgvDepartment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int department_index = 0;
            department_index = dgvDepartment.Columns["Department"].Index;
            //int button_index = 0;
            //button_index = dgvDepartment.Columns[" "].Index;

            if (e.RowIndex == dgvDepartment.Rows.Count - 1)
                return;
            var senderGrid = (DataGridView)sender; 
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex == dgvDepartment.Rows.Count - 1)
                return;




            //front of list and end 
            // tempData[0].ToString();
            //tempData[tempData.Count()].ToString();
            DateTime endDate = DateTime.Now;
            DateTime startDate = DateTime.Now;


            if (rdoWeekly.Checked == true) //weekly is the only nice format 
            {
                endDate = Convert.ToDateTime(tempData[tempData.Count() - 1].ToString());
                startDate = Convert.ToDateTime(tempData[department_index].ToString());
                endDate = endDate.AddDays(7); //because its the START of the week
                                              //IF THE SELECT IS NOT < THEN WE NEED TO ADD 6 DAYS BECAUSE RIGHT NOW ITS ADDING THE FIRST DAY OF THE NEXT WEEK
            }
            else if (rdoMonthly.Checked == true)
            {

                endDate = Convert.ToDateTime(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/01"); //THE FINAL ENTRY IS ALWAYS THIS CURRENT MONTH
                endDate = endDate.AddMonths(1); //we need to include this months data so if its januray its everything < feb
                startDate = endDate.AddYears(-1);
            }
            else if (rdoQuaterly.Checked == true)
            {
                // find out what is the start month of the quater we are currently in (this should always be the final quater on the graph
                //after we have that take away 3 months for every position away from the final quater
                endDate = DateTime.Now;
                int quarterNumber = (endDate.Month - 1) / 3 + 1;
                endDate = new DateTime(endDate.Year, (quarterNumber - 1) * 3 + 1, 1); //get the current quarter because thats final quater on the graph <<<<<<<<<<<<<<<<<<<<<<<
                startDate = endDate.AddMonths(-9);
                endDate = endDate.AddMonths(3);

            }
            else if (rdoYearly.Checked == true)
            {
                //this one should be fairly easy as the output is the year
                //MessageBox.Show( tempData[tempData.Count() -1].ToString());
                endDate = Convert.ToDateTime(tempData[tempData.Count() - 1].ToString() + "/01/01");
                startDate = endDate.AddYears(-3);
                endDate = endDate.AddYears(1);

                //startDate = Convert.ToDateTime(tempData[tempData.Count() - 1].ToString());
            }

            frmRepaints frm = new frmRepaints(startDate, endDate, -1, dgvDepartment.Rows[e.RowIndex].Cells[department_index].Value.ToString(), 0, "");
            frm.ShowDialog();
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == dgvDepartment.Rows.Count - 1)
            //    return;


            //front of list and end 
            // tempData[0].ToString();
            //tempData[tempData.Count()].ToString();
            DateTime endDate = DateTime.Now;
            DateTime startDate = DateTime.Now;


            if (rdoWeekly.Checked == true) //weekly is the only nice format 
            {
                endDate = Convert.ToDateTime(tempData[tempData.Count() - 1].ToString());
                startDate = Convert.ToDateTime(tempData[0].ToString());
                endDate = endDate.AddDays(7); //because its the START of the week
                //IF THE SELECT IS NOT < THEN WE NEED TO ADD 6 DAYS BECAUSE RIGHT NOW ITS ADDING THE FIRST DAY OF THE NEXT WEEK
            }
            else if (rdoMonthly.Checked == true)
            {

                endDate = Convert.ToDateTime(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/01"); //THE FINAL ENTRY IS ALWAYS THIS CURRENT MONTH
                endDate = endDate.AddMonths(1); //we need to include this months data so if its januray its everything < feb
                startDate = endDate.AddYears(-1);
            }
            else if (rdoQuaterly.Checked == true)
            {
                // find out what is the start month of the quater we are currently in (this should always be the final quater on the graph
                //after we have that take away 3 months for every position away from the final quater
                endDate = DateTime.Now;
                int quarterNumber = (endDate.Month - 1) / 3 + 1;
                endDate = new DateTime(endDate.Year, (quarterNumber - 1) * 3 + 1, 1); //get the current quarter because thats final quater on the graph <<<<<<<<<<<<<<<<<<<<<<<
                startDate = endDate.AddMonths(-9);
                endDate = endDate.AddMonths(3);

            }
            else if (rdoYearly.Checked == true)
            {
                //this one should be fairly easy as the output is the year
                //MessageBox.Show( tempData[tempData.Count() -1].ToString());
                endDate = Convert.ToDateTime(tempData[tempData.Count() - 1].ToString() + "/01/01");
                startDate = endDate.AddYears(-3);
                endDate = endDate.AddYears(1);

                //startDate = Convert.ToDateTime(tempData[tempData.Count() - 1].ToString());
            }

            frmRepaints frm = new frmRepaints(startDate, endDate, 0, "", -1, dgvStaff.Rows[e.RowIndex].Cells[0].Value.ToString());
            frm.ShowDialog();
        }
    }
}
