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
    public partial class frmRemakeResponsible : Form
    {
        public int dept_int { get; set; }
        public frmRemakeResponsible(int door_id, string dept_responsible)
        {
            InitializeComponent();
            int current_dept = 0;

            switch (dept_responsible)
            {
                case "Assessing":
                    current_dept = 0;
                    break;
                case "Programming":
                    current_dept = 1;
                    break;
                case "Checking":
                    current_dept = 2;
                    break;
                case "Punching":
                    current_dept = 3;
                    break;
                case "Bending":
                    current_dept = 4;
                    break;
                case "Welding":
                    current_dept = 5;
                    break;
                case "Buffing":
                    current_dept = 6;
                    break;
                case "Dressing":
                    current_dept = 6;
                    break;
                case "Painting":
                    current_dept = 7;
                    break;
                case "Packing":
                    current_dept = 8;
                    break;
                default:
                    current_dept = 9;
                    break;
            }
            dept_int = current_dept;

            //build a unique datatable based on several select strings for each dept

            DataTable finalDT = new DataTable();
            finalDT.Columns.Add("Department", typeof(string));
            finalDT.Columns.Add("Staff Responsible", typeof(string));

            string assessingStaff = "", programmingStaff = "", checkingStaff = "", punchingStaff = "", bendingStaff = "", weldingStaff = "", buffStaff = "", paintingStaff = "", packingStaff = "";

            string sql = "";
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                //assess/prog/check
                sql = "select ass_id.forename + ' ' + ass_id.surname as [assessed_by],pro_id.forename + ' ' + pro_id.surname as [programed_by],che_id.forename + ' ' + che_id.surname as [checked_by] from dbo.door_program " +
                     "left join [user_info].dbo.[user] as ass_id on ass_id.id = assessed_by_id " +
                     "left join [user_info].dbo.[user] as pro_id on pro_id.id = programed_by_id " +
                     "left join [user_info].dbo.[user] as che_id on che_id.id = checked_by_id WHERE door_id  =" + door_id;

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    assessingStaff = dt.Rows[0][0].ToString();
                    programmingStaff = dt.Rows[0][1].ToString();
                    checkingStaff = dt.Rows[0][2].ToString();
                }

                //punching
                sql = "select distinct forename + ' ' + surname as [punch_by] from dbo.remake left join dbo.power_plan_date on power_plan_date.date_plan = dbo.remake.date " +
                         "left join dbo.power_plan_staff on power_plan_staff.date_id = power_plan_date.id left join[user_info].dbo.[user] on[user].id = power_plan_staff.staff_id " +
                         "where power_plan_staff.department = 'Punching' AND [remake].door_id = " + door_id + " order by punch_by ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        punchingStaff = punchingStaff + row[0].ToString() + " / ";
                    }
                    punchingStaff = punchingStaff.Substring(0, punchingStaff.Length - 2);
                }

                //bending
                sql = "select max([user].forename) + ' ' + max([user].surname) [bend_by] from dbo.door_part_completion_log left join[user_info].dbo.[user] on[user].id = [door_part_completion_log].staff_id " +
                         "where op = 'bending' AND  door_id = " + door_id + " group by [door_part_completion_log].staff_id,door_id order by bend_by";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        bendingStaff = bendingStaff + row[0].ToString() + " / ";
                    }
                    bendingStaff = bendingStaff.Substring(0, bendingStaff.Length - 2);
                }


                //welding/buffing/packing
                sql = "select weld_staff_allocation as [weld_by],buff_staff_allocation as [buff_by],pack_staff_allocation as [pack_by] from dbo.door " +
                         "WHERE id = " + door_id;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    weldingStaff = dt.Rows[0][0].ToString();
                    buffStaff = dt.Rows[0][1].ToString();
                    packingStaff = dt.Rows[0][2].ToString();
                }

                //painting
                sql = "select max([user].forename) + ' ' + max([user].surname) as [paint_by] from dbo.door_part_completion_log  left join[user_info].dbo.[user] on[user].id = [door_part_completion_log].staff_id " +
                         "where part = 'powder coat' AND door_id = " + door_id + " group by staff_id,door_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        paintingStaff = paintingStaff + row[0].ToString() + " / ";
                    }
                    paintingStaff = paintingStaff.Substring(0, paintingStaff.Length - 2);
                }
                //need to speak to tom on painting
                conn.Close();
            }
            DataRow drAss = finalDT.NewRow();
            drAss[0] = "Assessing";
            drAss[1] = assessingStaff;
            DataRow drProg = finalDT.NewRow();
            drProg[0] = "Programming";
            drProg[1] = programmingStaff;
            DataRow drCheck = finalDT.NewRow();
            drCheck[0] = "Checking";
            drCheck[1] = checkingStaff;
            DataRow drPunch = finalDT.NewRow();
            drPunch[0] = "Punching";
            drPunch[1] = punchingStaff;
            DataRow drBend = finalDT.NewRow();
            drBend[0] = "Bending";
            drBend[1] = bendingStaff;
            DataRow drWeld = finalDT.NewRow();
            drWeld[0] = "Welding";
            drWeld[1] = weldingStaff;
            DataRow drBuff = finalDT.NewRow();
            drBuff[0] = "Buffing";
            drBuff[1] = buffStaff;
            DataRow drPaint = finalDT.NewRow();
            drPaint[0] = "Painting";
            drPaint[1] = paintingStaff;
            DataRow drPack = finalDT.NewRow();
            drPack[0] = "Packing";
            drPack[1] = packingStaff;

            finalDT.Rows.Add(drAss);
            finalDT.Rows.Add(drProg);
            finalDT.Rows.Add(drCheck);
            finalDT.Rows.Add(drPunch);
            finalDT.Rows.Add(drBend);
            finalDT.Rows.Add(drWeld);
            finalDT.Rows.Add(drBuff);
            finalDT.Rows.Add(drPaint);
            finalDT.Rows.Add(drPack);
            dataGridView1.DataSource = finalDT;

      

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void frmRemakeResponsible_Shown(object sender, EventArgs e)
        {
            for (int i = dept_int; i < dataGridView1.Rows.Count ; i++)
                dataGridView1.Rows[i].Visible = false;


        }
    }
}
