﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPIAnalyser
{
    class ConnectionStrings
    {
        public static int excel_number;
        public const string ConnectionString = "user id=sa;" +
                             "password=Dodid1;Network Address=192.168.0.150\\sqlexpress;" +
                             "Trusted_Connection=no;" +
                             "database=order_database; " +
                             "connection timeout=60";



        public const string ConnectionStringComplaint = "user id=sa;" +
                     "password=Dodid1;Network Address=192.168.0.150\\sqlexpress;" +
                     "Trusted_Connection=no;" +
                     "database=complaint; " +
                     "connection timeout=60";

        public const string ConnectionStringUser = "user id=sa;" +
                               "password=Dodid1;Network Address=192.168.0.150\\sqlexpress;" +
                               "Trusted_Connection=no;" +
                               "database=user_info; " +
                               "connection timeout=60";
    }
}
