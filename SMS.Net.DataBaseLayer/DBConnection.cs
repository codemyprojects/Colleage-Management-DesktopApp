/********************************************************************************
Copyright (C)
***********************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
namespace SMS.Net.DataBaseLayer
{
    class DBConnection
    {
        public static string connectionString()
        {

            var __connectionStringBuilder = new SqlConnectionStringBuilder();
            __connectionStringBuilder.DataSource = ConfigurationSettings.AppSettings["Server"];
            __connectionStringBuilder.InitialCatalog = ConfigurationSettings.AppSettings["DataBase"];
            __connectionStringBuilder.UserInstance = false;
            __connectionStringBuilder.IntegratedSecurity = true;
        ////    //__connectionStringBuilder.UserID = ConfigurationSettings.AppSettings["UserId"];
        ////    //__connectionStringBuilder.Password = ConfigurationSettings.AppSettings["Password"];
            return __connectionStringBuilder.ConnectionString;
             // string dbpath = "\\Application Folder\\Data\\SMS.mdf";
              ///string ConnString = String.Format("Data Source=.\\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;User Instance=True",dbpath);
          //  // string conString ="Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Application Folder\\Data\\SMS.mdf;Integrated Security=True;User Instance=True";
          //string cons = ConfigurationSettings.AppSettings[@"SMSConnString"];
          //   //return ConnString;
          //return cons;
        }
    }

}
