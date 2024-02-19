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
using System.Drawing.Printing;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace KPIAnalyser
{
    public partial class frmEstimatorComparisonSlimline : Form
    {
        public frmEstimatorComparisonSlimline()
        {
            InitializeComponent();
            lstStaff.Items.Add("All");
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
                        lstStaff.Items.Add(reader[0].ToString());
                    }
                    conn.Close();
                }
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            dailyPrice();
            populateAbsenseChart();
            populateLatenessChart();
            //populateProblemsChart();  cant do this one
            populateOvertimeChart();
        }
        private void dailyPrice()
        {

            string user1 = "";
            string user2 = "";
            string user3 = "";
            string user4 = "";
            string user5 = "";
            string user6 = "";
            string user7 = "";
            string user8 = "";
            string user9 = "";
            string user10 = "";


            double daily1 = 0;
            double daily2 = 0;
            double daily3 = 0;
            double daily4 = 0;
            double daily5 = 0;
            double daily6 = 0;
            double daily7 = 0;
            double daily8 = 0;
            double daily9 = 0;
            double daily10 = 0;


            double target1 = 0;
            double target2 = 0;
            double target3 = 0;
            double target4 = 0;
            double target5 = 0;
            double target6 = 0;
            double target7 = 0;
            double target8 = 0;
            double target9 = 0;
            double target10 = 0;







            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = "";


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);



            int i = 0;


            List<string> staffNames = new List<string>();

            foreach (var item in lstStaff.SelectedItems)
            {
                staffNames.Add(item.ToString());
            }



            while (i < staffNames.Count)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_kpi_average_daily_output_slimline", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffNames[i];
                cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
                cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;
                cmd.Parameters.Add("@incRev", SqlDbType.Int).Value = -1; 

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    switch (i)
                    {
                        case 0:
                            try
                            {
                                user1 = staffNames[i];
                                daily1 = reader.GetDouble(0);
                                target1 = 62500;
                            }
                            catch
                            {
                                user1 = "";
                                daily1 = 0;
                                target1 = 0;
                            }
                            break;
                        case 1:
                            try
                            {
                                user2 = staffNames[i];
                                daily2 = reader.GetDouble(0);
                                target2 = 62500;
                            }
                            catch
                            {
                                user2 = "";
                                daily2 = 0;
                                target2 = 0;
                            }

                            break;
                        case 2:
                            try
                            {
                                user3 = staffNames[i];
                                daily3 = reader.GetDouble(0);
                                target3 = 62500;
                            }

                            catch
                            {
                                user3 = "";
                                daily3 = 0;
                                target3 = 0;
                            }
                            break;
                        case 3:
                            try
                            {
                                user4 = staffNames[i];
                                daily4 = reader.GetDouble(0);
                                target4 = 62500;
                            }
                            catch
                            {
                                user4 = "";
                                daily4 = 0;
                                target4 = 0;
                            }
                            break;
                        case 4:
                            try
                            {
                                user5 = staffNames[i];
                                daily5 = reader.GetDouble(0);
                                target5 = 62500;
                            }
                            catch
                            {
                                user5 = "";
                                daily5 = 0;
                                target5 = 0;
                            }
                            break;
                        case 5:
                            try
                            {
                                user6 = staffNames[i];
                                daily6 = reader.GetDouble(0);
                                target6 = 62500;
                            }
                            catch
                            {
                                user6 = "";
                                daily6 = 0;
                                target6 = 0;
                            }
                            break;
                        case 6:
                            try
                            {
                                user7 = staffNames[i];
                                daily7 = reader.GetDouble(0);
                                target7 = 62500;
                            }
                            catch
                            {
                                user7 = "";
                                daily7 = 0;
                                target7 = 0;
                            }
                            break;
                        case 7:
                            try
                            {
                                user8 = staffNames[i];
                                daily8 = reader.GetDouble(0);
                                target8 = 62500;
                            }
                            catch
                            {
                                user8 = "";
                                daily8 = 0;
                                target8 = 0;
                            }
                            break;
                        case 8:
                            try
                            {
                                user9 = staffNames[i];
                                daily9 = reader.GetDouble(0);
                                target9 = 62500;
                            }
                            catch
                            {
                                user9 = "";
                                daily9 = 0;
                                target9 = 0;
                            }
                            break;
                        case 9:
                            try
                            {
                                user10 = staffNames[i];
                                daily10 = reader.GetDouble(0);
                                target10 = 62500;
                            }
                            catch
                            {
                                user10 = "";
                                daily10 = 0;
                                target10 = 0;
                            }
                            break;


                        default:
                            break;

                    }

                }

                conn.Close();
                i += 1;
            }

            dailyAverageItemsBar.AxisY.Clear();
            dailyAverageItemsBar.AxisX.Clear();

            dailyAverageItemsBar.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Value",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,
                    Values = new ChartValues<double> { daily1, daily2, daily3, daily4, daily5 }
                }


            };

            //adding series will update and animate the chart automatically
            dailyAverageItemsBar.Series.Add(new StepLineSeries
            {
                Title = "Target",
                FontSize = 10,

                Fill = System.Windows.Media.Brushes.Orange,
                Values = new ChartValues<double> { target1, target2, target3, target4, target5 }
            });


            dailyAverageItemsBar.AxisX.Add(new Axis
            {
                Title = "Estimator",
                FontSize = 10,
                Labels = new[] { user1, user2, user3, user4, user5 }
            });

            dailyAverageItemsBar.AxisY.Add(new Axis
            {
                Title = "Average Value",
                FontSize = 16,

            });




        }
        private void populateAbsenseChart()
        {

            string user1 = "";
            string user2 = "";
            string user3 = "";
            string user4 = "";

            int daily1 = 0;
            int daily2 = 0;
            int daily3 = 0;
            int daily4 = 0;





            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = "";


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);



            int i = 0;


            List<string> staffNames = new List<string>();

            foreach (var item in lstStaff.SelectedItems)
            {
                staffNames.Add(item.ToString());
            }




            while (i < staffNames.Count)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_kpi_absent_late_estimating_slimline", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffNames[i];
                cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
                cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    switch (i)
                    {
                        case 0:
                            try
                            {
                                user1 = staffNames[i];
                                daily1 = reader.GetInt32(0);
                            }
                            catch
                            {
                                user1 = "";
                                daily1 = 0;
                            }
                            break;
                        case 1:
                            try
                            {
                                user2 = staffNames[i];
                                daily2 = reader.GetInt32(0);
                            }
                            catch
                            {
                                user2 = "";
                                daily2 = 0;
                            }

                            break;
                        case 2:
                            try
                            {
                                user3 = staffNames[i];
                                daily3 = reader.GetInt32(0);
                            }

                            catch
                            {
                                user3 = "";
                                daily3 = 0;
                            }
                            break;
                        case 3:
                            try
                            {
                                user4 = staffNames[i];
                                daily4 = reader.GetInt32(0);
                            }
                            catch
                            {
                                user4 = "";
                                daily4 = 0;
                            }

                            break;

                        default:
                            break;

                    }

                }

                conn.Close();
                i += 1;
            }

            absenseBar.AxisY.Clear();
            absenseBar.AxisX.Clear();

            absenseBar.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Days",
                    FontSize = 10,
                    DataLabels = true,
                    Values = new ChartValues<int> { daily1, daily2, daily3, daily4 }

                }
            };

            absenseBar.AxisX.Add(new Axis
            {
                Title = "Estimator",
                FontSize = 16,
                Labels = new[] { user1, user2, user3, user4 }
            });

            absenseBar.AxisY.Add(new Axis
            {
                Title = "Days Absent",
                FontSize = 16,

            });

        }

        private void populateLatenessChart()
        {

            string user1 = "";
            string user2 = "";
            string user3 = "";
            string user4 = "";

            int daily1 = 0;
            int daily2 = 0;
            int daily3 = 0;
            int daily4 = 0;





            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = "";


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);



            int i = 0;


            List<string> staffNames = new List<string>();

            foreach (var item in lstStaff.SelectedItems)
            {
                staffNames.Add(item.ToString());
            }



            while (i < staffNames.Count)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_kpi_absent_late_estimating_slimline", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffNames[i];
                cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
                cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    switch (i)
                    {
                        case 0:
                            try
                            {
                                user1 = staffNames[i];
                                daily1 = reader.GetInt32(3);
                            }
                            catch
                            {
                                user1 = "";
                                daily1 = 0;
                            }
                            break;
                        case 1:
                            try
                            {
                                user2 = staffNames[i];
                                daily2 = reader.GetInt32(3);
                            }
                            catch
                            {
                                user2 = "";
                                daily2 = 0;
                            }

                            break;
                        case 2:
                            try
                            {
                                user3 = staffNames[i];
                                daily3 = reader.GetInt32(3);
                            }

                            catch
                            {
                                user3 = "";
                                daily3 = 0;
                            }
                            break;
                        case 3:
                            try
                            {
                                user4 = staffNames[i];
                                daily4 = reader.GetInt32(3);
                            }
                            catch
                            {
                                user4 = "";
                                daily4 = 0;
                            }

                            break;

                        default:
                            break;

                    }

                }

                conn.Close();
                i += 1;
            }

            latenessBar.AxisY.Clear();
            latenessBar.AxisX.Clear();

            latenessBar.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Days",
                    FontSize = 10,
                    DataLabels = true,
                    Values = new ChartValues<int> { daily1, daily2, daily3, daily4 }

                }
            };

            latenessBar.AxisX.Add(new Axis
            {
                Title = "Estimator",
                FontSize = 16,
                Labels = new[] { user1, user2, user3, user4 }
            });

            latenessBar.AxisY.Add(new Axis
            {
                Title = "Days Late",
                FontSize = 16,

            });

        }


        private void populateOvertimeChart()
        {
            string user1 = "";
            string user2 = "";
            string user3 = "";
            string user4 = "";

            double daily1 = 0;
            double daily2 = 0;
            double daily3 = 0;
            double daily4 = 0;





            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = "";


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);



            int i = 0;


            List<string> staffNames = new List<string>();

            foreach (var item in lstStaff.SelectedItems)
            {
                staffNames.Add(item.ToString());
            }



            while (i < staffNames.Count)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_kpi_estimator_overtime", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffNames[i];
                cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
                cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    switch (i)
                    {
                        case 0:
                            try
                            {
                                user1 = staffNames[i];
                                daily1 = reader.GetDouble(0);
                            }
                            catch
                            {
                                user1 = "";
                                daily1 = 0;
                            }
                            break;
                        case 1:
                            try
                            {
                                user2 = staffNames[i];
                                daily2 = reader.GetDouble(0);
                            }
                            catch
                            {
                                user2 = "";
                                daily2 = 0;
                            }

                            break;
                        case 2:
                            try
                            {
                                user3 = staffNames[i];
                                daily3 = reader.GetDouble(0);
                            }

                            catch
                            {
                                user3 = "";
                                daily3 = 0;
                            }
                            break;
                        case 3:
                            try
                            {
                                user4 = staffNames[i];
                                daily4 = reader.GetDouble(0);
                            }
                            catch
                            {
                                user4 = "";
                                daily4 = 0;
                            }

                            break;

                        default:
                            break;

                    }

                }

                conn.Close();
                i += 1;
            }

            overtimeChart.AxisY.Clear();
            overtimeChart.AxisX.Clear();

            overtimeChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Staff OverTime",
                    Fill = System.Windows.Media.Brushes.Green,
                    DataLabels = true,
                    FontSize = 10,
                    Values = new ChartValues<double> { daily1, daily2, daily3, daily4 }

                }
            };

            overtimeChart.AxisX.Add(new Axis
            {
                Title = "Estimator",
                FontSize = 16,
                Labels = new[] { user1, user2, user3, user4 }
            });

            overtimeChart.AxisY.Add(new Axis
            {
                Title = "OverTime",
                FontSize = 16,

            });
        }

        private void btnPrint_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
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
            mailItem.Display(false);
            //mailItem.Send();
        }
    }
}
