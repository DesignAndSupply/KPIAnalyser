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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace KPIAnalyser
{
    public partial class frmViewQuotationSlimline : Form
    {
        public string _startDate { get; set; }
        public string _endDate { get; set; }
        public string _staffName { get; set; }
        public frmViewQuotationSlimline(string startDate, string endDate, string staffName)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _startDate = startDate;
            _endDate = endDate;
            _staffName = staffName;
            populateGrid();

            lblName.Text = "Quotations output by: " + staffName;
            lblStart.Text = "Start Date: " + startDate;
            lblEnd.Text = "End Date:  " + endDate;
        }


        private void populateGrid()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);

            conn.Open();


            SqlCommand cmd = new SqlCommand("usp_kpi_view_quotations_slimline", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = _startDate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = _endDate;
            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = _staffName;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void printImage()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    System.Drawing.Image i = System.Drawing.Image.FromFile(@"C:\temp\temp2.jpg");
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

        public static void Email_Screen()
        {


            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\temp2.jpg");


            }
            catch
            {

            }





            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.Subject = "";
            mailItem.To = "";
            string imageSrc = @"C:\Temp\temp2.jpg"; // Change path as needed

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
            //mailItem.Send();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\temp2.jpg");

                printImage();
            }
            catch
            {

            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Email_Screen();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                int columnindex = 0;
                int issueIndex = 0;
                issueIndex = dataGridView1.Columns["Issue"].Index;

                int quoteID = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString());
                string quotationLocation = @"\\designsvr1\apps\SLIMLINE QUOTES\SL" + quoteID.ToString() + ".rtf";

                if (Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[issueIndex].Value) > 1)
                {
                     quotationLocation = @"\\designsvr1\apps\SLIMLINE QUOTES\SL" + quoteID.ToString() + " i" + dataGridView1.Rows[rowindex].Cells[issueIndex].Value.ToString() + ".rtf";
                }
              //  LWordDoc = "S:\SLIMLINE QUOTES\SL" & Me.quote_id & ".rtf"


                Process.Start(quotationLocation);


            }

            catch

            {



            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            Process[] processesBefore = Process.GetProcessesByName("excel");

            //
            int customer_index = 0;
            customer_index = dataGridView1.Columns["Customer"].Index;

            string FileName = @"C:\temp\total_quotations_" + DateTime.Now.ToString("mmss") + ".xls";


            //adjust the chase description


            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

            xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);

            Process[] processesAfter = Process.GetProcessesByName("excel");



            //if there are rows in chaseing

            // Copy DataGridView results to clipboard
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.SelectAll();

                //delete all of the first row


                DataObject dataObj = dataGridView1.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);


                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Name = "Quotations";

                // Get Excel processes after opening the file. 



                // Paste clipboard results to worksheet range
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[3, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                //delete the first row
                ((Excel.Range)xlWorkSheet.Rows[1, Missing.Value]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);



                xlWorkSheet.get_Range("A3").Select();

                Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;



            //ws.Columns.AutoFit();
            //ws.Rows.AutoFit();


            xlWorkSheet.Cells[1, 1].Value = "Total Quotations - " + dataGridView1.Rows.Count.ToString();
                xlWorkSheet.Range["A1:G1"].Cells.Font.Size = 20;
                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 7]].Merge();
                //Make all top/left align
                xlWorkSheet.get_Range("A2", "G1000").Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignGeneral;
                xlWorkSheet.get_Range("A2", "G1000").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                //change the entire top row to center align (AND BOTH DATE COLUMNS)
                xlWorkSheet.get_Range("A1", "G2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //xlWorkSheet.Columns[2].Style.HorizontalAlignment = HorizontalAlignment.Center;
                //xlWorkSheet.Columns[4].Style.HorizontalAlignment = HorizontalAlignment.Center;


                xlWorkSheet.Range["A2:G2"].Interior.Color = System.Drawing.Color.LightSkyBlue;
                xlWorkSheet.Range["A2:G2"].AutoFilter(1);
                xlWorkSheet.Range["A2:G2"].Cells.Font.Size = 12;

                ws.Columns.AutoFit();
                ws.Rows.AutoFit();

                //adjust the description conversation to fit and look nicer
                //xlWorkSheet.Columns[4].ColumnWidth = 100;
                //xlWorkSheet.Columns[4].WrapText = true;

                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.Borders.Color = ColorTranslator.ToOle(Color.Black);

                var chase_pagesetup = xlWorkSheet.PageSetup;
                chase_pagesetup.FitToPagesWide = 1;
                chase_pagesetup.FitToPagesTall = false;
                chase_pagesetup.Zoom = false;
                chase_pagesetup.Orientation = Excel.XlPageOrientation.xlLandscape;


            xlWorkBook.Sheets[1].Select();





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
    }
}
