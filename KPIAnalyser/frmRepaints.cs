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
using System.IO;
using System.Diagnostics;

namespace KPIAnalyser
{
    public partial class frmRepaints : Form 
    {
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public int dept_only { get; set; }
        public int staff_only { get; set; }
        public string dept { get; set; }
        public string staff { get; set; }
        public frmRepaints(DateTime _dateStart, DateTime _dateEnd, int _dept_only, string _dept, int _staff_only, string _staff)
        {
            InitializeComponent();
            dateStart = _dateStart;
            dateEnd = _dateEnd;
            dept_only = _dept_only;
            staff_only = _staff_only;
            staff = _staff;
            dept = _dept;
            if (dept_only == -1)
                lblTitle.Text = dept + " Repaints From: " + dateStart.ToString("dd/MM/yyyy") + " to " + dateEnd.ToString("dd/MM/yyyy");
            else if (staff_only == -1)
                lblTitle.Text = "Repaints caused by " + _staff + " From: " + dateStart.ToString("dd/MM/yyyy") + " to " + dateEnd.ToString("dd/MM/yyyy");
            else
                lblTitle.Text = "Repaints From: " + dateStart.ToString("dd/MM/yyyy") + " to " + dateEnd.ToString("dd/MM/yyyy");
            apply_filter();
            fill_grid();
            this.WindowState = FormWindowState.Maximized;
        }

        private void apply_filter()
        {
            string sql = "select d.id as [Door ID],r.reason_for_repaint as [Repaint Reason],u_logged.forename + ' ' + u_logged.surname as [Logged By],r.date_logged as [Log Date],s.[NAME] as [Customer],COALESCE(u_fault.forename + ' ' + u_fault.surname,'N/A') as [Person Responsible]," +
                "dept.department_name as [Department Responsible],COALESCE(round(r.repaint_cost,2),0) as [Repaint Cost] from dbo.door d " +
                "right join dbo.repaints r on r.door_id = d.id " +
                "left join [user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                "left join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref " +
                "left join[dsl_kpi].dbo.department dept on dept.id = r.department " +
                "left join dbo.door_type dt on d.door_type_id = dt.id " +
                "left join [user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id " +
                "WHERE  date_logged >= '" + dateStart.ToString("yyyy-MM-dd") + "' AND date_logged < '" + dateEnd.ToString("yyyy-MM-dd") + "' AND (slimline_y_n = 0 or slimline_y_n is null) ";

            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
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
                    using (SqlCommand cmd = new SqlCommand("select id from [dsl_kpi].dbo.[department] where department_name = '" + cmbDeptResponsible.Text + "'", conn))
                    {
                        var temp = Convert.ToString(cmd.ExecuteScalar());
                        sql = sql + " AND r.department = " + temp.ToString();
                    }
                }
                if (cmbCustomer.Text.Length > 0)
                {
                    sql = sql + " AND s.[NAME] = '" + cmbCustomer.Text.ToString() + "'";
                }
                if (dept_only == -1)
                {
                    sql = sql + " AND dept.department_name = '" + dept + "' ";
                }
                if (staff_only == -1)
                {
                    if (staff == "N/A")
                        sql = sql + " AND r.painter_name = 0 ";
                    else
                        sql = sql + " AND  u_fault.forename + ' ' + u_fault.surname = '" + staff + "'";
                }
                sql = sql + " ORDER BY r.date_logged asc,d.id asc";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    format();
                }
                conn.Close();
            }
        }

        private void format()
        {
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            double costTotal = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                costTotal = costTotal + Convert.ToDouble(row.Cells[7].Value);
            }
            lblTotal.Text = "TOTAL: £" + costTotal.ToString();
        }

        private void frmRepaints_Shown(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
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

        private void cmbPersonResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
            fill_grid();
        }

        private void cmbDeptResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
            fill_grid();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
            fill_grid();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbPersonResponsible.Text = "";
            cmbDeptResponsible.Text = "";
            cmbCustomer.Text = "";
            apply_filter();
            fill_grid();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.Cells[1].Value = row.Cells[1].Value.ToString().Replace("\n", "").Replace("\r", " - ");

            Process[] processesBefore = Process.GetProcessesByName("excel");

            //unformat the grid because it causes big issues
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //
            int customer_index = 0;
            customer_index = dataGridView1.Columns["Customer"].Index;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string temp = dataGridView1.Rows[i].Cells[customer_index].Value.ToString();
                temp = temp.Trim();
                dataGridView1.Rows[i].Cells[customer_index].Value = temp;
            }

            string FileName = @"C:\temp\temp" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".xls";
             
            // Copy DataGridView results to clipboard
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.SelectAll();

            DataObject dataObj = dataGridView1.GetClipboardContent();
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
            xlWorkSheet.Range["A1:H1"].Merge();
            xlWorkSheet.Range["A2:H2"].AutoFilter(1);
            xlWorkSheet.Range["A1"].Value2 = "" + lblTitle.Text;
            xlWorkSheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.Range["A1"].Cells.Font.Size = 22;
            xlWorkSheet.Columns[2].ColumnWidth = 98.14;
            xlWorkSheet.Columns[2].WrapText = true;
            xlWorkSheet.Range["H1:H300"].NumberFormat = "£#,###,###.00";

            xlWorkSheet.Range["H" + (dataGridView1.Rows.Count + 3).ToString()].Value2 = "=SUBTOTAL(9,H3:H" + (dataGridView1.Rows.Count + 2).ToString() + ")";
            xlWorkSheet.Range["H" + (dataGridView1.Rows.Count + 3).ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlWorkSheet.Range["H" + (dataGridView1.Rows.Count + 3).ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);


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
            dataGridView1.ClearSelection();

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

        private void btnEmail_Click(object sender, EventArgs e)
        {
            //upload the current datagrid into the table ready to email
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmdWipe = new SqlCommand("DELETE FROM dbo.repaint_data_email", conn);
            cmdWipe.ExecuteNonQuery();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string sql = "INSERT INTO dbo.repaint_data_email (door_id,repaint_description,log_date,customer,person_responsible,department_responsible,cost) " +
                    "VALUES ('" + row.Cells[0].Value.ToString() + "','" + row.Cells[1].Value.ToString() + "','" + Convert.ToDateTime(row.Cells[2].Value.ToString()).ToString("dd/MM/yyyy") + "','" + row.Cells[3].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "'," +
                    "'" + row.Cells[5].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "')";
                using (SqlCommand cmdInsert = new SqlCommand(sql, conn))
                {
                    cmdInsert.ExecuteNonQuery();
                }
            }

            SqlCommand cmd = new SqlCommand("usp_repaint_data_email", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@title", SqlDbType.Date).Value = lblTitle.Text;
            cmd.Parameters.AddWithValue("@total", SqlDbType.Date).Value = lblTotal.Text;
            cmd.ExecuteNonQuery();

            MessageBox.Show("Email Sent", "", MessageBoxButtons.OK);

            conn.Close();
        }

        private void fill_grid()
        {
            string sql = "select COALESCE(max(u_painter_name.forename) + ' ' + max(u_painter_name.surname),'N/A') as [Person Responsible],count(painter_name) as [Number of Repaints],'£' + CAST(round(sum(COALESCE(repaint_cost,0)), 2) as nvarchar(max)) as [Total Cost] " +
                "from dbo.repaints" +
                " left join [user_info].dbo.[user] u_painter_name on u_painter_name.id = painter_name " +
                "left join[dsl_kpi].dbo.department d on d.id = repaints.department " +
                "LEFT join dbo.door door on door.id = dbo.repaints.door_id " +
                "left join dbo.SALES_LEDGER s on s.ACCOUNT_REF = door.customer_acc_ref " +
                "WHERE CAST(date_logged as date) >= '" + dateStart.ToString("yyyy-MM-dd") + "' AND CAST(date_logged as date) <= '" + dateEnd.ToString("yyyy-MM-dd") + "' ";
            ////////////////////////////
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
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
                    using (SqlCommand cmd = new SqlCommand("select id from [dsl_kpi].dbo.[department] where department_name = '" + cmbDeptResponsible.Text + "'", conn))
                    {
                        var temp = Convert.ToString(cmd.ExecuteScalar());
                        sql = sql + " AND dbo.repaints.department = " + temp.ToString();
                    }
                }
                if (cmbCustomer.Text.Length > 0)
                {
                    sql = sql + " AND s.[NAME] = '" + cmbCustomer.Text.ToString() + "'";
                }
                /////////////////////////////
                //check for dept
                if (dept_only == -1)
                {
                    sql = sql + " and d.department_name = '" + dept + "'";
                }
                if (staff_only == -1)
                {
                    sql = sql + " AND  u_painter_name.forename + ' ' + u_painter_name.surname = '" + staff + "'";
                }
                sql = sql + " group by painter_name order by count(painter_name) desc";


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (staff_only != -1)
                    {
                        DataRow toInsert = dt.NewRow();
                        // insert in the desired place
                        dt.Rows.InsertAt(toInsert, dt.Rows.Count);
                        dt.Rows[dt.Rows.Count - 1][0] = "Totals:";
                        double totalCost = 0;
                        int totalRemake = 0;
                        for (int i = 0; i < dt.Rows.Count - 1; i++)
                        {
                            string temp = dt.Rows[i][2].ToString().Substring(1);
                            totalRemake = totalRemake + Convert.ToInt32(dt.Rows[i][1]);
                            totalCost = totalCost + Convert.ToDouble(temp);
                        }

                        dt.Rows[dt.Rows.Count - 1][1] = totalRemake;
                        dt.Rows[dt.Rows.Count - 1][2] = "£" + totalCost.ToString();
                    }
                    dgvStaff.DataSource = dt;
                    dgvStaff.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvStaff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvStaff.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvStaff.ClearSelection();
                }
            }
        }

    }
}
