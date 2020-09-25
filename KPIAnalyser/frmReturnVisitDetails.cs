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
    public partial class frmReturnVisitDetails : Form
    {

        public string _st { get; set; }

        public int _visitID { get; set; }
        public frmReturnVisitDetails(string st ,int visitID)
        {
            InitializeComponent();
            _st = st;
            _visitID = visitID;
            populateFields();
        }

        private void populateFields()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();


            if(_st== "t")
            {
                SqlCommand cmd = new SqlCommand("SELECT * from dbo.view_kpi_return_visit where id = @visitID;", conn);
                cmd.Parameters.AddWithValue("@visitID", _visitID);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    this.lblVisitDate.Text = rdr.GetDateTime(0).ToString();
                    this.lblDoorNumber.Text = rdr.GetInt32(1).ToString();
                    this.lblCustomerName.Text = rdr.GetString(2);
                    this.lblOrderNumber.Text = rdr.GetString(3);
                    this.lblOrderRef.Text = rdr.GetString(4);
                    this.textBox1.Text = rdr.GetString(5);
                    this.lblCost.Text = rdr.GetDouble(6).ToString();


                }

            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * from dbo.view_kpi_return_visit_sl where id = @visitID;", conn);
                cmd.Parameters.AddWithValue("@visitID", _visitID);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    this.lblVisitDate.Text = rdr.GetDateTime(0).ToString();
                    this.lblDoorNumber.Text = rdr.GetInt32(1).ToString();
                    this.lblCustomerName.Text = rdr.GetString(2);
                    this.lblOrderNumber.Text = rdr.GetString(3);
                    this.lblOrderRef.Text = rdr.GetString(4);
                    this.textBox1.Text = rdr.GetString(5);
                    this.lblCost.Text = rdr.GetDouble(6).ToString();


                }
            }
            

            conn.Close();



        }


        private void FrmReturnVisitDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
