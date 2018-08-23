using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPIAnalyser
{
    class DateConversion
    {

        public DateTime GetDate(string monthName, string yearName)
        {
            string monthPart = "";
            string yearPart = yearName;
            DateTime datePart;

            switch (monthName)
            {
                case "January":
                    monthPart = "01/01/";
                    break;
                case "February":
                    monthPart = "01/02/";
                    break;
                case "March":
                    monthPart = "01/03/";
                    break;
                case "April":
                    monthPart = "01/04/";
                    break;
                case "May":
                    monthPart = "01/05/";
                    break;
                case "June":
                    monthPart = "01/06/";
                    break;
                case "July":
                    monthPart = "01/07/";
                    break;
                case "August":
                    monthPart = "01/08/";
                    break;
                case "September":
                    monthPart = "01/09/";
                    break;
                case "October":
                    monthPart = "01/10/";
                    break;
                case "November":
                    monthPart = "01/11/";
                    break;
                case "December":
                    monthPart = "01/12/";
                    break;


            }


            datePart = Convert.ToDateTime(monthPart + yearPart);



            return datePart;

        }

    }
}
