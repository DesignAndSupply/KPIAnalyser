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
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace KPIAnalyser
{
    public partial class frmStaffDataChecker : Form
    {
        public int shopfloor { get; set; }
        public int estimator { get; set; }
        public int engineer { get; set; }
        public int slimline { get; set; }
        public int staff_id { get; set; }
        public frmStaffDataChecker()
        {
            InitializeComponent();
            string sql = "SELECT forename + ' ' +surname as staff from [user_info].dbo.[user] WHERE [current] =  1 and (non_user = 0 or non_user is null) order by forename "; //test aaa

            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        cmbStaff.Items.Add(row[0].ToString());
                    }
                }
                conn.Close();
            }
            //get the start and end of current month
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

                staff_id = 0;
                string sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbStaff.Text + "' ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    staff_id = Convert.ToInt32(cmd.ExecuteScalar());


                //absent total
                sql = "select  coalesce(sum(1),0) as [Total Absent] from dbo.absent_holidays " +
                         "left join[user_info].dbo.[user] u on u.id = staff_id " +
                         "where(absent_type = 5 or absent_type = 8) AND " +
                         "staff_id = " + staff_id.ToString() +
                         " AND date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    lblAbsent.Text = "Total Absent Days: " + cmd.ExecuteScalar().ToString();
                }

                //late total
                sql = "select  coalesce(sum(1),0) as [ Total Late] from dbo.absent_holidays " +
                        "left join[user_info].dbo.[user] u on u.id = staff_id " +
                        "where(absent_type = 7) AND " +
                        "staff_id = " + staff_id.ToString() +
                        "AND date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    lblLate.Text = "Total Late Days: " + cmd.ExecuteScalar().ToString();

                //absences
                sql = "select  Convert(char,date_absent,103)  as [Absent Date],datename(WEEKDAY,date_absent) as [Day of Week],sum(1) [Absent] from dbo.absent_holidays " +
                    "left join[user_info].dbo.[user] u on u.id = staff_id " +
                    "where(absent_type = 5 or absent_type = 8) AND " +
                    "staff_id =  " + staff_id.ToString() +
                    " AND date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                    "group by date_absent";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAbsent.DataSource = dt;
                }
                //lates 
                sql = "select  Convert(char,date_absent,103)  as [Late Date],datename(WEEKDAY,date_absent) as [Day of Week],sum(1) [Late] from dbo.absent_holidays " +
                    "left join[user_info].dbo.[user] u on u.id = staff_id " +
                    "where(absent_type = 7) AND " +
                    "staff_id =  " + staff_id.ToString() +
                    "AND date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                    "group by date_absent";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLate.DataSource = dt;
                }

                //performance data
                //look up shopfloor or office
                sql = "select coalesce(ShopFloor,0),coalesce(isEngineer,0),coalesce(isEstimator,0),coalesce(slimline,0) from [user_info].dbo.[user] where id = " + staff_id.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //dgvLate.DataSource = dt;

                    try
                    {
                        shopfloor = Convert.ToInt32(dt.Rows[0][0].ToString());
                        engineer = Convert.ToInt32(dt.Rows[0][1].ToString());
                        estimator = Convert.ToInt32(dt.Rows[0][2].ToString());
                        slimline = Convert.ToInt32(dt.Rows[0][3].ToString());
                    }
                    catch
                    {
                        shopfloor = 0;
                        engineer = 0;
                        estimator = 0;
                    }
                }
                if (shopfloor == -1)
                {
                    sql = "select cast(d.date_plan as date) as date_plan,datename(WEEKDAY,date_plan) as day_of_week,round(cast([hours] as float) + coalesce((ot.overtime * 0.8),0),2) as [set_hours]," +
                        "COALESCE(worked.worked_hours,0) as worked_hours from dbo.power_plan_staff s " +
                        "left join dbo.power_plan_date d on s.date_id = d.id " +
                        "left join dbo.power_plan_overtime_remake ot on s.date_id = ot.date_id AND s.staff_id = ot.staff_id " +
                        "left join (SELECT CAST(part_complete_date as date) as [date],ROUND((SUM(time_for_part) / 60), 2) as [worked_hours],staff_id FROM dbo.door_part_completion_log  " +
                        "WHERE staff_id = " + staff_id.ToString() + " AND CAST(part_complete_date as DATE) >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND CAST(part_complete_date as DATE) <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                        "AND part_status = 'Complete'   GROUP BY CAST(part_complete_date as date),staff_id) as worked on d.date_plan = worked.date " +
                        "where  s.staff_id = " + staff_id.ToString() + " and d.date_plan >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' and d.date_plan <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' AND d.date_plan <= CAST(GETDATE() as date) " +
                        "order by d.date_plan";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPerformance.DataSource = dt;
                    }
                }
                else if (engineer == -1)
                {
                    using (SqlCommand cmd = new SqlCommand("usp_staff_checker_programming", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@startDate", SqlDbType.DateTime).Value = dteStart.Value;
                        cmd.Parameters.AddWithValue("@endDate", SqlDbType.DateTime).Value = dteEnd.Value;
                        cmd.Parameters.AddWithValue("@staffID", SqlDbType.Int).Value = staff_id;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        dgvPerformance.DataSource = dt;
                    }
                }
                else if (estimator == -1)
                { 
                    string estSwitch;
                    estSwitch = cmbStaff.Text;

                    if (estSwitch == "Nicholas Thomas")
                    {
                        estSwitch = "Nick Thomas";
                    }
                    



                    sql = "select date_output,day_of_week,coalesce(1* 90,0) as goal,coalesce(items,0) from " +
                          "(select cast(date_output as date) as date_output, datename(WEEKDAY, cast(date_output as date)) as day_of_week,sum(item_count) as items " +
                          "from dbo.solidworks_quotation_log l where quoted_by = '" + estSwitch + "' group by cast(date_output as date)) as solidworks " +
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
                else if (slimline == -1)
                {
                    sql = "select cast(quote_date as date) as quote_date,datename(WEEKDAY, cast(quote_date as date)) as day_of_week,62500,sum(coalesce(price,0)) as price " +
                          "from [price_master].dbo.sl_quotation " +
                          "left join [user_info].dbo.[user] u on sl_quotation.created_by_id = u.id " +
                          "where highest_issue = -1 AND u.forename + ' ' + u.surname = '" + cmbStaff.Text + "' AND " +
                          "cast(quote_date as date) >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' and cast(quote_date as date) <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                          "group by quote_date ";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPerformance.DataSource = dt;
                    }
                }
                else if (slimline == -1 && shopfloor == -1)
                {
                    sql = "select cast(d.date_plan as date) as date_plan,datename(WEEKDAY,date_plan) as day_of_week,round(cast([hours] as float) + coalesce((ot.overtime * 0.8),0),2) as [set_hours]," +
                          "COALESCE(worked.worked_hours,0) as worked_hours from dbo.power_plan_staff s " +
                          "left  merge join dbo.power_plan_date d on s.date_id = d.id " +
                          "left  merge join dbo.power_plan_overtime_remake ot on s.date_id = ot.date_id AND s.staff_id = ot.staff_id " +
                          "left merge join (SELECT CAST(part_complete_date as date) as [date],ROUND((SUM(time_for_part) / 60), 2) as [worked_hours],staff_id FROM dbo.door_part_completion_log  " +
                          "WHERE part_percent_complete is not null AND staff_id = " + staff_id.ToString() + " AND CAST(part_complete_date as DATE) >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND CAST(part_complete_date as DATE) <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                          "AND part_status = 'Complete'   GROUP BY CAST(part_complete_date as date),staff_id) as worked on d.date_plan = worked.date " +
                          "where  s.staff_id = " + staff_id.ToString() + " and d.date_plan >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' and d.date_plan <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' AND d.date_plan <= CAST(GETDATE() as date) " +
                          "order by d.date_plan";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPerformance.DataSource = dt;
                    }

                }
                else
                    dgvPerformance.DataSource = null;



                //remake/repaint
                sql = "SELECT [date] as [Work Date],datename(WEEKDAY,[date]) as [Day of Week],sum(repaint_count) as [Repaint Count],sum(remake_count) as [Remake Count],sum(cost) as [Cost] FROM ( " +
                         "select cast(date_logged as date) as [date],count(dept.department_name) as repaint_count,0 as remake_count,sum(COALESCE(round(r.repaint_cost, 2), 0)) as [cost] from dbo.door d " +
                         "right join dbo.repaints r on r.door_id = d.id " +
                         "left join [user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                         "left merge join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref " +
                         "left merge join[dsl_kpi].dbo.department dept on dept.id = r.department " +
                         "left join[user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id " +
                         "WHERE date_logged >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "'  AND date_logged<= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "'  and u_fault.id = " + staff_id.ToString() + " " +
                         "group by cast(date_logged as date) union all " +
                         "select cast([date] as date) as [date],0 as repaint_count,count(dbo.remake.id) as remake_count,sum(coalesce(cost, 0)) as Cost from dbo.remake left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                         "left merge join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref left " +
                         "join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                         "left merge join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible left  merge " +
                         "join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                         "where [date] >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "'  AND[date] <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "'  and remake.persons_responsible = " + staff_id.ToString() + " " +
                         "group by[date]) as a group by[date] order by[date] ";

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
            if (shopfloor == -1)
            {
                dgvPerformance.Columns[0].HeaderText = "Work Date";
                dgvPerformance.Columns[1].HeaderText = "Day of Week";
                dgvPerformance.Columns[2].HeaderText = "Set Hours";
                dgvPerformance.Columns[3].HeaderText = "Worked Hours";
            }
            else if (engineer == -1)
            {
                dgvPerformance.Columns[0].HeaderText = "Work Date";
                dgvPerformance.Columns[1].HeaderText = "Day of Week";
                dgvPerformance.Columns[2].HeaderText = "Goal Points";
                dgvPerformance.Columns[3].HeaderText = "Actual Points";
            }
            else if (estimator == -1)
            {
                dgvPerformance.Columns[0].HeaderText = "Work Date";
                dgvPerformance.Columns[1].HeaderText = "Day of Week";
                dgvPerformance.Columns[2].HeaderText = "Target";
                dgvPerformance.Columns[3].HeaderText = "Items Quoted";
            }
            else if (slimline == -1)
            {
                dgvPerformance.Columns[0].HeaderText = "Work Date";
                dgvPerformance.Columns[1].HeaderText = "Day of Week";
                dgvPerformance.Columns[2].HeaderText = "Target";
                dgvPerformance.Columns[3].HeaderText = "Value Quoted";
            }

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
            //for (int i = 0; i < dgvRemakeRepaint.Rows.Count; i++)
            //    total_cost = total_cost + Convert.ToDouble(dgvRemakeRepaint.Rows[i].Cells[4].Value.ToString());

            //get the values for remake/repaint seperately 
            string total_cost_string = "";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();

                //remake
                string sql = "select COALESCE(sum(coalesce(cost, 0)),0) as Cost " +
                    "from dbo.remake left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                    "left merge join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref " +
                    "left join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                    "left merge join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible " +
                    "left merge join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                    "where [date] >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "'  AND[date] <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                    "and remake.persons_responsible = " + staff_id.ToString();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    var getData = cmd.ExecuteScalar();
                    if (getData != null)
                    {
                        lblRemake.Text = getData.ToString();

                        total_cost_string = Convert.ToDouble(cmd.ExecuteScalar().ToString()).ToString("#,##0.00");
                        //ammend stuff like colour and having £-100
                        total_cost_string = "£" + total_cost_string;
                        //first up is the - number

                        if (total_cost_string.Contains("-"))
                        {
                            total_cost_string = total_cost_string.Replace("-", "");
                            total_cost_string = total_cost_string.Insert(0, "-");
                        }
                        lblRemake.Text = total_cost_string;
                    }
                    else
                        lblRemake.Text = "£0";

                }

                //repaint
                sql = "select coalesce(sum(COALESCE(round(r.repaint_cost, 2), 0)),0) as [cost] " +
                    "from dbo.door d " +
                    "right join dbo.repaints r on r.door_id = d.id " +
                    "left  join [user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                    "left merge join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref " +
                    "left merge join[dsl_kpi].dbo.department dept on dept.id = r.department " +
                    "left  join[user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id " +
                    "WHERE date_logged >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "'  AND date_logged<= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                    "and u_fault.id = " + staff_id.ToString();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    var getData = cmd.ExecuteScalar();
                    if (getData != null)
                    {
                        lblRepaint.Text = getData.ToString();

                        total_cost_string = Convert.ToDouble(cmd.ExecuteScalar().ToString()).ToString("#,##0.00");
                        //ammend stuff like colour and having £-100
                        total_cost_string = "£" + total_cost_string;
                        //first up is the - number

                        if (total_cost_string.Contains("-"))
                        {
                            total_cost_string = total_cost_string.Replace("-", "");
                            total_cost_string = total_cost_string.Insert(0, "-");
                        }
                        lblRepaint.Text = total_cost_string;
                    }
                    else
                        lblRepaint.Text = "£0";

                }

                conn.Close();
            }


            //    string total_cost_string = total_cost.ToString("#,##0.00");
            ////ammend stuff like colour and having £-100
            //total_cost_string = "£" + total_cost_string;
            ////first up is the - number

            //if (total_cost_string.Contains("-"))
            //{
            //    total_cost_string = total_cost_string.Replace("-", "");
            //    total_cost_string = total_cost_string.Insert(0, "-");
            //}


            //  lblRemakeRepaint.Text = "Remake/Repaint Cost: " + total_cost_string;

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

                //this is the main reason why 

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
                mailItem.Display(false);

            }
            catch { }

        }

        private void dgvLate_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cmbStaff.Text == "")
                return;

            Excel.PageSetup xlPageSetUp;

            object misValue = System.Reflection.Missing.Value;
            // Store the Excel processes before opening. 
            Process[] processesBefore = Process.GetProcessesByName("excel");

            // Open the file in Excel. 
            string fileName = @"C:\temp\" + cmbStaff.Text.Replace(" ", "_") + "Export_" + DateTime.Now.ToString("hh_mm_ss") + ".xls";
            var xlApp = new Excel.Application();
            var xlWorkbooks = xlApp.Workbooks;
            var xlWorkbook = xlWorkbooks.Add(Type.Missing);
            var xlWorksheet = xlWorkbook.Sheets[1];

            xlApp.DisplayAlerts = false; //turn off annoying alerts that make me want to cryyyy

            xlWorkbook.Worksheets[1].Name = "TARGET";

            // Get Excel processes after opening the file. 
            Process[] processesAfter = Process.GetProcessesByName("excel");

            if ("target" == "target")
            {
                //target formatting
                xlWorksheet.Range["A1:D1"].Merge();
                xlWorksheet.Range["A1"].Value2 = cmbStaff.Text + " Target";
                xlWorksheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorksheet.Range["A1"].Cells.Font.Size = 22;

                xlWorksheet.Range["A2:D2"].Merge();
                xlWorksheet.Range["A2"].Value2 = dteStart.Value.ToString("dd/MM/yyyy") + " - " + dteEnd.Value.ToString("dd/MM/yyyy");
                xlWorksheet.Range["A2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorksheet.Range["A2"].Cells.Font.Size = 22;

                xlWorksheet.Range["A3:D3"].Merge();
                xlWorksheet.Range["A3"].Value2 = lblPerformance.Text;
                xlWorksheet.Range["A3"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorksheet.Range["A3"].Cells.Font.Size = 22;

                //headers
                xlWorksheet.Range["A4"].Value2 = "Work Date";
                xlWorksheet.Range["B4"].Value2 = "Day of Week";
                xlWorksheet.Range["C4"].Value2 = dgvPerformance.Columns[2].HeaderText;
                xlWorksheet.Range["D4"].Value2 = dgvPerformance.Columns[3].HeaderText;


                //loop through the dgv and add to the table

                int current_excel_row = 5;

                for (int i = 0; i < dgvPerformance.Rows.Count; i++)
                {
                    xlWorksheet.Cells[1][current_excel_row].Value2 = dgvPerformance.Rows[i].Cells[0].Value;
                    xlWorksheet.Cells[2][current_excel_row].Value2 = dgvPerformance.Rows[i].Cells[1].Value.ToString();
                    xlWorksheet.Cells[3][current_excel_row].Value2 = dgvPerformance.Rows[i].Cells[2].Value.ToString();
                    //colours
                    if (dgvPerformance.Rows[i].Cells[2].Style.BackColor == Color.PaleVioletRed)
                        xlWorksheet.Cells[3][current_excel_row].Interior.Color = System.Drawing.Color.PaleVioletRed;
                    if (dgvPerformance.Rows[i].Cells[2].Style.BackColor == Color.LightSeaGreen)
                        xlWorksheet.Cells[3][current_excel_row].Interior.Color = System.Drawing.Color.LightSeaGreen;

                    xlWorksheet.Cells[4][current_excel_row].Value2 = dgvPerformance.Rows[i].Cells[3].Value.ToString();
                    //colours
                    if (dgvPerformance.Rows[i].Cells[3].Style.BackColor == Color.PaleVioletRed)
                        xlWorksheet.Cells[4][current_excel_row].Interior.Color = System.Drawing.Color.PaleVioletRed;
                    if (dgvPerformance.Rows[i].Cells[3].Style.BackColor == Color.LightSeaGreen)
                        xlWorksheet.Cells[4][current_excel_row].Interior.Color = System.Drawing.Color.LightSeaGreen;

                    current_excel_row++;
                }

                Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
                ws.Columns.AutoFit();
                ws.Rows.AutoFit();

                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.Borders.Color = ColorTranslator.ToOle(Color.Black);
                xlWorksheet.Columns.AutoFit();
                xlWorksheet.Rows.AutoFit();

                xlWorksheet.Range["A:A"].NumberFormat = "dd/MM/yyyy";


                xlPageSetUp = xlWorksheet.PageSetup;

                xlPageSetUp.Zoom = false;

                xlPageSetUp.FitToPagesWide = 1;

                xlPageSetUp.Orientation = Excel.XlPageOrientation.xlPortrait;
            }

            if ("remakes" == "remakes")
            {
                //INSERT NEW SHEET
                Excel.Worksheet remakeSheet = xlWorkbook.Sheets.Add(After: xlWorkbook.ActiveSheet);

                xlWorksheet = xlWorkbook.Sheets[2];

                //xlWorksheet.Select(remakeSheet);



                xlWorkbook.Worksheets[2].Name = " REMAKES";

                //all the remakes by this person
                string sql = "select dbo.remake.door_id as [Door ID],[User] as [Logged By],[description] as [Remake Description],[date] as [Log Date],[NAME] as Customer," +
                            "coalesce(u.forename + ' ' + u.surname,'') as [Person Responsible]," +
                            "d1.department_name as [Department Responsible] ,d2.department_name as [Department Noticed] ,coalesce(cost, 0) as Cost " +
                            "from dbo.remake " +
                            "left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                            "left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref " +
                            "left join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                            "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible " +
                            "left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                            "left join dbo.door_type dt on door.door_type_id = dt.id " +
                            "where [date] >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND[date] < '" + dteEnd.Value.ToString("yyyyMMdd") + "' " +
                            "AND  (dt.slimline_y_n = 0 or dt.slimline_y_n is null) AND u.forename + ' ' + u.surname = '" + cmbStaff.Text + "' " +
                            "ORDER BY [DATE] asc, dbo.remake.door_id asc";

                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }

                    conn.Close();
                }

                //remove new line character from the dgv
                foreach (DataRow row in dt.Rows)
                    row[2] = row[2].ToString().Replace("\n", "").Replace("\r", " - ");


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string temp = dt.Rows[i][5].ToString();
                    temp = temp.Trim();
                    dt.Rows[i][5] = temp;
                }


                //target formatting
                xlWorksheet.Range["A1:I1"].Merge();
                xlWorksheet.Range["A1"].Value2 = "Remakes";
                xlWorksheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorksheet.Range["A1"].Cells.Font.Size = 22;


                //headers
                xlWorksheet.Range["A2"].Value2 = dt.Columns[0].ColumnName;
                xlWorksheet.Range["B2"].Value2 = dt.Columns[1].ColumnName;
                xlWorksheet.Range["C2"].Value2 = dt.Columns[2].ColumnName;
                xlWorksheet.Range["D2"].Value2 = dt.Columns[3].ColumnName;
                xlWorksheet.Range["E2"].Value2 = dt.Columns[4].ColumnName;
                xlWorksheet.Range["F2"].Value2 = dt.Columns[5].ColumnName;
                xlWorksheet.Range["G2"].Value2 = dt.Columns[6].ColumnName;
                xlWorksheet.Range["H2"].Value2 = dt.Columns[7].ColumnName;
                xlWorksheet.Range["I2"].Value2 = dt.Columns[8].ColumnName;


                //loop through the dgv and add to the table

                int current_excel_row = 3;
                double cost_total = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    xlWorksheet.Cells[1][current_excel_row].Value2 = dt.Rows[i][0].ToString();
                    xlWorksheet.Cells[2][current_excel_row].Value2 = dt.Rows[i][1].ToString();
                    xlWorksheet.Cells[3][current_excel_row].Value2 = dt.Rows[i][2].ToString();
                    xlWorksheet.Cells[4][current_excel_row].Value2 = dt.Rows[i][3].ToString();
                    xlWorksheet.Cells[5][current_excel_row].Value2 = dt.Rows[i][4].ToString();
                    xlWorksheet.Cells[6][current_excel_row].Value2 = dt.Rows[i][5].ToString();
                    xlWorksheet.Cells[7][current_excel_row].Value2 = dt.Rows[i][6].ToString();
                    xlWorksheet.Cells[8][current_excel_row].Value2 = dt.Rows[i][7].ToString();
                    xlWorksheet.Cells[9][current_excel_row].Value2 = dt.Rows[i][8].ToString();
                    cost_total = cost_total + Convert.ToDouble(dt.Rows[i][8].ToString());

                    current_excel_row++;
                }

                xlWorksheet.Range["A1"].Value2 = cmbStaff.Text + " - Remakes - £" +  cost_total.ToString() + " - " + dteStart.Value.ToString("dd/MM/yyyy") + " to " + dteEnd.Value.ToString("dd/MM/yyyy"); 

                // Format column D as text before pasting results, this was required for my data
                //xlWorksheet.Range["I:I"].NumberFormat = "@";

                xlWorksheet.Range["A2:I2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
                xlWorksheet.Range["A2:I2"].AutoFilter(1);
                xlWorksheet.Columns[3].ColumnWidth = 98.14;
                xlWorksheet.Columns[3].WrapText = true;
                xlWorksheet.Range["H:H"].NumberFormat = "£#,###,###.00";

                Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[2];
                Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.Borders.Color = ColorTranslator.ToOle(Color.Black);


                xlWorksheet.Range["I" + (dt.Rows.Count + 3).ToString()].Value2 = "=SUBTOTAL(9,I3:I" + (dt.Rows.Count + 2).ToString() + ")";
                xlWorksheet.Range["I" + (dt.Rows.Count + 3).ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range["I" + (dt.Rows.Count + 3).ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);

                ws.Columns.AutoFit();
                ws.Rows.AutoFit();


                xlWorksheet.Columns.AutoFit();
                xlWorksheet.Rows.AutoFit();

                xlWorksheet.Columns[3].ColumnWidth = 98.14;
                xlWorksheet.Columns[3].WrapText = true;

                xlPageSetUp = xlWorksheet.PageSetup;

                xlPageSetUp.Zoom = false;

                xlPageSetUp.FitToPagesWide = 1;

                xlPageSetUp.Orientation = Excel.XlPageOrientation.xlLandscape;

            }

            if ("absence" == "absence")
            {

                //INSERT NEW SHEET
                Excel.Worksheet remakeSheet = xlWorkbook.Sheets.Add(After: xlWorkbook.ActiveSheet);

                xlWorksheet = xlWorkbook.Sheets[3];

                //xlWorksheet.Select(remakeSheet);
                xlWorkbook.Worksheets[3].Name = "ABSENCE AND LATES";

                xlWorksheet.Range["A:A"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                //target formatting
                xlWorksheet.Range["A2:C2"].Merge();
                xlWorksheet.Range["A2"].Value2 = "ABSENCE";
                xlWorksheet.Range["A2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorksheet.Range["A2"].Cells.Font.Size = 22;

                xlWorksheet.Range["A3:C3"].Merge();
                xlWorksheet.Range["A3"].Value2 = lblAbsent.Text;
                xlWorksheet.Range["A3"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorksheet.Range["A3"].Cells.Font.Size = 22;

                //headers
                xlWorksheet.Range["A4"].Value2 = "Absence Date";
                xlWorksheet.Range["B4"].Value2 = "Day of Week";
                xlWorksheet.Range["C4"].Value2 = dgvAbsent.Columns[2].HeaderText;

                xlWorksheet.Range["A:A"].NumberFormat = "dd/MM/yyyy";
                //loop through the dgv and add to the table

                int current_excel_row = 4;

                for (int i = 0; i < dgvAbsent.Rows.Count; i++)
                {
                    xlWorksheet.Cells[1][current_excel_row].Value2 = Convert.ToDateTime(dgvAbsent.Rows[i].Cells[0].Value).ToString("dd/MM/yyyy");
                    xlWorksheet.Cells[2][current_excel_row].Value2 = dgvAbsent.Rows[i].Cells[1].Value.ToString();
                    xlWorksheet.Cells[3][current_excel_row].Value2 = dgvAbsent.Rows[i].Cells[2].Value.ToString();

                    current_excel_row++;
                }

                Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[3];
                Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
                ws.Columns.AutoFit();
                ws.Rows.AutoFit();

                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.Borders.Color = ColorTranslator.ToOle(Color.Black);
                xlWorksheet.Columns.AutoFit();
                xlWorksheet.Rows.AutoFit();

                xlWorksheet.Columns[2].ColumnWidth = 16.00;

                xlPageSetUp = xlWorksheet.PageSetup;

                xlPageSetUp.Zoom = false;

                xlPageSetUp.FitToPagesWide = 1;

                xlPageSetUp.Orientation = Excel.XlPageOrientation.xlPortrait;
            }



            if ("Late" == "Late")
            {
                //xlWorksheet.Select(remakeSheet);
                xlWorkbook.Worksheets[3].Name = "ABSENCE AND LATES";

                xlWorksheet.Range["C:G"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                xlWorksheet.Range["A1:G1"].Merge();
                xlWorksheet.Range["A1"].Value2 = cmbStaff.Text + " - " + dteStart.Value.ToString("dd/MM/yyyy") + " to " + dteEnd.Value.ToString("dd/MM/yyyy");
                xlWorksheet.Range["A1"].Cells.Font.Size = 22;
                xlWorksheet.Range["A1:G1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //target formatting
                xlWorksheet.Range["E2:G2"].Merge();
                xlWorksheet.Range["E2"].Value2 = "LATE";
                xlWorksheet.Range["E2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorksheet.Range["E2"].Cells.Font.Size = 22;

                xlWorksheet.Range["E3:G3"].Merge();
                xlWorksheet.Range["E3"].Value2 = lblLate.Text;
                xlWorksheet.Range["E3"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlWorksheet.Range["E3"].Cells.Font.Size = 22;

                //headers
                xlWorksheet.Range["E4"].Value2 = "Late Date";
                xlWorksheet.Range["F4"].Value2 = "Day of Week";
                xlWorksheet.Range["G4"].Value2 = dgvLate.Columns[2].HeaderText;

                xlWorksheet.Range["E:E"].NumberFormat = "dd/MM/yyyy";

                //loop through the dgv and add to the table

                int current_excel_row = 5;

                for (int i = 0; i < dgvLate.Rows.Count; i++)
                {
                    xlWorksheet.Cells[5][current_excel_row].Value2 = dgvLate.Rows[i].Cells[0].Value;
                    xlWorksheet.Cells[6][current_excel_row].Value2 = dgvLate.Rows[i].Cells[1].Value.ToString();
                    xlWorksheet.Cells[7][current_excel_row].Value2 = dgvLate.Rows[i].Cells[2].Value.ToString();

                    current_excel_row++;
                }

                Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[3];
                Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
                ws.Columns.AutoFit();
                ws.Rows.AutoFit();

                current_excel_row--;

                xlWorksheet.Range["E1:G" + current_excel_row.ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range["E1:G" + current_excel_row.ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);
                xlWorksheet.Columns.AutoFit();
                xlWorksheet.Rows.AutoFit();

                xlWorksheet.Columns[2].ColumnWidth = 16.00;
                xlWorksheet.Columns[3].ColumnWidth = 16.00;
                xlWorksheet.Columns[6].ColumnWidth = 16.00;
                xlWorksheet.Columns[7].ColumnWidth = 10.00;

                xlPageSetUp = xlWorksheet.PageSetup;
                xlPageSetUp.Zoom = false;

                xlPageSetUp.FitToPagesWide = 1;

                xlPageSetUp.Orientation = Excel.XlPageOrientation.xlPortrait;
            }





            xlPageSetUp = xlWorksheet.PageSetup;
            xlPageSetUp.Zoom = false;
            xlPageSetUp.FitToPagesWide = 1;
            xlPageSetUp.Orientation = Excel.XlPageOrientation.xlPortrait;
            xlWorkbook.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);


            xlWorkbook.Close(false); //close the excel sheet without saving 
            xlApp.Quit();

            // Now find the process id that was created, and store it. 
            int processID = 0;
            foreach (Process process in processesAfter)
            {
                if (!processesBefore.Select(p => p.Id).Contains(process.Id))
                    processID = process.Id;
            }

            // And now kill the process we opened earlier. 
            if (processID != 0)
            {
                Process process = Process.GetProcessById(processID);
                process.Kill();
            }

            Process.Start(fileName);

        }
    }
}

