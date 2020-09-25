using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Data.SqlClient;
using Brushes = System.Windows.Media.Brushes;
using System.Windows.Media;
using System.Drawing.Printing;

namespace KPIAnalyser
{
    public partial class frmInstallationProductivity : Form
    {
        public frmInstallationProductivity()
        {
            InitializeComponent();


            //FORMAT INTERNAL GUAGE
            internalReturnGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            internalReturnGuage.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 50 ,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            internalReturnGuage.FromValue = 0;
            internalReturnGuage.ToValue = 50;
            internalReturnGuage.TicksForeground = Brushes.White;
            internalReturnGuage.Base.Foreground = Brushes.White;
            internalReturnGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            internalReturnGuage.Base.FontSize = 16;
            internalReturnGuage.SectionsInnerRadius = 0.5;
            /////
            ///



            //FORMAT INTERNAL COST GUAGE
            internalReturnCostGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            internalReturnCostGuage.Sections.Add(new AngularSection
            {
                FromValue = 5000,
                ToValue = 50000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            internalReturnCostGuage.FromValue = 0;
            internalReturnCostGuage.ToValue = 50000;
            internalReturnCostGuage.TicksForeground = Brushes.White;
            internalReturnCostGuage.Base.Foreground = Brushes.White;
            internalReturnCostGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            internalReturnCostGuage.Base.FontSize = 16;
            internalReturnCostGuage.SectionsInnerRadius = 0.5;
            /////
            ///


            //FORMAT EXTERNAL GUAGE
            externalReturnGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            externalReturnGuage.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 50,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            externalReturnGuage.FromValue = 0;
            externalReturnGuage.ToValue =50;
            externalReturnGuage.TicksForeground = Brushes.White;
            externalReturnGuage.Base.Foreground = Brushes.White;
            externalReturnGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            externalReturnGuage.Base.FontSize = 16;
            externalReturnGuage.SectionsInnerRadius = 0.5;
            /////
            ///


            //FORMAT INTERNAL COST GUAGE
            externalReturnCostGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            externalReturnCostGuage.Sections.Add(new AngularSection
            {
                FromValue = 5000,
                ToValue = 50000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            externalReturnCostGuage.FromValue = 0;
            externalReturnCostGuage.ToValue = 50000;
            externalReturnCostGuage.TicksForeground = Brushes.White;
            externalReturnCostGuage.Base.Foreground = Brushes.White;
            externalReturnCostGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            externalReturnCostGuage.Base.FontSize = 16;
            externalReturnCostGuage.SectionsInnerRadius = 0.5;
            /////
            ///


            /////////////////SLIMLINE GUAGES/////////////////////////////////////////////////////////

            //FORMAT INTERNAL GUAGE
            internalReturnGuageSL.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            internalReturnGuageSL.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 50,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            internalReturnGuageSL.FromValue = 0;
            internalReturnGuageSL.ToValue = 50;
            internalReturnGuageSL.TicksForeground = Brushes.White;
            internalReturnGuageSL.Base.Foreground = Brushes.White;
            internalReturnGuageSL.Base.FontWeight = System.Windows.FontWeights.Bold;
            internalReturnGuageSL.Base.FontSize = 16;
            internalReturnGuageSL.SectionsInnerRadius = 0.5;
            /////
            ///



            //FORMAT INTERNAL COST GUAGE
            internalReturnCostGuageSL.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            internalReturnCostGuageSL.Sections.Add(new AngularSection
            {
                FromValue = 5000,
                ToValue = 50000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            internalReturnCostGuageSL.FromValue = 0;
            internalReturnCostGuageSL.ToValue = 50000;
            internalReturnCostGuageSL.TicksForeground = Brushes.White;
            internalReturnCostGuageSL.Base.Foreground = Brushes.White;
            internalReturnCostGuageSL.Base.FontWeight = System.Windows.FontWeights.Bold;
            internalReturnCostGuageSL.Base.FontSize = 16;
            internalReturnCostGuageSL.SectionsInnerRadius = 0.5;
            /////
            ///


            //FORMAT EXTERNAL GUAGE
            externalReturnGuageSL.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            externalReturnGuageSL.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 50,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            externalReturnGuageSL.FromValue = 0;
            externalReturnGuageSL.ToValue = 50;
            externalReturnGuageSL.TicksForeground = Brushes.White;
            externalReturnGuageSL.Base.Foreground = Brushes.White;
            externalReturnGuageSL.Base.FontWeight = System.Windows.FontWeights.Bold;
            externalReturnGuageSL.Base.FontSize = 16;
            externalReturnGuageSL.SectionsInnerRadius = 0.5;
            /////
            ///


            //FORMAT INTERNAL COST GUAGE
            externalReturnCostGuageSL.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            externalReturnCostGuageSL.Sections.Add(new AngularSection
            {
                FromValue = 5000,
                ToValue = 50000,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            externalReturnCostGuageSL.FromValue = 0;
            externalReturnCostGuageSL.ToValue = 50000;
            externalReturnCostGuageSL.TicksForeground = Brushes.White;
            externalReturnCostGuageSL.Base.Foreground = Brushes.White;
            externalReturnCostGuageSL.Base.FontWeight = System.Windows.FontWeights.Bold;
            externalReturnCostGuageSL.Base.FontSize = 16;
            externalReturnCostGuageSL.SectionsInnerRadius = 0.5;
            /////
            ///


            //FORMAT Complaint
            complaintGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 20,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            complaintGuage.Sections.Add(new AngularSection
            {
                FromValue = 20,
                ToValue = 50,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            complaintGuage.FromValue = 0;
            complaintGuage.ToValue = 50;
            complaintGuage.TicksForeground = Brushes.White;
            complaintGuage.Base.Foreground = Brushes.White;
            complaintGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            complaintGuage.Base.FontSize = 16;
            complaintGuage.SectionsInnerRadius = 0.5;
            /////
            ///


            //FORMAT Complaint SL
            complaintGuageSlimline.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 20,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            complaintGuageSlimline.Sections.Add(new AngularSection
            {
                FromValue = 20,
                ToValue = 50,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            complaintGuageSlimline.FromValue = 0;
            complaintGuageSlimline.ToValue = 50;
            complaintGuageSlimline.TicksForeground = Brushes.White;
            complaintGuageSlimline.Base.Foreground = Brushes.White;
            complaintGuageSlimline.Base.FontWeight = System.Windows.FontWeights.Bold;
            complaintGuageSlimline.Base.FontSize = 16;
            complaintGuageSlimline.SectionsInnerRadius = 0.5;
            /////
            ///





        }

        private void FrmInstallationProductivity_Load(object sender, EventArgs e)
        {

        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            installationSalesCostsChart();
            populateReturnGuages();
            populateReturnGuagesSL();
            populateComplaintGuage();
            populateComplaintGuageSL();
        }


        private void populateReturnGuagesSL()
        {
            int returnInternalCount = 0;
            double returnInternalCost = 0;
            int returnExternalCount = 0;
            double returnExternalCost = 0;


            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_return_site_visits_sl", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                try
                {
                    returnInternalCount = reader.GetInt32(0);
                }
                catch
                {

                }


                try
                {
                    returnInternalCost = reader.GetDouble(1);
                }
                catch
                {

                }
                try
                {
                    returnExternalCount = reader.GetInt32(2);
                }
                catch
                {

                }
                try
                {
                    returnExternalCost = reader.GetDouble(3);
                }
                catch
                {

                }


            }


            internalReturnGuageSL.Value = returnInternalCount;
            lblInternalCountSL.Text = "Return Site Visits(Our Fault): " + returnInternalCount;


            internalReturnCostGuageSL.Value = returnInternalCost;
            lblInternalCostSL.Text = "COST: Return Site Visits (Our Fault): " + returnInternalCost;

            externalReturnGuageSL.Value = returnExternalCount;
            lblExternalCountSL.Text = "Return Site Visits(External Fault): " + returnExternalCount;

            externalReturnCostGuageSL.Value = returnExternalCost;
            lblExternalCostSL.Text = "COST: Return Site Visits (External Fault): " + returnExternalCost;


            conn.Close();
        }


        private void populateComplaintGuage()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");

            int complaintCount = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionStringComplaint);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_installation_complaint_gauge", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@doorType", SqlDbType.NVarChar).Value = "t";
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                complaintCount =  reader.GetInt32(0);

            }

            lblComplaintCount.Text = "Number of complaints: " + complaintCount;
            complaintGuage.Value = complaintCount;


            conn.Close();


        }




        private void populateComplaintGuageSL()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");

            int complaintCount = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionStringComplaint);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_installation_complaint_gauge", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@doorType", SqlDbType.NVarChar).Value = "s";
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                complaintCount = reader.GetInt32(0);

            }

            lblComplaintCountSL.Text = "Number of complaints: " + complaintCount;
            complaintGuageSlimline.Value = complaintCount;


            conn.Close();


        }

        private void populateReturnGuages()
        {

            int returnInternalCount = 0;
            double returnInternalCost = 0;
            int returnExternalCount = 0;
            double returnExternalCost = 0;


            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_return_site_visits", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;

            SqlDataReader reader = cmd.ExecuteReader();

            
            while (reader.Read())
            {

                try
                {
                    returnInternalCount = reader.GetInt32(0);
                }
                catch
                {

                }


                try
                {
                    returnInternalCost = reader.GetDouble(1);
                }
                catch
                {

                }
                try
                {
                    returnExternalCount = reader.GetInt32(2);
                }
                catch
                {

                }
                try
                {
                    returnExternalCost = reader.GetDouble(3);
                }
                catch
                {

                }
             

            }


            internalReturnGuage.Value = returnInternalCount;
            lblInternalCount.Text = "Return Site Visits(Our Fault): " + returnInternalCount;


            internalReturnCostGuage.Value = returnInternalCost;
            lblInternalCost.Text = "COST: Return Site Visits (Our Fault): " + returnInternalCost;

            externalReturnGuage.Value = returnExternalCount;
            lblExternalCount.Text =  "Return Site Visits(External Fault): " + returnExternalCount;

            externalReturnCostGuage.Value = returnExternalCost;
            lblExternalCost.Text = "COST: Return Site Visits (External Fault): " + returnExternalCost;


            conn.Close();

        }

        private void installationSalesCostsChart()
        {
            int m1=0;
            int m2 = 0;
            int m3 = 0;
            int m4 = 0;
            int m5 = 0;
            int m6 = 0;
            int m7 = 0;
            int m8 = 0;
            int m9 = 0;
            int m10 = 0;
            int m11 = 0;
            int m12 = 0;

            int y1 = 0;
            int y2 = 0;
            int y3 = 0;
            int y4 = 0;
            int y5 = 0;
            int y6 = 0;
            int y7 = 0;
            int y8 = 0;
            int y9 = 0;
            int y10 = 0;
            int y11 = 0;
            int y12 = 0;

            double s1 = 0;
            double s2 = 0;
            double s3 = 0;
            double s4 = 0;
            double s5 = 0;
            double s6 = 0;
            double s7 = 0;
            double s8 = 0;
            double s9 = 0;
            double s10 = 0;
            double s11 = 0;
            double s12 = 0;

            double c1 = 0;
            double c2 = 0;
            double c3 = 0;
            double c4 = 0;
            double c5 = 0;
            double c6 = 0;
            double c7 = 0;
            double c8 = 0;
            double c9 = 0;
            double c10 = 0;
            double c11 = 0;
            double c12 = 0;




            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_installation_cost_and_sales", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;

            SqlDataReader reader = cmd.ExecuteReader();

            int loopcount = 1;
            while (reader.Read())
            {
                switch (loopcount)
                {
                    case 1:


                        m1 = reader.GetInt32(0);
                        y1 = reader.GetInt32(1);
                        try
                        {
                            s1 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c1 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }
                        
                        loopcount += 1;
                        break;
                    case 2:
                        m2 = reader.GetInt32(0);
                        y2 = reader.GetInt32(1);
                        try
                        {
                            s2 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c2 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;
                    case 3:
                        m3 = reader.GetInt32(0);
                        y3 = reader.GetInt32(1);
                        try
                        {
                            s3 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c3 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;
                    case 4:
                        m4 = reader.GetInt32(0);
                        y4 = reader.GetInt32(1);
                        try
                        {
                            s4 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c4 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;
                    case 5:
                        m5 = reader.GetInt32(0);
                        y5 = reader.GetInt32(1);
                        try
                        {
                            s5 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c5 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;
                    case 6:
                        m6 = reader.GetInt32(0);
                        y6 = reader.GetInt32(1);
                        try
                        {
                            s6 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c6 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;
                    case 7:
                        m7 = reader.GetInt32(0);
                        y7 = reader.GetInt32(1);
                        try
                        {
                            s7 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c7 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;
                    case 8:
                        m8 = reader.GetInt32(0);
                        y8 = reader.GetInt32(1);
                        try
                        {
                            s8 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c8 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;
                    case 9:
                        m9 = reader.GetInt32(0);
                        y9 = reader.GetInt32(1);
                        try
                        {
                            s9 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c9 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;
                    case 10:
                        m10 = reader.GetInt32(0);
                        y10= reader.GetInt32(1);
                        try
                        {
                            s10 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c10 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;

                    case 11:
                        m11 = reader.GetInt32(0);
                        y11 = reader.GetInt32(1);
                        try
                        {
                            s11 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c11 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;

                    case 12:
                        m12 = reader.GetInt32(0);
                        y12 = reader.GetInt32(1);
                        try
                        {
                            s12 = reader.GetDouble(2);
                        }
                        catch
                        {

                        }
                        try
                        {
                            c12 = reader.GetDouble(3);
                        }
                        catch
                        {

                        }

                        loopcount += 1;
                        break;
                    default:
                        break;
                }
            }


            conn.Close();


            salesCostsChart.AxisY.Clear();
            salesCostsChart.AxisX.Clear();

            salesCostsChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Sales Value",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,
                    Values = new ChartValues<double> {s1,s2,s3,s4, s5, s6, s7, s8, s9, s10, s11, s12 }
                },

                new ColumnSeries
                {
                    Title = "Cost Value",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Red,
                    Values = new ChartValues<double> {c1,c2,c3,c4, c5, c6, c7, c8, c9, c10, c11, c12 }
                }
            };

            salesCostsChart.AxisX.Add(new Axis
            {
                Title = "Month",
                FontSize = 16,
                Labels = new[] { convertNumToMonth(m1) + ' ' +  y1.ToString(),
                    convertNumToMonth(m2) + ' ' + y2.ToString(),
                    convertNumToMonth(m3) + ' ' + y3.ToString(),
                    convertNumToMonth(m4) + ' ' + y4.ToString(),
                    convertNumToMonth(m5) + ' ' + y5.ToString(),
                    convertNumToMonth(m6) + ' ' + y6.ToString(),
                    convertNumToMonth(m7) + ' ' + y7.ToString(),
                    convertNumToMonth(m8) + ' ' + y8.ToString(),
                    convertNumToMonth(m9) + ' ' + y9.ToString(),
                    convertNumToMonth(m10) + ' ' + y10.ToString(),
                    convertNumToMonth(m11) + ' ' + y11.ToString(),
                    convertNumToMonth(m12) + ' ' + y12.ToString(),
               






                }
            });

            salesCostsChart.AxisY.Add(new Axis
            {
                Title = "Installation Sales/Costs",
                FontSize = 16,

            });






        }


        private string convertNumToMonth(int monthNum)
        {
            string monthName="";

            switch (monthNum)
            {
                case 1:
                    monthName = "January";
                    break;
                case 2:
                    monthName = "February";
                    break;
                case 3:
                    monthName = "March";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "June";
                    break;
                case 7:
                    monthName = "July";
                    break;
                case 8:
                    monthName = "August";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "October";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "December";
                    break;
            }

            return monthName;

            }

        private void Button1_Click(object sender, EventArgs e)
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            frmReturnVisits frmRV = new frmReturnVisits("t","Internal", startdate, enddate);
            frmRV.ShowDialog();
        }

        private void BtnExternal_Click(object sender, EventArgs e)
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            frmReturnVisits frmRV = new frmReturnVisits("t","External", startdate, enddate);
            frmRV.ShowDialog();
        }

        private void BtnInternalVisitSL_Click(object sender, EventArgs e)
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            frmReturnVisits frmRV = new frmReturnVisits("s", "Internal", startdate, enddate);
            frmRV.ShowDialog();
        }

        private void BtnExternalSL_Click(object sender, EventArgs e)
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            frmReturnVisits frmRV = new frmReturnVisits("s", "External", startdate, enddate);
            frmRV.ShowDialog();
        }

        private void BtnComplaintView_Click(object sender, EventArgs e)
        {

            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            frmInstallationComplaintDetails frmicd = new frmInstallationComplaintDetails(startdate, enddate, "t");
            frmicd.Show();


        }

        private void BtnComplaintViewSL_Click(object sender, EventArgs e)
        {

            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            frmInstallationComplaintDetails frmicd = new frmInstallationComplaintDetails(startdate, enddate, "s");
            frmicd.Show();
        }
    }
}
