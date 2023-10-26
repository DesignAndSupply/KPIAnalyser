using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPIAnalyser
{
    public partial class frmViewCorrespondence : Form
    {

        public frmViewCorrespondence(string _date,string _staff)
        {
            InitializeComponent();

            lblTitle.Text = "Correspondence - " + _staff + " - " + _date;

            string sql = "select customer_name as [Customer Name],contact as [Contact],body as [Correspondence Note] FROM [order_database].dbo.quotation_chase_customer c " +
                         "LEFT JOIN [user_info].dbo.[user] u on c.correspondence_by = u.id " +
                         "where forename + ' ' + surname = '" + _staff + "' and cast(date_created as date) = '" + Convert.ToDateTime(_date).ToString("yyyyMMdd") + "'";


            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView1.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                }

                conn.Close();
            }

        }

        private void frmViewCorrespondence_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
