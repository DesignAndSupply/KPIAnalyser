using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace KPIAnalyser
{
    public partial class frmRemakeRepaintGraph : Form
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        List<string> remakeDepartments = new List<string>();

        List<string> repaintDepartments = new List<string>();
        public int slimline { get; set; }
        public frmRemakeRepaintGraph(DateTime _startDate, DateTime _endDate,int _slimline)
        {
            InitializeComponent();
            startDate = _startDate;
            endDate = _endDate;
            slimline = _slimline;
            loadCharts();
        }

        private void loadCharts()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                if (1 == 1) //repaints
                {
                    lblRepaints.Text = "Department Repaints : " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy");
                    SqlCommand cmd = new SqlCommand("usp_kpi_production_manager_repaint_graph", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                    cmd.Parameters.Add("@slimline", SqlDbType.Int).Value = slimline;

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DateTime> datelist = new List<DateTime>();
                    List<double> repaint_cost = new List<double>();
                    List<string> department = new List<string>();



                    while (reader.Read())
                    {
                        //datelist.Add(reader.GetDateTime(1));
                        department.Add(reader.GetString(0));
                        repaintDepartments.Add(reader.GetString(0));
                        repaint_cost.Add(reader.GetDouble(2));
                    }

                    reader.Close();
                    //string[] datearray = datelist.ToArray();
                    double[] itemarray = repaint_cost.ToArray();

                    repaintChart.AxisY.Clear();
                    repaintChart.AxisX.Clear();

                    repaintChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Repaint Cost",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.LightSkyBlue,

                    Values = new ChartValues<double>(itemarray)
                }};

                    repaintChart.AxisX.Add(new Axis
                    {
                        Title = "Departments",
                        FontSize = 13,
                        Foreground = System.Windows.Media.Brushes.Black,
                        Labels = department
                    });

                    repaintChart.AxisY.Add(new Axis
                    {
                        Title = "Repaint Value",
                        FontSize = 16,

                    });
                } //repaints

                if (1 == 1) //repaints
                {
                    lblRemakes.Text = "Department Remakes : " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy");
                    SqlCommand cmd = new SqlCommand("usp_kpi_production_manager_remake_graph", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                    cmd.Parameters.Add("@slimline", SqlDbType.Int).Value = slimline;

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DateTime> datelist = new List<DateTime>();
                    List<double> remake_cost = new List<double>();
                    List<string> department = new List<string>();



                    while (reader.Read())
                    {
                        //datelist.Add(reader.GetDateTime(1));
                        department.Add(reader.GetString(0));
                        remakeDepartments.Add(reader.GetString(0));
                        remake_cost.Add(reader.GetDouble(1));
                    }


                    //string[] datearray = datelist.ToArray();
                    double[] itemarray = remake_cost.ToArray();

                    remakeChart.AxisY.Clear();
                    remakeChart.AxisX.Clear();

                    remakeChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Remake Cost",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.PaleVioletRed,

                    Values = new ChartValues<double>(itemarray)
                }};

                    remakeChart.AxisX.Add(new Axis
                    {
                        Title = "Departments",
                        FontSize = 13,
                        Foreground = System.Windows.Media.Brushes.Black,
                        Labels = department
                    });

                    remakeChart.AxisY.Add(new Axis
                    {
                        Title = "Remake Value",
                        FontSize = 16,

                    });
                } //remakes
                conn.Close();
            }
        }

        private void repaintChart_DataClick(object sender, ChartPoint p)
        {
            var asPixels = repaintChart.Base.ConvertToPixels(p.AsPoint());
            string department = repaintDepartments[Convert.ToInt32(p.X)].ToString();
            frmRemakeRepaintDepartmentGraph frm = new frmRemakeRepaintDepartmentGraph(startDate, endDate, department, -1,slimline);
            frm.ShowDialog();
        }

        private void remakeChart_DataClick(object sender, ChartPoint p)
        {
            var asPixels = repaintChart.Base.ConvertToPixels(p.AsPoint());
            string department = remakeDepartments[Convert.ToInt32(p.X)].ToString();
            frmRemakeRepaintDepartmentGraph frm = new frmRemakeRepaintDepartmentGraph(startDate, endDate, department, 0,slimline);
                frm.ShowDialog();


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
        private void btnEmail_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            btnEmail.Visible = false;
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
            btnEmail.Visible = true;

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            btnEmail.Visible = false;
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
        }

        private void btnAllDepartments_Click(object sender, EventArgs e)
        {
            frmRemakeRepaintMultipleSelection frm = new frmRemakeRepaintMultipleSelection(startDate,endDate,slimline);
            frm.ShowDialog();
        }
    }
}
