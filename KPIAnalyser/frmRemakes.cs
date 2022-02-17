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
    public partial class frmRemakes : Form
    {
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public int dept_only { get; set; }
        public int staff_only { get; set; }
        public string dept { get; set; }
        public string staff { get; set; }
        public frmRemakes(DateTime _dateStart, DateTime _dateEnd, int _dept_only, string _dept,int _staff_only,string _staff)
        {
            InitializeComponent();
            dateStart = _dateStart;
            dateEnd = _dateEnd;
            dept_only = _dept_only;
            staff_only = _staff_only;
            staff = _staff;
            dept = _dept;
            if (dept_only == -1)
                lblTitle.Text = dept + " Remakes From: " + dateStart.ToString("dd/MM/yyyy") + " to " + dateEnd.ToString("dd/MM/yyyy");
            else if (staff_only == -1)
                lblTitle.Text = "Remakes caused by " + _staff + " From: " + dateStart.ToString("dd/MM/yyyy") + " to " + dateEnd.ToString("dd/MM/yyyy");
            else
                lblTitle.Text = "Remakes From: " + dateStart.ToString("dd/MM/yyyy") + " to " + dateEnd.ToString("dd/MM/yyyy");
            apply_filter();
            this.WindowState = FormWindowState.Maximized;
        }

        private void format()
        {
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            double costTotal = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                costTotal = costTotal + Convert.ToDouble(row.Cells[8].Value);
            }
            lblTotal.Text = "TOTAL: £" + costTotal.ToString();
        }

        private void apply_filter()
        {

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            string sql = "select dbo.remake.door_id as [Door ID],[User] as [Logged By],[description] as [Remake Description],[date] as [Log Date],[NAME] as Customer,coalesce(u.forename + ' ' + u.surname,'') as [Person Responsible],d1.department_name as [Department Responsible] ,d2.department_name  as [Department Noticed] ,coalesce(cost,0) as Cost from dbo.remake " +
                                "left join dbo.door on dbo.door.id = dbo.remake.door_id left join dbo.SALES_LEDGER on dbo.SALES_LEDGER.ACCOUNT_REF = dbo.door.customer_acc_ref left join[user_info].dbo.[user] as u on u.id = dbo.remake.persons_responsible " +
                                "left join dsl_kpi.dbo.department as d1 on d1.id = dbo.remake.dept_responsible left join dsl_kpi.dbo.department as d2 on d2.id = dbo.remake.dept_noticed " +
                                "where [date] >= '" + dateStart.ToString("yyyy-MM-dd") + "' AND[date] < '" + dateEnd.ToString("yyyy-MM-dd") + "'";


            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
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

                //if (cmbPersonResponsible.Text.Length > 0)
                //{
                //    //work out which user it is 
                //    using (SqlCommand cmd = new SqlCommand("Select id from [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbPersonResponsible.Text + "'", conn))
                //    {
                //        var temp = Convert.ToString(cmd.ExecuteScalar());
                //        sql = sql + " AND [persons_responsible] = " + temp.ToString();
                //    }
                //}

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

                //dept onmly
                if (dept_only == -1)
                {
                    sql = sql + " AND d1.department_name = '" + dept + "' ";
                }
                if (staff_only == -1)
                {
                    sql = sql + " AND (u.forename) + ' ' + (u.surname) = '" + staff + "'";
                }

                sql = sql + " ORDER BY [DATE] asc, dbo.remake.door_id asc";
                conn.Close();
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
            format();
        }

        private void frmRemakes_Shown(object sender, EventArgs e)
        {
            format();

            //fill combo boxes 

            foreach (DataGridViewRow row in dataGridView1.Rows)
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

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbDeptNoticed_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbDeptResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbPersonResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void cmbLoggedBy_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnEmail_Click(object sender, EventArgs e)
        {
            //upload the current datagrid into the table ready to email
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmdWipe = new SqlCommand("DELETE FROM dbo.remake_data_email", conn);
            cmdWipe.ExecuteNonQuery();
            foreach (DataGridViewRow row in dataGridView1.Rows)
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
            cmd.Parameters.AddWithValue("@title", SqlDbType.Date).Value = lblTitle.Text;
            cmd.Parameters.AddWithValue("@total", SqlDbType.Date).Value = lblTotal.Text;
            cmd.ExecuteNonQuery();

            MessageBox.Show("Email Sent", "", MessageBoxButtons.OK);

            conn.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //sFullPath = "Z:\door_history 1\" & door_id & ".xlsm"
                string gtInput = @"\\DESIGNSVR1\terry\door_history 1\" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + ".xlsm";
                System.Diagnostics.Process.Start(gtInput);
                MessageBox.Show("Opening GT input sheet...", "Excel", MessageBoxButtons.OK);
            }
            else
            {
                //open a more detailed row
                frmRemakeResponsible frm = new frmRemakeResponsible(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value), dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()); //6
                frm.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int customer_index = 0;
            customer_index = dataGridView1.Columns["Customer"].Index;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string temp = dataGridView1.Rows[i].Cells[customer_index].Value.ToString();
                temp = temp.Trim();
                dataGridView1.Rows[i].Cells[customer_index].Value = temp;
            }

            string FileName = @"C:\temp\temp.xls";
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

            // Paste clipboard results to worksheet range
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
            // Delete blank column A and select cell A1
            Microsoft.Office.Interop.Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                delRng.Delete(Type.Missing);
                xlWorkSheet.get_Range("A1").Select();

            Microsoft.Office.Interop.Excel.Worksheet ws = xlexcel.ActiveWorkbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;
            //ws.Columns.ClearFormats();
            //ws.Rows.ClearFormats();
            //range.EntireColumn.AutoFit();
            //range.EntireRow.AutoFit();
            xlWorkSheet.Range["A1:H1"].EntireRow.Interior.Color = System.Drawing.Color.LightSkyBlue;
            xlWorkSheet.Columns[2].ColumnWidth = 98.14;
            xlWorkSheet.Columns[2].WrapText = true;
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

