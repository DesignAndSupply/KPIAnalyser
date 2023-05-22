using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Excel = Microsoft.Office.Interop.Excel;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace KPIAnalyser
{
    public partial class frmRemakeRepaintMultipleSelection : Form
    {
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int remake_selected { get; set; }
        public int repaint_selected { get; set; }
        public string remake_sheet_name { get; set; }
        public string repaint_sheet_name { get; set; }
        public frmRemakeRepaintMultipleSelection(DateTime _start_date, DateTime _end_date)
        {
            InitializeComponent();
            start_date = _start_date;
            end_date = _end_date;

            remake_selected = 0;
            repaint_selected = 0;

            lblTitle.Text = "Date Range: " + start_date.ToString("dd/MM/yyyy") + " to " + end_date.ToString("dd/MM/yyyy");

            check_buttons();

        }

        private void check_buttons()
        {
            string sql = "";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();

                //check remakes first
                sql = "SELECT distinct d1.department_name from dbo.remake left join dbo.door on dbo.door.id = dbo.remake.door_id  " +
                      "left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref " +
                      "left join[user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                      "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible " +
                      "left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                      "left join dbo.door d on  remake.door_id = d.id " +
                      "left join dbo.door_type dt on d.door_type_id = dt.id " +
                      "where [date] >= '" + start_date.ToString("yyyyMMdd") + "' AND [date] < '" + end_date.ToString("yyyyMMdd") + "' AND " +
                      "(dt.slimline_y_n = 0 or dt.slimline_y_n is null)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable(sql);
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[0].ToString() == "Punching")
                            chkRemakePunching.Enabled = true;
                        if (row[0].ToString() == "Bending")
                            chkRemakeBending.Enabled = true;
                        if (row[0].ToString() == "Welding")
                            chkRemakeWelding.Enabled = true;
                        if (row[0].ToString() == "Dressing")
                            chkRemakeBuffing.Enabled = true;
                        if (row[0].ToString() == "Painting")
                            chkRemakePainting.Enabled = true;
                        if (row[0].ToString() == "Packing")
                            chkRemakePacking.Enabled = true;
                        if (row[0].ToString() == "Dispatch")
                            chkRemakeDispatch.Enabled = true;
                        if (row[0].ToString() == "Estimating")
                            chkRemakeEstimating.Enabled = true;
                        if (row[0].ToString() == "Programming")
                            chkRemakeProgramming.Enabled = true;
                        if (row[0].ToString() == "Survey")
                            chkRemakeSurvey.Enabled = true;
                        if (row[0].ToString() == "External")
                            chkRemakeExternal.Enabled = true;
                        if (row[0].ToString() == "N/A")
                            chkRemakeNA.Enabled = true;
                    }

                }


                sql = "SELECT distinct department_name " +
                    "from dbo.door d " +
                    "right join dbo.repaints r on r.door_id = d.id " +
                    "left join [user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                    "left join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref  " +
                    "left join[dsl_kpi].dbo.department dept on dept.id = r.department  " +
                    "left join [user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id  " +
                    "left join dbo.door_type dt on d.door_type_id = dt.id " +
                    "WHERE CAST(date_logged as date) >= '" + start_date.ToString("yyyyMMdd") + "' AND CAST(date_logged as date) <= '" + end_date.ToString("yyyyMMdd") + "' " +
                    "AND (slimline_y_n = 0 or slimline_y_n is null)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable(sql);
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[0].ToString() == "Punching")
                            chkRepaintPunching.Enabled = true;
                        if (row[0].ToString() == "Welding")
                            chkRepaintWelding.Enabled = true;
                        if (row[0].ToString() == "Dressing")
                            chkRepaintBuffing.Enabled = true;
                        if (row[0].ToString() == "Painting")
                            chkRepaintPainting.Enabled = true;
                        if (row[0].ToString() == "Packing")
                            chkRepaintPacking.Enabled = true;
                        if (row[0].ToString() == "Office")
                            chkRepaintOffice.Enabled = true;
                        if (row[0].ToString() == "Programming")
                            chkRepaintProgramming.Enabled = true;
                        if (row[0].ToString() == "SL Buff")
                            chkRepaintSlBuff.Enabled = true;
                    }

                }


                conn.Close();
            }
        }


        private void create_repaint_sheet()
        {
            object misValue = System.Reflection.Missing.Value;
            //fill some arrays for <sheet number> // <department>
            List<string> repaintDepartmentList = new List<string>();
            List<int> repaintSheetNumber = new List<int>();
            int repaintCount = 0;
            if ("repaint" == "repaint")
            {
                if (chkRepaintPunching.Checked == true)
                {
                    repaintCount++;
                    repaintDepartmentList.Add("Punching");
                    repaintSheetNumber.Add(repaintCount);
                    repaint_selected++;
                }
                if (chkRepaintWelding.Checked == true)
                {
                    repaintCount++;
                    repaintDepartmentList.Add("Welding");
                    repaintSheetNumber.Add(repaintCount);
                    repaint_selected++;
                }
                if (chkRepaintBuffing.Checked == true)
                {
                    repaintCount++;
                    repaintDepartmentList.Add("Dressing");
                    repaintSheetNumber.Add(repaintCount);
                    repaint_selected++;
                }
                if (chkRepaintPainting.Checked == true)
                {
                    repaintCount++;
                    repaintDepartmentList.Add("Painting");
                    repaintSheetNumber.Add(repaintCount);
                    repaint_selected++;
                }
                if (chkRepaintPacking.Checked == true)
                {
                    repaintCount++;
                    repaintDepartmentList.Add("Packing");
                    repaintSheetNumber.Add(repaintCount);
                    repaint_selected++;
                }
                if (chkRepaintOffice.Checked == true)
                {
                    repaintCount++;
                    repaintDepartmentList.Add("Office");
                    repaintSheetNumber.Add(repaintCount);
                    repaint_selected++;
                }
                if (chkRepaintProgramming.Checked == true)
                {
                    repaintCount++;
                    repaintDepartmentList.Add("Programming");
                    repaintSheetNumber.Add(repaintCount);
                    repaint_selected++;
                }
                if (chkRepaintSlBuff.Checked == true)
                {
                    repaintCount++;
                    repaintDepartmentList.Add("SL Buff");
                    repaintSheetNumber.Add(repaintCount);
                    repaint_selected++;
                }
                if (repaint_selected == 0)
                    return;
            }


            //if there is already data in this dgv then add it to a datatable so we can append this later 

            // Store the Excel processes before opening. 
            Process[] processesBefore = Process.GetProcessesByName("excel");
            // Open the file in Excel. 
            var xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            var xlWorkbooks = xlApp.Workbooks;
            var xlWorkbook = xlWorkbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
            // Get Excel processes after opening the file. 
            Process[] processesAfter = Process.GetProcessesByName("excel");

            //start filling each sheet here
            //===============================

            for (int sheetNumber = 1; sheetNumber < repaintSheetNumber.Count + 1; sheetNumber++)
            {
                //fill the datagridview with this current department
                //string repaint_sql = "select dbo.remake.door_id as [Door ID],[User] as [Logged By],[description] as [Remake Description]," +
                //            "[date] as [Log Date],RTRIM([NAME]) as Customer," +
                //            "coalesce(u.forename + ' ' + u.surname,'') as [Person Responsible]," +
                //            "d1.department_name as [Department Responsible] ,d2.department_name as [Department Noticed] ,coalesce(cost, 0) as Cost " +
                //            "from dbo.remake " +
                //            "left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                //            "left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref " +
                //            "left join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                //            "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible " +
                //            "left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                //            "left join dbo.door_type dt on door.door_type_id = dt.id " +
                //            "where [date] >= '" + start_date.ToString("yyyyMMdd") + "' AND[date] < '" + end_date.ToString("yyyyMMdd") + "' " +
                //            "AND d1.department_name = '" + remakeDepartmentList[sheetNumber - 1].ToString() + "' AND (dt.slimline_y_n = 0 or dt.slimline_y_n is null) ";

                string repaint_sql = "select d.id as [Door ID],r.reason_for_repaint as [Repaint Reason],u_logged.forename + ' ' + u_logged.surname as [Logged By]," +
                    "r.date_logged as [Log Date],s.[NAME] as [Customer],COALESCE(u_fault.forename + ' ' + u_fault.surname,'N/A') as [Person Responsible], " +
                         "dept.department_name as [Department Responsible],COALESCE(round(r.repaint_cost,2),0) as [Repaint Cost] from dbo.door d " +
                         "right join dbo.repaints r on r.door_id = d.id  " +
                         "left join [user_info].dbo.[user] u_fault on u_fault.id = r.painter_name " +
                         "left join dbo.SALES_LEDGER s on s.ACCOUNT_REF = d.customer_acc_ref  " +
                         "left join[dsl_kpi].dbo.department dept on dept.id = r.department  " +
                         "left join [user_info].dbo.[user] u_logged on u_logged.id = r.logged_by_id  " +
                         "left join dbo.door_type dt on d.door_type_id = dt.id " +
                         "WHERE  date_logged >= '" + start_date.ToString("yyyyMMdd") + "' AND date_logged < '" + end_date.ToString("yyyyMMdd") + "' " +
                         "AND (dt.slimline_y_n = 0 or dt.slimline_y_n is null) " +
                         "and dept.department_name = '" + repaintDepartmentList[sheetNumber - 1].ToString() + "'";

                using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(repaint_sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvExcelTemp.DataSource = dt;

                        //remove new line character from the dgv
                        foreach (DataGridViewRow row in dgvExcelTemp.Rows)
                            row.Cells[1].Value = row.Cells[1].Value.ToString().Replace("\n", "").Replace("\r", " - ");

                        //manipulate the sheets -- if there it the first sheet then just rename it

                        if (sheetNumber == 1)
                        {
                            xlWorkSheet.Name = repaintDepartmentList[sheetNumber - 1];
                        }
                        else
                        {
                            var xlSheets = xlWorkbook.Sheets as Excel.Sheets;
                            var xlNewSheet = (Excel.Worksheet)xlSheets.Add(Type.Missing, xlSheets[sheetNumber - 1], Type.Missing, Type.Missing);
                            xlNewSheet.Name = repaintDepartmentList[sheetNumber - 1].Replace("/", "");

                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets.get_Item(sheetNumber);


                        }

                        // Copy DataGridView results to clipboard
                        dgvExcelTemp.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                        dgvExcelTemp.SelectAll();

                        DataObject dataObj = dgvExcelTemp.GetClipboardContent();
                        if (dataObj != null)
                            Clipboard.SetDataObject(dataObj);


                        if ("excel formatting" == "excel formatting")
                        {
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

                            Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[sheetNumber];
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


                            xlWorkSheet.Range["H" + (dgvExcelTemp.Rows.Count + 3).ToString()].Value2 = "=SUBTOTAL(9,H3:H" + (dgvExcelTemp.Rows.Count + 2).ToString() + ")";
                            xlWorkSheet.Range["H" + (dgvExcelTemp.Rows.Count + 3).ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlWorkSheet.Range["H" + (dgvExcelTemp.Rows.Count + 3).ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);

                            ws.Columns.AutoFit();
                            ws.Rows.AutoFit();
                            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            range.Borders.Color = ColorTranslator.ToOle(Color.Black);


                            //make column C a certain length
                            xlWorkSheet.Columns[3].ColumnWidth = 98.14;
                            xlWorkSheet.Columns[3].WrapText = true;

                            //releaseObject(xlWorkSheet);
                            //releaseObject(xlWorkBook);
                            //releaseObject(xlexcel);

                            // Clear Clipboard and DataGridView selection
                            Clipboard.Clear();
                            dgvExcelTemp.ClearSelection();
                        }
                    }

                    conn.Close();
                }


            }

            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
            xlWorkSheet.Activate();


            // Save the excel file under the captured location from the SaveFileDialog
            xlWorkbook.SaveAs(repaint_sheet_name, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlApp.DisplayAlerts = true;
            xlWorkbook.Close(true, misValue, misValue);
            xlApp.Quit();


            //===============================

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
        }


        private void create_remake_sheet()
        {
            object misValue = System.Reflection.Missing.Value;
            //fill some arrays for <sheet number> // <department>
            List<string> remakeDepartmentList = new List<string>();
            List<int> remakeSheetNumber = new List<int>();
            int remakeCount = 0;
            if ("remake" == "remake")
            {
                if (chkRemakePunching.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("Punching");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakeBending.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("Bending");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakeWelding.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("Welding");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakeBuffing.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("Dressing");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakePainting.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("Painting");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakePacking.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("Packing");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakeDispatch.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("Dispatch");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakeEstimating.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("Estimating");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakeProgramming.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("Programming");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakeSurvey.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("Survey");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakeExternal.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("External");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (chkRemakeNA.Checked == true)
                {
                    remakeCount++;
                    remakeDepartmentList.Add("N/A");
                    remakeSheetNumber.Add(remakeCount);
                    remake_selected++;
                }
                if (remake_selected == 0)
                    return;
            }


            //if there is already data in this dgv then add it to a datatable so we can append this later 

            // Store the Excel processes before opening. 
            Process[] processesBefore = Process.GetProcessesByName("excel");
            // Open the file in Excel. 
            var xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            var xlWorkbooks = xlApp.Workbooks;
            var xlWorkbook = xlWorkbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
            // Get Excel processes after opening the file. 
            Process[] processesAfter = Process.GetProcessesByName("excel");

            //start filling each sheet here
            //===============================

            for (int sheetNumber = 1; sheetNumber < remakeSheetNumber.Count + 1; sheetNumber++)
            {
                //fill the datagridview with this current department
                string remake_sql = "select dbo.remake.door_id as [Door ID],[User] as [Logged By],[description] as [Remake Description]," +
                            "[date] as [Log Date],RTRIM([NAME]) as Customer," +
                            "coalesce(u.forename + ' ' + u.surname,'') as [Person Responsible]," +
                            "d1.department_name as [Department Responsible] ,d2.department_name as [Department Noticed] ,coalesce(cost, 0) as Cost " +
                            "from dbo.remake " +
                            "left join dbo.door on dbo.door.id = dbo.remake.door_id " +
                            "left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref " +
                            "left join [user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                            "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible " +
                            "left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                            "left join dbo.door_type dt on door.door_type_id = dt.id " +
                            "where [date] >= '" + start_date.ToString("yyyyMMdd") + "' AND[date] < '" + end_date.ToString("yyyyMMdd") + "' " +
                            "AND d1.department_name = '" + remakeDepartmentList[sheetNumber - 1].ToString() + "' AND (dt.slimline_y_n = 0 or dt.slimline_y_n is null) ";

                using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(remake_sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvExcelTemp.DataSource = dt;

                        //remove new line character from the dgv
                        foreach (DataGridViewRow row in dgvExcelTemp.Rows)
                            row.Cells[2].Value = row.Cells[2].Value.ToString().Replace("\n", "").Replace("\r", " - ");

                        //manipulate the sheets -- if there it the first sheet then just rename it

                        if (sheetNumber == 1)
                        {
                            xlWorkSheet.Name = remakeDepartmentList[sheetNumber - 1];
                        }
                        else
                        {
                            var xlSheets = xlWorkbook.Sheets as Excel.Sheets;
                            var xlNewSheet = (Excel.Worksheet)xlSheets.Add(Type.Missing, xlSheets[sheetNumber - 1], Type.Missing, Type.Missing);
                            xlNewSheet.Name = remakeDepartmentList[sheetNumber - 1].Replace("/", "");

                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets.get_Item(sheetNumber);


                        }

                        // Copy DataGridView results to clipboard
                        dgvExcelTemp.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                        dgvExcelTemp.SelectAll();

                        DataObject dataObj = dgvExcelTemp.GetClipboardContent();
                        if (dataObj != null)
                            Clipboard.SetDataObject(dataObj);


                        if ("excel formatting" == "excel formatting")
                        {
                            // Format column D as text before pasting results, this was required for my data
                            Microsoft.Office.Interop.Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                            rng.NumberFormat = "@";

                            /////////
                            //string aaa = @"C:\temp\remake_multiple_dept.xls";
                            //xlWorkbook.SaveAs(aaa, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                            ////////



                            // Paste clipboard results to worksheet range
                            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
                            CR.Select();
                            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                            // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                            // Delete blank column A and select cell A1
                            //Microsoft.Office.Interop.Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                            //delRng.Delete(Type.Missing);
                            xlWorkSheet.get_Range("A2").Select();

                            Microsoft.Office.Interop.Excel.Worksheet ws = xlApp.ActiveWorkbook.Worksheets[sheetNumber];
                            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
                            //ws.Columns.ClearFormats();
                            //ws.Rows.ClearFormats();
                            //range.EntireColumn.AutoFit();
                            //range.EntireRow.AutoFit();

                            xlWorkSheet.Range["A1:E1"].Merge();
                            xlWorkSheet.Range["A1"].Value2 = remakeDepartmentList[sheetNumber - 1] + " Remakes: " + start_date.ToString("dd/MM/yyyy") + " to " + end_date.ToString("dd/MM/yyyy");
                            xlWorkSheet.Range["A1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            xlWorkSheet.Range["A1"].Cells.Font.Size = 22;

                            xlWorkSheet.Range["F1:I1"].Merge();
                            xlWorkSheet.Range["F1"].Value2 = "Report Generated on: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            xlWorkSheet.Range["F1"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                            xlWorkSheet.Range["F1"].Cells.Font.Size = 22;

                            xlWorkSheet.Range["A2:I2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
                            xlWorkSheet.Range["A2:I2"].AutoFilter(1);
                            xlWorkSheet.Columns[2].ColumnWidth = 98.14;
                            xlWorkSheet.Columns[2].WrapText = true;
                            xlWorkSheet.Range["H2:H300"].NumberFormat = "£#,###,###.00";

                            xlWorkSheet.Range["I" + (dgvExcelTemp.Rows.Count + 3).ToString()].Value2 = "=SUBTOTAL(9,I3:I" + (dgvExcelTemp.Rows.Count + 2).ToString() + ")";
                            xlWorkSheet.Range["I" + (dgvExcelTemp.Rows.Count + 3).ToString()].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            xlWorkSheet.Range["I" + (dgvExcelTemp.Rows.Count + 3).ToString()].Borders.Color = ColorTranslator.ToOle(Color.Black);


                            ws.Columns.AutoFit();
                            ws.Rows.AutoFit();
                            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            range.Borders.Color = ColorTranslator.ToOle(Color.Black);

                            //make column C a certain length
                            xlWorkSheet.Columns[3].ColumnWidth = 98.14;
                            xlWorkSheet.Columns[3].WrapText = true;


                        }
                    }

                    conn.Close();
                }


            }

            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
            xlWorkSheet.Activate();


            // Save the excel file under the captured location from the SaveFileDialog
            xlWorkbook.SaveAs(remake_sheet_name, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlApp.DisplayAlerts = true;
            xlWorkbook.Close(true, misValue, misValue);
            xlApp.Quit();


            //===============================

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

        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {

            remake_selected = 0;
            repaint_selected = 0;


            remake_sheet_name = @"C:\temp\remake_multiple_dept_" + DateTime.Now.ToString("hh_mm_ss") + ".xls";
            repaint_sheet_name = @"C:\temp\repaint_multiple_dept_" + DateTime.Now.ToString("hh_mm_ss") + ".xls";

            create_remake_sheet();
            create_repaint_sheet();

            if (remake_selected == 0 && repaint_selected == 0)
                return;


            if (remake_selected > 0)
                Process.Start(remake_sheet_name);
            if (repaint_selected > 0)
                Process.Start(repaint_sheet_name);

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            remake_selected = 0;
            repaint_selected = 0;


            remake_sheet_name = @"C:\temp\remake_multiple_dept.xls";
            repaint_sheet_name = @"C:\temp\repaint_multiple_dept.xls";

            create_remake_sheet();
            create_repaint_sheet();

            if (remake_selected == 0 && repaint_selected == 0)
                return;


            //open outlook and send the email here
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "";
            mailItem.To = "";

            if (remake_selected > 0)
            {
                var attachments = mailItem.Attachments;
                var attachment = attachments.Add(remake_sheet_name);
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
                mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);
                mailItem.Attachments.Add(remake_sheet_name);
            }
            if (repaint_selected > 0)
            {
                var attachments = mailItem.Attachments;
                var attachment = attachments.Add(repaint_sheet_name);
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
                attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
                mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);
                mailItem.Attachments.Add(repaint_sheet_name);
            }

            // Set body format to HTML

            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;

            mailItem.GetInspector.Activate();
            var signature = mailItem.HTMLBody;
            
            mailItem.HTMLBody = "" /*+ signature*/ + mailItem.HTMLBody;
            mailItem.Display(true);

        }


    } //end

}
