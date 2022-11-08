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
    public partial class frmEstimatorComparison : Form
    {
        public frmEstimatorComparison()
        {
            InitializeComponent();
        }

        private void FrmEstimatorComparison_Load(object sender, EventArgs e)
        {

            string sql = "SELECT forename + ' ' + surname,* FROM dbo.[user] where [grouping] = 5 and [current] = 1 and (non_user = 0 or non_user is null) order by forename";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        lstStaff.Items.Add(row[0].ToString());
                    }
                }
            }

            //this is absolute shit i do not understand it so I have rewrote it to add the correct people 
            ////// TODO: This line of code loads data into the 'user_infoDataSet1.c_view_estimators' table. You can move, or remove it, as needed.
            ////this.c_view_estimatorsTableAdapter.Fill(this.user_infoDataSet1.c_view_estimators);
            ////// TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            ////this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);

        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            dailyItems();
            populateAbsenseChart();
            populateLatenessChart();
            populateProblemsChart();
            populateOvertimeChart();
            populateEnquiryLogChart();
        }

        private void populateEnquiryLogChart()
        {
            //select 
            List<string> staffNames = new List<string>();
            List<string> staffNamesInitials = new List<string>();
            List<int> quoteTime = new List<int>();

            foreach (var item in lstStaff.SelectedItems)
            {
                string firstLetter = item.ToString().Substring(0, 1);
                string secondLetter = (item.ToString().Split(' ').Skip(1).FirstOrDefault()).Substring(0,1);
                staffNamesInitials.Add(firstLetter + secondLetter);

                staffNames.Add(item.ToString());
            }

            int i = 0;
            while (i < staffNames.Count)
            {
                string sql = "select avg(hours_to_comp) as hours_to_comp,max(fullName) from (SELECT [enquirylog].dbo.enquiry_log.allocated_to_id, u.forename + ' ' + u.surname AS fullName, order_database.dbo.WorkTime([enquirylog].dbo.enquiry_log.recieved_time, " +
                    "[enquirylog].dbo.enquiry_log.complete_date) / 60 AS hours_to_comp, [enquirylog].dbo.enquiry_log.recieved_time, [enquirylog].dbo.enquiry_log.complete_date FROM[enquirylog].dbo.enquiry_log LEFT OUTER JOIN " +
                    "user_info.dbo.[user] AS u ON u.id = [enquirylog].dbo.enquiry_log.allocated_to_id WHERE([enquirylog].dbo.enquiry_log.complete_date IS NOT NULL) AND([enquirylog].dbo.enquiry_log.allocated_to_id IS NOT NULL)) as a " +
                    "where cast(complete_date as date) >= '" + dteStart.Text + "' AND cast(complete_date as date) <= '" + dteEnd.Text + "'  AND fullName = '" + staffNames[i].ToString() + "'";
                using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        //var temp = Convert.ToString(cmd.ExecuteScalar());
                        if (Convert.ToString(cmd.ExecuteScalar()) != "")
                        {
                            //MessageBox.Show(Convert.ToInt32(cmd.ExecuteScalar()).ToString());
                            quoteTime.Add(Convert.ToInt32(cmd.ExecuteScalar()));
                        }
                        else
                            quoteTime.Add(0);
                        
                        conn.Close();
                    }
                }
                i++;
            }

            chartEnquiryLog.AxisY.Clear();
            chartEnquiryLog.AxisX.Clear();

            chartEnquiryLog.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Average Enquiry Log Completion Time",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,
                    Values = new ChartValues<int>(quoteTime)
                }


            };

            chartEnquiryLog.AxisX.Add(new Axis
            {
                Title = "Estimator",
                FontSize = 10,
                Labels = staffNamesInitials
            }) ;

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
            string user9 = "";
            string user10 = "";
        

            int daily1 = 0;
            int daily2 = 0;
            int daily3 = 0;
            int daily4 = 0;
            int daily5 = 0;
            int daily6 = 0;
            int daily7 = 0;
            int daily8 = 0;
            int daily9 = 0;
            int daily10 = 0;


            int target1 = 0;
            int target2 = 0;
            int target3 = 0;
            int target4 = 0;
            int target5 = 0;
            int target6 = 0;
            int target7 = 0;
            int target8 = 0;
            int target9 = 0;
            int target10 = 0;







            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = "";


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
          


            int i = 0;


            List<string> staffNames = new List<string>();
            List<string> staffNamesInitials = new List<string>();
            foreach (var item in lstStaff.SelectedItems)
            {
                string firstLetter = item.ToString().Substring(0, 1);
                string secondLetter = (item.ToString().Split(' ').Skip(1).FirstOrDefault()).Substring(0, 1);
                staffNamesInitials.Add(firstLetter + secondLetter);
                staffNames.Add(item.ToString());
            }



            while (i < staffNames.Count)
            {
                conn.Open();
     
                SqlCommand cmd = new SqlCommand("usp_kpi_average_daily_output", conn);
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
                                daily1 = reader.GetInt32(0);
                                target1 = 90;
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
                                target2 = 90;
                            }
                            catch
                            {
                                user2 ="";
                                daily2 = 0;
                                target2 = 0;
                            }
                            
                            break;
                        case 2:
                            try
                            {
                                user3 = staffNames[i];
                                daily3 = reader.GetInt32(0);
                                target3 = 90;
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
                                target4 = 90;
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
                                target5 = 90;
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
                                target6 = 90;
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
                                target7 = 90;
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
                                target8 = 90;
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
                                daily9 = reader.GetInt32(0);
                                target9 = 90;
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
                                daily10 = reader.GetInt32(0);
                                target10 = 90;
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
                    Title = "Items",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,
                    Values = new ChartValues<int> { daily1, daily2, daily3, daily4, daily5 }
                }


            };

            //adding series will update and animate the chart automatically
            dailyAverageItemsBar.Series.Add(new StepLineSeries
            {
                Title = "Target",
                FontSize = 10,
               //FontStyle.Bold, 
            
                Fill = System.Windows.Media.Brushes.Orange,
                Values = new ChartValues<double> { target1, target2, target3, target4, target5}
            });











            dailyAverageItemsBar.AxisX.Add(new Axis
            {
                Title = "Estimator",
                FontSize = 10,
                Labels = (staffNamesInitials),
                Separator = DefaultAxes.CleanSeparator
            });

            dailyAverageItemsBar.AxisY.Add(new Axis
            {
                Title = "Average Items Quoted",
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
            List<string> staffNamesInitials = new List<string>();

            foreach (var item in lstStaff.SelectedItems)
            {
                string firstLetter = item.ToString().Substring(0, 1);
                string secondLetter = (item.ToString().Split(' ').Skip(1).FirstOrDefault()).Substring(0, 1);
                staffNamesInitials.Add(firstLetter + secondLetter);
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
                Labels = (staffNamesInitials)
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
            List<string> staffNamesInitials = new List<string>();

            foreach (var item in lstStaff.SelectedItems)
            {
                string firstLetter = item.ToString().Substring(0, 1);
                string secondLetter = (item.ToString().Split(' ').Skip(1).FirstOrDefault()).Substring(0, 1);
                staffNamesInitials.Add(firstLetter + secondLetter);
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
                Labels = (staffNamesInitials)
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
            List<string> staffNamesInitials = new List<string>();

            foreach (var item in lstStaff.SelectedItems)
            {
                string firstLetter = item.ToString().Substring(0, 1);
                string secondLetter = (item.ToString().Split(' ').Skip(1).FirstOrDefault()).Substring(0, 1);
                staffNamesInitials.Add(firstLetter + secondLetter);
                staffNames.Add(item.ToString());
            }



            while (i < staffNames.Count)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_kpi_estimator_problems", conn);
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

            problemsBar.AxisY.Clear();
            problemsBar.AxisX.Clear();

            problemsBar.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Issues Logged by programmers",
                    Fill = System.Windows.Media.Brushes.Green,
                    DataLabels = true,
                    FontSize = 10,
                    Values = new ChartValues<int> { daily1, daily2, daily3, daily4 }

                }
            };

            problemsBar.AxisX.Add(new Axis
            {
                Title = "Estimator",
                FontSize = 16,
                Labels = (staffNamesInitials)
            });

            problemsBar.AxisY.Add(new Axis
            {
                Title = "Problems Logged",
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
            List<string> staffNamesInitials = new List<string>();

            foreach (var item in lstStaff.SelectedItems)
            {
                string firstLetter = item.ToString().Substring(0, 1);
                string secondLetter = (item.ToString().Split(' ').Skip(1).FirstOrDefault()).Substring(0, 1);
                staffNamesInitials.Add(firstLetter + secondLetter);
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
                Labels = (staffNamesInitials)
            });

            overtimeChart.AxisY.Add(new Axis
            {
                Title = "OverTime",
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

        private void overtimeChart_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void elementHost3_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void elementHost2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void absenseBar_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void dteEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lstStaff_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
