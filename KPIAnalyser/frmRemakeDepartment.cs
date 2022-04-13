using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using System.Data.SqlClient;
using Brushes = System.Windows.Media.Brushes;
using System.Windows.Media;
using System.Drawing.Printing;
using Outlook = Microsoft.Office.Interop.Outlook;
using Brush = System.Windows.Media.Brush;

namespace KPIAnalyser
{
    public partial class frmRemakeDepartment : Form
    {
        public string sql { get; set; }
        public string department { get; set; }
        public string type { get; set; }
        public frmRemakeDepartment(string _sql, string _department,int remake)
        {
            InitializeComponent();
            lblTitle.Text = _department;
            sql = _sql;

            if (remake == -1)
                type = "Remakes";
            else
                type = "Repaints";

            this.Text = "Cost / Amount of " + type;

            this.WindowState = FormWindowState.Maximized;

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<DateTime> datelist = new List<DateTime>();
            List<double> itemlist = new List<double>();
            List<string> temp = new List<string>();
            List<double> values = new List<double>();


            while (reader.Read())
            {
                //datelist.Add(reader.GetDateTime(1));
                //itemlist.Add(reader.GetInt32(1));
                itemlist.Add(reader.GetDouble(2));
                //MessageBox.Show(reader.GetString(0));
                values.Add(reader.GetDouble(2));
               // temp.Add(reader.GetDouble(2).ToString());
                //vv this is old code
                temp.Add((reader.GetString(0)) + " - " + Convert.ToString(reader.GetInt32(1)) + " " + type);
                ////values.Add(reader.GetDouble(2));
            }


            //string[] datearray = datelist.ToArray();
            double[] itemarray = itemlist.ToArray();

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = type,
                    FontSize = 10,
                    DataLabels = true,
                    
                    Fill = System.Windows.Media.Brushes.Green,

                    Values = new ChartValues<double>(itemarray)
                }
        };

            //cartesianChart1.Series.Add(new LineSeries
            //{
            //    Title = "Value",
            //    FontSize = 10,

            //    Fill = System.Windows.Media.Brushes.Orange,
            //    Values = new ChartValues<double> ( values )
            //});



            //string.Join(",", datearray)#
            //string[] temp;
            //List<string> strList = datearray.ToList;
            //IList<string> testValues = datearray;

            //IList<string> targetList = new List<string>(testValues.Cast<string>());



            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Staff",
                FontSize = 10,
                Labels = temp
            }); 

            //

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = type,
                FontSize = 16,

            });


            //
        }
    }
}
