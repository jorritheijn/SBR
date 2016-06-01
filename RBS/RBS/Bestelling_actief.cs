using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    public class Bestelling_actief
    {
        private List<string> tafelid1;
        private List<string> productennaam1;
        private List<string> aantal1;

        public Bestelling_actief(List<string> tafelid1, List<string> productennaam1, List<string> aantal1)
        {
            // TODO: Complete member initialization
            this.tafelid1 = tafelid1;
            this.productennaam1 = productennaam1;
            this.aantal1 = aantal1;
        }
    }
}
