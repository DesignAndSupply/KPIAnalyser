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
    public partial class frmTimeInMotion : Form
    {
        public frmTimeInMotion()
        {
            InitializeComponent();
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

            fillStaff();
        }

        private void fillStaff()
        {
            cmbStaff.Text = "";
            cmbStaff.Items.Clear();

            string sql = "SELECT Distinct b.forename + ' ' + b.surname AS Fullname " +
                "FROM dbo.door_part_completion_log AS a " +
                "INNER JOIN user_info.dbo.[user] AS b ON a.staff_id = b.id " +
                "WHERE a.[part_complete_date] > = '" + dteStart1.Value.ToString("yyyyMMdd") + "' and a.part_complete_date <= '" + dteEnd1.Value.ToString("yyyyMMdd") + "' " +
                "and op = '" + cmbDepartment.Text + "' ";

            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbStaff.Items.Add(row[0].ToString());
                    }
                }

                conn.Close();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbYear.Text))
                return;

            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();

                //main datatable
                DataTable main_dt = new DataTable();
                main_dt.Columns.Add("Door Type");
                main_dt.Columns.Add("AVG time allowed 1");
                main_dt.Columns.Add("AVG time taken 1");
                main_dt.Columns.Add("% Difference 1");

                main_dt.Columns.Add(" ");

                main_dt.Columns.Add("AVG time allowed 2");
                main_dt.Columns.Add("AVG time taken 2");
                main_dt.Columns.Add("% Difference 2");

                main_dt.Columns.Add("  ");

                main_dt.Columns.Add("Difference between AVG time");


                //fill up the grid with the first date selection
                using (SqlCommand cmd = new SqlCommand("usp_time_in_motion_comparison", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@start_date", SqlDbType.DateTime).Value = dteStart1.Value;
                    cmd.Parameters.AddWithValue("@end_date", SqlDbType.DateTime).Value = dteEnd1.Value;
                    cmd.Parameters.AddWithValue("@department", SqlDbType.DateTime).Value = cmbDepartment.Text;
                    cmd.Parameters.AddWithValue("@staff_name", SqlDbType.DateTime).Value = cmbStaff.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow _row = main_dt.NewRow();
                        _row["Door Type"] = row[0].ToString();
                        _row["AVG time allowed 1"] = row[1].ToString();
                        _row["AVG time taken 1"] = row[2].ToString();
                        _row["% Difference 1"] = row[3].ToString();
                        main_dt.Rows.Add(_row);
                    }
                }

                //fill up the grid with the second date selection
                using (SqlCommand cmd = new SqlCommand("usp_time_in_motion_comparison", conn))
                {

                    DateTime _start_time = new DateTime(Convert.ToInt32(cmbYear.Text), dteStart1.Value.Month, dteStart1.Value.Day);
                    DateTime _end_time = new DateTime(Convert.ToInt32(cmbYear.Text), dteEnd1.Value.Month, dteEnd1.Value.Day);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@start_date", SqlDbType.DateTime).Value = _start_time;
                    cmd.Parameters.AddWithValue("@end_date", SqlDbType.DateTime).Value = _end_time;
                    cmd.Parameters.AddWithValue("@department", SqlDbType.DateTime).Value = cmbDepartment.Text;
                    cmd.Parameters.AddWithValue("@staff_name", SqlDbType.DateTime).Value = cmbStaff.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);



                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int z = 0; z < main_dt.Rows.Count; z++)
                        {
                            //MessageBox.Show(dt.Rows[i][0].ToString());
                            //MessageBox.Show(main_dt.Rows[z][0].ToString());

                            if (z >= main_dt.Rows.Count)
                            {
                                DataRow _row = main_dt.NewRow();
                                _row["Door Type"] = dt.Rows[i][0].ToString();
                                _row["AVG time allowed 2"] = dt.Rows[i][1].ToString();
                                _row["AVG time taken 2"] = dt.Rows[i][2].ToString();
                                _row["% Difference 2"] = dt.Rows[i][3].ToString();
                                main_dt.Rows.Add(_row);
                                break;
                            }
                            else if (dt.Rows[i][0].ToString() == main_dt.Rows[z][0].ToString())
                            {
                                main_dt.Rows[z][5] = dt.Rows[i][1].ToString();
                                main_dt.Rows[z][6] = dt.Rows[i][2].ToString();
                                main_dt.Rows[z][7] = dt.Rows[i][3].ToString();
                            }
                            //else
                            //{
                            //    DataRow _row = main_dt.NewRow();
                            //    _row["Door Type"] = dt.Rows[i][0].ToString();
                            //    _row["AVG time allowed 2"] = dt.Rows[i][1].ToString();
                            //    _row["AVG time taken 2"] = dt.Rows[i][2].ToString();
                            //    _row["% Difference 2"] = dt.Rows[i][3].ToString();
                            //    main_dt.Rows.Add(_row);
                            //    break;
                            //}
                        }



                        //DataRow _row = main_dt.NewRow();
                        //_row["Door Type"] = row[0].ToString();
                        //_row["AVG time allowed 2"] = row[1].ToString();
                        //_row["AVG time taken 2"] = row[2].ToString();
                        //_row["% Difference 2"] = row[3].ToString();
                        //main_dt.Rows.Add(_row);
                    }
                }

                foreach (DataRow row in main_dt.Rows)
                {
                    if (row[3].ToString().Length > 0 && row[6].ToString().Length > 0)
                        row[9] = Math.Round(Convert.ToDouble(row[2].ToString()) - Convert.ToDouble(row[6].ToString()),2);
                }

                int count = main_dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    if (main_dt.Rows[i][3].ToString().Length > 0 && main_dt.Rows[i][6].ToString().Length > 0)
                    {
                    }
                    else
                    { 
                        main_dt.Rows.RemoveAt(i);
                        i--;
                        count--;
                    }
                }

                dataGridView1.DataSource = main_dt;


                foreach (DataGridViewColumn col in dataGridView1.Columns)
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                double average_time = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToDouble(row.Cells[9].Value.ToString().Length) > 0)
                    {
                        if (Convert.ToDouble(row.Cells[9].Value.ToString()) > 0)
                            row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        else
                            row.DefaultCellStyle.BackColor = Color.LightSeaGreen;
                    }

                    average_time = average_time + Convert.ToDouble(row.Cells[9].Value.ToString());

                }

                average_time = Math.Round(average_time / dataGridView1.Rows.Count, 2);

                if (average_time == double.NaN)
                    average_time = 0;
               
                if (average_time >= 0)
                    lblAvg.Text = "Average Increase: " + average_time.ToString();
                else
                    lblAvg.Text = "Average Decrease: " + average_time.ToString();


                lblAvg.Text= lblAvg.Text.Replace("NaN", "0");


                conn.Close();
            }
        }

        private void frmTimeInMotion_Shown(object sender, EventArgs e)
        {
 
        }

        private void dteStart1_CloseUp(object sender, EventArgs e)
        {
            fillStaff();
        }

        private void dteEnd1_CloseUp(object sender, EventArgs e)
        {
            fillStaff();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillStaff();
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
