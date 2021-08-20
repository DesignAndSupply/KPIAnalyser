using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Data.SqlClient;
using System.Drawing.Printing;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace KPIAnalyser
{
    public partial class frmProgrammerComparison : Form
    {
        public List<string> _staffNames = new List<string>();
        public frmProgrammerComparison()
        {
            InitializeComponent();
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






        private void FrmEstimatorComparison_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_is_engineer' table. You can move, or remove it, as needed.
            //this.c_view_is_engineerTableAdapter.Fill(this.user_infoDataSet.c_view_is_engineer);
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);


            string sql = "select forename + ' ' + surname as [fullname] from [user_info].dbo.[user] where isEngineer = -1 and (id <> 3 AND id <> 29 and id <> 260)";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        lstStaff.Items.Add(row[0].ToString());
                    }
                    lstStaff.Refresh();
                    conn.Close();
                }
            }
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            dailyItems();
            populateAbsenseChart();
            populateLatenessChart();
            populateProblemsChart();
            populateOverTime();
        }

        private void dailyItems()
        {

            string user1 = "";
            string user2 = "";
            string user3 = "";
            string user4 = "";
            string user5 = "";
            string user6 = "";
            string user7 = "";
            string user8 = "";

            int daily1 = 0;
            int daily2 = 0;
            int daily3 = 0;
            int daily4 = 0;
            int daily5 = 0;
            int daily6 = 0;
            int daily7 = 0;
            int daily8 = 0;

            int target1 = 0;
            int target2 = 0;
            int target3 = 0;
            int target4 = 0;
            int target5 = 0;
            int target6 = 0;
            int target7 = 0;
            int target8 = 0;





            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = "";


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);



            int i = 0;


            List<string> staffNames = new List<string>();

            _staffNames.Clear();
            foreach (var item in lstStaff.SelectedItems)
            {
                staffNames.Add(item.ToString());
                _staffNames.Add(item.ToString());
            }



            while (i < staffNames.Count)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_kpi_average_daily_output_doors", conn);
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
                                target1 = 8;
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
                                daily2 = reader.GetInt32(0);
                                target2 = 8;
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
                                daily3 = reader.GetInt32(0);
                                target3 = 8;
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
                                daily4 = reader.GetInt32(0);
                                target4 = 8;
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
                                daily5 = reader.GetInt32(0);
                                target5 = 8;
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
                                daily6 = reader.GetInt32(0);
                                target6 = 8;
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
                                daily7 = reader.GetInt32(0);
                                target7 = 8;
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
                                daily8 = reader.GetInt32(0);
                                target8 = 8;
                            }
                            catch
                            {
                                user8 = "";
                                daily8 = 0;
                                target8 = 0;
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
                    Title = "Doors",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,
                    Values = new ChartValues<int> { daily1, daily2, daily3, daily4,daily5,daily6,daily7,daily8 }
                }
            };



            //adding series will update and animate the chart automatically
            dailyAverageItemsBar.Series.Add(new StepLineSeries
            {
                Title = "Target",
                FontSize = 10,

                Fill = System.Windows.Media.Brushes.Orange,
                Values = new ChartValues<double> { target1, target2, target3, target4, target5, target6, target7, target8 }
            });

            dailyAverageItemsBar.AxisX.Add(new Axis
            {
                Title = "Programmer",
                FontSize = 12,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                },
                Labels = new[] { user1, user2, user3, user4, user5, user6, user7, user8 }
            });

            dailyAverageItemsBar.AxisY.Add(new Axis
            {
                Title = "Average doors programmed",
                FontSize = 16,

            });




        }



        private void populateAbsenseChart()
        {

            string user1 = "";
            string user2 = "";
            string user3 = "";
            string user4 = "";
            string user5 = "";
            string user6 = "";
            string user7 = "";
            string user8 = "";

            int daily1 = 0;
            int daily2 = 0;
            int daily3 = 0;
            int daily4 = 0;
            int daily5 = 0;
            int daily6 = 0;
            int daily7 = 0;
            int daily8 = 0;





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

                SqlCommand cmd = new SqlCommand("usp_kpi_absent_late_estimating", conn);
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
                        case 4:
                            try
                            {
                                user5 = staffNames[i];
                                daily5 = reader.GetInt32(0);
                            }
                            catch
                            {
                                user5 = "";
                                daily5 = 0;
                            }
                            break;
                        case 5:
                            try
                            {
                                user6 = staffNames[i];
                                daily6 = reader.GetInt32(0);
                            }
                            catch
                            {
                                user6 = "";
                                daily6 = 0;
                            }

                            break;
                        case 6:
                            try
                            {
                                user7 = staffNames[i];
                                daily7 = reader.GetInt32(0);
                            }

                            catch
                            {
                                user7 = "";
                                daily7 = 0;
                            }
                            break;
                        case 7:
                            try
                            {
                                user8 = staffNames[i];
                                daily8 = reader.GetInt32(0);
                            }
                            catch
                            {
                                user8 = "";
                                daily8 = 0;
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
                    Values = new ChartValues<int> { daily1, daily2, daily3, daily4,daily5,daily6,daily7,daily8 }

                }
            };

            absenseBar.AxisX.Add(new Axis
            {
                Title = "Programmer",
                FontSize = 12,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                },
                Labels = new[] { user1, user2, user3, user4, user5, user6, user7, user8 }
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
            string user5 = "";
            string user6 = "";
            string user7 = "";
            string user8 = "";

            int daily1 = 0;
            int daily2 = 0;
            int daily3 = 0;
            int daily4 = 0;
            int daily5 = 0;
            int daily6 = 0;
            int daily7 = 0;
            int daily8 = 0;





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

                SqlCommand cmd = new SqlCommand("usp_kpi_absent_late_estimating", conn);
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
                        case 4:
                            try
                            {
                                user5 = staffNames[i];
                                daily5 = reader.GetInt32(3);
                            }
                            catch
                            {
                                user5 = "";
                                daily5 = 0;
                            }
                            break;
                        case 5:
                            try
                            {
                                user6 = staffNames[i];
                                daily6 = reader.GetInt32(3);
                            }
                            catch
                            {
                                user6 = "";
                                daily6 = 0;
                            }

                            break;
                        case 6:
                            try
                            {
                                user7 = staffNames[i];
                                daily7 = reader.GetInt32(3);
                            }

                            catch
                            {
                                user7 = "";
                                daily7 = 0;
                            }
                            break;
                        case 7:
                            try
                            {
                                user8 = staffNames[i];
                                daily8 = reader.GetInt32(3);
                            }
                            catch
                            {
                                user8 = "";
                                daily8 = 0;
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
                    Values = new ChartValues<int> { daily1, daily2, daily3, daily4,daily5,daily6,daily7,daily8 }

                }
            };

            latenessBar.AxisX.Add(new Axis
            {
                Title = "Programmer",
                FontSize = 10,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                },
                Labels = new[] { user1, user2, user3, user4,user5,user6,user7,user8 }
            });

            latenessBar.AxisY.Add(new Axis
            {
                Title = "Days Late",
                FontSize = 16,

            });

        }



        private void populateProblemsChart()
        {

            string user1 = "";
            string user2 = "";
            string user3 = "";
            string user4 = "";
            string user5 = "";
            string user6 = "";
            string user7 = "";
            string user8 = "";

            double daily1 = 0;
            double daily2 = 0;
            double daily3 = 0;
            double daily4 = 0;
            double daily5 = 0;
            double daily6 = 0;
            double daily7 = 0;
            double daily8 = 0;





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

                SqlCommand cmd = new SqlCommand("usp_kpi_remake_cost", conn);
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
                        case 4:
                            try
                            {
                                user5 = staffNames[i];
                                daily5 = reader.GetDouble(0);
                            }
                            catch
                            {
                                user5 = "";
                                daily5 = 0;
                            }
                            break;
                        case 5:
                            try
                            {
                                user6 = staffNames[i];
                                daily6 = reader.GetDouble(0);
                            }
                            catch
                            {
                                user6 = "";
                                daily6 = 0;
                            }

                            break;
                        case 6:
                            try
                            {
                                user7 = staffNames[i];
                                daily7 = reader.GetDouble(0);
                            }

                            catch
                            {
                                user7 = "";
                                daily7 = 0;
                            }
                            break;
                        case 7:
                            try
                            {
                                user8 = staffNames[i];
                                daily8 = reader.GetDouble(0);
                            }
                            catch
                            {
                                user8 = "";
                                daily8 = 0;
                            }

                            break;

                        default:
                            break;

                    }

                }

                conn.Close();
                i += 1;
            }

            problemsBar.AxisY.Clear();
            problemsBar.AxisX.Clear();

            problemsBar.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "COST OF REMAKES IN PERIOD",
                    Fill = System.Windows.Media.Brushes.Green,
                    DataLabels = true,
                    FontSize = 10,
                    Values = new ChartValues<double> { daily1, daily2, daily3, daily4,daily5,daily6,daily7,daily8 }

                }
            };

            problemsBar.AxisX.Add(new Axis
            {
                Title = "Programmer",
                FontSize = 10,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                },
                Labels = new[] { user1, user2, user3, user4,user5,user6,user7,user8 }
            });

            problemsBar.AxisY.Add(new Axis
            {
                Title = "Cost or remakes",
                FontSize = 16,

            });

        }

        private void BtnPrint_Click(object sender, EventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
        {
            Email_Screen();
        }

        private void populateOverTime()
        {

            string user1 = "";
            string user2 = "";
            string user3 = "";
            string user4 = "";
            string user5 = "";
            string user6 = "";
            string user7 = "";
            string user8 = "";

            double daily1 = 0;
            double daily2 = 0;
            double daily3 = 0;
            double daily4 = 0;
            double daily5 = 0;
            double daily6 = 0;
            double daily7 = 0;
            double daily8 = 0;

            int target1 = 0;
            int target2 = 0;
            int target3 = 0;
            int target4 = 0;
            int target5 = 0;
            int target6 = 0;
            int target7 = 0;
            int target8 = 0;





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

                SqlCommand cmd = new SqlCommand("usp_kpi_programmer_overtime", conn);
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
                                target1 = 8;
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
                                target2 = 8;
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
                                target3 = 8;
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
                                target4 = 8;
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
                                target5 = 8;
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
                                target6 = 8;
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
                                target7 = 8;
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
                                target8 = 8;
                            }
                            catch
                            {
                                user8 = "";
                                daily8 = 0;
                                target8 = 0;
                            }
                            break;

                        default:
                            break;

                    }

                }

                conn.Close();
                i += 1;
            }

            chartOverTime.AxisY.Clear();
            chartOverTime.AxisX.Clear();

            chartOverTime.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Hours",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,
                    Values = new ChartValues<double> { daily1, daily2, daily3, daily4,daily5,daily6,daily7,daily8 }
                }
            };



            //adding series will update and animate the chart automatically
            //chartOverTime.Series.Add(new StepLineSeries
            //{
            //    Title = "Target",
            //    FontSize = 10,

            //    Fill = System.Windows.Media.Brushes.Orange,
            //    Values = new ChartValues<double> { target1, target2, target3, target4 }
            //});

            chartOverTime.AxisX.Add(new Axis
            {
                Title = "Programmer",
                FontSize = 10,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                },
                Labels = new[] { user1, user2, user3, user4,user5,user6,user7,user8 }
            });

            chartOverTime.AxisY.Add(new Axis
            {
                Title = "Overtime",
                FontSize = 16,

            });




        }

        private void cviewisengineerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dailyAverageItemsBar_DataClick(object sender, ChartPoint p)
        {
            var asPixels = dailyAverageItemsBar.Base.ConvertToPixels(p.AsPoint());
            // vvv this will get the fullname of whoevers data it is 
            //_staffNames[Convert.ToInt32(p.X)];
            frmProgrammerOverview frm = new frmProgrammerOverview(_staffNames[Convert.ToInt32(p.X)], dteStart.Value, dteEnd.Value);
            frm.ShowDialog();

                
        }
    }
}
