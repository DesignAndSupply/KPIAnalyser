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
    public partial class frmProductionDoorTypeAnalysis : Form
    {


        public string _doorType { get; set; }
        public DateTime _firstDOM { get; set; }

        public string _department { get; set; }
        public frmProductionDoorTypeAnalysis(string doorType, DateTime firstDOM, string department)
        {
            InitializeComponent();
            _doorType = doorType;
            _firstDOM = firstDOM;
            _department = department;
            fillGrid();

        }


        private void fillGrid()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("usp_kpi_door_type_detailed_analysis", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@doorTypeDescription", SqlDbType.NVarChar).Value = _doorType;
            cmd.Parameters.Add("@start_date", SqlDbType.DateTime).Value = _firstDOM;

            cmd.Parameters.Add("@department", SqlDbType.NVarChar).Value = _department;

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgvDoorTypeBreakdown.DataSource = dt;
        }

        private void FrmProductionDoorTypeAnalysis_Load(object sender, EventArgs e)
        {

        }
    }
}
