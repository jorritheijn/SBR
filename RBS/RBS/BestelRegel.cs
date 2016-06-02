using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    public class BestelRegel
    {
        int productId;
        int aantal;
        int bestelId;
        int tafelId;
        string comment;
        string status;

        public BestelRegel(int tafelId, int productId, int aantal,  int bestelId, string comment, string status)
        {
            this.tafelId = tafelId;
            this.productId = productId;
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

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
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

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
