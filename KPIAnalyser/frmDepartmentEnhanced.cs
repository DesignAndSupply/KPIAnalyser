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
    public partial class frmDepartmentEnhanced : Form
    {
        public frmDepartmentEnhanced(string sql, string description, DateTime date)
        {
            InitializeComponent();
            lblDate.Text = date.ToString("dd-MM-yyyy");
            lblDescription.Text = description;
            loadData(sql);
        }

        private void loadData(string sql)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    

            }
        }
    }
}
