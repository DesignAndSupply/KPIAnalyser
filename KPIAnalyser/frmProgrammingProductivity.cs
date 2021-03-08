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
namespace KPIAnalyser
{
    public partial class frmProgrammingProductivity : Form
    {
        public frmProgrammingProductivity()
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
                ToValue = 8,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            dailyItemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 8,
                ToValue = 20,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            dailyItemsGuage.FromValue = 0;
            dailyItemsGuage.ToValue = 20;
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
                ToValue = 1000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            problemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 1000,
                ToValue = 10000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            problemsGuage.FromValue = 0;
            problemsGuage.ToValue = 10000;
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
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_is_engineer' table. You can move, or remove it, as needed.
            this.c_view_is_engineerTableAdapter.Fill(this.user_infoDataSet.c_view_is_engineer);
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);

        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {

            doorTypePieChart();
            doorDifficultyPiecchart();

            absentHolidaysLate();
            averageDailyItems();
            countRemakes();
        }

        private void doorTypePieChart()
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


          


            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_door_types_by_programmer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;
           
            SqlDataReader reader = cmd.ExecuteReader();

            int loopcount = 1;
            while (reader.Read())
            {
                switch (loopcount)
                {
                    case 1:
                        c1 = reader.GetString(0);
                        v1 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 2:
                        c2 = reader.GetString(0);
                        v2 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 3:
                        c3 = reader.GetString(0);
                        v3 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 4:
                        c4 = reader.GetString(0);
                        v4 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 5:
                        c5 = reader.GetString(0);
                        v5 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 6:
                        c6 = reader.GetString(0);
                        v6 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 7:
                        c7 = reader.GetString(0);
                        v7 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 8:
                        c8 = reader.GetString(0);
                        v8 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 9:
                        c9 = reader.GetString(0);
                        v9 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 10:
                        c10 = reader.GetString(0);
                        v10 = reader.GetInt32(1);

                        loopcount += 1;
                        break;

                    default:
                        break;
                }
            }

            //VALUES PIE CHART

            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
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



            pieChart1.LegendLocation = LegendLocation.Bottom;






            conn.Close();


        }
        private void doorDifficultyPiecchart()
        {

            string c1 = "";
            string c2 = "";
            string c3 = "";




            int i1 = 0;
            int i2 = 0;
            int i3 = 0;








            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_door_difficulty_by_programmer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;

            SqlDataReader reader = cmd.ExecuteReader();

          
            while (reader.Read())
            {

                        c1 = reader.GetString(3);
                        i1 = reader.GetInt32(0);


                        c2 = reader.GetString(4);
                        i2 = reader.GetInt32(1);

          
                        c3 = reader.GetString(5);
                        i3 = reader.GetInt32(2);

  
                
            }


            //ITEMS PIECHART


            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart2.Series = new SeriesCollection
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
                    



                };



            pieChart2.LegendLocation = LegendLocation.Bottom;




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
            SqlCommand cmd = new SqlCommand("usp_kpi_average_daily_output_doors", conn);
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
            lblDailyAverage.Text = "Daily Average Doors: " + averageDailyItems;

            conn.Close();

        }

        private void countRemakes()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            double remakesCaused = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_remake_cost", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
               try
               {
                    remakesCaused = reader.GetDouble(0);
               }
                catch
                {
                    remakesCaused = 0;
               }

            }

            problemsGuage.Value = remakesCaused;

            lblRemakes.Text = "Remakes Caused (Cost £): " + remakesCaused;
            conn.Close();
        }

        private void RunComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProgrammerComparison frmec = new frmProgrammerComparison();
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

            frmViewDoors frmvq = new frmViewDoors(startdate,enddate,staffName);
            frmvq.Show();
        }

        private void EmailScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email_Screen();
        }
        public static void Email_Screen()
        {


            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\temp.jpg");


            }
            catch
            {

            }


            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "";
            mailItem.To = "";
            string imageSrc = @"C:\Temp\temp.jpg"; // Change path as needed

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
            //mailItem.Send();
        }
    }
}


