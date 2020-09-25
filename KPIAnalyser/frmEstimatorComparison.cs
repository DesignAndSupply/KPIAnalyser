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
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);

        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            dailyItems();
            populateAbsenseChart();
            populateLatenessChart();
            populateProblemsChart();
        }

        private void dailyItems()
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
                staffNames.Add(((DataRowView)item).Row["fullname"].ToString());
            }



            while (i < staffNames.Count)
            {
                conn.Open();
     
                SqlCommand cmd = new SqlCommand("usp_kpi_average_daily_output", conn);
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
                                user2 ="";
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
                    Values = new ChartValues<int> { daily1, daily2, daily3, daily4 }
                }
            };

            dailyAverageItemsBar.AxisX.Add(new Axis
            {
                Title = "Estimator",
                FontSize = 16,
                Labels = new[] { user1, user2, user3, user4 }
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

            foreach (var item in lstStaff.SelectedItems)
            {
                staffNames.Add(((DataRowView)item).Row["fullname"].ToString());
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
                staffNames.Add(((DataRowView)item).Row["fullname"].ToString());
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
                Labels = new[] { user1, user2, user3, user4 }
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

            foreach (var item in lstStaff.SelectedItems)
            {
                staffNames.Add(((DataRowView)item).Row["fullname"].ToString());
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
                Labels = new[] { user1, user2, user3, user4 }
            });

            problemsBar.AxisY.Add(new Axis
            {
                Title = "Problems Logged",
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





    }
}
