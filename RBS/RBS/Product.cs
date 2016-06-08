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

        /// <summary>
        /// Lege constructor
        /// </summary>
        public Product() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naam"></param>
        /// <param name="prijs"></param>
        /// <param name="aantalVoorraad"></param>
        /// <param name="subCategorieId"></param>
        public Product(int id, string naam, decimal prijs, int aantalVoorraad, int subCategorieId)
        {
            this.id = id;
            this.naam = naam;
            this.prijs = prijs;
            this.aantalVoorraad = aantalVoorraad;
            this.subCategorieId = subCategorieId;
        }

      
        /// <summary>
        /// Berekent de btw op het product
        /// </summary>
        public decimal BerekenBTW
        {
            get
            {
                decimal btw = (decimal)0.06;
                //subCategorie 9, 10 en 11 zijn de alcohol houdende producten. Hebben andere BTW.
                if (subCategorieId == 9 || subCategorieId == 10 || subCategorieId == 11) btw = (decimal)0.21;
                btw = prijs * btw;
                return btw;
            }
        }

        /// <summary>
        /// get methode voor id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// get/set voor naam
        /// </summary>
        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        /// <summary>
        /// get/set voor prijs
        /// </summary>
        public decimal Prijs
        {
            get { return prijs; }
            set { prijs = value; }
        }

        /// <summary>
        /// get/set voor aantalVoorraad
        /// </summary>
        public int AantalVoorraad
        {
            get { return aantalVoorraad; }
            set { aantalVoorraad = value; }
        }

        /// <summary>
        /// get/set voor subCategorieId
        /// </summary>
        public int SubCategorieId
        {
            get { return subCategorieId; }
            set { subCategorieId = value; }
        }
    }
}
 