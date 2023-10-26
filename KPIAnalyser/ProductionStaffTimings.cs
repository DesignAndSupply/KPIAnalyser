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
    public partial class ProductionStaffTimings : Form
    {



        public DateTime _dateString { get; set; }
        public string _department { get; set; }



        string _staffName;
        int _staffID;

        DateTime dateStart;
        DateTime dateEnd;

        
        public ProductionStaffTimings(string department, DateTime _dateStart,DateTime _dateEnd)
        {
            InitializeComponent();
       
            //Sets up the date string
            DateConversion DC = new DateConversion();
            //_dateString = DC.GetDate(month, year);
            _department = department;
            dateStart = _dateStart;
            dateEnd = _dateEnd;
            populateCombo();
            //populateStaffTimings();
        
        }


        private void populateStaffTimings()
        {
            int staffid = Convert.ToInt16(_staffID);
            string storedProcName = "";

            switch (_department)
            {
                case "Welding":
                    storedProcName = "usp_kpi_weld_timings_grid_staff";
                    break;
                case "Buffing":
                    storedProcName = "usp_kpi_buff_timings_grid_staff";
                    break;
                case "Packing":
                    storedProcName = "usp_kpi_pack_timings_grid_staff";
                    break;
            }

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();


            SqlCommand cmd = new SqlCommand(storedProcName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@start_Date", SqlDbType.DateTime).Value = dateStart;
            cmd.Parameters.Add("@end_Date", SqlDbType.DateTime).Value = dateEnd;
            cmd.Parameters.Add("@staff_id", SqlDbType.Int).Value = _staffID;

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgStaffTimings.DataSource = dt;
        }

        private void ProductionStaffTimings_Load(object sender, EventArgs e)
        {

        }


        private void populateCombo()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);

            conn.Open();

            


            SqlCommand cmd = new SqlCommand("usp_kpi_get_staff_in_department",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@start_date", SqlDbType.DateTime).Value = dateStart;
            cmd.Parameters.Add("@department", SqlDbType.NVarChar).Value = _department;

            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(rdr);
            cmbStaffSelect.ValueMember = "id";
            cmbStaffSelect.DisplayMember = "FullName";
            cmbStaffSelect.DataSource = dt;
           

        }

        private void cmbStaffSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refreshList()
        {
           
 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {


            _staffName = cmbStaffSelect.Text.ToString();

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionStringUser);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select id from dbo.[user] where forename + ' ' + surname = @fullName", conn);
            cmd.Parameters.AddWithValue("@fullName", _staffName);


            _staffID = Convert.ToInt16(cmd.ExecuteScalar());

            populateStaffTimings();

            refreshList();
            paintStaffGrid();
        }




        private void paintStaffGrid()
        {
            foreach (DataGridViewRow Myrow in dgStaffTimings.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToDouble(Myrow.Cells[4].Value) > 100)// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.LightSeaGreen;

                }
            }

            dgStaffTimings.ClearSelection();
        }
    }
}
