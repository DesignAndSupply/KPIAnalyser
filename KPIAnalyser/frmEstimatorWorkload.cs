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
using LiveCharts.Wpf;
using LiveCharts;
using System.Runtime.InteropServices.ComTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace KPIAnalyser
{
    public partial class frmEstimatorWorkload : Form
    {
        public frmEstimatorWorkload()
        {
            InitializeComponent();

            cmbStaff.Text = "All";

            load_combo();
            load_chart();
        }

        private void load_combo()
        {
            string sql = "SELECT forename + ' ' + surname FROM dbo.[user] where [grouping] = 5 and [current] = 1 AND (non_user = 0 or non_user is null)  order by forename";
            cmbStaff.Items.Add("All");
            cmbStaff.Items.Add("Tomas Grother");
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionStringUser))
            {
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
            }
        }

        private void load_chart()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_kpi_enquiry_estimator_workload", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date_start", SqlDbType.Date).Value = dteStart.Value;
                cmd.Parameters.Add("@date_end", SqlDbType.Date).Value = dteEnd.Value;
                cmd.Parameters.Add("@staff", SqlDbType.NVarChar).Value = cmbStaff.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                List<DateTime> datelist = new List<DateTime>();
                List<int> rotec_list    = new List<int>();
                List<int> other_list    = new List<int>();
                List<int> quoted_list   = new List<int>();
                List<string> date_list  = new List<string>();


                int total_rotec = 0;
                int total_other = 0;
                int total_quote = 0;
                while (reader.Read())
                {
                    //datelist.Add(reader.GetDateTime(1));
                    rotec_list.Add(reader.GetInt32(0));
                    total_rotec = total_rotec + (reader.GetInt32(0));
                    other_list.Add(reader.GetInt32(1));
                    total_other = total_other + (reader.GetInt32(1));
                    quoted_list.Add(reader.GetInt32(2));
                    total_quote = total_quote + (reader.GetInt32(2));
                    date_list.Add(reader.GetDateTime(3).ToShortDateString());
                }
                lblRotec.Text = "Total Rotec: " + total_rotec.ToString();
                lblOther.Text = "Total Other: " + total_other.ToString();
                lblQuoted.Text = "Total Quoted: " + total_quote.ToString();
                lblTotal.Text = "Overall Total: " + (total_rotec + total_other).ToString();


                //string[] datearray = datelist.ToArray();
                int[] rotec_array  = rotec_list.ToArray();
                int[] other_array  = other_list.ToArray();
                int[] quoted_array = quoted_list.ToArray();

                cartesianChart1.AxisY.Clear();
                cartesianChart1.AxisX.Clear();

                cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "ROTEC Enquiries",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Goldenrod,

                    Values = new ChartValues<int>(rotec_array)
                },
                 new ColumnSeries
                {
                    Title = "Other Enquiries",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.LightSkyBlue,

                    Values = new ChartValues<int>(other_array)
                },
                 new ColumnSeries
                {
                    Title = "Quoted Items",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.PaleVioletRed,

                    Values = new ChartValues<int>(quoted_array)
                }

            };


                //string.Join(",", datearray)#
                //string[] temp;
                //List<string> strList = datearray.ToList;
                //IList<string> testValues = datearray;

                //IList<string> targetList = new List<string>(testValues.Cast<string>());



                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Dates",
                    FontSize = 10,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Labels = date_list
                });

                //

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Items",
                    FontSize = 16,

                });

                conn.Close();
            }
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            load_chart();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            load_chart();
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_chart();
        }
    }
}
