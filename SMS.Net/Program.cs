/****************************************************************************** **
Copyright (C) 
***********************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using SecureApp;
namespace SMS.Net
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()

        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          // Application.Run(new SMSMDI());
          //  String dbpath = Application.StartupPath + "\\Data\\sms.mdf";
            //String ConnString = String.Format("Data Source=.\\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;User Instance=True", dbpath); 
            string abc = @"Software\Tanmay\Protection";
            Secure scr = new Secure();
            bool logic = scr.Algorithm("Tanmay", abc);
            if (logic == true)
               // Application.Run(new SMSMDI());
                //Application.Run(new Reports.ImageForm1());
               Application.Run(new Login());

                 


        }
    }

}
