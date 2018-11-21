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
using System.Globalization;

namespace KPIAnalyser
{
    public partial class txtTraditionalConversionRate : Form
    {
        public txtTraditionalConversionRate()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void getCurrent()
        {
            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);

            //dateString = Convert.ToDateTime("23/08/2018");


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();


            SqlCommand cmd = new SqlCommand("usp_kpi_analysis", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@start_Date", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = dateString;



            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txtTraditionalSales.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["TraditionalSales"]);
                txtTraditionalEstimating.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["TraditionalEstimating"]);
                txtTraditionalTurnaround.Text = reader["TraditionalQuotationTurnaround"].ToString();
                txtTraditionalConversion.Text = reader["TraditionalConversion"].ToString() + '%';
                txtTraditionalQuoteCount.Text = reader["TraditionalQuoteCount"].ToString();


                txtSlimlineSales.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["SlimlineSales"]);
                txtSlimlineEstimating.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["SlimlineEstimating"]);
                txtSlimlineTurnaround.Text = reader["SlimlineQuotationTurnaround"].ToString();
                txtSlimlineConversion.Text = reader["SlimlineConversion"].ToString() + '%';
                txtSlimlineQuoteCount.Text = reader["SlimlineQuoteCount"].ToString();

                txtFreehandSales.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["FreehandSales"]);
                txtUniqueCustomers.Text = reader["UniqueCustomers"].ToString();
                txtNewCustomer.Text = reader["NewCustomers"].ToString();
                txtNonReturning.Text = reader["LostCustomers"].ToString();

                txtTop3Sales.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["Top3Sales"]);
                txtTop3Dependancy.Text = string.Format("{0:0.0%}", reader["Top3Dependancy"]);


                txtPipelineEntries.Text = reader["PipelineAdditions"].ToString();
                txtPipelineValues.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["PipelineValue"]);
                txtMeetings.Text = reader["MeetingCount"].ToString();
                txtOATurnaround.Text = reader["OATurnaround"].ToString();


                //Install related
                txtReturnInternal.Text = reader["NumberOfReturnVisitsInternal"].ToString();
                txtReturnExternal.Text = reader["NumberOfReturnVisitsExternal"].ToString();
                txtReturnValue.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["ValueOfReturnVisits"]);
                txtBookingInDelay.Text = reader["BookingInDelay"].ToString();


                //Production related
                txtRemakeCount.Text = reader["RemakeCount"].ToString();
                txtRepaintCount.Text = reader["RepaintCount"].ToString();
                txtDoorsPunched.Text = reader["DoorsPunched"].ToString();
                txtDoorsBent.Text = reader["DoorsBent"].ToString();
                txtDoorsWelded.Text = reader["DoorsWelded"].ToString();
                txtDoorsBuffed.Text = reader["DoorsBuffed"].ToString();
                txtDoorsPainted.Text = reader["DoorsPainted"].ToString();
                txtDoorsPacked.Text = reader["DoorsPacked"].ToString();
                txtDiffToOA.Text = reader["DifferenceToOA"].ToString();
                txtAverageSlimlineLeadtime.Text = reader["SlimlineLeadTime"].ToString();
                txtAverageTraditionalLeadtime.Text = reader["TraditionalLeadTime"].ToString();

            }
            conn.Close();

        }

        private void getTarget()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();


            SqlCommand cmd = new SqlCommand("select * from dbo.forecast_target where forecast_month=@month and forecast_year = @year", conn);
            cmd.Parameters.AddWithValue("@month", cmbMonth.Text);
            cmd.Parameters.AddWithValue("@year", cmbYear.Text);


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txtTraditionalSalesT.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["target_value"]);
                txtTraditionalEstimatingT.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["traditional_estimating_target"]);
                txtTraditionalTurnaroundT.Text =  reader["traditional_estimating_turnaround"] + " Hours";
                txtSlimlineSalesT.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["slimline_target_value"]);
                txtSlimlineEstimatingT.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["slimline_estimating_target"]);
                txtSlimlineTurnaroundT.Text =  reader["slimline_quotation_turnaround"] + " Hours" ;


                txtFreehandSalesT.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["freehand_sales_target"]);
                txtMeetingsT.Text = reader["meeting_target"].ToString(); ;
                txtPipelineEntriesT.Text = reader["pipeline_entry_target"].ToString();
                txtPipelineValuesT.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["pipeline_value_target"]);

                txtReturnInternalT.Text = reader["return_visit_internal_target"].ToString();
                txtReturnExternalT.Text = reader["return_visit_external_target"].ToString();
                txtReturnValueT.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["return_visit_value_target"]);

                txtOATurnaroundT.Text = reader["acknowledgement_turn_around_target"] + " Days";

                txtBookingInDelayT.Text = reader["booking_in_delay_target"] + " Hours";

            }

            conn.Close();
        }

        private void paint()
        {
            

        }


        private void refreshData()
        {


            getCurrent();
            getTarget();
            paint();


          
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void txtTraditionalSalesT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTraditionalSales_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTraditionalEstimating_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello! =)");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void btnViewNew_Click(object sender, EventArgs e)
        {
            DateTime dateString;
            lblMessage.Visible = false;
            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);

            //dateString = Convert.ToDateTime("23/08/2018");


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();


            SqlCommand cmd = new SqlCommand("usp_new_customer_view", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@start_Date", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = dateString;

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgvCustomer.DataSource = dt;


        }


        private void dgvCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }


        private void btnLost_Click(object sender, EventArgs e)
        {
            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);

            //dateString = Convert.ToDateTime("23/08/2018");
            lblMessage.Visible = true;

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();


            SqlCommand cmd = new SqlCommand("usp_lost_customer_view", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@start_Date", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = dateString;

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgvCustomer.DataSource = dt;
            paintGrid();
        }


        private void paintGrid()
        {
            foreach (DataGridViewRow row in dgvCustomer.Rows)
            {
                if (Convert.ToInt32(row.Cells["FirstAndLast"].Value) == -1)
                {
                    row.Cells["FirstAndLast"].Style.BackColor = Color.PaleVioletRed;
                    row.Cells["FirstAndLast"].Style.ForeColor = Color.PaleVioletRed;
                    row.Cells["Last Time Ordered"].Style.BackColor = Color.PaleVioletRed;
                    row.Cells["Customer"].Style.BackColor = Color.PaleVioletRed;
                    row.Cells["Trade_Contact"].Style.BackColor = Color.PaleVioletRed;
                    row.Cells["Telephone"].Style.BackColor = Color.PaleVioletRed;
                    row.Cells["Telephone_2"].Style.BackColor = Color.PaleVioletRed;
                }
                else
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

                    row.Cells["FirstAndLast"].Style.BackColor = Color.White;
                    row.Cells["FirstAndLast"].Style.ForeColor = Color.White;
                }
            }
        }

        private void Sales_Click(object sender, EventArgs e)
        {

        }
    }
}
