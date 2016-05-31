using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    public class Bestelling
    {
        int id;
        int personeelId;
        int tafelId;
        int betaalMethode;
        DateTime opnameTijd;
        string status;

        public Bestelling(int id, int personeelId, int tafelId, int betaalMethode, DateTime opnameTijd, string status)
        {
            this.id = id;
            this.personeelId = personeelId;
            this.tafelId = tafelId;
            this.betaalMethode = betaalMethode;
            this.opnameTijd = opnameTijd;
            this.status = status;
        }
    }
}
