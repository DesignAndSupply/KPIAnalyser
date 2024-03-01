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
    public partial class frmLateness : Form
    {
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }

        public frmLateness(DateTime _dateStart, DateTime _dateEnd)
        {
            InitializeComponent();

            dateStart = _dateStart;
            dateEnd = _dateEnd;

            lblTitle.Text = " Late Orders From: " + dateStart.ToString("dd/MM/yyyy") + " to " + dateEnd.ToString("dd/MM/yyyy");


            fill_grid();
        }

        private void fill_grid()
        {
            string sql = "SELECT RTRIM(s.NAME) as Customer,door.id as [Door ID],door_ref as [Door Ref],order_number as [Order Number], dbo.door.date_completion as [Date Compeletion], " +
                "date_complete_on_order_acknowledgement as [Date Complete on Order Acknowledgement], " +
                "CASE WHEN date_completion <= date_complete_on_order_acknowledgement THEN cast(-1 as bit) ELSE cast(0 as bit) END AS [Completed on Time],packing_note as [Packing Note] " +
                "FROM dbo.door " +
                "LEFT OUTER JOIN dbo.door_type ON dbo.door.door_type_id = dbo.door_type.id " +
                "left join dbo.sales_ledger s on s.ACCOUNT_REF = door.customer_acc_ref " +
                "WHERE (dbo.door.date_complete_on_order_acknowledgement IS NOT NULL) AND " +
                "(dbo.door_type.slimline_y_n = 0 OR dbo.door_type.slimline_y_n IS NULL) ";

            if (chkAll.Checked == false)
                sql = sql + "AND CASE WHEN date_completion <= date_complete_on_order_acknowledgement THEN - 1 ELSE 0 END = 0 ";

            sql = sql + "AND date_completion > '" + dateStart.ToString("yyyyMMdd") + "' AND date_completion < '" + dateEnd.ToString("yyyyMMdd") + "' " +
            "order by order_number,door.id";

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
                conn.Close();
            }
            format();
        }

        private void format()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[dataGridView1.Columns.Count - 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void frmLateness_Shown(object sender, EventArgs e)
        {
            format();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            fill_grid();
        }
    }
}
