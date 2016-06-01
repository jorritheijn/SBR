using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace RBS
{
    public class BestelRegel
    {
        int tafelId;
        string product;
        int aantal;
        decimal totaalPrijs;

        public BestelRegel(int tafelId, string product, int aantal, decimal totaalPrijs)
        {
            this.tafelId = tafelId;
            this.product = product;
            this.aantal = aantal;
            this.totaalPrijs = totaalPrijs;
        }

        public int TafelId
        {
            get { return tafelId; }
            set { tafelId = value; }
        }

        public string Product
        {
            get { return product; }
            set { product = value; }
        }

        public int Aantal
        {
            get { return aantal; }
            set { aantal = value; }
        }

        public decimal TotaalPrijs
        {
            get { return totaalPrijs; }
            set { totaalPrijs = value; }
        }
    }
}
