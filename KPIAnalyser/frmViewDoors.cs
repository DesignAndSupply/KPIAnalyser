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
    public partial class frmViewDoors : Form
    {


        public string _startDate { get; set; }
        public string _endDate { get; set; }
        public string _staffName { get; set; }


        public frmViewDoors(string startDate, string endDate, string staffName)
        {
            InitializeComponent();
            _startDate = startDate;
            _endDate = endDate;
            _staffName = staffName;
            populateGrid();

            lblName.Text = "Doors Programmed by: " + staffName;
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


            SqlCommand cmd = new SqlCommand("usp_kpi_view_doors", conn);
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

            //try
           // {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                int columnindex = 0;

                int doorID = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString());

                string quotationLocation = @"\\designsvr1\terry\door_history 1\" + doorID.ToString() + ".xlsm";


                Process.Start(quotationLocation);



           // }

           // catch 
                
           // {

              

          //  }


        }
    }
}
