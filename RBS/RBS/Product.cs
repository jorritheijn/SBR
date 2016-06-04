using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    public class Product
    {
        private int id;
        private string naam;
        private decimal prijs;
        private int aantalVoorraad;
        private int subCategorieId;

        public Product() { }

        public Product(int id, string naam, decimal prijs, int aantalVoorraad, int subCategorieId)
        {
            this.id = id;
            this.naam = naam;
            this.prijs = prijs;
            this.aantalVoorraad = aantalVoorraad;
            this.subCategorieId = subCategorieId;
        }

        public decimal BerekenBTW
        {
            get
            {
                decimal btw = (decimal)0.09;
                // subCategorie 9, 10 en 11 zijn de alcohol houdende producten. Hebben andere BTW.
                if (subCategorieId == 9 || subCategorieId == 10 || subCategorieId == 11) btw = (decimal)0.21;
                btw = prijs * btw;
                return btw;
            }
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
 