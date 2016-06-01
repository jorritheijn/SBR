using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    public class Product
    {
        //test
        private int id;
        private string naam;
        private decimal prijs;
        private int aantalVoorraad;
        private int subCategorieId;

        public Product(int id, string naam, decimal prijs, int aantalVoorraad, int subCategorieId)
        {
            this.id = id;
            this.naam = naam;
            this.prijs = prijs;
            this.aantalVoorraad = aantalVoorraad;
            this.subCategorieId = subCategorieId;
        }

        public int Id
        {
            get { return id; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public decimal Prijs
        {
            get { return prijs; }
            set { prijs = value; }
        }

        public int AantalVoorraad
        {
            get { return aantalVoorraad; }
            set { aantalVoorraad = value; }
        }

        public int SubCategorieId
        {
            get { return subCategorieId; }
            set { subCategorieId = value; }
        }
    }
}
 