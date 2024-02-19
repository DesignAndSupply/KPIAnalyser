using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace KPIAnalyser
{
    public partial class frmRemakeRepaintDepartmentGraph : Form
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string department { get; set; }
        public int repaint { get; set; }
        public int slimline { get; set; }
        public string repaint_or_remake { get; set; }
        List<string> staffList = new List<string>();


        public frmRemakeRepaintDepartmentGraph(DateTime _startDate, DateTime _endDate, string _department, int _repaint, int _slimline)
        {
            InitializeComponent();
            startDate = _startDate;
            endDate = _endDate;
            slimline = _slimline;
            department = _department;
            repaint = _repaint;

            if (repaint == -1)
            {
                repaint_or_remake = "Repaint";
                cmbDeptNoticed.Visible = false;
                lblDeptNoticed.Visible = false;
                cmbLoggedBy.Visible = false;
                lblLoggedBy.Visible = false;

            }
            else
                repaint_or_remake = "Remake";
            lblTitle.Text = department + " " + repaint_or_remake + "s: " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy");

            loadGraph();
            loadDGV();
            fillCombo();
        }

        private void loadGraph()
        {
            string sql = "";
            if (repaint == -1)
            {
                if (slimline == -1)
                {
                    sql = "select COALESCE(u_fault.forename + ' ' + u_fault.surname,'N/A') as [Person Responsible],sum(COALESCE(round(r.repaint_cost,2),0)) as [Repaint Cost] from dbo.door d " +
                        "right join dbo.repaints r on r.door_id = d.id " +
                        "left join[user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                        "left join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref " +
                        "left join[dsl_kpi].dbo.department dept on dept.id = r.department " +
                        "left join[user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id " +
                        "left join dbo.door_type dt on d.door_type_id = dt.id " +
                        "WHERE date_logged >= '" + startDate.ToString("yyyyMMdd") + "' AND date_logged < '" + endDate.ToString("yyyyMMdd") + "'  " +
                        "AND dept.department_name = '" + department + "' AND (slimline_y_n = -1) " +
                        "group by COALESCE(u_fault.forename + ' ' + u_fault.surname, 'N/A') " +
                        "order by  sum(COALESCE(round(r.repaint_cost, 2), 0)) desc";
                }
                else
                {
                    sql = "select COALESCE(u_fault.forename + ' ' + u_fault.surname,'N/A') as [Person Responsible],sum(COALESCE(round(r.repaint_cost,2),0)) as [Repaint Cost] from dbo.door d " +
                        "right join dbo.repaints r on r.door_id = d.id " +
                        "left join[user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                        "left join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref " +
                        "left join[dsl_kpi].dbo.department dept on dept.id = r.department " +
                        "left join[user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id " +
                        "left join dbo.door_type dt on d.door_type_id = dt.id " +
                        "WHERE date_logged >= '" + startDate.ToString("yyyyMMdd") + "' AND date_logged < '" + endDate.ToString("yyyyMMdd") + "'  " +
                        "AND dept.department_name = '" + department + "' AND (slimline_y_n = 0 or slimline_y_n is null) " +
                        "group by COALESCE(u_fault.forename + ' ' + u_fault.surname, 'N/A') " +
                        "order by  sum(COALESCE(round(r.repaint_cost, 2), 0)) desc";
                }
            }
            else
            {
                if (slimline == -1)
                {
                    sql = "select coalesce(u.forename + ' ' + u.surname,'') as [Person Responsible],sum(coalesce(cost, 0)) as Cost from dbo.remake left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                        "left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref " +
                        "left join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                        "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible " +
                        "left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                        "left join dbo.door_type dt on door.door_type_id = dt.id " +
                        "where [date] >= '" + startDate.ToString("yyyyMMdd") + "' AND[date] < '" + endDate.ToString("yyyyMMdd") + "' " +
                        "and d1.department_name = '" + department + "' AND (slimline_y_n = -1) " +
                        "group by coalesce(u.forename + ' ' + u.surname, '') order by sum(coalesce(cost, 0)) desc";
                }
                else
                {
                    sql = "select coalesce(u.forename + ' ' + u.surname,'') as [Person Responsible],sum(coalesce(cost, 0)) as Cost from dbo.remake left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                        "left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref " +
                        "left join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                        "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible " +
                        "left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                        "left join dbo.door_type dt on door.door_type_id = dt.id " +
                        "where [date] >= '" + startDate.ToString("yyyyMMdd") + "' AND[date] < '" + endDate.ToString("yyyyMMdd") + "' " +
                        "and d1.department_name = '" + department + "' AND (slimline_y_n = 0 or slimline_y_n is null) " +
                        "group by coalesce(u.forename + ' ' + u.surname, '') order by sum(coalesce(cost, 0)) desc";
                }
            }

            //fill the graph with data
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                if (1 == 1) //repaints
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DateTime> datelist = new List<DateTime>();
                    List<double> repaint_cost = new List<double>();
                    List<string> department = new List<string>();



                    while (reader.Read())
                    {
                        //datelist.Add(reader.GetDateTime(1));
                        department.Add(reader.GetString(0));
                        staffList.Add(reader.GetString(0));
                        repaint_cost.Add(reader.GetDouble(1));
                    }

                    reader.Close();
                    //string[] datearray = datelist.ToArray();
                    double[] itemarray = repaint_cost.ToArray();

                    repaintRemakeChart.AxisY.Clear();
                    repaintRemakeChart.AxisX.Clear();

                    if (repaint == -1)
                    {
                        repaintRemakeChart.Series = new SeriesCollection{
                    new ColumnSeries
                    {
                        Title = "Repaint Cost",
                        FontSize = 10,
                        DataLabels = true,
                        Fill = System.Windows.Media.Brushes.LightSkyBlue,

                        Values = new ChartValues<double>(itemarray)
                    }};
                    }
                    else
                    {
                        repaintRemakeChart.Series = new SeriesCollection{
                    new ColumnSeries
                    {
                        Title = "Remake Cost",
                        FontSize = 10,
                        DataLabels = true,
                        Fill = System.Windows.Media.Brushes.PaleVioletRed,

                        Values = new ChartValues<double>(itemarray)
                    }};
                    }

                    repaintRemakeChart.AxisX.Add(new Axis
                    {
                        Title = "Staff",
                        FontSize = 13,
                        Foreground = System.Windows.Media.Brushes.Black,
                        Labels = department
                    });

                    repaintRemakeChart.AxisY.Add(new Axis
                    {
                        Title = repaint_or_remake + " Value",
                        FontSize = 16,

                    });
                } //repaints
                conn.Close();
            }
        }

        private void loadDGV()
        {
            string sql = "";

            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                if (repaint == -1)
                {
                    if (slimline == -1)
                    {
                        sql = "select d.id as [Door ID],r.reason_for_repaint as [Repaint Reason],u_logged.forename + ' ' + u_logged.surname as [Logged By],r.date_logged as [Log Date],s.[NAME] as [Customer],COALESCE(u_fault.forename + ' ' + u_fault.surname,'N/A') as [Person Responsible], " +
                            "dept.department_name as [Department Responsible],COALESCE(round(r.repaint_cost,2),0) as [Repaint Cost] from dbo.door d " +
                            "right join dbo.repaints r on r.door_id = d.id  " +
                            "left join [user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                            "left join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref  " +
                            "left join[dsl_kpi].dbo.department dept on dept.id = r.department  " +
                            "left join [user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id  " +
                            "left join dbo.door_type dt on d.door_type_id = dt.id " +
                            "WHERE  date_logged >= '" + startDate.ToString("yyyyMMdd") + "' AND date_logged < '" + endDate.ToString("yyyyMMdd") + "' " +
                            "AND (dt.slimline_y_n = -1) " +
                            "and dept.department_name = '" + department + "'";
                    }
                    else
                    {
                        sql = "select d.id as [Door ID],r.reason_for_repaint as [Repaint Reason],u_logged.forename + ' ' + u_logged.surname as [Logged By],r.date_logged as [Log Date],s.[NAME] as [Customer],COALESCE(u_fault.forename + ' ' + u_fault.surname,'N/A') as [Person Responsible], " +
                            "dept.department_name as [Department Responsible],COALESCE(round(r.repaint_cost,2),0) as [Repaint Cost] from dbo.door d " +
                            "right join dbo.repaints r on r.door_id = d.id  " +
                            "left join [user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                            "left join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref  " +
                            "left join[dsl_kpi].dbo.department dept on dept.id = r.department  " +
                            "left join [user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id  " +
                            "left join dbo.door_type dt on d.door_type_id = dt.id " +
                            "WHERE  date_logged >= '" + startDate.ToString("yyyyMMdd") + "' AND date_logged < '" + endDate.ToString("yyyyMMdd") + "' " +
                            "AND (dt.slimline_y_n = 0 or dt.slimline_y_n is null) " +
                            "and dept.department_name = '" + department + "'";
                    }
                    if (cmbPersonResponsible.Text.Length > 0)
                    {
                        //work out which user it is 
                        using (SqlCommand cmd = new SqlCommand("Select id from [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbPersonResponsible.Text + "'", conn))
                        {
                            int temp = Convert.ToInt32(cmd.ExecuteScalar());
                            sql = sql + " AND [painter_name] = " + temp.ToString();
                        }
                    }
                    if (cmbDeptResponsible.Text.Length > 0)
                    {
                        //work out which user it is 
                        using (SqlCommand cmd = new SqlCommand("select id from [dsl_kpi].dbo.[department] where department_name = '" + cmbPersonResponsible.Text + "'", conn))
                        {
                            var temp = Convert.ToString(cmd.ExecuteScalar());
                            sql = sql + " AND r.department = " + temp.ToString();
                        }
                    }
                    if (cmbCustomer.Text.Length > 0)
                    {
                        sql = sql + " AND s.[NAME] = '" + cmbCustomer.Text.ToString() + "'";
                    }
                    sql = sql + " ORDER BY r.date_logged asc,d.id asc";
                }
                else
                {
                    if (slimline == -1)
                    {
                        sql = "select dbo.remake.door_id as [Door ID],[User] as [Logged By],[description] as [Remake Description],[date] as [Log Date],[NAME] as Customer," +
                            "coalesce(u.forename + ' ' + u.surname,'') as [Person Responsible]," +
                            "d1.department_name as [Department Responsible] ,d2.department_name as [Department Noticed] ,coalesce(cost, 0) as Cost " +
                            "from dbo.remake " +
                            "left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                            "left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref " +
                            "left join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                            "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible " +
                            "left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                            "left join dbo.door_type dt on door.door_type_id = dt.id " +
                            "where [date] >= '" + startDate.ToString("yyyyMMdd") + "' AND[date] < '" + endDate.ToString("yyyyMMdd") + "' " +
                            "AND d1.department_name = '" + department + "' AND (dt.slimline_y_n = -1) ";
                    }
                    else
                    {
                        sql = "select dbo.remake.door_id as [Door ID],[User] as [Logged By],[description] as [Remake Description],[date] as [Log Date],[NAME] as Customer," +
                            "coalesce(u.forename + ' ' + u.surname,'') as [Person Responsible]," +
                            "d1.department_name as [Department Responsible] ,d2.department_name as [Department Noticed] ,coalesce(cost, 0) as Cost " +
                            "from dbo.remake " +
                            "left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                            "left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref " +
                            "left join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                            "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible " +
                            "left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                            "left join dbo.door_type dt on door.door_type_id = dt.id " +
                            "where [date] >= '" + startDate.ToString("yyyyMMdd") + "' AND[date] < '" + endDate.ToString("yyyyMMdd") + "' " +
                            "AND d1.department_name = '" + department + "' AND (dt.slimline_y_n = 0 or dt.slimline_y_n is null) ";
                    }
                    if (cmbLoggedBy.Text.Length > 0)
                        sql = sql + " AND [user] = '" + cmbLoggedBy.Text.ToString() + "'";

                    if (cmbPersonResponsible.Text.Length > 0)
                    {
                        //work out which user it is 
                        using (SqlCommand cmd = new SqlCommand("Select id from [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbPersonResponsible.Text + "'", conn))
                        {
                            int temp = Convert.ToInt32(cmd.ExecuteScalar());
                            sql = sql + " AND [persons_responsible] = " + temp.ToString();
                        }
                    }

                    if (cmbDeptResponsible.Text.Length > 0)
                    {
                        //work out which user it is 
                        using (SqlCommand cmd = new SqlCommand("select id from [dsl_kpi].dbo.[department] where department_name = '" + cmbDeptResponsible.Text + "'", conn))
                        {
                            var temp = Convert.ToString(cmd.ExecuteScalar());
                            sql = sql + " AND [dept_responsible] = " + temp.ToString();
                        }
                    }

                    if (cmbDeptNoticed.Text.Length > 0)
                    {
                        //work out which user it is 
                        using (SqlCommand cmd = new SqlCommand("select id from [dsl_kpi].dbo.[department] where department_name = '" + cmbDeptNoticed.Text + "'", conn))
                        {
                            var temp = Convert.ToString(cmd.ExecuteScalar());
                            sql = sql + " AND [dept_noticed] = " + temp.ToString();
                        }
                    }

                    if (cmbCustomer.Text.Length > 0)
                        sql = sql + " AND dbo.SALES_LEDGER.[NAME] = '" + cmbCustomer.Text.ToString() + "'";

                    sql = sql + " ORDER BY [DATE] asc, dbo.remake.door_id asc";
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRemakesRepaints.DataSource = dt;
                }
                conn.Close();

                if (repaint == -1)
                    formatPaint();
                else
                    format();
            }
        }

        private void formatPaint()
        {
            dgvRemakesRepaints.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRemakesRepaints.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewColumn col in dgvRemakesRepaints.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
            dgvRemakesRepaints.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            double costTotal = 0;
            foreach (DataGridViewRow row in dgvRemakesRepaints.Rows)
            {
                costTotal = costTotal + Convert.ToDouble(row.Cells[7].Value);
            }
            lblTotal.Text = "TOTAL: £" + costTotal.ToString();
        }

        private void format()
        {
            dgvRemakesRepaints.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRemakesRepaints.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakesRepaints.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewColumn col in dgvRemakesRepaints.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            dgvRemakesRepaints.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            double costTotal = 0;
            foreach (DataGridViewRow row in dgvRemakesRepaints.Rows)
            {
                costTotal = costTotal + Convert.ToDouble(row.Cells[8].Value);
            }
            lblTotal.Text = "TOTAL: £" + costTotal.ToString();
        }

        private void fillCombo()
        {
            if (repaint == 0)
            {
                foreach (DataGridViewRow row in dgvRemakesRepaints.Rows)
                {
                    if (cmbLoggedBy.Items.Contains(row.Cells[1].Value.ToString()))
                    { } //nothing
                    else
                        cmbLoggedBy.Items.Add(row.Cells[1].Value.ToString());

                    if (cmbPersonResponsible.Items.Contains(row.Cells[5].Value.ToString()))
                    { } //nothing
                    else
                        cmbPersonResponsible.Items.Add(row.Cells[5].Value.ToString());

                    if (cmbDeptResponsible.Items.Contains(row.Cells[6].Value.ToString()))
                    { } //nothing
                    else
                        cmbDeptResponsible.Items.Add(row.Cells[6].Value.ToString());

                    if (cmbDeptNoticed.Items.Contains(row.Cells[7].Value.ToString()))
                    { } //nothing
                    else
                        cmbDeptNoticed.Items.Add(row.Cells[7].Value.ToString());

                    if (cmbCustomer.Items.Contains(row.Cells[4].Value.ToString()))
                    { } //nothing
                    else
                        cmbCustomer.Items.Add(row.Cells[4].Value.ToString());
                }
            }
            else
            {

                foreach (DataGridViewRow row in dgvRemakesRepaints.Rows)
                {

                    if (cmbPersonResponsible.Items.Contains(row.Cells[5].Value.ToString()))
                    { } //nothing
                    else
                        cmbPersonResponsible.Items.Add(row.Cells[5].Value.ToString());

                    if (cmbDeptResponsible.Items.Contains(row.Cells[6].Value.ToString()))
                    { } //nothing
                    else
                        cmbDeptResponsible.Items.Add(row.Cells[6].Value.ToString());

                    if (cmbCustomer.Items.Contains(row.Cells[4].Value.ToString()))
                    { } //nothing
                    else
                        cmbCustomer.Items.Add(row.Cells[4].Value.ToString());
                }
            }
        }

        private void cmbDeptNoticed_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void cmbLoggedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void cmbPersonResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void cmbDeptResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbDeptNoticed.Text = "";
            cmbLoggedBy.Text = "";
            cmbPersonResponsible.Text = "";
            cmbDeptResponsible.Text = "";
            cmbCustomer.Text = "";
            loadDGV();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (repaint == -1)
                excelRepaint();
            else
                excelRemake();
        }

        private void excelRepaint()
        {
            foreach (DataGridViewRow row in dgvRemakesRepaints.Rows)
                row.Cells[1].Value = row.Cells[1].Value.ToString().Replace("\n", "").Replace("\r", " - ");

            Process[] processesBefore = Process.GetProcessesByName("excel");

            //unformat the grid because it causes big issues
            foreach (DataGridViewColumn col in dgvRemakesRepaints.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
            dgvRemakesRepaints.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //
            int customer_index = 0;
            customer_index = dgvRemakesRepaints.Columns["Customer"].Index;

            for (int i = 0; i < dgvRemakesRepaints.Rows.Count; i++)
            {
                string temp = dgvRemakesRepaints.Rows[i].Cells[customer_index].Value.ToString();
                temp = temp.Trim();
                dgvRemakesRepaints.Rows[i].Cells[customer_index].Value = temp;
            }

            string FileName = @"C:\temp\temp" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".xls";

            // Copy DataGridView results to clipboard
            dgvRemakesRepaints.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvRemakesRepaints.SelectAll();

            DataObject dataObj = dgvRemakesRepaints.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

            xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Format column D as text before pasting results, this was required for my data
            Microsoft.Office.Interop.Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
            rng.NumberFormat = "@";

            // Get Excel processes after opening the file. 
            Process[] processesAfter = Process.GetProcessesByName("excel");


            // Paste clipboard results to worksheet range
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
            // Delete blank column A and select cell A1
            //Microsoft.Office.Interop.Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
            //delRng.Delete(Type.Missing);
            xlWorkSheet.get_Range("A2").Select();

            Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
            //ws.Columns.ClearFormats();
            //ws.Rows.ClearFormats();
            //range.EntireColumn.AutoFit();
            //range.EntireRow.AutoFit();
            xlWorkSheet.Range["A2:H2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
            xlWorkSheet.Range["A2:H2"].AutoFilter(1);

            xlWorkSheet.Range["A1:D1"].Merge();
            xlWorkSheet.Range["A1"].Value2 = "Repaints " + lblTitle.Text;
            xlWorkSheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            xlWorkSheet.Range["A1"].Cells.Font.Size = 22;

            xlWorkSheet.Range["E1:H1"].Merge();
            xlWorkSheet.Range["E1"].Value2 = "Report Generated on: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            xlWorkSheet.Range["E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            xlWorkSheet.Range["E1"].Cells.Font.Size = 22;


            xlWorkSheet.Columns[2].ColumnWidth = 98.14;
            xlWorkSheet.Columns[2].WrapText = true;
            xlWorkSheet.Range["H2:H3000"].NumberFormat = "£#,###,###.00";


            xlWorkSheet.Range["H" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Value2 = "=SUBTOTAL(9,H3:H" + (dgvRemakesRepaints.Rows.Count + 2).ToString() + ")";
            xlWorkSheet.Range["H" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlWorkSheet.Range["H" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);

            ws.Columns.AutoFit();
            ws.Rows.AutoFit();
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);

            // Save the excel file under the captured location from the SaveFileDialog
            xlWorkBook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlexcel.DisplayAlerts = true;
            xlWorkBook.Close(true, misValue, misValue);
            xlexcel.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlexcel);

            // Clear Clipboard and DataGridView selection
            Clipboard.Clear();
            dgvRemakesRepaints.ClearSelection();

            // Open the newly saved excel file
            if (File.Exists(FileName))
                System.Diagnostics.Process.Start(FileName);

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks workbooks;
            Microsoft.Office.Interop.Excel.Workbook excelBook;

            //app = null;
            //app = new Excel.Application(); // create a new instance
            excelApp.DisplayAlerts = false; //turn off annoying alerts that make me want to cryyyy

            workbooks = excelApp.Workbooks;
            excelBook = workbooks.Add(FileName);
            Microsoft.Office.Interop.Excel.Sheets sheets = excelBook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)(sheets[1]);

            //Range.Rows.AutoFit();
            //Range.Columns.AutoFit();

            excelApp.Quit();
            // Now find the process id that was created, and store it. 
            int processID = 0;
            foreach (Process process in processesAfter)
            {
                if (!processesBefore.Select(p => p.Id).Contains(process.Id))
                {
                    processID = process.Id;
                    // And now kill the process. 
                    if (processID != 0)
                    {
                        Process process2 = Process.GetProcessById(processID);
                        process2.Kill();
                    }
                }
            }
        }

        private void excelRemake()
        {
            //remove new line character from the dgv
            foreach (DataGridViewRow row in dgvRemakesRepaints.Rows)
                row.Cells[2].Value = row.Cells[2].Value.ToString().Replace("\n", "").Replace("\r", " - ");

            int customer_index = 0;
            customer_index = dgvRemakesRepaints.Columns["Customer"].Index;

            for (int i = 0; i < dgvRemakesRepaints.Rows.Count; i++)
            {
                string temp = dgvRemakesRepaints.Rows[i].Cells[customer_index].Value.ToString();
                temp = temp.Trim();
                dgvRemakesRepaints.Rows[i].Cells[customer_index].Value = temp;
            }

            string FileName = @"C:\temp\temp" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".xls";

            // Copy DataGridView results to clipboard
            dgvRemakesRepaints.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvRemakesRepaints.SelectAll();

            DataObject dataObj = dgvRemakesRepaints.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

            xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Format column D as text before pasting results, this was required for my data
            Microsoft.Office.Interop.Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
            rng.NumberFormat = "@";

            // Paste clipboard results to worksheet range
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
            // Delete blank column A and select cell A1
            //Microsoft.Office.Interop.Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
            //delRng.Delete(Type.Missing);
            xlWorkSheet.get_Range("A2").Select();

            Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
            //ws.Columns.ClearFormats();
            //ws.Rows.ClearFormats();
            //range.EntireColumn.AutoFit();
            //range.EntireRow.AutoFit();

            xlWorkSheet.Range["A1:D1"].Merge();
            xlWorkSheet.Range["A1"].Value2 = lblTitle.Text;
            xlWorkSheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            xlWorkSheet.Range["A1"].Cells.Font.Size = 22;

            xlWorkSheet.Range["E1:I1"].Merge();
            xlWorkSheet.Range["E1"].Value2 = "Report Generated on: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            xlWorkSheet.Range["E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            xlWorkSheet.Range["E1"].Cells.Font.Size = 22;

            xlWorkSheet.Range["A2:I2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
            xlWorkSheet.Range["A2:I2"].AutoFilter(1);
            xlWorkSheet.Columns[2].ColumnWidth = 98.14;
            xlWorkSheet.Columns[2].WrapText = true;
            xlWorkSheet.Range["H2:H300"].NumberFormat = "£#,###,###.00";

            xlWorkSheet.Range["I" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Value2 = "=SUBTOTAL(9,I3:I" + (dgvRemakesRepaints.Rows.Count + 2).ToString() + ")";
            xlWorkSheet.Range["I" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlWorkSheet.Range["I" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);


            ws.Columns.AutoFit();
            ws.Rows.AutoFit();
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);

            // Save the excel file under the captured location from the SaveFileDialog
            xlWorkBook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlexcel.DisplayAlerts = true;
            xlWorkBook.Close(true, misValue, misValue);
            xlexcel.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlexcel);

            // Clear Clipboard and DataGridView selection
            Clipboard.Clear();
            dgvRemakesRepaints.ClearSelection();

            // Open the newly saved excel file
            if (File.Exists(FileName))
                System.Diagnostics.Process.Start(FileName);

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks workbooks;
            Microsoft.Office.Interop.Excel.Workbook excelBook;

            //app = null;
            //app = new Excel.Application(); // create a new instance
            excelApp.DisplayAlerts = false; //turn off annoying alerts that make me want to cryyyy
            uint processID = 0;

            workbooks = excelApp.Workbooks;
            excelBook = workbooks.Add(FileName);
            Microsoft.Office.Interop.Excel.Sheets sheets = excelBook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)(sheets[1]);

            //Range.Rows.AutoFit();
            //Range.Columns.AutoFit();
        }

        private void repaintRemakeChart_DataClick(object sender, ChartPoint p)
        {
            var asPixels = repaintRemakeChart.Base.ConvertToPixels(p.AsPoint());
            string staff = staffList[Convert.ToInt32(p.X)].ToString();
            cmbPersonResponsible.Text = staff;
            loadDGV();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            btnEmail.Visible = false;
            btnClear.Visible = false;
            btnPrint.Visible = false;
            btnPrintScreen.Visible = false;
            btnEmailExcel.Visible = false;

            Application.DoEvents();
            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\Chart.jpg");


            }
            catch
            {

            }
            btnPrint.Visible = true;
            btnClear.Visible = true;
            btnPrintScreen.Visible = true;
            btnEmail.Visible = true;
            btnEmailExcel.Visible = true;

            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "";
            mailItem.To = "";
            string imageSrc = @"C:\Temp\Chart.jpg"; // Change path as needed

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
        }
        private void printImage()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    System.Drawing.Image i = System.Drawing.Image.FromFile(@"C:\temp\chart.jpg");
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

        private void btnPrintScreen_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            btnEmail.Visible = false;
            btnClear.Visible = false;
            btnPrintScreen.Visible = false;
            btnEmailExcel.Visible = false;
            Application.DoEvents();
            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\Chart.jpg");
                printImage();

            }
            catch
            {

            }
            btnPrint.Visible = true;
            btnEmail.Visible = true;
            btnClear.Visible = true;
            btnPrintScreen.Visible = true;
            btnEmailExcel.Visible = true;
        }

        private void btnEmailExcel_Click(object sender, EventArgs e)
        {
            if (repaint == -1)
                excelRepaintEmail();
            else
                excelRemakeEmail();
        }

        private void excelRepaintEmail()
        {
            foreach (DataGridViewRow row in dgvRemakesRepaints.Rows)
                row.Cells[1].Value = row.Cells[1].Value.ToString().Replace("\n", "").Replace("\r", " - ");

            Process[] processesBefore = Process.GetProcessesByName("excel");

            //unformat the grid because it causes big issues
            foreach (DataGridViewColumn col in dgvRemakesRepaints.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
            dgvRemakesRepaints.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //
            int customer_index = 0;
            customer_index = dgvRemakesRepaints.Columns["Customer"].Index;

            for (int i = 0; i < dgvRemakesRepaints.Rows.Count; i++)
            {
                string temp = dgvRemakesRepaints.Rows[i].Cells[customer_index].Value.ToString();
                temp = temp.Trim();
                dgvRemakesRepaints.Rows[i].Cells[customer_index].Value = temp;
            }

            string FileName = @"C:\temp\Repaint_Data_" + DateTime.Now.ToString("mmss") + ".xls";

            // Copy DataGridView results to clipboard
            dgvRemakesRepaints.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvRemakesRepaints.SelectAll();

            DataObject dataObj = dgvRemakesRepaints.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

            xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Format column D as text before pasting results, this was required for my data
            Microsoft.Office.Interop.Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
            rng.NumberFormat = "@";

            // Get Excel processes after opening the file. 
            Process[] processesAfter = Process.GetProcessesByName("excel");


            // Paste clipboard results to worksheet range
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
            // Delete blank column A and select cell A1
            //Microsoft.Office.Interop.Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
            //delRng.Delete(Type.Missing);
            xlWorkSheet.get_Range("A2").Select();

            Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
            //ws.Columns.ClearFormats();
            //ws.Rows.ClearFormats();
            //range.EntireColumn.AutoFit();
            //range.EntireRow.AutoFit();
            xlWorkSheet.Range["A2:H2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
            xlWorkSheet.Range["A2:H2"].AutoFilter(1);

            xlWorkSheet.Range["A1:D1"].Merge();
            xlWorkSheet.Range["A1"].Value2 = "Repaints " + lblTitle.Text;
            xlWorkSheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            xlWorkSheet.Range["A1"].Cells.Font.Size = 22;

            xlWorkSheet.Range["E1:H1"].Merge();
            xlWorkSheet.Range["E1"].Value2 = "Report Generated on: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            xlWorkSheet.Range["E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            xlWorkSheet.Range["E1"].Cells.Font.Size = 22;


            xlWorkSheet.Columns[2].ColumnWidth = 98.14;
            xlWorkSheet.Columns[2].WrapText = true;
            xlWorkSheet.Range["H2:H3000"].NumberFormat = "£#,###,###.00";


            xlWorkSheet.Range["H" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Value2 = "=SUBTOTAL(9,H3:H" + (dgvRemakesRepaints.Rows.Count + 2).ToString() + ")";
            xlWorkSheet.Range["H" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlWorkSheet.Range["H" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);

            ws.Columns.AutoFit();
            ws.Rows.AutoFit();
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);

            // Save the excel file under the captured location from the SaveFileDialog
            xlWorkBook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlexcel.DisplayAlerts = true;
            xlWorkBook.Close(true, misValue, misValue);
            xlexcel.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlexcel);

            // Clear Clipboard and DataGridView selection
            Clipboard.Clear();
            dgvRemakesRepaints.ClearSelection();



            // Now find the process id that was created, and store it. 
            int processID = 0;
            foreach (Process process in processesAfter)
            {
                if (!processesBefore.Select(p => p.Id).Contains(process.Id))
                {
                    processID = process.Id;
                    // And now kill the process. 
                    if (processID != 0)
                    {
                        Process process2 = Process.GetProcessById(processID);
                        process2.Kill();
                    }
                }
            }
            ExcelEmail(FileName);

        }
        private void excelRemakeEmail()
        {

            //remove new line character from the dgv
            foreach (DataGridViewRow row in dgvRemakesRepaints.Rows)
                row.Cells[2].Value = row.Cells[2].Value.ToString().Replace("\n", "").Replace("\r", " - ");

            int customer_index = 0;
            customer_index = dgvRemakesRepaints.Columns["Customer"].Index;

            for (int i = 0; i < dgvRemakesRepaints.Rows.Count; i++)
            {
                string temp = dgvRemakesRepaints.Rows[i].Cells[customer_index].Value.ToString();
                temp = temp.Trim();
                dgvRemakesRepaints.Rows[i].Cells[customer_index].Value = temp;
            }

            string FileName = @"C:\temp\Remake_Data_" + DateTime.Now.ToString("mmss") + ".xls";

            // Copy DataGridView results to clipboard
            dgvRemakesRepaints.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvRemakesRepaints.SelectAll();

            DataObject dataObj = dgvRemakesRepaints.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

            xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Format column D as text before pasting results, this was required for my data
            Microsoft.Office.Interop.Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
            rng.NumberFormat = "@";

            // Paste clipboard results to worksheet range
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
            // Delete blank column A and select cell A1
            //Microsoft.Office.Interop.Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
            //delRng.Delete(Type.Missing);
            xlWorkSheet.get_Range("A2").Select();

            Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
            //ws.Columns.ClearFormats();
            //ws.Rows.ClearFormats();
            //range.EntireColumn.AutoFit();
            //range.EntireRow.AutoFit();

            xlWorkSheet.Range["A1:D1"].Merge();
            xlWorkSheet.Range["A1"].Value2 = lblTitle.Text;
            xlWorkSheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            xlWorkSheet.Range["A1"].Cells.Font.Size = 22;

            xlWorkSheet.Range["E1:I1"].Merge();
            xlWorkSheet.Range["E1"].Value2 = "Report Generated on: " + DateTime.Now.ToString("dd/MM/yyyy mm:ss");
            xlWorkSheet.Range["E1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            xlWorkSheet.Range["E1"].Cells.Font.Size = 22;

            xlWorkSheet.Range["A2:I2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
            xlWorkSheet.Range["A2:I2"].AutoFilter(1);
            xlWorkSheet.Columns[2].ColumnWidth = 98.14;
            xlWorkSheet.Columns[2].WrapText = true;
            xlWorkSheet.Range["H2:H300"].NumberFormat = "£#,###,###.00";

            xlWorkSheet.Range["I" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Value2 = "=SUBTOTAL(9,I3:I" + (dgvRemakesRepaints.Rows.Count + 2).ToString() + ")";
            xlWorkSheet.Range["I" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlWorkSheet.Range["I" + (dgvRemakesRepaints.Rows.Count + 3).ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);


            ws.Columns.AutoFit();
            ws.Rows.AutoFit();
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);

            // Save the excel file under the captured location from the SaveFileDialog
            xlWorkBook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlexcel.DisplayAlerts = true;
            xlWorkBook.Close(true, misValue, misValue);
            xlexcel.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlexcel);

            // Clear Clipboard and DataGridView selection
            Clipboard.Clear();
            dgvRemakesRepaints.ClearSelection();
            uint processID = 0;



            //Range.Rows.AutoFit();
            //Range.Columns.AutoFit();
            ExcelEmail(FileName);
        }

        private void ExcelEmail(string file)
        {
            int attach_image = 0;
            DialogResult result = MessageBox.Show("Would you like to attach a screenshot aswell?", "Attach Screenshot", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                System.Threading.Thread.Sleep(1000);
                attach_image = -1;
                btnEmail.Visible = false;
                btnClear.Visible = false;
                btnPrint.Visible = false;
                btnPrintScreen.Visible = false;
                btnEmailExcel.Visible = false;

                Application.DoEvents();
                try
                {
                    System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                    Graphics gs = Graphics.FromImage(bit);

                    gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                    bit.Save(@"C:\temp\Chart.jpg");


                }
                catch
                {

                }
                btnPrint.Visible = true;
                btnClear.Visible = true;
                btnPrintScreen.Visible = true;
                btnEmail.Visible = true;
                btnEmailExcel.Visible = true;
            }

            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "";
            mailItem.To = "";
            string imageSrc = @"C:\Temp\Chart.jpg"; // Change path as needed

            var attachments2 = mailItem.Attachments;
            var attachment2 = attachments2.Add(file);
            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            if (attach_image == -1)
            {
                var attachments = mailItem.Attachments;
                var attachment = attachments.Add(imageSrc);
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
                mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);
                mailItem.Attachments.Add(imageSrc);
            }
            // Set body format to HTML



            string msgHTMLBody = "";
            mailItem.HTMLBody = msgHTMLBody;
            mailItem.Display(false);
        }
    }
}
