using RBS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    public class Bestelling
    {
        public int id;
        public int personeelId;
        public int tafelId;
        public string betaalMethode;
        public DateTime opnameTijd;
        public BestelStatus status;

        public Bestelling (int id, int personeelId, int tafelId, string betaalMethode, DateTime opnameTijd, BestelStatus status)
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
