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
        private double prijs;
        private int aantalVoorraad;

         public Product(int id, string naam, double prijs, int aantalVoorraad)
        {
            this.id = id;
            this.naam = naam;
            this.prijs = prijs;
            this.aantalVoorraad = aantalVoorraad;
        }
    }
}
 