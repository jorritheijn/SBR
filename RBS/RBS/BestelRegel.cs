using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    public class BestelRegel
    {
        string productNaam;
        int aantal;
        int bestelId;
        int tafelId;
        string comment;
        int status;

        public BestelRegel(int tafelId, string productNaam, int aantal,  int bestelId, string comment, int status)
        {
            this.tafelId = tafelId;
            this.productNaam = productNaam;
            this.aantal = aantal;
            this.bestelId = bestelId;
            this.comment = comment;
            this.status = status;
        }

        public int TafelId
        {
            get { return tafelId; }
            set { tafelId = value; }
        }

        public string ProductId
        {
            get { return productNaam; }
            set { productNaam = value; }
        }

        public int Aantal
        {
            get { return aantal; }
            set { aantal = value; }
        }

        public int BestelId
        {
            get { return bestelId; }
            set { bestelId = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
