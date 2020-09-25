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
    public partial class frmInstallationComplaintDetails : Form
    {

        public string _startDate { get; set; }
        public string _endDate { get; set; }
        public string _dept { get; set; }
        public frmInstallationComplaintDetails(string startDate, string endDate, string dept)
        {
            _startDate = startDate;
            _endDate = endDate;
            _dept = dept;
            InitializeComponent();
            fillGrid();
        }

        private void fillGrid()
        {

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionStringComplaint);

            conn.Open();


            SqlCommand cmd = new SqlCommand("usp_kpi_installation_complaint_details", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@dept", SqlDbType.NVarChar).Value = _dept;
  
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = _startDate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = _endDate;



            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();

        }

        private void FrmInstallationComplaintDetails_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = 0;

            int complaintID = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString());

            Process.Start (@"C:\DesignAndSupply_Programs\Complaint_Program\Complaint_Program-28.accdb" , "/cmd" + complaintID.ToString());
        }
    }
}
