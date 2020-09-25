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

namespace KPIAnalyser
{
    public partial class frmReturnVisits : Form
    {

        public string _visitType { get; set; }
        public string _startDate { get; set; }

        public string _st { get; set; }


        public string _endDate { get; set; }

        public frmReturnVisits(string st,string visitType, string startDate, string endDate)
        {
            InitializeComponent();
            _st = st;
            _visitType = visitType;
            _startDate = startDate;
            _endDate = endDate;
            populateGrid();
        }



        private void populateGrid()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);

            conn.Open();


            SqlCommand cmd = new SqlCommand("usp_kpi_return_visit_list", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@st", SqlDbType.NVarChar).Value = _st;
            cmd.Parameters.Add("@visitType", SqlDbType.NVarChar).Value = _visitType;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = _startDate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = _endDate;



            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
            //dataGridView1.DataBind();
        }


        private void FrmReturnVisits_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = 0;

            int visitID = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString());

            frmReturnVisitDetails frmRVD = new frmReturnVisitDetails(_st,visitID);
            frmRVD.ShowDialog();

        }
    }
}
