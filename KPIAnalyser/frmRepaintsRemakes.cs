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
using System.Diagnostics;
using System.IO;

namespace KPIAnalyser
{

    public partial class frmRepaintsRemakes : Form
    {
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public frmRepaintsRemakes(DateTime _dateStart, DateTime _dateEnd)
        {
            dateStart = _dateStart;
            dateEnd = _dateEnd;
            InitializeComponent();
            lblTitle.Text = "From: " + dateStart.ToString("dd/MM/yyyy") + " to " + dateEnd.ToString("dd/MM/yyyy");
            this.WindowState = FormWindowState.Maximized;
            apply_filter();
        }


        private void apply_filter()
        {

            //remake
            string sql = "";

            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();

                sql = "select dbo.remake.door_id as [Door ID],[User] as [Logged By],[description] as [Remake Description],[date] as [Log Date],[NAME] as Customer,coalesce(u.forename + ' ' + u.surname,'') as [Person Responsible]," +
                "d1.department_name as [Department Responsible] ,d2.department_name as [Department Noticed] ,coalesce(cost, 0) as Cost from dbo.remake left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                "left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref left join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                "where [date] >= '" + dateStart.ToString("yyyyMMdd") + "' AND[date] < '" + dateEnd.ToString("yyyyMMdd") + "'";

                if (cmbLoggedBy.Text.Length > 0)
                {
                    //work out which user it is 
                    //using (SqlCommand cmd = new SqlCommand("Select id from [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbLoggedBy.Text + "'"))
                    //{
                    //    var temp = Convert.ToString(cmd.ExecuteScalar());
                    sql = sql + " AND [user] = '" + cmbLoggedBy.Text.ToString() + "'";
                    //}
                }

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
                {
                    //work out which user it is 
                    //using (SqlCommand cmd = new SqlCommand("SELECT ACCOUNT_REF from dbo.SALES_LEDGER where [NAME] = '" + cmbCustomer.Text + "'", conn))
                    //{
                    // var temp = Convert.ToString(cmd.ExecuteScalar());
                    sql = sql + " AND dbo.SALES_LEDGER.[NAME] = '" + cmbCustomer.Text.ToString() + "'";
                    //}
                }
                sql = sql + " ORDER BY [DATE] asc, dbo.remake.door_id asc";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRemakes.DataSource = dt;
                }
                sql = "select d.id as [Door ID],r.reason_for_repaint as [Repaint Reason],u_logged.forename + ' ' + u_logged.surname as [Logged By],r.date_logged as [Log Date],s.[NAME] as [Customer],COALESCE(u_fault.forename + ' ' + u_fault.surname,'N/A') as [Person Responsible]," +
                    "dept.department_name as [Department Responsible],COALESCE(round(r.repaint_cost,2),0) as [Repaint Cost] from dbo.door d " +
                    "right join dbo.repaints r on r.door_id = d.id " +
                    "left join [user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                    "left join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref " +
                    "left join[dsl_kpi].dbo.department dept on dept.id = r.department " +
                    "left join [user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id " +
                    "WHERE  date_logged >= '" + dateStart.ToString("yyyy-MM-dd") + "' AND date_logged < '" + dateEnd.ToString("yyyy-MM-dd") + "'";

                if (cmbPaintPersonResponsible.Text.Length > 0)
                {
                    //work out which user it is 
                    using (SqlCommand cmd = new SqlCommand("Select id from [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbPaintPersonResponsible.Text + "'", conn))
                    {
                        int temp = Convert.ToInt32(cmd.ExecuteScalar());
                        sql = sql + " AND [painter_name] = " + temp.ToString();
                    }
                }
                if (cmbPaintDeptResponsible.Text.Length > 0)
                {
                    //work out which user it is 
                    using (SqlCommand cmd = new SqlCommand("select id from [dsl_kpi].dbo.[department] where department_name = '" + cmbPaintDeptResponsible.Text + "'", conn))
                    {
                        var temp = Convert.ToString(cmd.ExecuteScalar());
                        sql = sql + " AND r.department = " + temp.ToString();
                    }
                }
                if (cmbPaintCustomer.Text.Length > 0)
                {
                    sql = sql + " AND s.[NAME] = '" + cmbPaintCustomer.Text.ToString() + "'";
                }
                sql = sql + " ORDER BY r.date_logged asc,d.id asc";


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRepaints.DataSource = dt;
                }
                conn.Close();
            }
            format();
            formatPaint();
        }

        private void formatPaint()
        {
            dgvRepaints.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRepaints.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRepaints.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRepaints.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRepaints.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRepaints.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRepaints.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRepaints.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewColumn col in dgvRepaints.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
            dgvRepaints.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            double costTotal = 0;
            foreach (DataGridViewRow row in dgvRepaints.Rows)
            {
                costTotal = costTotal + Convert.ToDouble(row.Cells[7].Value);
            }
            lblTotalPaint.Text = "TOTAL: £" + costTotal.ToString();
        }

        private void format()
        {
            dgvRemakes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakes.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRemakes.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakes.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakes.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakes.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakes.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRemakes.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewColumn col in dgvRemakes.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            dgvRemakes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            double costTotal = 0;
            foreach (DataGridViewRow row in dgvRemakes.Rows)
            {
                costTotal = costTotal + Convert.ToDouble(row.Cells[8].Value);
            }
            lblTotalRemake.Text = "TOTAL: £" + costTotal.ToString();
        }

        private void frmRepaintsRemakes_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRemakes.Rows)
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


            foreach (DataGridViewRow row in dgvRepaints.Rows)
            {

                if (cmbPaintPersonResponsible.Items.Contains(row.Cells[5].Value.ToString()))
                { } //nothing
                else
                    cmbPaintPersonResponsible.Items.Add(row.Cells[5].Value.ToString());

                if (cmbPaintDeptResponsible.Items.Contains(row.Cells[6].Value.ToString()))
                { } //nothing
                else
                    cmbPaintDeptResponsible.Items.Add(row.Cells[6].Value.ToString());

                if (cmbPaintCustomer.Items.Contains(row.Cells[4].Value.ToString()))
                { } //nothing
                else
                    cmbPaintCustomer.Items.Add(row.Cells[4].Value.ToString());
            }
        }

        private void cmbLoggedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbPersonResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbDeptResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbDeptNoticed_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbPaintPersonResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbPaintDeptResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbPaintCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbLoggedBy.Text = "";
            cmbPersonResponsible.Text = "";
            cmbDeptResponsible.Text = "";
            cmbDeptNoticed.Text = "";
            cmbCustomer.Text = "";
            apply_filter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbPaintCustomer.Text = "";
            cmbPaintDeptResponsible.Text = "";
            cmbPaintPersonResponsible.Text = "";
            apply_filter();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //remove new line character from the dgv
            foreach (DataGridViewRow row in dgvRemakes.Rows)
                row.Cells[2].Value = row.Cells[2].Value.ToString().Replace("\n", "").Replace("\r", " - ");



            int customer_index = 0;
            customer_index = dgvRemakes.Columns["Customer"].Index;

            for (int i = 0; i < dgvRemakes.Rows.Count; i++)
            {
                string temp = dgvRemakes.Rows[i].Cells[customer_index].Value.ToString();
                temp = temp.Trim();
                dgvRemakes.Rows[i].Cells[customer_index].Value = temp;
            }

            string FileName = @"C:\temp\temp" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".xls";
             
            // Copy DataGridView results to clipboard
            dgvRemakes.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvRemakes.SelectAll();

            DataObject dataObj = dgvRemakes.GetClipboardContent();
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
            xlWorkSheet.Range["A1:I1"].Merge();
            xlWorkSheet.Range["A1"].Value2 = "Remakes " + lblTitle.Text;
            xlWorkSheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.Range["A1"].Cells.Font.Size = 22;

            xlWorkSheet.Range["A2:I2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
            xlWorkSheet.Range["A2:I2"].AutoFilter(1);
            xlWorkSheet.Columns[2].ColumnWidth = 98.14;
            xlWorkSheet.Columns[2].WrapText = true;
            xlWorkSheet.Range["H2:H300"].NumberFormat = "£#,###,###.00";

            xlWorkSheet.Range["I" + (dgvRemakes.Rows.Count + 3).ToString()].Value2 = "=SUBTOTAL(9,I3:I" + (dgvRemakes.Rows.Count + 2).ToString() + ")";
            xlWorkSheet.Range["I" + (dgvRemakes.Rows.Count + 3).ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlWorkSheet.Range["I" + (dgvRemakes.Rows.Count + 3).ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);

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
            dgvRemakes.ClearSelection();

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

        private void button2_Click(object sender, EventArgs e) //lazy
        {
            foreach (DataGridViewRow row in dgvRepaints.Rows)
                row.Cells[1].Value = row.Cells[1].Value.ToString().Replace("\n", "").Replace("\r", " - ");

            Process[] processesBefore = Process.GetProcessesByName("excel");

            //unformat the grid because it causes big issues
            foreach (DataGridViewColumn col in dgvRepaints.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
            dgvRepaints.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //
            int customer_index = 0;
            customer_index = dgvRepaints.Columns["Customer"].Index;

            for (int i = 0; i < dgvRepaints.Rows.Count; i++)
            {
                string temp = dgvRepaints.Rows[i].Cells[customer_index].Value.ToString();
                temp = temp.Trim();
                dgvRepaints.Rows[i].Cells[customer_index].Value = temp;
            }

            string FileName = @"C:\temp\temp" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".xls";
             
            // Copy DataGridView results to clipboard
            dgvRepaints.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgvRepaints.SelectAll();

            DataObject dataObj = dgvRepaints.GetClipboardContent();
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
            xlWorkSheet.Range["A1"].Value2 = "Repaints " + lblTitle.Text;
            xlWorkSheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.Range["A1"].Cells.Font.Size = 22;
            xlWorkSheet.Columns[2].ColumnWidth = 98.14;
            xlWorkSheet.Columns[2].WrapText = true;
            xlWorkSheet.Range["H2:H3000"].NumberFormat = "£#,###,###.00";


            xlWorkSheet.Range["H" + (dgvRepaints.Rows.Count + 3).ToString()].Value2 = "=SUBTOTAL(9,H3:H" + (dgvRepaints.Rows.Count + 2).ToString() + ")";
            xlWorkSheet.Range["H" + (dgvRepaints.Rows.Count + 3).ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            xlWorkSheet.Range["H" + (dgvRepaints.Rows.Count + 3).ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);

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
            dgvRepaints.ClearSelection();

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
            SqlCommand cmdWipe = new SqlCommand("DELETE FROM dbo.remake_data_email", conn);
            cmdWipe.ExecuteNonQuery();
            foreach (DataGridViewRow row in dgvRemakes.Rows)
            {
                string sql = "INSERT INTO dbo.remake_data_email (door_id,logged_by,remake_description,log_date,customer,person_responsible,department_responsible,department_noticed,cost) " +
                    "VALUES ('" + row.Cells[0].Value.ToString() + "','" + row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + Convert.ToDateTime(row.Cells[3].Value.ToString()).ToString("dd/MM/yyyy") + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "'," +
                    "'" + row.Cells[6].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "','" + row.Cells[8].Value.ToString() + "')";
                using (SqlCommand cmdInsert = new SqlCommand(sql, conn))
                {
                    cmdInsert.ExecuteNonQuery();
                }
            }

            SqlCommand cmd = new SqlCommand("usp_remake_data_email", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@title", SqlDbType.Date).Value = "Remakes From: " + dateStart.ToString("dd/MM/yyyy") + " to " + dateEnd.ToString("dd/MM/yyyy");
            cmd.Parameters.AddWithValue("@total", SqlDbType.Date).Value = lblTotalRemake.Text;
            cmd.ExecuteNonQuery();


            MessageBox.Show("Email Sent", "", MessageBoxButtons.OK);

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //upload the current datagrid into the table ready to email
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmdWipe = new SqlCommand("DELETE FROM dbo.repaint_data_email", conn);
            cmdWipe.ExecuteNonQuery();
            foreach (DataGridViewRow row in dgvRepaints.Rows)
            {
                string sql = "INSERT INTO dbo.repaint_data_email (door_id,repaint_description,log_date,customer,person_responsible,department_responsible,cost) " +
                    "VALUES ('" + row.Cells[0].Value.ToString() + "','" + row.Cells[1].Value.ToString() + "','" + Convert.ToDateTime(row.Cells[3].Value.ToString()).ToString("dd/MM/yyyy") + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "'," +
                    "'" + row.Cells[6].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "')";
                using (SqlCommand cmdInsert = new SqlCommand(sql, conn))
                {
                    cmdInsert.ExecuteNonQuery();
                }
            }

            SqlCommand cmd = new SqlCommand("usp_repaint_data_email", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@title", SqlDbType.Date).Value = "Repaints From: " + dateStart.ToString("dd/MM/yyyy") + " to " + dateEnd.ToString("dd/MM/yyyy");
            cmd.Parameters.AddWithValue("@total", SqlDbType.Date).Value = lblTotalPaint.Text;
            cmd.ExecuteNonQuery();

            MessageBox.Show("Email Sent", "", MessageBoxButtons.OK);

            conn.Close();
        }
    }
}
