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
using System.Drawing.Printing;

namespace KPIAnalyser
{
    public partial class frmDepartmentDataChecker : Form
    {
        public int shopfloor { get; set; }
        public int estimator { get; set; }
        public int engineer { get; set; }
        public frmDepartmentDataChecker()
        {
            InitializeComponent();

            dteStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dteEnd.Value = (dteStart.Value.AddMonths(1).AddDays(-1));
            apply_filter();
        }

        private void frmStaffDataChecker_Load(object sender, EventArgs e)
        {
        }

        private void apply_filter()
        {



            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();

                string sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbDepartment.Text + "' ";

                //absences
                sql = "select  Convert(char,date_absent,103)  as [Absent Date],datename(WEEKDAY,date_absent) as [Day of Week],sum(1) [Absent] from dbo.absent_holidays " +
                    "left join [user_info].dbo.[user] u on u.id = staff_id " +
                    "where(absent_type = 5 or absent_type = 8) AND u.[current] = 1 AND ";

                if (cmbDepartment.Text == "Slimline Office")
                    sql = sql + " u.slimline = -1 and (u.ShopFloor = 0 or u.ShopFloor is null) and u.[current] = 1  AND (u.id <> 3 and u.id <> 9 and u.id <> 29) ";
                else if (cmbDepartment.Text == "Slimline Production")
                    sql = sql + " u.slimline = -1 and u.ShopFloor = -1 and u.[current] = 1  AND (u.id <> 3 and u.id <> 9 and u.id <> 29) ";
                else
                    sql = sql + "default_in_department =  '" + cmbDepartment.Text.ToString() + "' ";

                sql = sql + " AND date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                        "group by date_absent";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAbsent.DataSource = dt;
                }
                //total absences
                int temp_sum = 0;
                foreach (DataGridViewRow row in dgvAbsent.Rows)
                    temp_sum += Convert.ToInt32(row.Cells[2].Value.ToString());
                lblAbsent.Text = "Total Absent Days: " + temp_sum.ToString();

                //lates 
                sql = "select  Convert(char,date_absent,103)  as [Late Date],datename(WEEKDAY,date_absent) as [Day of Week],sum(1) [Late] from dbo.absent_holidays " +
                    "left join[user_info].dbo.[user] u on u.id = staff_id " +
                    "where(absent_type = 7) AND u.[current] = 1 AND ";
                if (cmbDepartment.Text == "Slimline Office")
                    sql = sql + " u.slimline = -1 and (u.ShopFloor = 0 or u.ShopFloor is null) and u.[current] = 1  AND (u.id <> 3 and u.id <> 9 and u.id <> 29) ";
                else if (cmbDepartment.Text == "Slimline Production")
                    sql = sql + " u.slimline = -1 and u.ShopFloor = -1 and u.[current] = 1  AND (u.id <> 3 and u.id <> 9 and u.id <> 29) ";
                else
                    sql = sql + "default_in_department =  '" + cmbDepartment.Text.ToString() + "' ";
                sql = sql + "AND date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                    "group by date_absent";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLate.DataSource = dt;
                }
                //total absences
                temp_sum = 0;
                foreach (DataGridViewRow row in dgvLate.Rows)
                    temp_sum = temp_sum + Convert.ToInt32(row.Cells[2].Value.ToString());
                lblLate.Text = "Total Late Days: " + temp_sum.ToString();

                //performance data




                if (cmbDepartment.Text == "Estimating")
                {
                    sql = "select date_output,day_of_week,coalesce(allocated_estimators * 90,0) as goal,coalesce(items,0) from " +
                        "(select cast(date_output as date) as date_output, datename(WEEKDAY, cast(date_output as date)) as day_of_week,sum(item_count) as items " +
                        "from dbo.solidworks_quotation_log l group by cast(date_output as date)) as solidworks " +
                        "left join (select cast(placement_date as date) as placement_date,count(string) as allocated_estimators " +
                        "from [order_database].dbo.view_department_reverse_concat_office where department = 'Estimating' " +
                        " " +
                        "group by placement_date) placement on solidworks.date_output = placement.placement_date " +
                        "where cast(date_output as date) >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' and cast(date_output as date) <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPerformance.DataSource = dt;
                    }
                }
                else if (cmbDepartment.Text == "Slimline Office")
                {
                    sql = "select cast(quote_date as date) as quote_date,datename(WEEKDAY, cast(quote_date as date)) as day_of_week,62500,sum(coalesce(price,0)) as price " +
                        "from [price_master].dbo.sl_quotation " +
                        "where highest_issue = -1 AND cast(quote_date as date) >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' and cast(quote_date as date) <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                        "group by quote_date ";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPerformance.DataSource = dt;
                    }
                }
                else if (cmbDepartment.Text == "Slimline Production")
                {
                    sql = "SELECT a.date_plan as [Work Date],a.day_of_week as [Day of Week],round(coalesce(a.set_hours,0),2) as [Set Hours],coalesce(b.worked_hours,0) as [Worked Hours] FROM (" +
                           "select date_plan, max(day_of_week) as day_of_week,sum(set_hours) as set_hours from( " +
                           " select cast(d.date_plan as date) as date_plan, datename(WEEKDAY, date_plan) as day_of_week, round(cast([hours] as float) + coalesce((ot.overtime * 0.8), 0), 2) as [set_hours] " +
                           "from dbo.power_plan_staff s " +
                           "left join dbo.power_plan_date d on s.date_id = d.id left join dbo.power_plan_overtime_remake ot on s.date_id = ot.date_id AND s.staff_id = ot.staff_id " +
                           "where d.date_plan >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' and d.date_plan <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' and s.department = 'Slimline' " +
                           "AND d.date_plan <= CAST(GETDATE() as date)) as grouped group by date_plan) as a " +
                           "left join( SELECT CAST(part_complete_date as date) as [date],ROUND((SUM(time_for_part) / 60), 2) as [worked_hours] " +
                           "FROM dbo.door_part_completion_log WHERE part_percent_complete is not null " +
                           "AND CAST(part_complete_date as DATE) >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND CAST(part_complete_date as DATE) <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                           "AND part_status = 'Complete'   GROUP BY CAST(part_complete_date as date)) as b on a.date_plan = b.date " +
                           "order by a.date_plan";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPerformance.DataSource = dt;
                    }
                }
                else if (cmbDepartment.Text == "Programming")
                {
                    using (SqlCommand cmd = new SqlCommand("usp_staff_checker_programming_department", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@startDate", SqlDbType.DateTime).Value = dteStart.Value;
                        cmd.Parameters.AddWithValue("@endDate", SqlDbType.DateTime).Value = dteEnd.Value;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        dgvPerformance.DataSource = dt;
                    }
                }
                else if (cmbDepartment.Text == "")
                    dgvPerformance.DataSource = null;
                else //has to be shopfloor
                {
                    sql = "SELECT a.date_plan as [Work Date],a.day_of_week as [Day of Week],round(coalesce(a.set_hours,0),2) as [Set Hours],coalesce(b.worked_hours,0) as [Worked Hours] FROM (" +
                        "select date_plan, max(day_of_week) as day_of_week,sum(set_hours) as set_hours from( " +
                        " select cast(d.date_plan as date) as date_plan, datename(WEEKDAY, date_plan) as day_of_week, round(cast([hours] as float) + coalesce((ot.overtime * 0.8), 0), 2) as [set_hours] " +
                        "from dbo.power_plan_staff s " +
                        "left join dbo.power_plan_date d on s.date_id = d.id left join dbo.power_plan_overtime_remake ot on s.date_id = ot.date_id AND s.staff_id = ot.staff_id " +
                        "where d.date_plan >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' and d.date_plan <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' and s.department = '" + cmbDepartment.Text.Replace("Buffing", "Dressing") + "' " +
                        "AND d.date_plan <= CAST(GETDATE() as date)) as grouped group by date_plan) as a " +
                        "left join( SELECT CAST(part_complete_date as date) as [date],ROUND((SUM(time_for_part) / 60), 2) as [worked_hours] " +
                        "FROM dbo.door_part_completion_log WHERE door_part_completion_log.op = '" + cmbDepartment.Text.Replace("Buffing", "Dressing") + "' " +
                        "AND CAST(part_complete_date as DATE) >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND CAST(part_complete_date as DATE) <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                        "AND part_status = 'Complete'   GROUP BY CAST(part_complete_date as date)) as b on a.date_plan = b.date " +
                        "order by a.date_plan";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPerformance.DataSource = dt;
                    }
                }



                //remake/repaint
                sql = "SELECT[date] as [Work Date],datename(WEEKDAY,[date]) as [Day of Week],sum(repaint_count) as [Repaint Count],sum(remake_count) as [Remake Count],round(sum(cost),2) as [Cost] " +
                         "FROM(select cast(date_logged as date) as [date], count(dept.department_name) as repaint_count, 0 as remake_count, sum(COALESCE(round(r.repaint_cost, 2), 0)) as [cost] " +
                         "from dbo.door d right join dbo.repaints r on r.door_id = d.id " +
                         "left join [user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                         "left join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref  " +
                         "left join[dsl_kpi].dbo.department dept on dept.id = r.department " +
                         "left join[user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id " +
                         "WHERE date_logged >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "'  AND date_logged <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "'  and dept.department_name = '" + cmbDepartment.Text.Replace("Buffing", "Dressing") + "' " +
                         "group by cast(date_logged as date) " +
                         "union all " +
                         "select cast([date] as date) as [date],0 as repaint_count,count(dbo.remake.id) as remake_count,round(sum(coalesce(cost, 0)),2) as Cost " +
                         "from dbo.remake " +
                         "left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                         "left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref " +
                         "left join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                         "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible " +
                         "left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                         "where [date] >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "'  AND[date] <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "'  and d1.department_name = '" + cmbDepartment.Text.Replace("Buffing", "Dressing") + "' " +
                         "group by[date]) as a group by[date] order by[date]";


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRemakeRepaint.DataSource = dt;
                }

                conn.Close();
            }

            format();
        }

        private void format()
        {
            foreach (DataGridViewColumn col in dgvAbsent.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewColumn col in dgvLate.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewColumn col in dgvPerformance.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewColumn col in dgvRemakeRepaint.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //performance stuffs -- if shopfloor

            try
            {
                if (cmbDepartment.Text == "Programming")
                {
                    dgvPerformance.Columns[0].HeaderText = "Work Date";
                    dgvPerformance.Columns[1].HeaderText = "Day of Week";
                    dgvPerformance.Columns[2].HeaderText = "Goal Points";
                    dgvPerformance.Columns[3].HeaderText = "Actual Points";
                }
                else if (cmbDepartment.Text == "Slimline Office")
                {
                    dgvPerformance.Columns[0].HeaderText = "Work Date";
                    dgvPerformance.Columns[1].HeaderText = "Day of Week";
                    dgvPerformance.Columns[2].HeaderText = "Target";
                    dgvPerformance.Columns[3].HeaderText = "Value Quoted";
                }
                else if (cmbDepartment.Text == "Estimating")
                {
                    dgvPerformance.Columns[0].HeaderText = "Work Date";
                    dgvPerformance.Columns[1].HeaderText = "Day of Week";
                    dgvPerformance.Columns[2].HeaderText = "Target";
                    dgvPerformance.Columns[3].HeaderText = "Items Quoted";
                }
                else
                {
                    dgvPerformance.Columns[0].HeaderText = "Work Date";
                    dgvPerformance.Columns[1].HeaderText = "Day of Week";
                    dgvPerformance.Columns[2].HeaderText = "Set Hours";
                    dgvPerformance.Columns[3].HeaderText = "Worked Hours";
                }
            }
            catch { }

            //colours
            double green = 0;
            double red = 0;
            foreach (DataGridViewRow row in dgvPerformance.Rows)
            {

                if (Convert.ToDouble(row.Cells[2].Value.ToString()) <= Convert.ToDouble(row.Cells[3].Value.ToString()))
                {
                    dgvPerformance.Rows[row.Index].Cells[2].Style.BackColor = Color.LightSeaGreen;
                    dgvPerformance.Rows[row.Index].Cells[3].Style.BackColor = Color.LightSeaGreen;
                    green++;
                }
                else
                {
                    dgvPerformance.Rows[row.Index].Cells[2].Style.BackColor = Color.PaleVioletRed;
                    dgvPerformance.Rows[row.Index].Cells[3].Style.BackColor = Color.PaleVioletRed;
                    red++;
                }
            }

            //total cost of remake/repaint
            double total_cost = 0;
            for (int i = 0; i < dgvRemakeRepaint.Rows.Count; i++)
                total_cost = total_cost + Convert.ToDouble(dgvRemakeRepaint.Rows[i].Cells[4].Value.ToString());


            string total_cost_string = total_cost.ToString("#,##0.00");
            //ammend stuff like colour and having £-100
            total_cost_string = "£" + total_cost_string;
            //first up is the - number

            if (total_cost_string.Contains("-"))
            {
                total_cost_string = total_cost_string.Replace("-", "");
                total_cost_string = total_cost_string.Insert(0, "-");
            }


            lblRemakeRepaint.Text = "Remake/Repaint Cost: " + total_cost_string;

            //work out percentage
            if (green == 0 && red == 0)
            {
                lblPerformance.Text = "0% Over Target";
            }//nothing
            else
            {
                if (green == 0)
                    lblPerformance.Text = "0% Over Target";
                else if (red == 0)
                    lblPerformance.Text = "100% Over Target";
                else
                {
                    double test = 0;
                    test = Math.Round((green / (green + red) * 100), 2);
                    //Math.Round((green / red) * 100,2);
                    lblPerformance.Text = test.ToString() + "% Over Target";
                }
            }
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {

            apply_filter();
        }

        private void frmStaffDataChecker_Shown(object sender, EventArgs e)
        {
            //formatting here because it wont proc on open (instantly doing apply_filter)
            format();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print();
        }
        private void print()
        {
            string file_name = @"C:\temp\temp" + DateTime.Now.ToString("mmss") + ".jpg";
            try
            {
                Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                //bit.Save(@"C:\temp\temp.jpg");


                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }
                    bitmap.Save(file_name);
                }


                //var frm = Form.ActiveForm;
                //using (var bmp = new Bitmap(frm.Width, frm.Height))
                //{
                //    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                //    bmp.Save(@"C:\temp\temp.jpg");
                //}

                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    Image i = Image.FromFile(file_name);
                    Rectangle m = args.MarginBounds;
                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    args.Graphics.DrawImage(i, m);
                };

                pd.DefaultPageSettings.Landscape = true;
                //Margins margins = new Margins(50, 50, 50, 50);
                //pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            { }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                //bit.Save(@"C:\temp\temp.jpg");


                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }
                    bitmap.Save(@"C:\temp\temp.jpg");
                }


                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.Subject = "";
                mailItem.To = "";
                string imageSrc = @"C:\Temp\temp.jpg"; // Change path as needed

                var attachments = mailItem.Attachments;
                var attachment = attachments.Add(imageSrc);
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
                mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);

                // Set body format to HTML

                mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                mailItem.Attachments.Add(imageSrc);
                string msgHTMLBody = "";
                mailItem.HTMLBody = msgHTMLBody;
                mailItem.Display(true);

            }
            catch { }

        }

        private void dgvLate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql = "select  u.forename + ' ' + u.surname as [Late Staff] " +
                "from dbo.absent_holidays left join[user_info].dbo.[user] u on u.id = staff_id where(absent_type = 7) AND ";
            if (cmbDepartment.Text == "Slimline Office")
                sql = sql + " u.slimline = -1 and (u.ShopFloor = 0 or u.ShopFloor is null) and u.[current] = 1  AND (u.id <> 3 and u.id <> 9 and u.id <> 29) ";
            else if (cmbDepartment.Text == "Slimline Production")
                sql = sql + " u.slimline = -1 and u.ShopFloor = -1 and u.[current] = 1  AND (u.id <> 3 and u.id <> 9 and u.id <> 29) ";
            else
                sql = sql + "default_in_department =  '" + cmbDepartment.Text.ToString() + "' ";
            sql = sql + "AND date_absent = '" + Convert.ToDateTime(dgvLate.Rows[e.RowIndex].Cells[0].Value.ToString()).ToString("yyyy-MM-dd") + "'";

            frmDepartmentEnhanced frm = new frmDepartmentEnhanced(sql, "Late Employees", Convert.ToDateTime(dgvLate.Rows[e.RowIndex].Cells[0].Value.ToString()));
            frm.ShowDialog();


        }

        private void dgvAbsent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql = "select  u.forename + ' ' + u.surname as [Late Staff] from dbo.absent_holidays " +
                    "left join[user_info].dbo.[user] u on u.id = staff_id " +
                    "where(absent_type = 5 or absent_type = 8) AND ";
            if (cmbDepartment.Text == "Slimline Office")
                sql = sql + " u.slimline = -1 and (u.ShopFloor = 0 or u.ShopFloor is null) and u.[current] = 1  AND (u.id <> 3 and u.id <> 9 and u.id <> 29) ";
            else if (cmbDepartment.Text == "Slimline Production")
                sql = sql + " u.slimline = -1 and u.ShopFloor = -1 and u.[current] = 1  AND (u.id <> 3 and u.id <> 9 and u.id <> 29) ";
            else
                sql = sql + "default_in_department =  '" + cmbDepartment.Text.ToString() + "' ";
            sql = sql + " AND date_absent = '" + Convert.ToDateTime(dgvAbsent.Rows[e.RowIndex].Cells[0].Value.ToString()).ToString("yyyy-MM-dd") + "'  ";

            frmDepartmentEnhanced frm = new frmDepartmentEnhanced(sql, "Absent Employees", Convert.ToDateTime(dgvAbsent.Rows[e.RowIndex].Cells[0].Value.ToString()));
            frm.ShowDialog();
        }
    }
}

