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

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            clearGrid();
            DateTime dateString;
            
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

        private void clearGrid()
        {
            try
            {
                dgvCustomer.Columns.Remove("Button1");
               
            }
            catch
            {

            }
        }
        private void btnLost_Click(object sender, EventArgs e)
        {

            populateLostCustomers();


        }

        private void populateLostCustomers()
        {
            clearGrid();
            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);

            //dateString = Convert.ToDateTime("23/08/2018");


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

            //Color the datagrid

            paintGrid();



            //Add button to data grid
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "Button1";
                button.HeaderText = "Do Not Contact";
                button.Text = "Do Not Contact";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                if (dgvCustomer.Columns["Do Not Contact"] == null)
                {
                    this.dgvCustomer.Columns.Add(button);
                }
            }

        }


        private void paintGrid()
        {
            foreach (DataGridViewRow row in dgvCustomer.Rows)
            {

                string rowNotes = row.Cells["Notes"].Value.ToString();





                if (string.IsNullOrWhiteSpace(rowNotes) == false)
                {
                    row.Cells["FirstAndLast"].Style.BackColor = Color.LawnGreen;
                    row.Cells["FirstAndLast"].Style.ForeColor = Color.LawnGreen;
                    row.Cells["Last Time Ordered"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Customer"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Trade_Contact"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Telephone"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Telephone_2"].Style.BackColor = Color.LawnGreen;
                    row.Cells["AccRef"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Contact?"].Style.BackColor = Color.LawnGreen;
                    row.Cells["Notes"].Style.BackColor = Color.LawnGreen;
                }
                else
                {
                    if (row.Cells["Contact?"].Value.ToString() == "Do not contact")
                    {
                        row.Cells["FirstAndLast"].Style.BackColor = Color.DarkOrange;
                        row.Cells["FirstAndLast"].Style.ForeColor = Color.DarkOrange;
                        row.Cells["Last Time Ordered"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Customer"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Trade_Contact"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Telephone"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Telephone_2"].Style.BackColor = Color.DarkOrange;
                        row.Cells["AccRef"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Contact?"].Style.BackColor = Color.DarkOrange;
                        row.Cells["Notes"].Style.BackColor = Color.DarkOrange;
                    }
                    else
                    if (Convert.ToInt32(row.Cells["FirstAndLast"].Value) == -1)
                    {

                        row.Cells["FirstAndLast"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["FirstAndLast"].Style.ForeColor = Color.PaleVioletRed;
                        row.Cells["Last Time Ordered"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Customer"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Trade_Contact"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Telephone"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Telephone_2"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["AccRef"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Contact?"].Style.BackColor = Color.PaleVioletRed;
                        row.Cells["Notes"].Style.BackColor = Color.PaleVioletRed;


                    }
                    else
                    {
                        // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

                        row.Cells["FirstAndLast"].Style.BackColor = Color.White;
                        row.Cells["FirstAndLast"].Style.ForeColor = Color.White;
                    }
                }



            }
        }

        private void Sales_Click(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void dgvCustomer_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string accRef;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int selectedrowindex = dgvCustomer.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvCustomer.Rows[selectedrowindex];

                accRef = Convert.ToString(selectedRow.Cells["AccRef"].Value);


                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                if (checkDoNotOrder(accRef) == true)
                {
                    SqlCommand cmd = new SqlCommand("delete from dbo.crm_do_not_contact where customer_acc_ref=@accRef", conn);
                    cmd.Parameters.AddWithValue("@accRef", accRef);    //NEEDS THE ACC REF FROM THE CELL
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into dbo.crm_do_not_contact (customer_acc_ref, do_not_contact) values (@accRef,'Do not contact')", conn);
                    cmd.Parameters.AddWithValue("@accRef", accRef);    //NEEDS THE ACC REF FROM THE CELL
                    cmd.ExecuteNonQuery();
                }

                populateLostCustomers();
            }
        }

        private bool checkDoNotOrder(string custAccRef)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * from dbo.crm_do_not_contact where customer_acc_ref =@accRef",conn);
            cmd.Parameters.AddWithValue("@accRef", custAccRef);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                return true;
               

            }
            else
            {
                return false;
            }

            
        }

        private void btnRankedCustomerOrders_Click(object sender, EventArgs e)
        {
            clearGrid();
            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);

            //dateString = Convert.ToDateTime("23/08/2018");


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();


            SqlCommand cmd = new SqlCommand("usp_ranked_customer_orders", conn);
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

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dgvCustomer.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dgvCustomer.Rows[selectedrowindex];

            string accRef = Convert.ToString(selectedRow.Cells["AccRef"].Value);
            string cust = Convert.ToString(selectedRow.Cells["Customer"].Value);

            frmNonReturningCustomerDetails frmNRCD = new frmNonReturningCustomerDetails(accRef,cust);
            frmNRCD.ShowDialog();

        }
    }
}
