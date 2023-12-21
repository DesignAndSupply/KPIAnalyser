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
    public partial class frmProductionManagementLastWeek : Form
    {
        List<string> tempData = new List<string>();
        public frmProductionManagementLastWeek()
        {
            InitializeComponent();

            fillGrid();
        }

        private void fillGrid()
        {
            string sql = "usp_kpi_production_manager_remake_repaint";
            //stuffs

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
                cmd.Parameters.Add("@customerAccRef", SqlDbType.NVarChar).Value = "";

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



                completedOnTime.Series.Clear();
                completedOnTime.AxisX.Clear();
                completedOnTime.AxisY.Clear();

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);

                completedOnTime.Series = new SeriesCollection
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


                completedOnTime.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    FontSize = 13,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Labels = new[] { "Week Commencing " + ws4.ToShortDateString(), "Week Commencing " + ws3.ToShortDateString(), "Week Commencing " + ws2.ToShortDateString(), "Week Commencing " + ws1.ToShortDateString() },
                    Separator = DefaultAxes.CleanSeparator
                });

                completedOnTime.AxisY.Add(new Axis
                {
                    Title = "Output",
                    FontSize = 13,
                    Foreground = System.Windows.Media.Brushes.Black,
                    LabelFormatter = value => value + ""
                });



                completedOnTime.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    FontSize = 13,
                    // Foreground = System.Windows.Media.Brushes.Black,
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



                absenteeism.Series.Clear();
                absenteeism.AxisX.Clear();
                absenteeism.AxisY.Clear();

                p1 = l1;//Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = l2;// Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = l3;// Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = l4;// Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);

                absenteeism.Series = new SeriesCollection
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


                absenteeism.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    FontSize = 13,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Labels = new[] { "Week Commencing " + ws4.ToShortDateString(), "Week Commencing " + ws3.ToShortDateString(), "Week Commencing " + ws2.ToShortDateString(), "Week Commencing " + ws1.ToShortDateString() },
                    Separator = DefaultAxes.CleanSeparator
                });

                absenteeism.AxisY.Add(new Axis
                {
                    Title = "Output",
                    FontSize = 13,
                    Foreground = System.Windows.Media.Brushes.Black,
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



                Repaints.Series.Clear();
                Repaints.AxisX.Clear();
                Repaints.AxisY.Clear();

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);

                Repaints.Series = new SeriesCollection
            {

                new LineSeries
                {
                    Title = "Repaint",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    DataLabels = true
                },
            };

                Repaints.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    FontSize = 13,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Labels = new[] { "Week Commencing " + ws4.ToShortDateString(), "Week Commencing " + ws3.ToShortDateString(), "Week Commencing " + ws2.ToShortDateString(), "Week Commencing " + ws1.ToShortDateString() },
                    Separator = DefaultAxes.CleanSeparator
                });

                Repaints.AxisY.Add(new Axis
                {
                    Title = "Output",
                    FontSize = 13,
                    Foreground = System.Windows.Media.Brushes.Black,
                    LabelFormatter = value => value + ""
                });



                Repaints.AxisY.Add(new Axis
                {
                    Foreground = System.Windows.Media.Brushes.Orange,
                    Title = "Trend %",
                    FontSize = 13,
                    ////Foreground = System.Windows.Media.Brushes.Black,
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value + " % Late",
                    MinValue = 0,
                    MaxValue = 100

                });
            }
            //remake / repaint
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
                int rem1 = 0;
                int rem2 = 0;
                int rem3 = 0;
                int rem4 = 0;
                int rep1 = 0;
                int rep2 = 0;
                int rep3 = 0;
                int rep4 = 0;




                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
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

                    //dgv stuff
                    rem4 = Convert.ToInt32(reader[12]);
                    rem3 = Convert.ToInt32(reader[13]);
                    rem2 = Convert.ToInt32(reader[14]);
                    rem1 = Convert.ToInt32(reader[15]);
                    rep4 = Convert.ToInt32(reader[16]);
                    rep3 = Convert.ToInt32(reader[17]);
                    rep2 = Convert.ToInt32(reader[18]);
                    rep1 = Convert.ToInt32(reader[19]);
                }


                //datagridview stuff
                DataTable dt = new DataTable();
                dt.Columns.Add("Week of");
                dt.Columns.Add("Remakes");
                dt.Columns.Add("Repaints");
                DataRow week4 = dt.NewRow();
                week4[0] = ws4.ToShortDateString();
                week4[1] = rem1;
                week4[2] = rep1;
                dt.Rows.Add(week4);
                DataRow week3 = dt.NewRow();
                week3[0] = ws3.ToShortDateString();
                week3[1] = rem2;
                week3[2] = rep2;
                dt.Rows.Add(week3);
                DataRow week2 = dt.NewRow();
                week2[0] = ws2.ToShortDateString();
                week2[1] = rem3;
                week2[2] = rep3;
                dt.Rows.Add(week2);
                DataRow week1 = dt.NewRow();
                week1[0] = ws1.ToShortDateString();
                week1[1] = rem4;
                week1[2] = rep4;
                dt.Rows.Add(week1);
                DataRow totals = dt.NewRow();
                totals[0] = "Totals:";
                totals[1] = rem1 + rem2 + rem3 + rem4;
                totals[2] = rep1 + rep2 + rep3 + rep4;
                dt.Rows.Add(totals);
                //dgvRepaintRemake.DataSource = dt;
                ////////////

                conn.Close();



                remakeRepaintValue.Series.Clear();
                remakeRepaintValue.AxisX.Clear();
                remakeRepaintValue.AxisY.Clear();

                p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
                p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
                p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
                p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);

                remakeRepaintValue.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "Repaint",
                    Values = new ChartValues<double> {o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true
                },
                new StackedColumnSeries
                {
                    Title = "Remake",
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


                remakeRepaintValue.AxisX.Add(new Axis
                {
                    Title = "Date Range",
                    Labels = new[] { "Week Commencing " + ws4.ToShortDateString(), "Week Commencing " + ws3.ToShortDateString(), "Week Commencing " + ws2.ToShortDateString(), "Week Commencing " + ws1.ToShortDateString() },
                    FontSize = 13,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Separator = DefaultAxes.CleanSeparator

                });

                remakeRepaintValue.AxisY.Add(new Axis
                {
                    Title = "Output",
                    FontSize = 13,
                    Foreground = System.Windows.Media.Brushes.Black,
                    LabelFormatter = value => "£" + value + ""
                });

                remakeRepaintValue.LegendLocation = LegendLocation.Top;

                DefaultLegend legend = new DefaultLegend();
                legend.BulletSize = 15;
                //legend.Foreground = Brushes.White;
                legend.Orientation = System.Windows.Controls.Orientation.Horizontal;
                remakeRepaintValue.DefaultLegend = legend;




                //cartesianChart4.AxisY.Add(new Axis
                //{
                //    Foreground = System.Windows.Media.Brushes.Orange,
                //    Title = "Trend %",
                //    Position = AxisPosition.RightTop,
                //    LabelFormatter = value => value + " % Late",
                //    MinValue = 0,
                //    MaxValue = 100


                //});
            }
        }

        private void absenteeism_DataClick(object sender, ChartPoint p)
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

            dateStart = Convert.ToDateTime(tempData[Convert.ToInt32(p.X)].ToString());
            if (Convert.ToInt32(p.X) != 3)
                dateEnd = dateStart.AddDays(7);
            else
                today = -1;


            frmAbsenteeism frm = new frmAbsenteeism(dateStart, dateEnd, today);
            frm.ShowDialog();
        }

        private void Repaints_DataClick(object sender, ChartPoint p)
        {
            //var asPixels = cartesianChart2.Base.ConvertToPixels(p.AsPoint());
            //MessageBox.Show("[EVENT] You clicked ([EVENT] You clicked (" + p.X + ", " + p.Y + ") in pixels (" +
            //            asPixels.X + ", " + asPixels.Y + ")");
            //MessageBox.Show(Convert.ToInt32(p.X).ToString());
            //   MessageBox.Show(tempData[Convert.ToInt32(p.X)].ToString());

            //vvvv use this to get the current datatype tom uses for the chart 
            tempData[Convert.ToInt32(p.X)].ToString();

            //because the data types are so inconsistent we need to check which type it is
            DateTime dateStart = DateTime.Today;
            DateTime dateEnd = DateTime.Today;

            dateStart = Convert.ToDateTime(tempData[Convert.ToInt32(p.X)].ToString());
            dateEnd = dateStart.AddDays(7);



            //should have the start and end dates for the new form now

            frmRepaints frm = new frmRepaints(dateStart, dateEnd, 0, "", 0, "");
            frm.ShowDialog();
        }

        private void remakeRepaintValue_DataClick(object sender, ChartPoint p)
        {
           // var asPixels = cartesianChart2.Base.ConvertToPixels(p.AsPoint());
            //MessageBox.Show("[EVENT] You clicked ([EVENT] You clicked (" + p.X + ", " + p.Y + ") in pixels (" +
            //            asPixels.X + ", " + asPixels.Y + ")");
            //MessageBox.Show(Convert.ToInt32(p.X).ToString());
            //   MessageBox.Show(tempData[Convert.ToInt32(p.X)].ToString());

            //vvvv use this to get the current datatype tom uses for the chart 
            tempData[Convert.ToInt32(p.X)].ToString();

            //because the data types are so inconsistent we need to check which type it is
            DateTime dateStart = DateTime.Today;
            DateTime dateEnd = DateTime.Today;

                dateStart = Convert.ToDateTime(tempData[Convert.ToInt32(p.X)].ToString());
                dateEnd = dateStart.AddDays(7);
        

            frmRemakeRepaintGraph frm = new frmRemakeRepaintGraph(dateStart, dateEnd, 0);
            frm.ShowDialog();
        }
    }
}
