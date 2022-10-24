using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class frmRemakeRepaintGraph : Form
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        List<string> remakeDepartments = new List<string>();

        List<string> repaintDepartments = new List<string>();
        public frmRemakeRepaintGraph(DateTime _startDate, DateTime _endDate)
        {
            InitializeComponent();
            startDate = _startDate;
            endDate = _endDate;
            loadCharts();
        }

        private void loadCharts()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                if (1 == 1) //repaints
                {
                    lblRepaints.Text = "Department Repaints : " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy");
                    SqlCommand cmd = new SqlCommand("usp_kpi_production_manager_repaint_graph", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DateTime> datelist = new List<DateTime>();
                    List<double> repaint_cost = new List<double>();
                    List<string> department = new List<string>();



                    while (reader.Read())
                    {
                        //datelist.Add(reader.GetDateTime(1));
                        department.Add(reader.GetString(0));
                        repaintDepartments.Add(reader.GetString(0));
                        repaint_cost.Add(reader.GetDouble(2));
                    }

                    reader.Close();
                    //string[] datearray = datelist.ToArray();
                    double[] itemarray = repaint_cost.ToArray();

                    repaintChart.AxisY.Clear();
                    repaintChart.AxisX.Clear();

                    repaintChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Repaint Cost",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.LightSkyBlue,

                    Values = new ChartValues<double>(itemarray)
                }};

                    repaintChart.AxisX.Add(new Axis
                    {
                        Title = "Departments",
                        FontSize = 10,
                        Labels = department
                    });

                    repaintChart.AxisY.Add(new Axis
                    {
                        Title = "Repaint Value",
                        FontSize = 16,

                    });
                } //repaints

                if (1 == 1) //repaints
                {
                    lblRemakes.Text = "Department Remakes : " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy");
                    SqlCommand cmd = new SqlCommand("usp_kpi_production_manager_remake_graph", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DateTime> datelist = new List<DateTime>();
                    List<double> remake_cost = new List<double>();
                    List<string> department = new List<string>();



                    while (reader.Read())
                    {
                        //datelist.Add(reader.GetDateTime(1));
                        department.Add(reader.GetString(0));
                        remakeDepartments.Add(reader.GetString(0));
                        remake_cost.Add(reader.GetDouble(1));
                    }


                    //string[] datearray = datelist.ToArray();
                    double[] itemarray = remake_cost.ToArray();

                    remakeChart.AxisY.Clear();
                    remakeChart.AxisX.Clear();

                    remakeChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Remake Cost",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.PaleVioletRed,

                    Values = new ChartValues<double>(itemarray)
                }};

                    remakeChart.AxisX.Add(new Axis
                    {
                        Title = "Departments",
                        FontSize = 10,
                        Labels = department
                    });

                    remakeChart.AxisY.Add(new Axis
                    {
                        Title = "Remake Value",
                        FontSize = 16,

                    });
                } //remakes
                conn.Close();
            }
        }

        private void repaintChart_DataClick(object sender, ChartPoint p)
        {
            var asPixels = repaintChart.Base.ConvertToPixels(p.AsPoint());
            string department = repaintDepartments[Convert.ToInt32(p.X)].ToString();
            frmRemakeRepaintDepartmentGraph frm = new frmRemakeRepaintDepartmentGraph(startDate, endDate, department, -1);
            frm.ShowDialog();
        }

        private void remakeChart_DataClick(object sender, ChartPoint p)
        {
            var asPixels = repaintChart.Base.ConvertToPixels(p.AsPoint());
            string department = remakeDepartments[Convert.ToInt32(p.X)].ToString();
            frmRemakeRepaintDepartmentGraph frm = new frmRemakeRepaintDepartmentGraph(startDate, endDate, department, 0);
                frm.ShowDialog();


        }
    }
}
