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
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            //this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);

            btnCompare.PerformClick();
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Enabled = true;
            timer1.Interval = 900000;
            timer1.Tick += new EventHandler(timer_Tick);
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            temp.Text = timer1.Interval.ToString();
            btnCompare.PerformClick();
        }



        private void BtnCompare_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("a");
            dailyItems();
            
            timer1.Start();
            //populateAbsenseChart();
            //populateLatenessChart();
            //populateProblemsChart();
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

            int target1 = 0;
            int target2 = 0;
            int target3 = 0;
            int target4 = 0;




            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = "";


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
          


            int i = 0;


            List<string> staffNames = new List<string>();

            //foreach (var item in lstStaff.SelectedItems)
            //{
            //staffNames.Add(((DataRowView)item).Row["fullname"].ToString());
            dteStart.Value = DateTime.Now;
            dteEnd.Value = DateTime.Now;
            string sql = "SELECT forename +' ' + surname,id FROM dbo.[user] WHERE[grouping] = 5 and[current] = 1 and id<> 314";
            using (SqlConnection connTemp = new SqlConnection(ConnectionStrings.ConnectionStringUser))
            {
                connTemp.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connTemp))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    listAutoStaff.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        staffNames.Add(row[0].ToString());
                        listAutoStaff.Items.Add(row[0].ToString());
                    }
                }
                connTemp.Close();
            }
            //}



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
                    FontSize = 14,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,
                    Values = new ChartValues<int> { daily1, daily2, daily3, daily4 }
                }


            };

            //adding series will update and animate the chart automatically
            dailyAverageItemsBar.Series.Add(new StepLineSeries
            {
                Title = "Target",
                FontSize = 14,
            
                Fill = System.Windows.Media.Brushes.Orange,
                Values = new ChartValues<double> { target1, target2, target3, target4 }
            });











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


            //here produce DGV that shows  what quotes are null
            if (dataGridView1.DataSource != null)
            {
                //dataGridView1.Rows.Clear();
                dataGridView1.DataSource = null;
            }
            sql = "select a.quote_id,a.date_output,a.customer,a.item_count,a.revision_number,'£' + CAST(a.total_quotation_value as nvarchar(200)) as [total_quotation_value],a.quoted_by,a.customer_ref,a.first_open_time,emailed_to,b.date_started " +
                "from dbo.solidworks_quotation_log a left join dbo.solidworks_quotation_log_started b on a.quote_id = b.quote_id AND a.revision_number = b.revision_num" +
                " where date_output >= '" + dteStart.Value.ToString("yyyy-MM-dd").ToString() + "' AND date_output <= DATEADD(D, 1, '" + dteStart.Value.ToString("yyyy-MM-dd").ToString() + "') AND emailed_to is null";
            using (SqlConnection connNull = new SqlConnection(ConnectionStrings.ConnectionString))
            { 
                connNull.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connNull))
                {
                    DataTable dt = new DataTable(); 
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);  // simple datagridview for what is null
                    dataGridView1.DataSource = dt;
                    //format
                    dataGridView1.Columns[0].HeaderText = "Quote ID";
                    dataGridView1.Columns[1].HeaderText = "Date Output";
                    dataGridView1.Columns[2].HeaderText = "Customer";
                    dataGridView1.Columns[3].HeaderText = "Item Count";
                    dataGridView1.Columns[4].HeaderText = "Revision Number";
                    dataGridView1.Columns[5].HeaderText = "Total Quote Value";
                    dataGridView1.Columns[6].HeaderText = "Quoted By"; 
                    dataGridView1.Columns[7].HeaderText = "Customer Ref";
                    dataGridView1.Columns[8].HeaderText = "First Time Open";
                    dataGridView1.Columns[9].HeaderText = "Emailed To";
                    dataGridView1.Columns[10].HeaderText = "Date Started";

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                connNull.Close();

            }

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //open form to allow end user to assign THAT quote to a user
            frmAssignQuote frm = new frmAssignQuote(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value), Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value));
            frm.ShowDialog();
            btnCompare.PerformClick();
        }
    }
}
