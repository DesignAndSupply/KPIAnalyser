﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            mailItem.Display(true);
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
    }
}
