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
    public partial class frmAdminManagement : Form
    {
        List<string> tempData = new List<string>();
        public frmAdminManagement()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
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
                SqlCommand cmd = new SqlCommand("usp_kpi_admin_manager", conn);
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
                SqlCommand cmd = new SqlCommand("usp_kpi_admin_manager_acknowledged_on_time", conn);
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



                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);

                cartesianChart2.Series = new SeriesCollection
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



                cartesianChart2.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100
                });
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
                SqlCommand cmd = new SqlCommand("usp_kpi_admin_manager", conn);
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
            tempData.Clear();
            if (1==1)
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
                SqlCommand cmd = new SqlCommand("usp_kpi_admin_manager_acknowledged_on_time", conn);
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



                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);

                cartesianChart2.Series = new SeriesCollection
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



                cartesianChart2.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100


                });
            }

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
                SqlCommand cmd = new SqlCommand("usp_kpi_admin_manager", conn);
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
                SqlCommand cmd = new SqlCommand("usp_kpi_admin_manager_acknowledged_on_time", conn);
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


                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();

                cartesianChart2.Series = new SeriesCollection
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


                cartesianChart2.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100


                });
            }
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
                SqlCommand cmd = new SqlCommand("usp_kpi_admin_manager", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Quaterly";

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
            tempData.Clear();
            if (1==1)
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
                SqlCommand cmd = new SqlCommand("usp_kpi_admin_manager_acknowledged_on_time", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Quaterly";

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

                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);




                cartesianChart2.Series = new SeriesCollection
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

                cartesianChart2.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100

                });
            }
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

                int r1 = 0;
                int r2 = 0;
                int r3 = 0;
                int r4 = 0;



                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_admin_manager", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Yearly";

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
            tempData.Clear();
            if (1==1)
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
                SqlCommand cmd = new SqlCommand("usp_kpi_admin_manager_acknowledged_on_time", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Yearly";

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



                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();


                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);


                cartesianChart2.Series = new SeriesCollection
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


                cartesianChart2.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100
                });
            }
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

        private void frmAdminManagement_Load(object sender, EventArgs e)
        {

        }

        private void frmAdminManagement_Shown(object sender, EventArgs e)
        {
            rdoWeekly.Checked = true;
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

        private void tabEngineering_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEngineering.SelectedIndex == 0)
                lblGraphTitle.Text = "Booked in on Time";
            if (tabEngineering.SelectedIndex == 1)
                lblGraphTitle.Text = "Acknowledged on time";
        }
    }
}

