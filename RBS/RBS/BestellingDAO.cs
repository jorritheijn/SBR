﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace RBS
{
    public class BestellingDAO
    {

        protected SqlConnection dbConnection;

        public BestellingDAO(SqlConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        
        public List<Bestelling> GetAll(string status)
        {
            dbConnection.Open();

            string sql = string.Format("SELECT * FROM bestellingen WHERE status='{0}' ORDER by tafelId", status);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<Bestelling> alleBestellingen = new List<Bestelling>();

            while (reader.Read())
            {
                Bestelling bestelling = ReadBestelling(reader);
                alleBestellingen.Add(bestelling);
            }

            dbConnection.Close();

            return alleBestellingen;
        }

        

        //voor bestell-regel class.
        public List<BestelRegel> GetRekening(int bestelId)
        {
            dbConnection.Open();

            string sql = string.Format(
                "SELECT * FROM bestellingen " +
                    "INNER JOIN bestelRegels ON bestellingen.id = bestelRegels.bestelId " +
                    "INNER JOIN producten ON bestelRegels.productId = producten.id WHERE bestelId={0}", bestelId);

            System.Diagnostics.Debug.WriteLine("cooldduud" + bestelId);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<BestelRegel> rekeningRegels = new List<BestelRegel>();

            while (reader.Read())
            {
                //System.Diagnostics.Debug.WriteLine((int)reader["tafelId"]);
                BestelRegel bestelRegel = ReadBestelRegel(reader);
                rekeningRegels.Add(bestelRegel);
            }
            dbConnection.Close();

            return rekeningRegels;
        }
        public int GetBestelIdFromTafel(int tafelId)
        {
            dbConnection.Open();

            string sql = string.Format("SELECT TOP 1 id FROM bestellingen WHERE tafelId={0} ORDER BY opnameTijd DESC", tafelId);

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            int bestelId = 0;
            while (reader.Read())
            {
                bestelId = (int)reader["id"];
            }

            dbConnection.Close();

            return bestelId;
        }

        private Bestelling ReadBestelling(SqlDataReader reader)
        {
            int id = (int)reader["id"];
            int personeelId = (int)reader["personeelId"];
            int tafelId = (int)reader["tafelId"];
            int betaalMethode = (int)reader["betaalMethode"];
            DateTime opnameTijd = (DateTime)reader["opnameTijd"];
            string status = (string)reader["status"];

            return new Bestelling(id, personeelId, tafelId, betaalMethode, opnameTijd, status);
        }

        private BestelRegel ReadBestelRegel(SqlDataReader reader)
        {
            
            int tafelId = (int)reader["tafelId"];
            string product = (string)reader["naam"];
            int aantal = (int)reader["aantal"];
            decimal prijs = (decimal)reader["prijs"];
            //double prijs = (double)reader["prijs"];
            decimal totaalPrijs = prijs * (decimal)aantal;

            return new BestelRegel(tafelId, product, aantal, totaalPrijs);
        }


        /*public List<Tafel> GetAllTafel()
        {
            dbConnection.Open();

            string sql = string.Format(
                    "SELECT tafelId, naam, comment, aantal FROM bestellingen " +
                        "INNER JOIN bestelRegels on bestellingen.id = bestelRegels.bestelId " +
                        "INNER JOIN producten on productId = producten.id " +
                        "ORDER BY tafelId");

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<int> tafelid = new List<int>();
            while (reader.Read())
            {
                int tafelID = (int)reader["tafelId"];
                tafelid.Add(tafelID);
            }
            dbConnection.Close();

            return tafelid;
        }
        public List<string> GetAllProducten()
        {
            dbConnection.Open();

            string sql = string.Format(
                     "SELECT tafelId, naam, comment, aantal FROM bestellingen " +
                        "INNER JOIN bestelRegels on bestellingen.id = bestelRegels.bestelId " +
                        "INNER JOIN producten on productId = producten.id " +
                        "ORDER BY tafelId");

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<string> productennaam = new List<string>();

            while (reader.Read())
            {
                string Productennaam = (string)reader["naam"];

                productennaam.Add(Productennaam);
            }

            dbConnection.Close();

            return productennaam;
        }
        public List<string> GetAllComment()
        {
            dbConnection.Open();

            string sql = string.Format(
                     "SELECT tafelId, naam, comment, aantal FROM bestellingen " +
                        "INNER JOIN bestelRegels on bestellingen.id = bestelRegels.bestelId " +
                        "INNER JOIN producten on productId = producten.id " +
                        "ORDER BY tafelId");

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<string> comment = new List<string>();

            while (reader.Read())
            {
                string comments;
                try { comments = (string)reader["comment"]; }
                catch { comments = ""; }

                comment.Add(comments);
            }

            dbConnection.Close();

            return comment;
        }
        public List<int> GetAllAantal()
        {
            dbConnection.Open();

            string sql = string.Format(
                     "SELECT tafelId, naam, comment, aantal FROM bestellingen " +
                        "INNER JOIN bestelRegels on bestellingen.id = bestelRegels.bestelId " +
                        "INNER JOIN producten on productId = producten.id " +
                        "ORDER BY tafelId");

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<int> aantal = new List<int>();

            while (reader.Read())
            {
                int Aantal = (int)reader["aantal"];

                aantal.Add(Aantal);
            }

            dbConnection.Close();

            return aantal;
        }*/
    }
}
