﻿using System;
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
    public partial class frmStaffDataChecker : Form
    {
        public frmStaffDataChecker()
        {
            InitializeComponent();
            string sql = "SELECT forename + ' ' +surname as staff from [user_info].dbo.[user] WHERE [current] =  1 and (non_user = 0 or non_user is null)";

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
            //get the start and end of current month
            dteStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dteEnd.Value = (dteStart.Value.AddMonths(1).AddDays(-1));
            apply_filter();
        }

        private void frmStaffDataChecker_Load(object sender, EventArgs e)
        {
        }

        private void apply_filter()
        {



            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();

                int staff_id = 0;
                string sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbStaff.Text + "' ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    staff_id = Convert.ToInt32(cmd.ExecuteScalar());


                //absent total
                sql = "select  coalesce(sum(1),0) as [Total Absent] from dbo.absent_holidays " +
                         "left join[user_info].dbo.[user] u on u.id = staff_id " +
                         "where(absent_type = 5 or absent_type = 8) AND " +
                         "staff_id = " + staff_id.ToString() +
                         " AND date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    lblAbsent.Text = "Total Absent Days: " +cmd.ExecuteScalar().ToString();
                }

                //late total
                sql = "select  coalesce(sum(1),0) as [ Total Late] from dbo.absent_holidays " +
                        "left join[user_info].dbo.[user] u on u.id = staff_id " +
                        "where(absent_type = 7) AND " +
                        "staff_id = " + staff_id.ToString() +
                        "AND date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    lblLate.Text = "Total Lade Days: " + cmd.ExecuteScalar().ToString();

                //absences
                sql = "select  Convert(char,date_absent,103)  as [Absent Date],datename(WEEKDAY,date_absent) as [Day of Week],sum(1) [Absent] from dbo.absent_holidays " +
                    "left join[user_info].dbo.[user] u on u.id = staff_id " +
                    "where(absent_type = 5 or absent_type = 8) AND " +
                    "staff_id =  " + staff_id.ToString() +
                    " AND date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                    "group by date_absent";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAbsent.DataSource = dt;
                }
                //lates 
                sql = "select  Convert(char,date_absent,103)  as [Late Date],datename(WEEKDAY,date_absent) as [Day of Week],sum(1) [Late] from dbo.absent_holidays " +
                    "left join[user_info].dbo.[user] u on u.id = staff_id " +
                    "where(absent_type = 7) AND " +
                    "staff_id =  " + staff_id.ToString() +
                    "AND date_absent >= '" + dteStart.Value.ToString("yyyy-MM-dd") + "' AND date_absent <= '" + dteEnd.Value.ToString("yyyy-MM-dd") + "' " +
                    "group by date_absent";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLate.DataSource = dt;
                }
                conn.Close();
            }
            format();
        }
        
        private void format()
        {
            foreach (DataGridViewColumn col in dgvAbsent.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewColumn col in dgvLate.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            apply_filter();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {

            apply_filter();
        }

        private void frmStaffDataChecker_Shown(object sender, EventArgs e)
        {
            //formatting here because it wont proc on open (instantly doing apply_filter)
            format();
        }
    }
}
