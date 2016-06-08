﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace RBS
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

            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);

            PersoneelDAO personeelDAO = new PersoneelDAO(dbConnection);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);
            ProductDAO productDAO = new ProductDAO(dbConnection);
            Application.Run(new TafelOverzicht());
            //Application.Run(new BestelScherm(1));
        }
    }
}
