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
using System.Drawing.Imaging;
using System.Globalization;
using System.Drawing.Printing;

namespace KPIAnalyser
{
    public partial class frmEngineeringManagement : Form
    {
        List<string> tempData = new List<string>();

        public frmEngineeringManagement()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            drawStackedLatenessChartWeekly();
            rdoWeekly.Checked = true;
            filldatagrid();
        }

        private void FrmEngineeringManagement_Load(object sender, EventArgs e)
        {

        }


        private void drawStackedLatenessChartMonthly()
        {
            tempData.Clear();

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



                r1 = Convert.ToInt32(reader[36]);
                r2 = Convert.ToInt32(reader[37]);
                r3 = Convert.ToInt32(reader[38]);
                r4 = Convert.ToInt32(reader[39]);
                r5 = Convert.ToInt32(reader[40]);
                r6 = Convert.ToInt32(reader[41]);
                r7 = Convert.ToInt32(reader[42]);
                r8 = Convert.ToInt32(reader[43]);
                r9 = Convert.ToInt32(reader[44]);
                r10 = Convert.ToInt32(reader[45]);
                r11 = Convert.ToInt32(reader[46]);
                r12 = Convert.ToInt32(reader[47]);
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
                Labels = new[] { n12 + " - " + p12 + "%", n11 + " - " + p11 + "%", n10 + " - " + p10 + "%", n9 + " - " + p9 + "%", n8 + " - " + p8 + "%", n7 + " - " + p7 + "%", n6 + " - " + p6 + "%", n5 + " - " + p5 + "%", n4 + " - " + p4 + "%", n3 + " - " + p3 + "%", n2 + " - " + p2 + "%", n1 + " - " + p1 + "%", },
                Separator = DefaultAxes.CleanSeparator

            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Output",
                LabelFormatter = value => value + " Doors"
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



            //////////REMAKES MONTHLY
            ///

            cartesianChart2.Series.Clear();
            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisY.Clear();

            cartesianChart2.Series = new SeriesCollection
            {

            new LineSeries
                {
                    Title = "Count",
                    Values = new ChartValues<double> { r12, r11, r10, r9, r8, r7, r6, r5, r4, r3, r2, r1 },
                    DataLabels = true
                },
            };


            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "Date Range",
                Labels = new[] { n12, n11, n10, n9, n8, n7, n6, n5, n4, n3, n2, n1 },
                Separator = DefaultAxes.CleanSeparator

            });

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Remakes",
                LabelFormatter = value => value + " Remakes"
            });




            //////////////////////////////
            //remakes returned

            SqlConnection connRemakesReturned = new SqlConnection(ConnectionStrings.ConnectionString);
            connRemakesReturned.Open();
            SqlCommand cmdRemakesReturned = new SqlCommand("usp_kpi_remakes_returned", connRemakesReturned);
            cmdRemakesReturned.CommandType = CommandType.StoredProcedure;

            cmdRemakesReturned.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Monthly";

            SqlDataReader readerRemakesReturned = cmdRemakesReturned.ExecuteReader();

            while (readerRemakesReturned.Read())
            {

                n1 = readerRemakesReturned[0].ToString();
                n2 = readerRemakesReturned[3].ToString();
                n3 = readerRemakesReturned[6].ToString();
                n4 = readerRemakesReturned[9].ToString();
                n5 = readerRemakesReturned[12].ToString();
                n6 = readerRemakesReturned[15].ToString();
                n7 = readerRemakesReturned[18].ToString();
                n8 = readerRemakesReturned[21].ToString();
                n9 = readerRemakesReturned[24].ToString();
                n10 = readerRemakesReturned[27].ToString();
                n11 = readerRemakesReturned[30].ToString();
                n12 = readerRemakesReturned[33].ToString();

                l1 = Convert.ToInt32(readerRemakesReturned[1]);
                l2 = Convert.ToInt32(readerRemakesReturned[4]);
                l3 = Convert.ToInt32(readerRemakesReturned[7]);
                l4 = Convert.ToInt32(readerRemakesReturned[10]);
                l5 = Convert.ToInt32(readerRemakesReturned[13]);
                l6 = Convert.ToInt32(readerRemakesReturned[16]);
                l7 = Convert.ToInt32(readerRemakesReturned[19]);
                l8 = Convert.ToInt32(readerRemakesReturned[22]);
                l9 = Convert.ToInt32(readerRemakesReturned[25]);
                l10 = Convert.ToInt32(readerRemakesReturned[28]);
                l11 = Convert.ToInt32(readerRemakesReturned[31]);
                l12 = Convert.ToInt32(readerRemakesReturned[34]);

                o1 = Convert.ToInt32(readerRemakesReturned[2]);
                o2 = Convert.ToInt32(readerRemakesReturned[5]);
                o3 = Convert.ToInt32(readerRemakesReturned[8]);
                o4 = Convert.ToInt32(readerRemakesReturned[11]);
                o5 = Convert.ToInt32(readerRemakesReturned[14]);
                o6 = Convert.ToInt32(readerRemakesReturned[17]);
                o7 = Convert.ToInt32(readerRemakesReturned[20]);
                o8 = Convert.ToInt32(readerRemakesReturned[23]);
                o9 = Convert.ToInt32(readerRemakesReturned[26]);
                o10 = Convert.ToInt32(readerRemakesReturned[29]);
                o11 = Convert.ToInt32(readerRemakesReturned[32]);
                o12 = Convert.ToInt32(readerRemakesReturned[35]);



                r1 = Convert.ToInt32(readerRemakesReturned[36]);
                r2 = Convert.ToInt32(readerRemakesReturned[37]);
                r3 = Convert.ToInt32(readerRemakesReturned[38]);
                r4 = Convert.ToInt32(readerRemakesReturned[39]);
                r5 = Convert.ToInt32(readerRemakesReturned[40]);
                r6 = Convert.ToInt32(readerRemakesReturned[41]);
                r7 = Convert.ToInt32(readerRemakesReturned[42]);
                r8 = Convert.ToInt32(readerRemakesReturned[43]);
                r9 = Convert.ToInt32(readerRemakesReturned[44]);
                r10 = Convert.ToInt32(readerRemakesReturned[45]);
                r11 = Convert.ToInt32(readerRemakesReturned[46]);
                r12 = Convert.ToInt32(readerRemakesReturned[47]);
            }

            connRemakesReturned.Close();

            //p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
            //p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
            //p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
            //p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);
            //p5 = Math.Round((Convert.ToDouble(l5) / (Convert.ToDouble(o5) + Convert.ToDouble(l5)) * 100), 2);
            //p6 = Math.Round((Convert.ToDouble(l6) / (Convert.ToDouble(o6) + Convert.ToDouble(l6)) * 100), 2);
            //p7 = Math.Round((Convert.ToDouble(l7) / (Convert.ToDouble(o7) + Convert.ToDouble(l7)) * 100), 2);
            //p8 = Math.Round((Convert.ToDouble(l8) / (Convert.ToDouble(o8) + Convert.ToDouble(l8)) * 100), 2);
            //p9 = Math.Round((Convert.ToDouble(l9) / (Convert.ToDouble(o9) + Convert.ToDouble(l9)) * 100), 2);
            //p10 = Math.Round((Convert.ToDouble(l10) / (Convert.ToDouble(o10) + Convert.ToDouble(l10)) * 100), 2);
            //p11 = Math.Round((Convert.ToDouble(l11) / (Convert.ToDouble(o11) + Convert.ToDouble(l11)) * 100), 2);
            //p12 = Math.Round((Convert.ToDouble(l12) / (Convert.ToDouble(o12) + Convert.ToDouble(l12)) * 100), 2);


            cartesianChart3.Series.Clear();
            cartesianChart3.AxisX.Clear();
            cartesianChart3.AxisY.Clear();

            cartesianChart3.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "Foc",
                    Values = new ChartValues<double> { o12, o11, o10, o9, o8, o7, o6, o5, o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true,

                },
                new StackedColumnSeries
                {
                    Title = "Non Foc",
                    Values = new ChartValues<double> { l12, l11, l10, l9, l8, l7, l6, l5, l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },


                //new LineSeries   //trendline isnt needed
                //{
                //    Title = "Trend",
                //    Values = new ChartValues<double> { p12, p11, p10, p9, p8, p7, p6, p5, p4, p3, p2, p1 },
                //    ScalesYAt = 1
                //},
            };






            cartesianChart3.AxisX.Add(new Axis
            {
                Title = "Date Range",
                Labels = new[] { n12 + " - £" + r12, n11 + " - £" + r11 , n10 + " - £" + r10, n9 + " - £" + r9 , n8 + " - £" + r8 , n7 + " - £" + r7, n6 + " - £" + r6, n5 + " - £" + r5, n4 + " - £" + r4 , n3 + " - £" + r3 , n2 + " - £" + r2 , n1 + " - £" + r1 },
                Separator = DefaultAxes.CleanSeparator

            });

            cartesianChart3.AxisY.Add(new Axis
            {
                Title = "Output",
                LabelFormatter = value => "£" + value + ""
            });


            //cartesianChart3.AxisY.Add(new Axis
            //{
            //    Foreground = System.Windows.Media.Brushes.Orange,
            //    Title = "Trend %",
            //    Position = AxisPosition.RightTop,
            //    LabelFormatter = value => value + " % Late",
            //    MinValue = 0,
            //    MaxValue = 100


            //});
            //////////////////////////////



        }
        private void drawStackedLatenessChartWeekly()
        {
            tempData.Clear();

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


                r1 = Convert.ToInt32(reader[12]);
                r2 = Convert.ToInt32(reader[13]);
                r3 = Convert.ToInt32(reader[14]);
                r4 = Convert.ToInt32(reader[15]);
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
                Labels = new[] { "Week Commencing " + ws4.ToShortDateString() + " - " + p4 + "%", "Week Commencing " + ws3.ToShortDateString() + " - " + p3 + "%", "Week Commencing " + ws2.ToShortDateString() + " - " + p2 + "%", "Week Commencing " + ws1.ToShortDateString() + " - " + p1 + "%" },
                Separator = DefaultAxes.CleanSeparator
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Output",
                LabelFormatter = value => value + " Doors"
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


            ///////REMAKES
            ///
            cartesianChart2.Series.Clear();
            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisY.Clear();

            cartesianChart2.Series = new SeriesCollection
            {

            new LineSeries
                {
                    Title = "Count",
                    Values = new ChartValues<double> {  r4, r3, r2, r1 },
                    DataLabels = true
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
                Title = "Remakes",
                LabelFormatter = value => value + " Remakes"
            });



            //remakes returned
            ///////////////

            SqlConnection connRemakeReturned = new SqlConnection(ConnectionStrings.ConnectionString);
            connRemakeReturned.Open();
            SqlCommand cmdRemakeReturned = new SqlCommand("usp_kpi_remakes_returned", connRemakeReturned);
            cmdRemakeReturned.CommandType = CommandType.StoredProcedure;

            cmdRemakeReturned.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Weekly";

            SqlDataReader readerRemakeReturned = cmdRemakeReturned.ExecuteReader();

            while (readerRemakeReturned.Read())
            {
                ws1 = Convert.ToDateTime(readerRemakeReturned[0]);
                ws2 = Convert.ToDateTime(readerRemakeReturned[3]);
                ws3 = Convert.ToDateTime(readerRemakeReturned[6]);
                ws4 = Convert.ToDateTime(readerRemakeReturned[9]);

                l1 = Convert.ToInt32(readerRemakeReturned[1]);  //Free of charge
                l2 = Convert.ToInt32(readerRemakeReturned[4]);
                l3 = Convert.ToInt32(readerRemakeReturned[7]);
                l4 = Convert.ToInt32(readerRemakeReturned[10]);

                o1 = Convert.ToInt32(readerRemakeReturned[2]); //Not Free of charge
                o2 = Convert.ToInt32(readerRemakeReturned[5]);
                o3 = Convert.ToInt32(readerRemakeReturned[8]);
                o4 = Convert.ToInt32(readerRemakeReturned[11]);

                r1 = Convert.ToInt32(readerRemakeReturned[12]); //total values
                r2 = Convert.ToInt32(readerRemakeReturned[13]);
                r3 = Convert.ToInt32(readerRemakeReturned[14]);
                r4 = Convert.ToInt32(readerRemakeReturned[15]);


            }


            connRemakeReturned.Close();



            cartesianChart3.Series.Clear();
            cartesianChart3.AxisX.Clear();
            cartesianChart3.AxisY.Clear();

            p1 = Math.Round((Convert.ToDouble(l1) / (Convert.ToDouble(o1) + Convert.ToDouble(l1)) * 100), 2);
            p2 = Math.Round((Convert.ToDouble(l2) / (Convert.ToDouble(o2) + Convert.ToDouble(l2)) * 100), 2);
            p3 = Math.Round((Convert.ToDouble(l3) / (Convert.ToDouble(o3) + Convert.ToDouble(l3)) * 100), 2);
            p4 = Math.Round((Convert.ToDouble(l4) / (Convert.ToDouble(o4) + Convert.ToDouble(l4)) * 100), 2);

            cartesianChart3.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "Free of Charge",
                    Values = new ChartValues<double> {o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true
                },
                new StackedColumnSeries
                {
                    Title = "Not Free of Charge",
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


            cartesianChart3.AxisX.Add(new Axis
            {
                Title = "Date Range",
                Labels = new[] { "Week Commencing " + ws4.ToShortDateString() + " - £" + r4 , "Week Commencing " + ws3.ToShortDateString() + " - £" + r3, "Week Commencing " + ws2.ToShortDateString() + " - £" + r2 , "Week Commencing " + ws1.ToShortDateString() + " - £" + r1},
                Separator = DefaultAxes.CleanSeparator
            });

            cartesianChart3.AxisY.Add(new Axis
            {
                Title = "Output",
                LabelFormatter = value => "£" + value 
            });



            ///////////////


        }


        private void drawStackedLatenessChartQuater()
        {
            tempData.Clear();
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
            SqlCommand cmd = new SqlCommand("usp_kpi_engineering_manager", conn);
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


                r1 = Convert.ToInt32(reader[12]);
                r2 = Convert.ToInt32(reader[13]);
                r3 = Convert.ToInt32(reader[14]);
                r4 = Convert.ToInt32(reader[15]);
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
                Labels = new[] { "Q" + n4 + " - " + p4 + "%", "Q" + n3 + " - " + p3 + "%", "Q" + n2 + " - " + p2 + "%", "Q" + n1 + " - " + p1 + "%" },
                Separator = DefaultAxes.CleanSeparator
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Output",
                LabelFormatter = value => value + " Doors"
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



            ///////REMAKES
            ///
            cartesianChart2.Series.Clear();
            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisY.Clear();

            cartesianChart2.Series = new SeriesCollection
            {

            new LineSeries
                {
                    Title = "Count",
                    Values = new ChartValues<double> {  r4, r3, r2, r1 },
                    DataLabels = true
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
                Title = "Remakes",
                LabelFormatter = value => value + " Remakes"
            });


            //////////////////
            //remake returns
            SqlConnection connRemakeReturned = new SqlConnection(ConnectionStrings.ConnectionString);
            connRemakeReturned.Open();
            SqlCommand cmdRemakeReturned = new SqlCommand("usp_kpi_remakes_returned", connRemakeReturned);
            cmdRemakeReturned.CommandType = CommandType.StoredProcedure;
            cmdRemakeReturned.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Quaterly";

            SqlDataReader readerRemakeReturned = cmdRemakeReturned.ExecuteReader();

            while (readerRemakeReturned.Read())
            {
                n1 = readerRemakeReturned[0].ToString();
                n2 = readerRemakeReturned[3].ToString();
                n3 = readerRemakeReturned[6].ToString();
                n4 = readerRemakeReturned[9].ToString();

                l1 = Convert.ToInt32(readerRemakeReturned[1]);
                l2 = Convert.ToInt32(readerRemakeReturned[4]);
                l3 = Convert.ToInt32(readerRemakeReturned[7]);
                l4 = Convert.ToInt32(readerRemakeReturned[10]);

                o1 = Convert.ToInt32(readerRemakeReturned[2]);
                o2 = Convert.ToInt32(readerRemakeReturned[5]);
                o3 = Convert.ToInt32(readerRemakeReturned[8]);
                o4 = Convert.ToInt32(readerRemakeReturned[11]);


                r1 = Convert.ToInt32(readerRemakeReturned[12]);
                r2 = Convert.ToInt32(readerRemakeReturned[13]);
                r3 = Convert.ToInt32(readerRemakeReturned[14]);
                r4 = Convert.ToInt32(readerRemakeReturned[15]);
            }


            connRemakeReturned.Close();

            cartesianChart3.Series.Clear();
            cartesianChart3.AxisX.Clear();
            cartesianChart3.AxisY.Clear();






            cartesianChart3.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "Foc",
                    Values = new ChartValues<double> {o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true
                },
                new StackedColumnSeries
                {
                    Title = "Non Foc",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                }
                ,


            };



            cartesianChart3.AxisX.Add(new Axis
            {
                Title = "Date Range",
                Labels = new[] { "Q" + n4 + " - £" + r4, "Q" + n3 + " - £" + r3 , "Q" + n2 + " - £" + r2 , "Q" + n1 + " - £" + r1  },
                Separator = DefaultAxes.CleanSeparator
            });

            cartesianChart3.AxisY.Add(new Axis
            {
                Title = "Output",
                LabelFormatter = value => "£" + value 
            });


            //////////////////



        }





        private void drawStackedLatenessChartYear()
        {
            tempData.Clear();

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
            SqlCommand cmd = new SqlCommand("usp_kpi_engineering_manager", conn);
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

                r1 = Convert.ToInt32(reader[12]);
                r2 = Convert.ToInt32(reader[13]);
                r3 = Convert.ToInt32(reader[14]);
                r4 = Convert.ToInt32(reader[15]);
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
                Labels = new[] { n4 + " - " + p4 + "%", n3 + " - " + p3 + "%", n2 + " - " + p2 + "%", n1 + " - " + p1 + "%" },
                Separator = DefaultAxes.CleanSeparator
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Output",
                LabelFormatter = value => value + " Doors"
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





            ///////REMAKES
            ///
            cartesianChart2.Series.Clear();
            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisY.Clear();

            cartesianChart2.Series = new SeriesCollection
            {

            new LineSeries
                {
                    Title = "Count",
                    Values = new ChartValues<double> {  r4, r3, r2, r1 },
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
                Title = "Remakes",
                LabelFormatter = value => value + " Remakes"
            });



            //////////////////////
            //remakes returned
            SqlConnection connRemakesReturned = new SqlConnection(ConnectionStrings.ConnectionString);
            connRemakesReturned.Open();
            SqlCommand cmdRemakesReturned = new SqlCommand("usp_kpi_remakes_returned", connRemakesReturned);
            cmdRemakesReturned.CommandType = CommandType.StoredProcedure;

            cmdRemakesReturned.Parameters.Add("@rangeType", SqlDbType.NVarChar).Value = "Yearly";

            SqlDataReader readerRemakesReturned = cmdRemakesReturned.ExecuteReader();

            while (readerRemakesReturned.Read())
            {
                n1 = readerRemakesReturned[0].ToString();
                n2 = readerRemakesReturned[3].ToString();
                n3 = readerRemakesReturned[6].ToString();
                n4 = readerRemakesReturned[9].ToString();

                l1 = Convert.ToInt32(readerRemakesReturned[1]);
                l2 = Convert.ToInt32(readerRemakesReturned[4]);
                l3 = Convert.ToInt32(readerRemakesReturned[7]);
                l4 = Convert.ToInt32(readerRemakesReturned[10]);

                o1 = Convert.ToInt32(readerRemakesReturned[2]);
                o2 = Convert.ToInt32(readerRemakesReturned[5]);
                o3 = Convert.ToInt32(readerRemakesReturned[8]);
                o4 = Convert.ToInt32(readerRemakesReturned[11]);

                r1 = Convert.ToInt32(readerRemakesReturned[12]);
                r2 = Convert.ToInt32(readerRemakesReturned[13]);
                r3 = Convert.ToInt32(readerRemakesReturned[14]);
                r4 = Convert.ToInt32(readerRemakesReturned[15]);
            }


            connRemakesReturned.Close();



            cartesianChart3.Series.Clear();
            cartesianChart3.AxisX.Clear();
            cartesianChart3.AxisY.Clear();



            cartesianChart3.Series = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "Foc",
                    Values = new ChartValues<double> {o4, o3, o2, o1},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true
                },
                new StackedColumnSeries
                {
                    Title = "Non Foc",
                    Values = new ChartValues<double> {l4, l3, l2, l1},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },


            };





            cartesianChart3.AxisX.Add(new Axis
            {
                Title = "Date Range",
                Labels = new[] { n4 + " - £" + r4, n3 + " - £" + r3, n2 + " - £" + r2, n1 + " - £" + r1 },
                Separator = DefaultAxes.CleanSeparator
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Output",
                LabelFormatter = value => "£" + value 
            });

            //////////////////////

        }

        private void RdoWeekly_Click(object sender, EventArgs e)
        {
            drawStackedLatenessChartWeekly();
            filldatagrid();
        }

        private void RdoMonthly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RdoYearly_Click(object sender, EventArgs e)
        {
            drawStackedLatenessChartYear();
            filldatagrid();
        }

        private void RdoQuaterly_Click(object sender, EventArgs e)
        {
            drawStackedLatenessChartQuater();
            filldatagrid();
        }
        private void rdoMonthly_Click(object sender, EventArgs e)
        {
            drawStackedLatenessChartMonthly();
            filldatagrid();
        }

        private void BtnPrintLateness_Click(object sender, EventArgs e)
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

        private void RdoWeekly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cartesianChart2_DataClick(object sender, ChartPoint p)
        {
            var asPixels = cartesianChart2.Base.ConvertToPixels(p.AsPoint());
            //MessageBox.Show("[EVENT] You clicked ([EVENT] You clicked (" + p.X + ", " + p.Y + ") in pixels (" +
            //            asPixels.X + ", " + asPixels.Y + ")");
            //MessageBox.Show(Convert.ToInt32(p.X).ToString());
            //   MessageBox.Show(tempData[Convert.ToInt32(p.X)].ToString());

            //vvvv use this to get the current datatype tom uses for the chart 
            tempData[Convert.ToInt32(p.X)].ToString();

            //because the data types are so inconsistent we need to check which type it is
            DateTime dateStart = DateTime.Today;
            DateTime dateEnd = DateTime.Today;
            if (rdoWeekly.Checked == true) //weekly is the only nice format 
            {
                dateStart = Convert.ToDateTime(tempData[Convert.ToInt32(p.X)].ToString());
                dateEnd = dateStart.AddDays(7);
            }
            else if (rdoMonthly.Checked == true)
            {
                int monthsToRemove = tempData.IndexOf(tempData[Convert.ToInt32(p.X)].ToString()) + 1; //add one because list stars at 0
                monthsToRemove = monthsToRemove - tempData.Count(); //remove the current pos from the  list total to get the amount of jumps back we take
                dateStart = Convert.ToDateTime(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/01");
                dateStart = dateStart.AddMonths(monthsToRemove);
                dateEnd = dateStart.AddMonths(1);
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
                dateEnd = dateEnd.AddMonths(3);
            }
            else if (rdoYearly.Checked == true)
            {
                //this one should be fairly easy as the output is the year
                dateStart = Convert.ToDateTime(tempData[Convert.ToInt32(p.X)].ToString() + "/01/01");
                dateEnd = dateStart.AddYears(1);
            }

            //should have the start and end dates for the new form now

            frmRemakes frm = new frmRemakes(dateStart, dateEnd, 0, "", 0, "");
            frm.ShowDialog();
        }

        private void rdoYearly_CheckedChanged(object sender, EventArgs e)
        {
        }


        private void remakeDeptChart(string department)
        {
            //front of list and end 
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
            string sql = "select coalesce(max(u.forename),'') + ' ' + coalesce(max(u.surname),'') as [Person Responsibile] ,COUNT(d1.department_name) as [Number of Remakes],sum(remake.cost) as [Total Cost]  from dbo.remake " +
                                "left join dbo.door on dbo.door.id = dbo.remake.door_id left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref left join[user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                                "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                                "where[date] >= '" + startDate.ToString("yyyy-MM-dd") + "' AND[date] < '" + endDate.ToString("yyyyMMdd") + "'  AND d1.department_name = '" + department + "' group by dbo.remake.persons_responsible order by COUNT(dbo.remake.persons_responsible) desc,max(u.forename) asc";

            department = department + " Remakes From " + startDate.ToString("yyyy-MM-dd") + " to " + endDate.ToString("yyyy-MM-dd");

            frmRemakeDepartment frm = new frmRemakeDepartment(sql,department);
            frm.Show();
        }
        private void filldatagrid()
        {
            //front of list and end 
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
            string sql = "select d1.department_name as [Department] ,COUNT(d1.department_name) as [Number of Remakes],'£' + Cast(sum(remake.cost) as nvarchar(max)) as [Total Cost]  from dbo.remake " +
                "left join dbo.door on dbo.door.id = dbo.remake.door_id left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref left join[user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                "where[date] >= '" + startDate.ToString("yyyy-MM-dd") + "' AND[date] < '" + endDate.ToString("yyyyMMdd") + "' group by d1.department_name order by COUNT(d1.department_name) desc";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // generate the data you want to insert
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
                    conn.Close();
                }
            }

            DataGridViewButtonColumn chartButton = new DataGridViewButtonColumn();
            chartButton.Name = " ";
            chartButton.Text = "Chart";
            chartButton.UseColumnTextForButtonValue = true;
            if (dgvDepartment.Columns.Contains(" ") == true)
            {
                dgvDepartment.Columns.Remove(" ");
            }
            int columnIndex = 3;
            if (dgvDepartment.Columns["chart_column"] == null)
            {
                dgvDepartment.Columns.Insert(columnIndex, chartButton);
            }

            dgvDepartment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDepartment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDepartment.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDepartment.ClearSelection();


            //fill staff
            sql = "select max(u.forename) + ' ' + max(u.surname) as [Person Responsibile] ,COUNT(d1.department_name) as [Number of Remakes],'£' + Cast(sum(remake.cost) as nvarchar(max)) as [Total Cost]  from dbo.remake " +
    "left join dbo.door on dbo.door.id = dbo.remake.door_id left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref left join[user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
    "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
    "where[date] >= '" + startDate.ToString("yyyy-MM-dd") + "' AND[date] < '" + endDate.ToString("yyyyMMdd") + "' group by dbo.remake.persons_responsible order by COUNT(dbo.remake.persons_responsible) desc,max(u.forename) asc";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // generate the data you want to insert
                    //DataRow toInsert = dt.NewRow();
                    //// insert in the desired place
                    //dt.Rows.InsertAt(toInsert, dt.Rows.Count);
                    //dt.Rows[dt.Rows.Count - 1][0] = "Totals:";
                    //double totalCost = 0;
                    //int totalRemake = 0;
                    //for (int i = 0; i < dt.Rows.Count - 1; i++)
                    //{
                    //    string temp = dt.Rows[i][2].ToString().Substring(1);
                    //    totalRemake = totalRemake + Convert.ToInt32(dt.Rows[i][1]);
                    //    totalCost = totalCost + Convert.ToDouble(temp);
                    //}

                    //dt.Rows[dt.Rows.Count - 1][1] = totalRemake;
                    //dt.Rows[dt.Rows.Count - 1][2] = "£" + totalCost.ToString();
                    dgvStaff.DataSource = dt;
                    conn.Close();
                }
            }

            dgvStaff.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStaff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStaff.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvStaff.ClearSelection();




        }

        private void frmEngineeringManagement_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dgvDepartment.ClearSelection();
            dgvStaff.ClearSelection();
        }

        private void tabEngineering_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEngineering.SelectedIndex == 1)
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int department_index = 0;
            department_index = dgvDepartment.Columns["Department"].Index;
            int button_index = 0;
            button_index = dgvDepartment.Columns[" "].Index;

            if (e.RowIndex == dgvDepartment.Rows.Count - 1)
                return;
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex == dgvDepartment.Rows.Count - 1)
                return;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex < dgvDepartment.Rows.Count - 1)
            {
                remakeDeptChart(dgvDepartment.Rows[e.RowIndex].Cells[department_index].Value.ToString());
            }
            else
            {


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

                frmRemakes frm = new frmRemakes(startDate, endDate, -1, dgvDepartment.Rows[e.RowIndex].Cells[department_index].Value.ToString(), 0, "");
                frm.ShowDialog();
            }
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

            frmRemakes frm = new frmRemakes(startDate, endDate, 0, "", -1, dgvStaff.Rows[e.RowIndex].Cells[0].Value.ToString());
            frm.ShowDialog();
        }


    }
}
