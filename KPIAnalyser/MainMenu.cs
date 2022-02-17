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
            if (cmbMonth.Text == "")
                refreshProgramming();
            else
                refreshData();
        }
        private void refreshProgramming()
        {
            DateTime dateString;
            DateConversion dc = new DateConversion();
            dateString = dc.GetDate("January", cmbYear.Text);

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_engineering_loop_yearly", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startDate", SqlDbType.DateTime).Value = dateString;

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            ad.Fill(dt);

            dgvMonthly.DataSource = dt;

            conn.Close();
            paintEngineeringGrid();
        }



        private void getCurrent()
        {
            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);

            //dateString = Convert.ToDateTime("23/08/2018");


            using (SqlConnection con = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_kpi_analysis", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@start_Date", SqlDbType.DateTime).Value = dateString;


                    con.Open();

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

                        txtInstallationCost.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["InstallationCost"]);
                        txtInstallationSales.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["InstallationSales"]);
                        txtInstallationMarkup.Text = reader["InstallationMarkup"].ToString() + '%';

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
                    con.Close();

                    //Populate accounts data
                    fillAccounts();



                }
            }


        }
        private void populateBuffTimingsGrid()
        {
            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);

            //dateString = Convert.ToDateTime("23/08/2018");


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();


            SqlCommand cmd = new SqlCommand("usp_kpi_buff_timings_grid", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@start_Date", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = dateString;

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgBuffTimings.DataSource = dt;
        }
        private void populateWeldTimingsGrid()
        {
            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);

            //dateString = Convert.ToDateTime("23/08/2018");

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("usp_kpi_weld_timings_grid", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@start_Date", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = dateString;

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgWeldTimings.DataSource = dt;
        }


        private void populatePackTimingsGrid()
        {
            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);

            //dateString = Convert.ToDateTime("23/08/2018");

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();


            SqlCommand cmd = new SqlCommand("usp_kpi_pack_timings_grid", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter();
            param = cmd.Parameters.Add("@start_Date", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Input;
            param.Value = dateString;

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adap.Fill(dt);
            dgPackTimings.DataSource = dt;
        }



        private void fillAccounts()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.kpi_accounts where [Month]=@month and [Year]=@year", conn);
            cmd.Parameters.AddWithValue("@month", cmbMonth.Text);
            cmd.Parameters.AddWithValue("@year", cmbYear.Text);

            SqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                txtTurnover.Text = rdr["turnover"].ToString();
                txtGrossProfit.Text = rdr["gross_profit"].ToString();
                txtDebtorsCurrent.Text = rdr["debt_current"].ToString();
                txtDebtors30.Text = rdr["debt_30"].ToString();
                txtDebtors60.Text = rdr["debt_60"].ToString();
                txtDebtors90.Text = rdr["debt_90"].ToString();
                txtDebtorsOlder.Text = rdr["debt_older"].ToString();
                txtCreditorsCurrent.Text = rdr["credit_current"].ToString();
                txtCreditors30.Text = rdr["credit_30"].ToString();
                txtCreditors60.Text = rdr["credit_60"].ToString();
                txtCreditors90.Text = rdr["credit_90"].ToString();
                txtCreditorsOlder.Text = rdr["credit_older"].ToString();

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
                txtTraditionalTurnaroundT.Text = reader["traditional_estimating_turnaround"] + " Hours";
                txtSlimlineSalesT.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["slimline_target_value"]);
                txtSlimlineEstimatingT.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", reader["slimline_estimating_target"]);
                txtSlimlineTurnaroundT.Text = reader["slimline_quotation_turnaround"] + " Hours";

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
            populateWeldTimingsGrid();
            populatePackTimingsGrid();
            populateBuffTimingsGrid();
            paintWeldingGrid();
            paintBuffingGrid();
            paintPackingGrid();
            fillEngineeringGrid();
            fillEngineeringOvertime();
            paint();
            paintEngineeringGridDaily();

        }

        private void fillEngineeringGrid()
        {
            DateTime dateString;

            DateConversion dc = new DateConversion();
            dateString = dc.GetDate(cmbMonth.Text, cmbYear.Text);


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_engineering_loop", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startDate", SqlDbType.DateTime).Value = dateString;


            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();



            ad.Fill(dt);

            dgvMonthly.DataSource = dt;

            conn.Close();
            paintEngineeringGrid();

        }


        private void fillEngineeringOvertime()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT employee_name as 'Employee' , OT_Hours 'Total Overtime' from dbo.kpi_overtime_hours WHERE [month]= @month and [year] = @year and is_engineer = -1 order by employee_name", conn);

            cmd.Parameters.AddWithValue("@month", cmbMonth.Text);
            cmd.Parameters.AddWithValue("@year", cmbYear.Text);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            //dgEngineerOvertime.DataSource = dt;
            conn.Close();
        }

        private void paintEngineeringGrid()
        {
            foreach (DataGridViewRow Myrow in dgvMonthly.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToDouble(Myrow.Cells[15].Value) < Convert.ToDouble(Myrow.Cells[14].Value))// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.LightSeaGreen;

                }
            }

            dgvMonthly.ClearSelection();
        }


        private void paintEngineeringGridDaily()
        {

            float overTarget = 0f;
            float underTarget = 0f;
            float goldTarget = 0f;
            float percentageTarget = 0f;

            foreach (DataGridViewRow Myrow in dgEngineeringDaily.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToDouble(Myrow.Cells[15].Value) < Convert.ToDouble(Myrow.Cells[14].Value))// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    underTarget = underTarget + 1;
                }
                else if ((Convert.ToDouble(Myrow.Cells[15].Value) - Convert.ToDouble(Myrow.Cells[14].Value)) > 5)
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Yellow;
                    goldTarget = goldTarget + 1;
                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.LightSeaGreen;
                    overTarget = overTarget + 1;
                }

            }

            lblGold.Text = goldTarget.ToString() + " Days";
            lblOver.Text = overTarget.ToString() + " Days";
            lblUnder.Text = underTarget.ToString() + " Days";

            try
            {
                percentageTarget = ((goldTarget + overTarget) / (goldTarget + overTarget + underTarget)) * 100;
            }
            catch
            {

            }

            lblPercentageOver.Text = percentageTarget.ToString() + "%";

            dgEngineeringDaily.ClearSelection();
        }



        private void paintWeldingGrid()
        {
            foreach (DataGridViewRow Myrow in dgWeldTimings.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToDouble(Myrow.Cells[3].Value) > 100)// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.LightSeaGreen;

                }
            }

            dgvMonthly.ClearSelection();
        }

        private void paintBuffingGrid()
        {
            foreach (DataGridViewRow Myrow in dgBuffTimings.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToDouble(Myrow.Cells[3].Value) > 100)// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.LightSeaGreen;

                }
            }

            dgvMonthly.ClearSelection();
        }

        private void paintPackingGrid()
        {
            foreach (DataGridViewRow Myrow in dgPackTimings.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToDouble(Myrow.Cells[3].Value) > 100)// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.LightSeaGreen;

                }
            }

            dgvMonthly.ClearSelection();
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


        private void generateEngineerData(string fullname)
        {
            DateTime dateString;
            if (cmbMonth.Text == "")
            {
                DateConversion dc = new DateConversion();
                dateString = dc.GetDate("January", cmbYear.Text);
                lblEngineerName.Text = fullname;
                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_detailed_engineering_info_yearly", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fullName", SqlDbType.NVarChar).Value = fullname;
                cmd.Parameters.AddWithValue("@startDate", SqlDbType.Date).Value = dateString;
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblProg.Text = rdr[0].ToString();
                    lblAssess.Text = rdr[1].ToString();
                    lblCheck.Text = rdr[2].ToString();
                    lblDraw.Text = rdr[3].ToString();
                    lblHoliday.Text = rdr[4].ToString();
                    lblAbsent.Text = rdr[5].ToString();
                    lblLate.Text = rdr[6].ToString();
                    lblOvertimeHours.Text = rdr[7].ToString();
                }
                conn.Close();
                populateDailyEngineerGridYearly(fullname);

            }
            else
            {
                DateConversion dc = new DateConversion();
                dateString = dc.GetDate(cmbMonth.Text, cmbYear.Text);
                lblEngineerName.Text = fullname;
                SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_kpi_detailed_engineering_info", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fullName", SqlDbType.NVarChar).Value = fullname;
                cmd.Parameters.AddWithValue("@startDate", SqlDbType.Date).Value = dateString;
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblProg.Text = rdr[0].ToString();
                    lblAssess.Text = rdr[1].ToString();
                    lblCheck.Text = rdr[2].ToString();
                    lblDraw.Text = rdr[3].ToString();
                    lblHoliday.Text = rdr[4].ToString();
                    lblAbsent.Text = rdr[5].ToString();
                    lblLate.Text = rdr[6].ToString();
                    lblOvertimeHours.Text = rdr[7].ToString();
                }


                conn.Close();
                populateDailyEngineerGrid(fullname);
            }
            
            paintEngineeringGridDaily();
            programmingLessDetail();
        }

        private void populateDailyEngineerGridYearly(string fullname)
        {
            DateTime dateString;

            DateConversion dc = new DateConversion();
            dateString = dc.GetDate("January", cmbYear.Text);


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_engineering_loop_daily_yearly", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startDate", SqlDbType.DateTime).Value = dateString;
            cmd.Parameters.AddWithValue("@staffName", SqlDbType.NVarChar).Value = fullname;

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            ad.Fill(dt);

            dgEngineeringDaily.DataSource = dt;

            conn.Close();
        }

        private void populateDailyEngineerGrid(string fullname)
        {
            DateTime dateString;

            DateConversion dc = new DateConversion();
            dateString = dc.GetDate(cmbMonth.Text, cmbYear.Text);


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_engineering_loop_daily", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startDate", SqlDbType.DateTime).Value = dateString;
            cmd.Parameters.AddWithValue("@staffName", SqlDbType.NVarChar).Value = fullname;

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            ad.Fill(dt);

            dgEngineeringDaily.DataSource = dt;

            conn.Close();
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
            SqlCommand cmd = new SqlCommand("SELECT * from dbo.crm_do_not_contact where customer_acc_ref =@accRef", conn);
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

            frmNonReturningCustomerDetails frmNRCD = new frmNonReturningCustomerDetails(accRef, cust);
            frmNRCD.ShowDialog();

        }

        private void groupBox14_Enter(object sender, EventArgs e)
        {

        }

        private void btnCommitAccounts_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbMonth.Text) || string.IsNullOrWhiteSpace(cmbYear.Text))
            {
                MessageBox.Show("Please ensure you have a month and a year selected", "Missing month or year", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE dbo.kpi_accounts set turnover=@turnover,gross_profit=@grossProfit," +
                                                    "debt_current=@debtCurrent,debt_30=@debt30, debt_60=@debt60,debt_90=@debt90,debt_older=@debtOlder," +
                                                    "credit_current=@creditCurrent, credit_30=@credit30, credit_60 =@credit60, credit_90=@credit90, credit_older =@creditOlder " +
                                                    "where [Month] = @month and [Year]=@year", conn);

                    cmd.Parameters.AddWithValue("@turnover", txtTurnover.Text);
                    cmd.Parameters.AddWithValue("@grossProfit", txtGrossProfit.Text);
                    cmd.Parameters.AddWithValue("@debtCurrent", txtDebtorsCurrent.Text);
                    cmd.Parameters.AddWithValue("@debt30", txtDebtors30.Text);
                    cmd.Parameters.AddWithValue("@debt60", txtDebtors60.Text);
                    cmd.Parameters.AddWithValue("@debt90", txtDebtors90.Text);
                    cmd.Parameters.AddWithValue("@debtOlder", txtDebtorsOlder.Text);

                    cmd.Parameters.AddWithValue("@CreditCurrent", txtCreditorsCurrent.Text);
                    cmd.Parameters.AddWithValue("@Credit30", txtCreditors30.Text);
                    cmd.Parameters.AddWithValue("@Credit60", txtCreditors60.Text);
                    cmd.Parameters.AddWithValue("@Credit90", txtCreditors90.Text);
                    cmd.Parameters.AddWithValue("@CreditOlder", txtCreditorsOlder.Text);

                    cmd.Parameters.AddWithValue("@month", cmbMonth.Text);
                    cmd.Parameters.AddWithValue("@year", cmbYear.Text);

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Accounts data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("An error has occured, if this error persists please contact IT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnWeldStaffTimingBreakdown_Click(object sender, EventArgs e)
        {
            ProductionStaffTimings pst = new ProductionStaffTimings("Welding", this.cmbMonth.Text, this.cmbYear.Text);
            pst.ShowDialog();
        }

        private void btnPackStaffTimingBreakdown_Click(object sender, EventArgs e)
        {
            ProductionStaffTimings pst = new ProductionStaffTimings("Packing", this.cmbMonth.Text, this.cmbYear.Text);
            pst.ShowDialog();
        }

        private void btnBuffStaffTimingBreakdown_Click(object sender, EventArgs e)
        {
            ProductionStaffTimings pst = new ProductionStaffTimings("Buffing", this.cmbMonth.Text, this.cmbYear.Text);
            pst.ShowDialog();
        }

        private void DgvMonthly_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonthly.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvMonthly.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvMonthly.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["fullname"].Value); 

                generateEngineerData(a);

            }
        }

        private void TxtReturnValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void TabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            paintEngineeringGrid();
            paintEngineeringGridDaily();
            paintBuffingGrid();
            paintWeldingGrid();
            paintPackingGrid();
        }

        private void DgvMonthly_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label85_Click(object sender, EventArgs e)
        {

        }

        private void DgWeldTimings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgWeldTimings_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {



            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);



            if (dgWeldTimings.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgWeldTimings.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgWeldTimings.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Door Type"].Value);

                frmProductionDoorTypeAnalysis dta = new frmProductionDoorTypeAnalysis(a, dateString, "Welding");
                dta.ShowDialog();

            }
        }

        private void DgBuffTimings_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);



            if (dgBuffTimings.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgBuffTimings.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgBuffTimings.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Door Type"].Value);

                frmProductionDoorTypeAnalysis dta = new frmProductionDoorTypeAnalysis(a, dateString, "Buffing");
                dta.ShowDialog();

            }
        }

        private void DgPackTimings_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DateTime dateString;

            DateConversion DC = new DateConversion();
            dateString = DC.GetDate(cmbMonth.Text, cmbYear.Text);



            if (dgPackTimings.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgPackTimings.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgPackTimings.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Door Type"].Value);

                frmProductionDoorTypeAnalysis dta = new frmProductionDoorTypeAnalysis(a, dateString, "Packing");
                dta.ShowDialog();

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmEngineeringManagement frmEM = new frmEngineeringManagement();
            frmEM.ShowDialog();
        }

        private void BtnEstimating_Click(object sender, EventArgs e)
        {
            frmEstimatingProductivity frmep = new frmEstimatingProductivity();
            frmep.Show();
        }

        private void BtnInstallationPerformance_Click(object sender, EventArgs e)
        {
            frmInstallationProductivity frmip = new frmInstallationProductivity();
            frmip.Show();
        }

        private void BtnProgrammerProductivity_Click(object sender, EventArgs e)
        {
            frmProgrammingProductivity frmpp = new frmProgrammingProductivity();
            frmpp.Show();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void DgEngineeringDaily_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnMoreLess_Click(object sender, EventArgs e)
        {
            if (this.dgEngineeringDaily.Columns[8].Visible == true)
            {
                programmingLessDetail();
            }
            else
            {
                programmingMoreDetail();
            }

        }


        private void programmingMoreDetail()
        {
            this.dgEngineeringDaily.Columns[2].Visible = true;
            this.dgEngineeringDaily.Columns[3].Visible = true;
            this.dgEngineeringDaily.Columns[4].Visible = true;
            this.dgEngineeringDaily.Columns[5].Visible = true;
            this.dgEngineeringDaily.Columns[6].Visible = true;
            this.dgEngineeringDaily.Columns[7].Visible = true;
            this.dgEngineeringDaily.Columns[8].Visible = true;
            this.dgEngineeringDaily.Columns[9].Visible = true;
            this.dgEngineeringDaily.Columns[10].Visible = true;
            this.dgEngineeringDaily.Columns[11].Visible = true;
            this.dgEngineeringDaily.Columns[12].Visible = true;
            this.dgEngineeringDaily.Columns[13].Visible = true;
        }

        private void programmingLessDetail()
        {
            this.dgEngineeringDaily.Columns[2].Visible = false;
            this.dgEngineeringDaily.Columns[3].Visible = false;
            this.dgEngineeringDaily.Columns[4].Visible = false;
            this.dgEngineeringDaily.Columns[5].Visible = false;
            this.dgEngineeringDaily.Columns[6].Visible = false;
            this.dgEngineeringDaily.Columns[7].Visible = false;
            this.dgEngineeringDaily.Columns[8].Visible = false;
            this.dgEngineeringDaily.Columns[9].Visible = false;
            this.dgEngineeringDaily.Columns[10].Visible = false;
            this.dgEngineeringDaily.Columns[11].Visible = false;
            this.dgEngineeringDaily.Columns[12].Visible = false;
            this.dgEngineeringDaily.Columns[13].Visible = false;
        }

        private void uPLOADOVERTIMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpload frm = new frmUpload();
            frm.ShowDialog();
        }

        private void dgEngineeringDaily_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //open up form here that shows notes + other stuff
            frmProgrammerSummary frm = new frmProgrammerSummary(lblEngineerName.Text, Convert.ToDateTime(dgEngineeringDaily.Rows[e.RowIndex].Cells[1].Value));
            frm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSlimlineEstimatingProductivity frm = new frmSlimlineEstimatingProductivity();
            frm.Show();
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            frmAdminManagement frm = new frmAdminManagement();
            frm.ShowDialog();
        }
    }
}
