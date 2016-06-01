using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    class Product
    {
        private int productId;
        private string productNaam;
        private double productPrijs;
        private int aantalVoorraad;

         public Product(int productId, string productNaam, double productPrijs, int aantalVoorraad)
        {
            this.productId = productId;
            this.productNaam = productNaam;
            this.productPrijs = productPrijs;
            this.aantalVoorraad = aantalVoorraad;
        }
       
         }
    }
