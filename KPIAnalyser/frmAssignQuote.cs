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
    public partial class frmAssignQuote : Form
    {
        public int _quoteID { get; set; }
        public int _revNumber { get; set; }
        public frmAssignQuote(int quoteID, int revNumber)
        {
            InitializeComponent();
            _quoteID = quoteID;
            _revNumber = revNumber;
            string sql = "SELECT forename +' ' + surname,id FROM dbo.[user] WHERE[grouping] = 5 and[current] = 1 and id<> 314";
            using (SqlConnection connTemp = new SqlConnection(ConnectionStrings.ConnectionStringUser))
            {
                connTemp.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connTemp))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    cmbEstimators.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbEstimators.Items.Add(row[0].ToString());
                    }
                }
                connTemp.Close();
            }
        }

        private void frmAssignQuote_Load(object sender, EventArgs e)
        {
            label1.Text = "Assign User to quote " + _quoteID.ToString();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbEstimators.Text == "")
            {
                MessageBox.Show("Please Selected a user first!", "ERROR");
                return;
            }
            string sql = "SELECT email_address FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbEstimators.Text + "'";
            string email_address = "";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    email_address = Convert.ToString(cmd.ExecuteScalar());
                }

                //apply it here
                sql = "UPDATE dbo.solidworks_quotation_log SET emailed_to = '" + email_address + "' WHERE quote_id = " + _quoteID.ToString() + " AND revision_number = " + _revNumber;  //possibly rev number only? would be number 4 in the datagridview
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                     cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            this.Close();
        }
    }
}
