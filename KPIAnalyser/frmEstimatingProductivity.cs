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
    public partial class frmEstimatingProductivity : Form
    {

        List<string> static_date_list = new List<string>();

        public frmEstimatingProductivity()
        {
            InitializeComponent();


            //add people to combobox


            if (1 == 1)
            {
                cmbStaffMember.Items.Add("Tomas Grother");
                string sql = "SELECT forename + ' ' + surname FROM dbo.[user] where [grouping] = 5 and [current] = 1 and (non_user is null or non_user = 0)  order by forename";
                using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionStringUser))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            cmbStaffMember.Items.Add(row[0].ToString());
                        }
                    }
                }
            }


            //FORMAT ABSENT GUAGE
            absentGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            absentGuage.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 20,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            absentGuage.FromValue = 0;
            absentGuage.ToValue = 20;
            absentGuage.TicksForeground = Brushes.White;
            absentGuage.Base.Foreground = Brushes.White;
            absentGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            absentGuage.Base.FontSize = 16;
            absentGuage.SectionsInnerRadius = 0.5;
            /////
            ///


            //FORMAT ANNUALLEAVE GUAGE
            annualLeaveGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 23,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            annualLeaveGuage.Sections.Add(new AngularSection
            {
                FromValue = 23,
                ToValue = 40,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            annualLeaveGuage.FromValue = 0;
            annualLeaveGuage.ToValue = 40;
            annualLeaveGuage.TicksForeground = Brushes.White;
            annualLeaveGuage.Base.Foreground = Brushes.White;
            annualLeaveGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            annualLeaveGuage.Base.FontSize = 16;
            annualLeaveGuage.SectionsInnerRadius = 0.5;
            /////
            ///

            //FORMAT LATE GUAGE

            lateGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 50,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            lateGuage.FromValue = 0;
            lateGuage.ToValue = 50;
            lateGuage.TicksForeground = Brushes.White;
            lateGuage.Base.Foreground = Brushes.White;
            lateGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            lateGuage.Base.FontSize = 16;
            lateGuage.SectionsInnerRadius = 0.5;
            /////
            ///


            //FORMAT unpaid GUAGE
            unpaidGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            unpaidGuage.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 20,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            unpaidGuage.FromValue = 0;
            unpaidGuage.ToValue = 20;
            unpaidGuage.TicksForeground = Brushes.White;
            unpaidGuage.Base.Foreground = Brushes.White;
            unpaidGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            unpaidGuage.Base.FontSize = 16;
            unpaidGuage.SectionsInnerRadius = 0.5;
            /////
            ///

            //FORMAT daily items guage
            dailyItemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 90,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            dailyItemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 90,
                ToValue = 150,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            dailyItemsGuage.FromValue = 0;
            dailyItemsGuage.ToValue = 150;
            dailyItemsGuage.TicksForeground = Brushes.White;
            dailyItemsGuage.Base.Foreground = Brushes.White;
            dailyItemsGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            dailyItemsGuage.Base.FontSize = 12;
            dailyItemsGuage.SectionsInnerRadius = 0.5;
            /////
            ///

            //FORMAT problems  guage
            problemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            problemsGuage.Sections.Add(new AngularSection
            {
                FromValue = 5,
                ToValue = 20,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            problemsGuage.FromValue = 0;
            problemsGuage.ToValue = 20;
            problemsGuage.TicksForeground = Brushes.White;
            problemsGuage.Base.Foreground = Brushes.White;
            problemsGuage.Base.FontWeight = System.Windows.FontWeights.Bold;
            problemsGuage.Base.FontSize = 12;
            problemsGuage.SectionsInnerRadius = 0.5;
            /////
            ///


        }

        private void FrmEstimatingProductivity_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'user_infoDataSet11.c_view_estimators' table. You can move, or remove it, as needed.
            this.c_view_estimatorsTableAdapter.Fill(this.user_infoDataSet11.c_view_estimators);
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_sales_program_users' table. You can move, or remove it, as needed.
            this.c_view_sales_program_usersTableAdapter.Fill(this.user_infoDataSet.c_view_sales_program_users);

        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            drawTopCustomersByItems(); //didnt include 
            drawTopCustomersByvalue(); //done
            absentHolidaysLate(); //done
            averageDailyItems(); //done but doesnt really work

            //countEstimatorIssues(); //cant  really be done

            estimatorCorrespondence();

            drawTopDoorTypes();
            drawDailyItems();
        }

        private void drawDailyItems()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            //do a fancy card here real quick 

            using (SqlConnection cardConn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                cardConn.Open();
                string cardEmail = "";
                string cardValue = "";
                string cardDays = "";
                string cardSql = "SELECT email_address FROM [user_info].dbo.[user] where forename + ' ' + surname = '" + staffName + "'";
                using (SqlCommand cardCmd = new SqlCommand(cardSql, cardConn))
                    cardEmail = Convert.ToString(cardCmd.ExecuteScalar());

                cardSql = "SELECT sum(total_quotation_value) FROM solidworks_quotation_log as a INNER JOIN(SELECT max(quote_id) as max_quote_id, max(revision_number) as max_revision_number " +
                "FROM dbo.solidworks_quotation_log group by quote_id) as b ON a.quote_id = max_quote_id AND a.revision_number = max_revision_number WHERE a.date_output > '" + startdate + "' and a.date_output < dateadd(d, 1, '" + enddate + "') " +
                "and a.emailed_to = '" + cardEmail + "'";
                using (SqlCommand cardCmd = new SqlCommand(cardSql, cardConn))
                {
                    cardValue = Convert.ToString(cardCmd.ExecuteScalar());
                }
                cardSql = "select CONVERT(INT, CONVERT(DATETIME,dbo.func_calc_working_day_difference('" + startdate + "','" + enddate + "')))";
                using (SqlCommand cardCmd = new SqlCommand(cardSql, cardConn))
                {
                    cardDays = Convert.ToString(cardCmd.ExecuteScalar());
                    if (cardDays == "0")
                        cardDays = "1";
                    lblDays.Text = cardDays;
                }
                cardConn.Close();
                //total quote value
                string data = "";
                double temp2 = 0;
                if (cardValue != "")
                {
                    data = cardValue;
                    temp2 = 0;
                    temp2 = Convert.ToDouble(data);
                    data = temp2.ToString("#,##0.00");

                    //ammend stuff like colour and having £-100
                    data = "£" + data;
                    //first up is the - number

                    if (data.Contains("-"))
                    {
                        data = data.Replace("-", "");
                        data = data.Insert(0, "-");
                    }
                    lblValue.Text = data;
                    ////////////////////////////////

                    //quote per day 
                    data = Convert.ToString(Convert.ToDouble(cardValue) / Convert.ToDouble(cardDays));
                    temp2 = 0;
                    temp2 = Convert.ToDouble(data);
                    data = temp2.ToString("#,##0.00");

                    //ammend stuff like colour and having £-100
                    data = "£" + data;
                    //first up is the - number

                    if (data.Contains("-"))
                    {
                        data = data.Replace("-", "");
                        data = data.Insert(0, "-");
                    }
                    lblQuoteDays.Text = data;
                }
                else
                {
                    lblValue.Text = "No Data";
                    lblQuoteDays.Text = "No Data";
                }
                ////////////////////////////////
            }

            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();

            //sales card
            string sql = "SELECT	round(sum(v.line_total),2) from dbo.door d left join dbo.view_door_value v on v.id = d.id left join dbo.door_type dt on dt.id = d.door_type_id " +
                "where date_completion >= '" + startdate + "' AND date_completion <= '" + enddate + "' AND(status_id = 1 or status_id = 2 or status_id = 3) and (dt.slimline_y_n = 0 or dt.slimline_y_n  is null)";
            using (SqlCommand salesCmd = new SqlCommand(sql, conn))
            {
                var value = salesCmd.ExecuteScalar().ToString();
                if (value != null)
                {
                    string data = "";
                    double temp2 = 0;
                    data = value;
                    temp2 = 0;
                    temp2 = Convert.ToDouble(data);
                    data = temp2.ToString("#,##0.00");

                    //ammend stuff like colour and having £-100
                    data = "£" + data;
                    //first up is the - number

                    if (data.Contains("-"))
                    {
                        data = data.Replace("-", "");
                        data = data.Insert(0, "-");
                    }
                    lblSales.Text = data;

                }
                else
                    lblSales.Text = "£0";
            }
            /////////////////////////////////////////////


            SqlCommand cmd = new SqlCommand("usp_kpi_estimators_daily", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;

            SqlDataReader reader = cmd.ExecuteReader();
            static_date_list.Clear();
            List<DateTime> datelist = new List<DateTime>();
            List<int> itemlist = new List<int>();
            List<int> chaseList = new List<int>();
            List<int> correspondenceList = new List<int>();
            List<string> temp = new List<string>();



            while (reader.Read())
            {
                //datelist.Add(reader.GetDateTime(1));
                temp.Add(reader.GetDateTime(1).ToShortDateString());
                static_date_list.Add(reader.GetDateTime(1).ToShortDateString());
                itemlist.Add(reader.GetInt32(0));
                chaseList.Add(reader.GetInt32(2));
                correspondenceList.Add(reader.GetInt32(3));
            }


            //string[] datearray = datelist.ToArray();
            int[] itemarray = itemlist.ToArray();
            int[] chasearray = chaseList.ToArray();
            int[] correspondencearray = correspondenceList.ToArray();

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Items",
                    FontSize = 10,
                    Foreground = Brushes.Black,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,

                    Values = new ChartValues<int>(itemarray)
                },
                 new ColumnSeries
                {
                    Title = "Chase",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.LightSkyBlue,

                    Values = new ChartValues<int>(chasearray)
                },
                 new ColumnSeries
                {
                    Title = "Correspondence",
                    FontSize = 10,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.PaleVioletRed,

                    Values = new ChartValues<int>(correspondencearray)
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
                Foreground = Brushes.Black,
                Labels = temp
            });

            //

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Items Quoted",
                FontSize = 16,

            });


        }



        private void drawTopDoorTypes()
        {
            string d1 = "";
            string d2 = "";
            string d3 = "";
            string d4 = "";
            string d5 = "";
            string d6 = "";
            string d7 = "";
            string d8 = "";
            string d9 = "";
            string d10 = "";


            double v1 = 0;
            double v2 = 0;
            double v3 = 0;
            double v4 = 0;
            double v5 = 0;
            double v6 = 0;
            double v7 = 0;
            double v8 = 0;
            double v9 = 0;
            double v10 = 0;


            string c1 = "";
            string c2 = "";
            string c3 = "";
            string c4 = "";
            string c5 = "";
            string c6 = "";
            string c7 = "";
            string c8 = "";
            string c9 = "";
            string c10 = "";


            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_door_type_piechart", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                d1 = reader.GetString(0);
                v1 = reader.GetDouble(1);
                c1 = getDoorTypeColour(d1);
                d2 = reader.GetString(2);
                v2 = reader.GetDouble(3);
                c2 = getDoorTypeColour(d2);
                d3 = reader.GetString(4);
                v3 = reader.GetDouble(5);
                c3 = getDoorTypeColour(d3);
                d4 = reader.GetString(6);
                v4 = reader.GetDouble(7);
                c4 = getDoorTypeColour(d4);
                d5 = reader.GetString(8);
                v5 = reader.GetDouble(9);
                c5 = getDoorTypeColour(d5);
                d6 = reader.GetString(10);
                v6 = reader.GetDouble(11);
                c6 = getDoorTypeColour(d6);
                d7 = reader.GetString(12);
                v7 = reader.GetDouble(13);
                c7 = getDoorTypeColour(d7);
                d8 = reader.GetString(14);
                v8 = reader.GetDouble(15);
                c8 = getDoorTypeColour(d8);
                d9 = reader.GetString(16);
                v9 = reader.GetDouble(17);
                c9 = getDoorTypeColour(d9);
                d10 = reader.GetString(18);
                v10 = reader.GetDouble(19);
                c10 = getDoorTypeColour(d10);
            }



            Type t1 = typeof(Brushes);
            Brush b1 = (Brush)t1.GetProperty(c1).GetValue(null, null);

            Type t2 = typeof(Brushes);
            Brush b2 = (Brush)t2.GetProperty(c2).GetValue(null, null);

            Type t3 = typeof(Brushes);
            Brush b3 = (Brush)t1.GetProperty(c3).GetValue(null, null);

            Type t4 = typeof(Brushes);
            Brush b4 = (Brush)t4.GetProperty(c4).GetValue(null, null);

            Type t5 = typeof(Brushes);
            Brush b5 = (Brush)t5.GetProperty(c5).GetValue(null, null);

            Type t6 = typeof(Brushes);
            Brush b6 = (Brush)t6.GetProperty(c6).GetValue(null, null);

            Type t7 = typeof(Brushes);
            Brush b7 = (Brush)t7.GetProperty(c7).GetValue(null, null);

            Type t8 = typeof(Brushes);
            Brush b8 = (Brush)t8.GetProperty(c8).GetValue(null, null);

            Type t9 = typeof(Brushes);
            Brush b9 = (Brush)t9.GetProperty(c9).GetValue(null, null);

            Type t10 = typeof(Brushes);
            Brush b10 = (Brush)t10.GetProperty(c10).GetValue(null, null);

            Type tf = typeof(Brushes);
            Brush bf = (Brush)tf.GetProperty("Black").GetValue(null, null);




            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart3.Series = new SeriesCollection
                {

                    new PieSeries
                        {
                            Title = d1,
                            Values = new ChartValues<double> { v1 },
                            PushOut = 15,
                            Fill = b1,
                            Foreground = bf,
                            DataLabels = true,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = d2,
                            Values = new ChartValues<double> { v2 },
                            Fill = b2,
                            Foreground = bf,
                            DataLabels = true,
                            LabelPoint = labelPoint
                        },

                    new PieSeries
                        {
                            Title = d3,
                            Values = new ChartValues<double> { v3 },
                            Fill = b3,
                            Foreground = bf,
                            DataLabels = true,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = d4,
                            Values = new ChartValues<double> { v4 },
                            Fill = b4,
                            Foreground = bf,
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = d5,
                            Values = new ChartValues<double> { v5 },
                            Fill = b5,
                            Foreground = bf,

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = d6,
                            Values = new ChartValues<double> { v6 },
                            Fill = b6,
                            Foreground = bf,
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = d7,
                            Values = new ChartValues<double> { v7 },
                            Fill = b7,
                            Foreground = bf,
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = d8,
                            Values = new ChartValues<double> { v8 },
                            Fill = b8,
                            Foreground = bf,
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },

                    new PieSeries
                        {
                            Title = d9,
                            Values = new ChartValues<double> { v9 },
                            Fill = b9,
                            Foreground = bf,
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = d10,
                            Values = new ChartValues<double> { v10 },
                            Fill = b10,
                            Foreground = bf,
                            DataLabels = false,
                            LabelPoint = labelPoint
                        }



                };



            pieChart3.LegendLocation = LegendLocation.Bottom;






            conn.Close();


        }




        private string getDoorTypeColour(string doorType)
        {

            string colourID = "";


            switch (doorType)
            {
                case "Fire Protect":
                    colourID = "Green";
                    break;
                case "Fire Rated":
                    colourID = "Red";
                    break;
                case "General Purpose":
                    colourID = "Pink";
                    break;
                case "SG":
                    colourID = "Yellow";
                    break;
                case "SR 1":
                    colourID = "White";
                    break;
                case "SR 2":
                    colourID = "Purple";
                    break;
                case "SR 3":
                    colourID = "Orange";
                    break;
                case "SR 4":
                    colourID = "Gray";
                    break;
                case "Flood":
                    colourID = "Blue";
                    break;
                default:
                    colourID = "Brown";
                    break;
            }


            return colourID;






        }




        private void drawTopCustomersByvalue()
        {
            string c1 = "";
            string c2 = "";
            string c3 = "";
            string c4 = "";
            string c5 = "";
            string c6 = "";
            string c7 = "";
            string c8 = "";
            string c9 = "";
            string c10 = "";

            double v1 = 0;
            double v2 = 0;
            double v3 = 0;
            double v4 = 0;
            double v5 = 0;
            double v6 = 0;
            double v7 = 0;
            double v8 = 0;
            double v9 = 0;
            double v10 = 0;

            int includeRevisions = 0;

            if (chkIncludeRevisions.Checked == true)
            {
                includeRevisions = 1;
            }


            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_top_customers_quoted_by_estimator", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;
            cmd.Parameters.Add("@itemOrValue", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@includeRevs", SqlDbType.Int).Value = includeRevisions;
            SqlDataReader reader = cmd.ExecuteReader();

            int loopcount = 1;
            while (reader.Read())
            {
                switch (loopcount)
                {
                    case 1:
                        c1 = reader.GetString(0);
                        v1 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 2:
                        c2 = reader.GetString(0);
                        v2 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 3:
                        c3 = reader.GetString(0);
                        v3 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 4:
                        c4 = reader.GetString(0);
                        v4 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 5:
                        c5 = reader.GetString(0);
                        v5 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 6:
                        c6 = reader.GetString(0);
                        v6 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 7:
                        c7 = reader.GetString(0);
                        v7 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 8:
                        c8 = reader.GetString(0);
                        v8 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 9:
                        c9 = reader.GetString(0);
                        v9 = reader.GetDouble(2);

                        loopcount += 1;
                        break;
                    case 10:
                        c10 = reader.GetString(0);
                        v10 = reader.GetDouble(2);

                        loopcount += 1;
                        break;

                    default:
                        break;
                }
            }

            //VALUES PIE CHART

            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart2.Series = new SeriesCollection
                {

                    new PieSeries
                        {
                            Title = c1,
                            Values = new ChartValues<double> { v1 },
                            PushOut = 15,
                            DataLabels = true,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c2,
                            Values = new ChartValues<double> { v2 },

                            DataLabels = true,
                            LabelPoint = labelPoint
                        },

                    new PieSeries
                        {
                            Title = c3,
                            Values = new ChartValues<double> { v3 },

                            DataLabels = true,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c4,
                            Values = new ChartValues<double> { v4 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c5,
                            Values = new ChartValues<double> { v5 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c6,
                            Values = new ChartValues<double> { v6 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c7,
                            Values = new ChartValues<double> { v7 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c8,
                            Values = new ChartValues<double> { v8 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },

                    new PieSeries
                        {
                            Title = c9,
                            Values = new ChartValues<double> { v9 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c10,
                            Values = new ChartValues<double> { v10 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        }



                };



            pieChart2.LegendLocation = LegendLocation.Bottom;






            conn.Close();


        }
        private void drawTopCustomersByItems()
        {

            string c1 = "";
            string c2 = "";
            string c3 = "";
            string c4 = "";
            string c5 = "";
            string c6 = "";
            string c7 = "";
            string c8 = "";
            string c9 = "";
            string c10 = "";



            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            int i4 = 0;
            int i5 = 0;
            int i6 = 0;
            int i7 = 0;
            int i8 = 0;
            int i9 = 0;
            int i10 = 0;


            int includeRevisions = 0;

            if (chkIncludeRevisions.Checked == true)
            {
                includeRevisions = 1;
            }



            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;
            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_top_customers_quoted_by_estimator", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;
            cmd.Parameters.Add("@itemOrValue", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@includeRevs", SqlDbType.Int).Value = includeRevisions;
            SqlDataReader reader = cmd.ExecuteReader();

            int loopcount = 1;
            while (reader.Read())
            {
                switch (loopcount)
                {
                    case 1:
                        c1 = reader.GetString(0);
                        i1 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 2:
                        c2 = reader.GetString(0);
                        i2 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 3:
                        c3 = reader.GetString(0);
                        i3 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 4:
                        c4 = reader.GetString(0);
                        i4 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 5:
                        c5 = reader.GetString(0);
                        i5 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 6:
                        c6 = reader.GetString(0);
                        i6 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 7:
                        c7 = reader.GetString(0);
                        i7 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 8:
                        c8 = reader.GetString(0);
                        i8 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 9:
                        c9 = reader.GetString(0);
                        i9 = reader.GetInt32(1);

                        loopcount += 1;
                        break;
                    case 10:
                        c10 = reader.GetString(0);
                        i10 = reader.GetInt32(1);

                        loopcount += 1;
                        break;

                    default:
                        break;
                }
            }


            //ITEMS PIECHART


            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
                {

                    new PieSeries
                        {
                            Title = c1,
                            Values = new ChartValues<double> { i1 },
                            PushOut = 15,
                            DataLabels = true,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c2,
                            Values = new ChartValues<double> { i2 },

                            DataLabels = true,
                            LabelPoint = labelPoint
                        },

                    new PieSeries
                        {
                            Title = c3,
                            Values = new ChartValues<double> { i3 },

                            DataLabels = true,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c4,
                            Values = new ChartValues<double> { i4 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c5,
                            Values = new ChartValues<double> { i5 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c6,
                            Values = new ChartValues<double> { i6 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c7,
                            Values = new ChartValues<double> { i7 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c8,
                            Values = new ChartValues<double> { i8 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },

                    new PieSeries
                        {
                            Title = c9,
                            Values = new ChartValues<double> { i9 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    new PieSeries
                        {
                            Title = c10,
                            Values = new ChartValues<double> { i10 },

                            DataLabels = false,
                            LabelPoint = labelPoint
                        }



                };



            pieChart1.LegendLocation = LegendLocation.Bottom;




            conn.Close();
        }



        private void absentHolidaysLate()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            int lateCount = 0;
            double annualLeavecount = 0;
            int absentCount = 0;
            int absentTakenHolidayCount = 0;
            int unpaidCount = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_absent_late_estimating", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                absentCount = reader.GetInt32(0);
                annualLeavecount = reader.GetDouble(1);
                absentTakenHolidayCount = reader.GetInt32(2);
                lateCount = reader.GetInt32(3);
                unpaidCount = reader.GetInt32(4);
            }

            conn.Close();

            ///ABSENT GUAGE
            /////////////////////////////////////////
            ///

            absentGuage.Value = absentCount;
            absentDays.Text = "Absent Days: " + absentCount.ToString();
            annualLeaveGuage.Value = annualLeavecount;
            annualLeave.Text = "Annual Leave: " + annualLeavecount.ToString();
            lateGuage.Value = lateCount;
            lateDays.Text = "Late Days: " + lateCount.ToString();
            unpaidGuage.Value = unpaidCount;
            unpaidLeave.Text = "Unpaid Days: " + unpaidCount.ToString();



            //////////////////////////////////////



        }

        private void averageDailyItems()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;
            int includeRevisions = 0;

            int averageDailyItems = 0;

            if (chkIncludeRevisions.Checked == true)
            {
                includeRevisions = -1;
            }


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_average_daily_output", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;
            cmd.Parameters.Add("@increv", SqlDbType.Int).Value = includeRevisions;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    averageDailyItems = reader.GetInt32(0);
                }
                catch
                {
                    averageDailyItems = 0;
                }

            }

            dailyItemsGuage.Value = averageDailyItems;
            lblDailyAverage.Text = "Daily Average Items: " + averageDailyItems;

            conn.Close();

        }

        private void countEstimatorIssues()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            int estimatorIssues = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_estimator_problems", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    estimatorIssues = reader.GetInt32(0);
                }
                catch
                {
                    estimatorIssues = 0;
                }

            }

            problemsGuage.Value = estimatorIssues;

            lblEstimatorissues.Text = "Issues Logged: " + estimatorIssues;
            conn.Close();
        }

        private void RunComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstimatorComparison frmec = new frmEstimatorComparison();
            frmec.Show();
        }

        private void PrintScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\temp.jpg");

                printImage();
            }
            catch
            {

            }
        }


        private void printImage()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, args) =>
                {
                    System.Drawing.Image i = System.Drawing.Image.FromFile(@"C:\temp\temp.jpg");
                    Point p = new Point(100, 100);
                    args.Graphics.DrawImage(i, args.MarginBounds);

                };

                pd.DefaultPageSettings.Landscape = true;
                Margins margins = new Margins(50, 50, 50, 50);
                pd.DefaultPageSettings.Margins = margins;
                pd.Print();
            }
            catch
            {

            }
        }

        private void BtnViewQuotes_Click(object sender, EventArgs e)
        {

            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;

            frmViewQuotations frmvq = new frmViewQuotations(startdate, enddate, staffName);
            frmvq.Show();
        }

        private void EmailScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Email_Screen();
        }


        public static void Email_Screen()
        {


            try
            {
                System.Drawing.Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                Graphics gs = Graphics.FromImage(bit);

                gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);

                bit.Save(@"C:\temp\temp.jpg");


            }
            catch
            {

            }





            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "";
            mailItem.To = "";
            string imageSrc = @"C:\Temp\temp.jpg"; // Change path as needed

            var attachments = mailItem.Attachments;
            var attachment = attachments.Add(imageSrc);
            attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpeg");
            attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", "myident"); // Image identifier found in the HTML code right after cid. Can be anything.
            mailItem.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/id/{00062008-0000-0000-C000-000000000046}/8514000B", true);

            // Set body format to HTML

            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
            mailItem.Attachments.Add(imageSrc);
            string msgHTMLBody = "";
            mailItem.HTMLBody = msgHTMLBody;
            mailItem.Display(true);
            //mailItem.Send();
        }

        private void BtnViewItems_Click(object sender, EventArgs e)
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;

            //frmViewQuotationItems frmvq = new frmViewQuotationItems(startdate, enddate, staffName);
            //frmvq.Show();
        }

        private void PieChart3_DataClick(object sender, ChartPoint p)
        {



            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;
            string doorType = p.SeriesView.Title;

            frmViewQuotationItems frmvq = new frmViewQuotationItems(startdate, enddate, staffName, doorType);
            frmvq.Show();


        }

        private void CartesianChart1_DataClick(object sender, ChartPoint p)
        {
            //var asPixels = cartesianChart1.Base.ConvertToPixels(p.AsPoint());
            //MessageBox.Show("[EVENT] You clicked (" + p.X + ", " + p.Y + ") in pixels (" +
            //                asPixels.X + ", " + asPixels.Y + ")");

            var asPixels = cartesianChart1.Base.ConvertToPixels(p.AsPoint());
            string date = static_date_list[Convert.ToInt32(p.X)].ToString();

            //MessageBox.Show(date);

            frmViewCorrespondence frm = new frmViewCorrespondence(date, cmbStaffMember.Text);
            frm.ShowDialog();


            //cmbPersonResponsible.Text = staff;
            //loadDGV();

        }

        private void BtnIssuesLogged_Click(object sender, EventArgs e)
        {


            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            frmEstimatorIssuesLogged frmeil = new frmEstimatorIssuesLogged(startdate, enddate, staffName);
            frmeil.Show();
        }

        private void BtnWorkload_Click(object sender, EventArgs e)
        {
            frmEstimatorWorkload frm = new frmEstimatorWorkload();
            frm.ShowDialog();
        }
        private void estimatorCorrespondence()
        {
            string startdate = dteStart.Value.ToString("yyyyMMdd");
            string enddate = dteEnd.Value.ToString("yyyyMMdd");
            string staffName = cmbStaffMember.Text;


            double estimatorIssues = 0;


            SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_kpi_estimator_correspondence", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@staffName", SqlDbType.NVarChar).Value = staffName;
            cmd.Parameters.Add("@startDate", SqlDbType.NVarChar).Value = startdate;
            cmd.Parameters.Add("@endDate", SqlDbType.NVarChar).Value = enddate;


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    estimatorIssues = reader.GetDouble(0);
                }
                catch
                {
                    estimatorIssues = 0;
                }

            }

            problemsGuage.Value = estimatorIssues;

            lblEstimatorissues.Text = "Average Correspondence: " + estimatorIssues;
            conn.Close();
        }

    }
}

