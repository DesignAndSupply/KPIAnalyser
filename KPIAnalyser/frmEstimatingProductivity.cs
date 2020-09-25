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

namespace KPIAnalyser
{
    public partial class frmEstimatingProductivity : Form
    {
        public frmEstimatingProductivity()
        {
            InitializeComponent();


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
                ToValue = 90,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            dailyItemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 90,
                ToValue = 150,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            dailyItemsGuage.FromValue = 0;
            dailyItemsGuage.ToValue = 150;
            dailyItemsGuage.TicksForeground = Brushes.White;
            dailyItemsGuage.Base.Foreground = Brushes.White;
            dailyItemsGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            dailyItemsGuage.Base.FontSize = 12;
            dailyItemsGuage.SectionsInnerRadius = 0.5;
            /////
            ///

            //FORMAT problems  guage
            problemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            problemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 50,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            problemsGuage.FromValue = 0;
            problemsGuage.ToValue = 50;
            problemsGuage.TicksForeground = Brushes.White;
            problemsGuage.Base.Foreground = Brushes.White;
            problemsGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            problemsGuage.Base.FontSize = 12;
            problemsGuage.SectionsInnerRadius = 0.5;
            /////
            ///




        }

        private void FrmEstimatingProductivity_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);

        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            drawTopCustomersByItems();
            drawTopCustomersByvalue();
            absentHolidaysLate();
            averageDailyItems();
            countEstimatorIssues();
        }

        private void drawTopCustomersByvalue()
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

            double v1 = 0;
            double v2 = 0;
            double v3 = 0;
            double v4 = 0;
            double v5 = 0;
            double v6 = 0;
            double v7 = 0;
            double v8 = 0;
            double v9 = 0;
            double v10 = 0;

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
            SqlCommand cmd = new SqlCommand("usp_kpi_top_customers_quoted_by_estimator", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;
            cmd.Parameters.Add("@itemOrValue", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@includeRevs", SqlDbType.Int).Value = includeRevisions;
            SqlDataReader reader = cmd.ExecuteReader();

            int loopcount = 1;
            while (reader.Read())
            {
                switch (loopcount)
                {
                    case 1:
                        c1 = reader.GetString(0);
                        v1 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 2:
                        c2 = reader.GetString(0);
                        v2 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 3:
                        c3 = reader.GetString(0);
                        v3 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 4:
                        c4 = reader.GetString(0);
                        v4 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 5:
                        c5 = reader.GetString(0);
                        v5 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 6:
                        c6 = reader.GetString(0);
                        v6 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 7:
                        c7 = reader.GetString(0);
                        v7 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 8:
                        c8 = reader.GetString(0);
                        v8 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 9:
                        c9 = reader.GetString(0);
                        v9 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 10:
                        c10 = reader.GetString(0);
                        v10 = reader.GetDouble(2);

                        loopcount += 1;
                        break;

                    default:
                        break;
                }
            }

            //VALUES PIE CHART

            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart2.Series = new SeriesCollection
                {

                    new PieSeries
                        {
                            Title = c1,
                            Values = new ChartValues<double> { v1 },
                            PushOut = 15,
                            DataLabels = true,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c2,
                            Values = new ChartValues<double> { v2 },

                            DataLabels = true,
                            LabelPoint = labelPoint
                        },

                    new PieSeries
                        {
                            Title = c3,
                            Values = new ChartValues<double> { v3 },

                            DataLabels = true,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c4,
                            Values = new ChartValues<double> { v4 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c5,
                            Values = new ChartValues<double> { v5 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c6,
                            Values = new ChartValues<double> { v6 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c7,
                            Values = new ChartValues<double> { v7 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c8,
                            Values = new ChartValues<double> { v8 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },

                    new PieSeries
                        {
                            Title = c9,
                            Values = new ChartValues<double> { v9 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c10,
                            Values = new ChartValues<double> { v10 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        }



                };



            pieChart2.LegendLocation = LegendLocation.Bottom;






            conn.Close();


        }
        private void drawTopCustomersByItems()
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



            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            int i4 = 0;
            int i5 = 0;
            int i6 = 0;
            int i7 = 0;
            int i8 = 0;
            int i9 = 0;
            int i10 = 0;


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
            SqlCommand cmd = new SqlCommand("usp_kpi_top_customers_quoted_by_estimator", conn);
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
                        c1 = reader.GetString(0);
                        i1 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 2:
                        c2 = reader.GetString(0);
                        i2 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 3:
                        c3 = reader.GetString(0);
                        i3 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 4:
                        c4 = reader.GetString(0);
                        i4 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 5:
                        c5 = reader.GetString(0);
                        i5 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 6:
                        c6 = reader.GetString(0);
                        i6 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 7:
                        c7 = reader.GetString(0);
                        i7 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 8:
                        c8 = reader.GetString(0);
                        i8 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 9:
                        c9 = reader.GetString(0);
                        i9 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 10:
                        c10 = reader.GetString(0);
                        i10 = reader.GetInt32(1);

                        loopcount += 1;
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
        }



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
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            int averageDailyItems = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_average_daily_output", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    averageDailyItems = reader.GetInt32(0);
                }
                catch
                {
                    averageDailyItems = 0;
                }

            }

            dailyItemsGuage.Value = averageDailyItems;
            lblDailyAverage.Text = "Daily Average Items: " + averageDailyItems;

            conn.Close();

        }

        private void countEstimatorIssues()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            int estimatorIssues = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_estimator_problems", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    estimatorIssues = reader.GetInt32(0);
                }
                catch
                {
                    estimatorIssues = 0;
                }

            }

            problemsGuage.Value = estimatorIssues;

            lblEstimatorissues.Text = "Issues Logged: " + estimatorIssues;
            conn.Close();
        }

        private void RunComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstimatorComparison frmec = new frmEstimatorComparison();
            frmec.Show();
        }

        private void PrintScreenToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void BtnViewQuotes_Click(object sender, EventArgs e)
        {

            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;

            frmViewQuotations frmvq = new frmViewQuotations(startdate,enddate,staffName);
            frmvq.Show();
        }
    }
}

