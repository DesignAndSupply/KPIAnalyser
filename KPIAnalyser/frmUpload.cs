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


    public partial class frmUpload : Form
    {
        public string _clock { get; set; }
        public frmUpload()
        {
            InitializeComponent();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This process will close ALL excel applications you have open, please ensure you have saved any work before uploading", "WARNING", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
                return;
            progressBar1.Show();
            string sql = "";
            string path = txtFilePath.Text;

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1]; // assume it is the first sheet
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange; // get the entire used range
            int value = 10;
            int numberOfColumnsToRead = value;
            int last = xlWorksheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
            Microsoft.Office.Interop.Excel.Range range = xlWorksheet.get_Range("A1:A" + last);
            progressBar1.Maximum = last;
            progressBar1.Value = 4;
            using (SqlConnection conn = new SqlConnection(ConnectionStrings.ConnectionString))
            {
                conn.Open();
                for (int i = 4; i < last; i++)  //for (int i = 1; i < last; i++)      //for X amount of rows in the excel sheet 
                {
                    progressBar1.Value = progressBar1.Value + 1;
                    //double temp = 0;
                    //if (xlRange.Cells[i, 1].Value2 != null)
                    //{
                    //    string charCheck = Convert.ToString(xlRange.Cells[i, 1].Value2);
                    //    if (charCheck.All(char.IsDigit))// if (System.Text.RegularExpressions.Regex.IsMatch(charCheck, @"^[a-zA-Z]+$") == false)
                    //        temp = xlRange.Cells[i, 1].Value2;
                    //}
                    //remove the space from the start of material here 
                    string tempString = xlRange.Cells[i, 3].Value2.ToString();
                    tempString = tempString.Trim();  //remove the leading spaces in material (for some reason there is white space at start of it in the csv by default

                    string tempNotes = "";
                    tempNotes = Convert.ToString(xlRange.Cells[i, 10].Value2);
                    if (string.IsNullOrEmpty(tempNotes))
                        tempNotes = "N/A";
                    string tempInLocation = "";
                    string tempOutLocation = "";
                    tempInLocation = Convert.ToString(xlRange.Cells[i, 11].Value2);
                    tempOutLocation = Convert.ToString(xlRange.Cells[i, 12].Value2);

                    if (i == 20)
                        tempNotes = tempNotes;
                    //stitch together toms excel equation here vvv so they are readable figures

                    //sometimes this value is null so we need to skip if it is~
                    if (string.IsNullOrEmpty(Convert.ToString(xlRange.Cells[i, 5].Value2)) || string.IsNullOrEmpty(Convert.ToString(xlRange.Cells[i, 6].Value2)) || string.IsNullOrEmpty(Convert.ToString(xlRange.Cells[i, 7].Value2)))
                        continue;

                    calculations(xlRange.Cells[i, 5].Value2.ToString());
                    string clock_in = _clock;
                    calculations(xlRange.Cells[i, 6].Value2.ToString());
                    string clock_out = _clock;
                    calculations(xlRange.Cells[i, 7].Value2.ToString());
                    string total = _clock;
                    if (clock_in == null || clock_out == null || total == null)
                        continue;


                    //other calculations here
                    DateTime date = Convert.ToDateTime(xlRange.Cells[i, 4].Value.ToString("yyyy-MM-dd"));
                    //MessageBox.Show(xlRange.Cells[i, 4].Value.ToString());
                    double hoursSet = 8.5;
                    string dateName = date.DayOfWeek.ToString();
                    int saturday = 0;
                    int friday = 0;
                    decimal difference = 0;
                    decimal rounded = 0;
                    decimal totalAdjusted = 0;
                    if (date.DayOfWeek == DayOfWeek.Saturday)
                        saturday = -1;

                    if (date.DayOfWeek == DayOfWeek.Friday)
                    {
                        friday = -1;
                        hoursSet = 7.5;
                    }


                    //need to change total into the adjusted form for CORRECT value
                    string temp = "";
                    double temp2 = 0;
                    temp = "0." + total.Substring(total.IndexOf(".") + 1);
                    temp2 = Convert.ToDouble(temp);
                    temp2 = Math.Round((temp2 / 6) * 10, 2);
                    temp = total.Substring(0, total.IndexOf(".") + 1) + Convert.ToString(temp2).Substring(Convert.ToString(temp2).IndexOf(".") + 1);

                    totalAdjusted = Convert.ToDecimal(temp);

                    difference = Convert.ToDecimal(totalAdjusted) - Convert.ToDecimal(hoursSet);

                    //rounded = Math.Floor(difference);
                    rounded = Math.Round(difference * 4, MidpointRounding.ToEven) / 4;
                    rounded = Math.Truncate(4 * difference) / 4;
                    if (rounded < 0)
                        rounded = 0;
                    int exists = 0;
                    //we need to check if the data for that employee + day exists and if it does then update rather than insert
                    sql = "select id FROM dbo.clock_in_import WHERE clock_in_id = " + xlRange.Cells[i, 3].Value.ToString() + " AND date = CAST( '" + xlRange.Cells[i, 4].Value.ToString() + "' as DATE) ";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        var getData = Convert.ToString(cmd.ExecuteScalar());
                        if (getData == null || getData == "")
                            exists =0;
                        else
                            exists = -1;
                    }
                    try
                    {
                        if (exists == -1)
                        {
                            sql = "UPDATE dbo.clock_in_import SET clock_in = '" + clock_in + "', clock_out = '" + clock_out +"',total = '" + total +"', total_adjusted = " + totalAdjusted + " ,[difference] = " + difference + " ,rounded="+ rounded + " " +
                                "where clock_in_id = " + xlRange.Cells[i, 3].Value.ToString() + " AND date = '" + xlRange.Cells[i, 4].Value.ToString() + "' "; 
                        }
                        else
                        {
                            sql = "INSERT INTO dbo.clock_in_import (last_name,first_name,clock_in_id,[date],clock_in,clock_out,total,nickname,department_name,notes,in_location,out_location,day_of_week,friday,saturday,hours_set,total_adjusted,difference,rounded) VALUES ('" +
                           xlRange.Cells[i, 1].Value.ToString() + "','" + //last name
                           xlRange.Cells[i, 2].Value.ToString() + "'," +//first name
                           xlRange.Cells[i, 3].Value.ToString() + ",CAST('" +//clock_in_id
                           xlRange.Cells[i, 4].Value.ToString() + "' as date)," +//date
                           clock_in + "," +//clock_in
                           clock_out + "," +//clock_out
                           total + ",'" +//total
                           xlRange.Cells[i, 8].Value.ToString() + "','" +//nickname
                           xlRange.Cells[i, 9].Value.ToString() + "','" + //department name
                           tempNotes + "','" + //notes
                           tempInLocation + "','" +//in_location
                           tempOutLocation + "','" +
                           dateName + "'," +
                            friday + "," +
                             saturday + "," +
                             hoursSet + "," +
                            totalAdjusted + "," +
                             difference + "," +
                             rounded + ")";//out_location
                        }
                    }
                    catch
                    {
                        continue;
                    }
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();

                    //if (xlRange.Cells[i, 1].Value2 != null)
                    //    Console.WriteLine(xlRange.Cells[i, 1].Value2.ToString()); // do whatever with value
                }
                conn.Close();
            }

            xlWorkbook.Close(0);
            xlApp.Quit(); //this isnt enough to properly close the app... 

            //this will loop through every process and kill anything that is related to excel - this is probably fine as it'll be run somewhere where there is no user opening excel files
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill(); //kills each process :}
                    }
                    catch { }
                }
            }
            MessageBox.Show("Upload Complete", "Clock in Upload", MessageBoxButtons.OK);
            this.Close();
            progressBar1.Visible = false;

        }

        private void frmUpload_Shown(object sender, EventArgs e)
        {
            btnFolder.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            string sql = "";
            OpenFileDialog openFileName = new OpenFileDialog();
            openFileName.FilterIndex = 1;
            openFileName.RestoreDirectory = true;

            if (openFileName.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtFilePath.Text = openFileName.FileName;
                    btnUpload.Enabled = true;
                }
                catch
                {
                    btnUpload.Enabled = false;
                    MessageBox.Show("Error loading file, please check the filetype is correct.");
                }
            }
        }

        private void calculations(string clock)
        {
            try
            {
                if (clock.Contains(".") == false)
                {
                    clock = clock + ".00";
                }

                string left = "";
                string right = "";
                double temp = 0;
                temp = Convert.ToDouble(clock) * 24;
                clock = Convert.ToString(temp);
                if (clock.Contains(".") == false)
                {
                    clock = clock + ".00";
                }
                left = clock.Substring(0, clock.IndexOf("."));
                right = "0." + clock.Substring(clock.IndexOf(".") + 1);
                temp = Convert.ToDouble(right);
                temp = 60 * temp;
                if (temp.ToString().Contains("E"))
                    temp = 0;
                right = Convert.ToString(temp);
                if (right.Contains("."))
                    right = right.Substring(0, right.IndexOf("."));
                if (right == "0")
                    right = "00";
                if (right.Length == 1)
                    right = "0" + right;
                _clock = left + "." + right;

            }
            catch
            {
                _clock = null;
            }
        }

    }
}
