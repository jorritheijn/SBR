using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    public class Bestelling
    {
        //om te testen, weet niet zeker of dit goed is
        public int id;
        public string bestelling;
        public int tafel;

        public Bestelling(int id, string bestelling, int tafel)
        {
            this.id = id;
            this.bestelling = bestelling;
            this.tafel = tafel;
        }
    }
}
