using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace rbs_test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connString = ConfigurationManager.ConnectionStrings["ReserveringenConnectionStringSQL"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);

            Application.Run(new Form1());
        }
    }
}
