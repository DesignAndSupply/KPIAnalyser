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

namespace KPIAnalyser
{
    public partial class frmViewQuotations : Form
    {


        public string _startDate { get; set; }
        public string _endDate { get; set; }
        public string _staffName { get; set; }


        public frmViewQuotations(string startDate, string endDate, string staffName)
        {
            InitializeComponent();
            _startDate = startDate;
            _endDate = endDate;
            _staffName = staffName;
            populateGrid();





            lblName.Text = "Quotations output by: " + staffName;
            lblStart.Text = "Start Date: " + startDate;
            lblEnd.Text = "End Date:  " + endDate;
        }

        private void FrmViewQuotations_Load(object sender, EventArgs e)
        {

        }


        private void populateGrid()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);

            conn.Open();


            SqlCommand cmd = new SqlCommand("usp_kpi_view_quotations", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = _startDate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = _endDate ;
            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = _staffName ;




            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = 0;

            int quoteID = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString());

            string quotationLocation = @"\\designsvr1\solidworks\Door Designer\Specifications\Project " + quoteID.ToString();


            Process.Start(quotationLocation);

        }
    }
}
