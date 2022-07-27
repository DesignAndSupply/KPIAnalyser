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

namespace KPIAnalyser
{
    public partial class frmAbsenteeism : Form
    {
        public frmAbsenteeism(DateTime startDate, DateTime endDate, int today)
        {
            InitializeComponent();
            lblTitle.Text = "Absenteeism from: " + startDate.ToString("dd/MM/yyyy") + " to: " + endDate.ToString("dd/MM/yyyy");
            string sql = "";
            if (today == 0)
            {
                sql = "select max(u.forename) + ' ' + max(surname) as fullName,sum(1) as total_absenteeism, sum(case when absent_type = 5 then 1 else 0 end) as total_absent_days, " +
                "sum(case when absent_type = 8 then 1 else 0 end) as total_absent_taken_holiday from dbo.absent_holidays ah left join [user_info].dbo.[user] u on u.id = ah.staff_id " +
                "where ShopFloor = -1 and(absent_type = 5 or absent_type = 8) and date_absent >= '" + startDate.ToString("yyyyMMdd") + "' and date_absent <  '" + endDate.ToString("yyyyMMdd") + "'  group by u.id order by total_absenteeism desc";
            }
            else
            {
                sql = "select max(u.forename) + ' ' + max(surname) as fullName,sum(1) as total_absenteeism, sum(case when absent_type = 5 then 1 else 0 end) as total_absent_days, " +
          "sum(case when absent_type = 8 then 1 else 0 end) as total_absent_taken_holiday from dbo.absent_holidays ah left join [user_info].dbo.[user] u on u.id = ah.staff_id " +
          "where ShopFloor = -1 and(absent_type = 5 or absent_type = 8) and date_absent >= '" + startDate.ToString("yyyyMMdd") + "' and date_absent <=  '" + endDate.ToString("yyyyMMdd") + "'  group by u.id order by total_absenteeism desc";

            }
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }

            //format the dgv
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Full Name";
            dataGridView1.Columns[1].HeaderText = "Total Absenteeism";
            dataGridView1.Columns[2].HeaderText = "Total Absent Days";
            dataGridView1.Columns[3].HeaderText = "Total Absent Days Taken Holiday";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {


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
            //Microsoft.Office.Interop.Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
            //rng.NumberFormat = "@";

            // Paste clipboard results to worksheet range
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
            // Delete blank column A and select cell A1
            //Microsoft.Office.Interop.Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
            //delRng.Delete(Type.Missing);
            xlWorkSheet.get_Range("A1").Select();

            Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
            //ws.Columns.ClearFormats();
            //ws.Rows.ClearFormats();
            //range.EntireColumn.AutoFit();
            //range.EntireRow.AutoFit();
            xlWorkSheet.Range["A1:D1"].Interior.Color = System.Drawing.Color.LightSkyBlue;
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
            uint processID = 0;

            workbooks = excelApp.Workbooks;
            excelBook = workbooks.Add(FileName);
            Microsoft.Office.Interop.Excel.Sheets sheets = excelBook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)(sheets[1]);

            //Range.Rows.AutoFit();
            //Range.Columns.AutoFit();
        }
    }
}
