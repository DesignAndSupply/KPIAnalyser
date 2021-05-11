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
    public partial class frmProgrammerSummary : Form
    {
        public string _userFullName { get; set; }
        public int _userID { get; set; }
        public DateTime _search_date { get; set; }
        public frmProgrammerSummary(string userFullName, DateTime search_date)
        {
            InitializeComponent();
            _userFullName = userFullName;
            _search_date = search_date;
            //get user id from this too
            string sql = "select id FROM dbo.[user] where forename + ' ' + surname = '" + _userFullName + "'";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    _userID = Convert.ToInt32(cmd.ExecuteScalar()); //now we can use this to populate the dgv with the data from the access report
                    conn.Close();
                }
            }

            txtNote.BackColor = SystemColors.Control;
            loadData();

            lblTitle.Text = "Engineer Work Overview - " + _userFullName + " - " + _search_date.ToString("dd/MM/yyyy");
        }

        private void loadData()
        {
            string sql = "SELECT * FROM (select dbo.door_program.door_id as [Job ID],'Jobs Assessed' as job_name,dbo.door_type.door_type_description as [Job Type], dbo.door_program.assessed_date as [Job Completion Date], SALES_LEDGER.NAME as [Customer],1 as [Job Qty], " +
                "dbo.programming_difficulty.difficulty_description as [Difficulty],1 as [order], '' as [note] FROM ((dbo.door_program INNER JOIN dbo.door ON dbo.door_program.door_id = dbo.door.id) " +
                " LEFT JOIN dbo.door_type ON dbo.door.door_type_id = dbo.door_type.id) " +
                "LEFT JOIN SALES_LEDGER ON dbo.door.customer_acc_ref = SALES_LEDGER.ACCOUNT_REF " +
                "LEFT JOIN dbo.programming_difficulty ON dbo.door_program.programming_difficulty_id = dbo.programming_difficulty.id " +
                "WHERE dbo.door_program.assessed_by_id = " + _userID + " AND dbo.door_program.assessed_date BETWEEN '" + _search_date.ToString("yyyy-MM-dd") + " 00:00' AND '" + _search_date.ToString("yyyy-MM-dd") + " 23:59' " +
                "Union all " +
                "SELECT dbo.door_program.door_id as [Job ID],'Jobs Programmed' as job_name,dbo.door_type.door_type_description as [Job Type], dbo.door_program.program_date as [Job Completion Date], SALES_LEDGER.NAME as [Customer],1 as [Job Qty], " +
                "dbo.programming_difficulty.difficulty_description as [Difficulty],2 as [order], '' as [note] FROM ((dbo.door_program INNER JOIN dbo.door ON dbo.door_program.door_id = dbo.door.id) LEFT JOIN dbo.door_type ON dbo.door.door_type_id = dbo.door_type.id) " +
                "LEFT JOIN SALES_LEDGER ON dbo.door.customer_acc_ref = SALES_LEDGER.ACCOUNT_REF " +
                " LEFT JOIN dbo.programming_difficulty ON dbo.door_program.programming_difficulty_id = dbo.programming_difficulty.id " +
                "WHERE dbo.door_program.programed_by_id =" + _userID + " AND dbo.door_program.program_date BETWEEN '" + _search_date.ToString("yyyy-MM-dd") + " 00:00' AND '" + _search_date.ToString("yyyy-MM-dd") + " 23:59'  " +
                "Union all " +
                "SELECT dbo.door_program.door_id as [Job ID],'Laser Jobs Programmed' as job_name,dbo.door_type.door_type_description as [Job Type], dbo.door_program.laser_program_date as [Job Completion Date], SALES_LEDGER.NAME as [Customer],1 as [Job Qty], " +
                "dbo.programming_difficulty.difficulty_description as [Difficulty],3 as [order], '' as [note] FROM ((dbo.door_program INNER JOIN dbo.door ON dbo.door_program.door_id = dbo.door.id) LEFT JOIN dbo.door_type ON dbo.door.door_type_id = dbo.door_type.id) " +
                "LEFT JOIN SALES_LEDGER ON dbo.door.customer_acc_ref = SALES_LEDGER.ACCOUNT_REF LEFT JOIN dbo.programming_difficulty ON dbo.door_program.programming_difficulty_id = dbo.programming_difficulty.id " +
                "WHERE dbo.door_program.laser_programmed_by_id = " + _userID + " AND dbo.door_program.laser_program_date BETWEEN '" + _search_date.ToString("yyyy-MM-dd") + " 00:00' AND '" + _search_date.ToString("yyyy-MM-dd") + " 23:59'  " +
                "Union all " +
                "SELECT dbo.door_program.door_id as [Job ID],'Jobs Checked' as job_name,dbo.door_type.door_type_description as [Job Type], dbo.door_program.checked_date as [Job Completion Date], SALES_LEDGER.NAME as [Customer],1 as [Job Qty]," +
                "dbo.programming_difficulty.difficulty_description as [Difficulty],4 as [order], '' as [note] FROM ((dbo.door_program INNER JOIN dbo.door ON dbo.door_program.door_id = dbo.door.id) LEFT JOIN dbo.door_type ON dbo.door.door_type_id = dbo.door_type.id) " +
                "LEFT JOIN SALES_LEDGER ON dbo.door.customer_acc_ref = SALES_LEDGER.ACCOUNT_REF LEFT JOIN dbo.programming_difficulty ON dbo.door_program.programming_difficulty_id = dbo.programming_difficulty.id " +
                "WHERE dbo.door_program.checked_by_id = " + _userID + " AND dbo.door_program.checked_date BETWEEN '" + _search_date.ToString("yyyy-MM-dd") + " 00:00' AND '" + _search_date.ToString("yyyy-MM-dd") + " 23:59'  " +
                "Union all " +
                "SELECT cast(id as nvarchar) as [Job ID],'Jobs Drawn' as [job_name],[subject] as [Job Type],Convert(varchar,complete_cad_date,121) as [Job Completion Date], " +
                "CASE WHEN sender_email_address LIKE '%/O=EXCHANGELABS/OU=EXCHANGE%' THEN 'Internal Email' ELSE sender_email_address END as [Customer],drawing_qty_required as [Job Qty],'N/A' as [Difficulty],5 as [order], '' as [note]  From [EnquiryLog].dbo.Enquiry_log " +
                "WHERE allocated_to_cad_id =" + _userID + " AND complete_cad_date BETWEEN '" + _search_date.ToString("yyyy-MM-dd") + " 00:00' AND '" + _search_date.ToString("yyyy-MM-dd") + " 23:59') as a" +
                " order by [Job Completion Date]";


            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }



                //count all the job types here
                int totalAssessed = 0, totalChecked = 0, totalProgrammed = 0, totalDrawn = 0, totalLaserProgrammed = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString() == "Jobs Assessed")
                        totalAssessed++;
                    if (row.Cells[1].Value.ToString() == "Jobs Checked")
                        totalChecked++;
                    if (row.Cells[1].Value.ToString() == "Jobs Programmed")
                        totalProgrammed++;
                    if (row.Cells[1].Value.ToString() == "Jobs Drawn")
                        totalDrawn =totalDrawn + Convert.ToInt32(row.Cells[5].Value.ToString());
                    if (row.Cells[1].Value.ToString() == "Laser Jobs Programmed")
                        totalLaserProgrammed++;
                }

                lblAssess.Text = totalAssessed.ToString();
                lblChecked.Text = totalChecked.ToString();
                lblProgrammed.Text = totalProgrammed.ToString();
                lblDrawn.Text = totalDrawn.ToString();
                lblLaserProgrammed.Text = totalLaserProgrammed.ToString();

                //if there is a note then get it
                sql = "SELECT COALESCE([note],'') as [note] FROM dbo.engineer_note WHERE [date] = '" + _search_date.ToString("yyyy-MM-dd") + "' AND engineer_id = " + _userID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var data = Convert.ToString(cmd.ExecuteScalar());
                    if (data.Length > 2)
                        txtNote.Text = "Note: " + data;
                    else
                        txtNote.Text = "";
                }
                    conn.Close();
            }


            format();
        }

        private void format()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[1].HeaderText = "Job Name";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                //Graphics gs = Graphics.FromImage(bit);

                //gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                //bit.Save(@"C:\temp\temp.jpg");
                var frm = Form.ActiveForm;
                using (var bmp = new Bitmap(frm.Width, frm.Height))
                {
                    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(@"C:\temp\temp.png");
                }
                    printImage();
            }
            catch
            {

            }
        }


        private void printImage()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    System.Drawing.Image i = System.Drawing.Image.FromFile(@"C:\temp\temp.png");
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
    }
}
