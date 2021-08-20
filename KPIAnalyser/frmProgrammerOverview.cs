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
using LiveCharts;
using LiveCharts.Wpf;

namespace KPIAnalyser
{
    public partial class frmProgrammerOverview : Form
    {
        public frmProgrammerOverview(String programmerName, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            List<double> data = new List<double>();
            List<string> days = new List<string>();

            lblTitle.Text = programmerName + " - " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy");
            string sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + programmerName + "'";
            int staff_id = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    staff_id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                sql = "Select count(id) as countDoors, CONVERT(nvarchar,cast(program_date as date)) as progDate from dbo.door a " +
                "inner join dbo.door_program b on a.id = b.door_id " +
                "where b.programed_by_id = " + staff_id + " and b.program_date >= '" + startDate.ToString("yyyyMMdd") + "' and b.program_date <= DATEADD(d, 1, '" + endDate.ToString("yyyyMMdd") + "')" +
               " group by cast(b.program_date as date)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    //use this datatable to full two lists for the chart info~

                    foreach (DataRow row in dt.Rows)
                    {
                        data.Add(Convert.ToDouble(row[0]));
                        days.Add(Convert.ToString(row[1]));
                    }
                }
                conn.Close();
            }

            var tempData = new ChartValues<double>();
            for (int i = 0; i < data.Count; i++)
            {
                tempData.Add(data[i]); //convert list to double list?
            }
            // value = value - 1;

            dailyItemsBar.Series.Add(new StackedColumnSeries
            {

                Values = tempData,
                DataLabels = true,
                Title = "Doors Programmed"
            }) ;

            dailyItemsBar.AxisX.Add(new Axis
            {
                Title = "Days",
                FontSize = 11,
                Labels = days,
                Separator = new Separator { Step = 1 }
            }) ;

            dailyItemsBar.AxisY.Add(new Axis
            {
                Title = "Number of doors",
                FontSize = 12,

            });
            dailyItemsBar.LegendLocation = LegendLocation.Top;
         
        }
    }
}
