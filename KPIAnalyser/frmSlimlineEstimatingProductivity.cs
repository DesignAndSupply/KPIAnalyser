using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using System.Data.SqlClient;
using Brushes = System.Windows.Media.Brushes;
using System.Windows.Media;
using System.Drawing.Printing;
using Outlook = Microsoft.Office.Interop.Outlook;
using Brush = System.Windows.Media.Brush;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Documents;
using System.Windows;

namespace KPIAnalyser
{
    public partial class frmSlimlineEstimatingProductivity : Form
    {
        public string print_file { get; set; }
        public frmSlimlineEstimatingProductivity()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //add to the combobox
            string sql = "SELECT forename + ' ' + surname FROM [user_info].dbo.[user] WHERE grouping = 25 and id <> 7 and id <> 24 ";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbStaffMember.Items.Add(reader[0].ToString());
                    }
                    conn.Close();
                }
            }
            //



            //FORMAT chase  guage
            chaseGague.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            chaseGague.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 20,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            chaseGague.FromValue = 0;
            chaseGague.ToValue = 20;
            chaseGague.TicksForeground = Brushes.White;
            chaseGague.Base.Foreground = Brushes.White;
            chaseGague.Base.FontWeight = System.Windows.FontWeights.Bold;
            chaseGague.Base.FontSize = 12;
            chaseGague.SectionsInnerRadius = 0.5;
            /////
            ///


            cmbStaffMember.SelectedIndex = 0;
            //FORMAT ABSENT GUAGE
            absentGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            absentGuage.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 20,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            absentGuage.FromValue = 0;
            absentGuage.ToValue = 20;
            absentGuage.TicksForeground = Brushes.White;
            absentGuage.Base.Foreground = Brushes.White;
            absentGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            absentGuage.Base.FontSize = 16;
            absentGuage.SectionsInnerRadius = 0.5;
            /////
            ///

            //FORMAT ANNUALLEAVE GUAGE
            annualLeaveGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 23,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            annualLeaveGuage.Sections.Add(new AngularSection
            {
                FromValue = 23,
                ToValue = 40,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            annualLeaveGuage.FromValue = 0;
            annualLeaveGuage.ToValue = 40;
            annualLeaveGuage.TicksForeground = Brushes.White;
            annualLeaveGuage.Base.Foreground = Brushes.White;
            annualLeaveGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            annualLeaveGuage.Base.FontSize = 16;
            annualLeaveGuage.SectionsInnerRadius = 0.5;
            /////
            ///

            //FORMAT LATE GUAGE

            lateGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 50,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            lateGuage.FromValue = 0;
            lateGuage.ToValue = 50;
            lateGuage.TicksForeground = Brushes.White;
            lateGuage.Base.Foreground = Brushes.White;
            lateGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            lateGuage.Base.FontSize = 16;
            lateGuage.SectionsInnerRadius = 0.5;
            /////
            ///


            //FORMAT unpaid GUAGE
            unpaidGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            unpaidGuage.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 20,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            unpaidGuage.FromValue = 0;
            unpaidGuage.ToValue = 20;
            unpaidGuage.TicksForeground = Brushes.White;
            unpaidGuage.Base.Foreground = Brushes.White;
            unpaidGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            unpaidGuage.Base.FontSize = 16;
            unpaidGuage.SectionsInnerRadius = 0.5;
            /////
            ///

            //FORMAT daily items guage
            dailyItemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 100000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            dailyItemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 0, //moves orange  
                ToValue = 75000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            dailyItemsGuage.FromValue = 0;
            dailyItemsGuage.ToValue = 100000;
            dailyItemsGuage.TicksForeground = Brushes.White;
            dailyItemsGuage.Base.Foreground = Brushes.White;
            dailyItemsGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            dailyItemsGuage.Base.FontSize = 12;
            dailyItemsGuage.SectionsInnerRadius = 0.5;
            /////
            ///


        }

        private void drawTopCustomerByItems()
        {

            string c1 = "";
            string c2 = "";
            string c3 = "";
            string c4 = "";
            string c5 = "";
            string c6 = "";
            string c7 = "";
            string c8 = "";
            string c9 = "";
            string c10 = "";
            double i1 = 0;
            double i2 = 0;
            double i3 = 0;
            double i4 = 0;
            double i5 = 0;
            double i6 = 0;
            double i7 = 0;
            double i8 = 0;
            double i9 = 0;
            double i10 = 0;

            int includeRevisions = 0;

            if (chkIncludeRevisions.Checked == true)
            {
                includeRevisions = 1;
            }

            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_top_customers_quoted_by_estimator_slimline", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;
            cmd.Parameters.Add("@itemOrValue", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@includeRevs", SqlDbType.Int).Value = includeRevisions;
            SqlDataReader reader = cmd.ExecuteReader();

            int loopcount = 1;
            while (reader.Read())
            {

                switch (loopcount)
                {
                    case 1:
                        try
                        {
                            c1 = reader.GetString(0);
                            i1 = reader.GetDouble(1);

                            loopcount += 1;
                        }
                        catch
                        {
                            c1 = "";
                            i1 = 0;
                            loopcount += 1;
                        }
                        break;
                    case 2:
                        try
                        {
                            c2 = reader.GetString(0);
                            i2 = reader.GetDouble(1);

                            loopcount += 1;
                        }
                        catch
                        {
                            c2 = "";
                            i2 = 0;
                            loopcount += 1;
                        }
                        break;
                    case 3:
                        try
                        {
                            c3 = reader.GetString(0);
                            i3 = reader.GetDouble(1);

                            loopcount += 1;
                        }
                        catch
                        {
                            c3 = "";
                            i3 = 0;
                            loopcount += 1;
                        }
                        break;
                    case 4:
                        try
                        {
                            c4 = reader.GetString(0);
                            i4 = reader.GetDouble(1);

                            loopcount += 1;
                        }
                        catch
                        {
                            c4 = "";
                            i4 = 0;
                            loopcount += 1;
                        }
                        break;
                    case 5:
                        try
                        {
                            c5 = reader.GetString(0);
                            i5 = reader.GetDouble(1);

                            loopcount += 1;
                        }
                        catch
                        {
                            c5 = "";
                            i5 = 0;
                            loopcount += 1;
                        }
                        break;
                    case 6:
                        try
                        {
                            c6 = reader.GetString(0);
                            i6 = reader.GetDouble(1);
                            loopcount += 1;
                        }
                        catch
                        {
                            c6 = "";
                            i6 = 0;
                            loopcount += 1;
                        }
                        break;
                    case 7:
                        try
                        {
                            c7 = reader.GetString(0);
                            i7 = reader.GetDouble(1);

                            loopcount += 1;
                        }
                        catch
                        {
                            c7 = "";
                            i7 = 0;
                            loopcount += 1;
                        }
                        break;
                    case 8:
                        try
                        {
                            c8 = reader.GetString(0);
                            i8 = reader.GetDouble(1);

                            loopcount += 1;
                        }
                        catch
                        {
                            c8 = "";
                            i8 = 0;
                            loopcount += 1;
                        }
                        break;
                    case 9:
                        try
                        {
                            c9 = reader.GetString(0);
                            i9 = reader.GetDouble(1);

                            loopcount += 1;
                        }
                        catch
                        {
                            c9 = "";
                            i9 = 0;
                            loopcount += 1;
                        }
                        break;
                    case 10:
                        try
                        {
                            c10 = reader.GetString(0);
                            i10 = reader.GetDouble(1);

                            loopcount += 1;
                        }
                        catch
                        {
                            c10 = "";
                            i10 = 0;
                            loopcount += 1;
                        }
                        break;

                    default:
                        break;
                }
            }
            //ITEMS PIECHART


            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
                {

                    new PieSeries
                        {
                            Title = c1,
                            Values = new ChartValues<double> { i1 },
                            PushOut = 15,
                            DataLabels = true,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c2,
                            Values = new ChartValues<double> { i2 },

                            DataLabels = true,
                            LabelPoint = labelPoint
                        },

                    new PieSeries
                        {
                            Title = c3,
                            Values = new ChartValues<double> { i3 },

                            DataLabels = true,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c4,
                            Values = new ChartValues<double> { i4 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c5,
                            Values = new ChartValues<double> { i5 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c6,
                            Values = new ChartValues<double> { i6 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c7,
                            Values = new ChartValues<double> { i7 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c8,
                            Values = new ChartValues<double> { i8 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },

                    new PieSeries
                        {
                            Title = c9,
                            Values = new ChartValues<double> { i9 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c10,
                            Values = new ChartValues<double> { i10 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        }



                };



            pieChart1.LegendLocation = LegendLocation.Bottom;




            conn.Close();

        }//end of void

        private void absentHolidaysLate()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            int lateCount = 0;
            double annualLeavecount = 0;
            int absentCount = 0;
            int absentTakenHolidayCount = 0;
            int unpaidCount = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_absent_late_estimating", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                absentCount = reader.GetInt32(0);
                annualLeavecount = reader.GetDouble(1);
                absentTakenHolidayCount = reader.GetInt32(2);
                lateCount = reader.GetInt32(3);
                unpaidCount = reader.GetInt32(4);
            }

            conn.Close();

            ///ABSENT GUAGE
            /////////////////////////////////////////
            ///

            absentGuage.Value = absentCount;
            absentDays.Text = "Absent Days: " + absentCount.ToString();
            annualLeaveGuage.Value = annualLeavecount;
            annualLeave.Text = "Annual Leave: " + annualLeavecount.ToString();
            lateGuage.Value = lateCount;
            lateDays.Text = "Late Days: " + lateCount.ToString();
            unpaidGuage.Value = unpaidCount;
            unpaidLeave.Text = "Unpaid Days: " + unpaidCount.ToString();



            //////////////////////////////////////



        }

        private void averageDailyItems()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.AddDays(1).ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;
            int includeRevisions = 0;

            double averageDailyItems = 0;

            if (chkIncludeRevisions.Checked == true)
            {
                includeRevisions = -1;
            }


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_average_daily_output_slimline", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;
            cmd.Parameters.Add("@increv", SqlDbType.Int).Value = includeRevisions;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                try //this is 
                {
                    averageDailyItems = reader.GetDouble(0);
                }
                catch
                {
                    averageDailyItems = 0;
                }

            }

            dailyItemsGuage.Value = averageDailyItems;
            lblDailyAverage.Text = "Daily Average Price: " + averageDailyItems;

            conn.Close();

        }

        private void drawDailyValue()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();

            //sales card
            string sql = "SELECT round(coalesce(sum(v.line_total),0),2) from dbo.door d left join dbo.view_door_value v on v.id = d.id left join dbo.door_type dt on dt.id = d.door_type_id " +
                "where date_completion >= '" + startdate + "' AND date_completion <= '" + enddate + "' AND(status_id = 1 or status_id = 2 or status_id = 3) and (dt.slimline_y_n = -1)";
            using (SqlCommand salesCmd = new SqlCommand(sql, conn))
            {
                var value = salesCmd.ExecuteScalar().ToString();
                if (value != null)
                {
                    string data = "";
                    double temp2 = 0;
                    data = value;
                    temp2 = 0;
                    temp2 = Convert.ToDouble(data);
                    data = temp2.ToString("#,##0.00");

                    //ammend stuff like colour and having £-100
                    data = "£" + data;
                    //first up is the - number

                    if (data.Contains("-"))
                    {
                        data = data.Replace("-", "");
                        data = data.Insert(0, "-");
                    }
                    lblSales.Text = data;

                }
                else
                    lblSales.Text = "£0";
            }
            /////////////////////////////////////////////
            SqlCommand cmd = new SqlCommand("usp_kpi_estimators_daily_slimline", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;

            SqlDataReader reader = cmd.ExecuteReader();

            List<DateTime> datelist = new List<DateTime>();
            List<double> valueList = new List<double>();
            List<string> temp = new List<string>();



            while (reader.Read())
            {
                //datelist.Add(reader.GetDateTime(1));
                temp.Add(reader.GetDateTime(1).ToShortDateString());
                valueList.Add(reader.GetDouble(0));
            }


            //string[] datearray = datelist.ToArray();
            double[] itemarray = valueList.ToArray();

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Value",
                    FontSize = 10,
                    Foreground = Brushes.Black,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,

                    Values = new ChartValues<double>(valueList)
                }

            };


            //string.Join(",", datearray)#
            //string[] temp;
            //List<string> strList = datearray.ToList;
            //IList<string> testValues = datearray;

            //IList<string> targetList = new List<string>(testValues.Cast<string>());



            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Dates",
                FontSize = 10,
                Foreground = Brushes.Black,
                Labels = temp
            });

            //

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Value",
                FontSize = 16,

            });


            //chases
        }

        private void drawDailychase()
        {

            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("usp_kpi_daily_chase_slimline", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;

            SqlDataReader reader = cmd.ExecuteReader();

            List<DateTime> datelist = new List<DateTime>();
            List<int> valueList = new List<int>();
            List<string> temp = new List<string>();
            List<int> correspondenceList = new List<int>();



            while (reader.Read())
            {
                //datelist.Add(reader.GetDateTime(1));
                temp.Add(reader.GetDateTime(1).ToShortDateString());
                valueList.Add(reader.GetInt32(0));
                correspondenceList.Add(reader.GetInt32(2));
            }


            //string[] datearray = datelist.ToArray();
            int[] itemarray = valueList.ToArray();
            int[] correspondencearray = correspondenceList.ToArray();

            cartesianChart2.AxisY.Clear();
            cartesianChart2.AxisX.Clear();

            cartesianChart2.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Value",
                    FontSize = 10,
                    Foreground = Brushes.Black,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.LightSkyBlue,

                    Values = new ChartValues<int>(valueList)
                },
                 new ColumnSeries
                {
                    Title = "Correspondence",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.PaleVioletRed,

                    Values = new ChartValues<int>(correspondencearray)
                }

            };


            //string.Join(",", datearray)#
            //string[] temp;
            //List<string> strList = datearray.ToList;
            //IList<string> testValues = datearray;

            //IList<string> targetList = new List<string>(testValues.Cast<string>());



            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "Dates",
                FontSize = 10,
                Foreground = Brushes.Black,
                Labels = temp
            }); ;

            //

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Value",
                FontSize = 16,

            });

            conn.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            drawTopCustomerByItems();
            absentHolidaysLate();
            averageDailyItems();
            drawDailyValue();
            drawDailychase();

            averageChase();
        }

        private void averageChase()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            double estimatorIssues = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_estimator_chase_slimline", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    estimatorIssues = reader.GetDouble(0);
                }
                catch
                {
                    estimatorIssues = 0;
                }

            }

            chaseGague.Value = estimatorIssues;

            lblChase.Text = "Average Chases: " + estimatorIssues;
            conn.Close();
        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnViewQuotes_Click(object sender, EventArgs e)
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;

            frmViewQuotationSlimline frmvq = new frmViewQuotationSlimline(startdate, enddate, staffName);
            frmvq.Show();
        }

        private void runComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstimatorComparisonSlimline frmec = new frmEstimatorComparisonSlimline();
            frmec.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            print_file = @"C:\temp\slimline_" + DateTime.Now.ToString("hh_mm_ss") + ".jpg";


            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), bit.Size);

                bit.Save(print_file);

                printImage("A4");
            }
            catch
            {

            }
        }

        private void printImage(string paperType)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    System.Drawing.Image i = System.Drawing.Image.FromFile(print_file);
                    System.Drawing.Point p = new System.Drawing.Point(100, 100);
                    args.Graphics.DrawImage(i, args.MarginBounds);

                };

                pd.DefaultPageSettings.Landscape = true;

                PrinterSettings ps = new PrinterSettings();
                IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
                PaperSize type = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4);
                if (paperType == "A3")
                    type = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A3);
                else
                    type = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4); // setting paper size to A4 size
                pd.DefaultPageSettings.PaperSize = type;

                Margins margins = new Margins(50, 50, 50, 50);
                pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            {

            }
        }

        private void btnA3_Click(object sender, EventArgs e)
        {
            print_file = @"C:\temp\slimline_" + DateTime.Now.ToString("hh_mm_ss") + ".jpg";


            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), bit.Size);

                bit.Save(print_file);

                printImage("A3");
            }
            catch
            {

            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            
            string imageSrc = @"C:\Temp\slimline_estimating.jpg";

            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), bit.Size);

                bit.Save(imageSrc);


            }
            catch
            {

            }


            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "";
            mailItem.To = "";
             // Change path as needed

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
    }
}
