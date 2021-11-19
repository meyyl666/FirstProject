using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace WinFormsBase
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        ///

        

          [STAThread]
        static void Main()
        {
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new FrmLogin());
            Application.Run(new FrmWorking());
            //var form1 = new FrmLogin();
            //form1.ShowDialog();



        }

        


    }
}
