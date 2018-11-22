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
    public partial class frmNonReturningCustomerDetails : Form
    {
        public frmNonReturningCustomerDetails(string customerAccRef,string customerName)
        {
            InitializeComponent();
            _customerAccRef = customerAccRef;
            _customerName = customerName;
            fillControls();
        }

        public string _customerAccRef { get; set; }
        public string _customerName { get; set; }
        public string _notes { get; set; }
        public DateTime _contactDate { get; set; }
        public string _contactedBy { get; set; }

        private void frmNonReturningCustomerDetails_Load(object sender, EventArgs e)
        {

        }
        private void fillControls()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from dbo.crm_do_not_contact where customer_acc_ref =@accRef", conn);
            cmd.Parameters.AddWithValue("@accRef", _customerAccRef);

            SqlDataReader rdr = cmd.ExecuteReader();
            lblCustomer.Text = _customerName;
            lblContactBy.Text = "Not contacted";
            lblContactDate.Text = "No Contact Date";
            while (rdr.Read())
            {
                lblContactBy.Text = "Contacted by: " + rdr["contacted_by"].ToString();
                lblContactDate.Text = "Contacted On: " + rdr["contacted_date"].ToString();
                txtNotes.Text = rdr["notes_of_conversation"].ToString();
            }


        }
    }
}
