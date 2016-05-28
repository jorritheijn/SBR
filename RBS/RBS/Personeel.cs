using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    public class Personeel
    {
        private int id;
        private string username;    //max 15 chars
        private int pincode;
        private string functie;     //max 15 chars

        public Personeel()
        {
            id = 1234;
            username = "Bob Ross";
            pincode = 1234;
            functie = "Manager";
        }

        public Personeel(int id, string username, int pincode, string functie)
        {
            this.id = id;
            this.username = username;
            this.pincode = pincode;
            this.functie = functie;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public int Pincode
        {
            get { return pincode; }
            set { pincode = value; }
        }

        public string Functie
        {
            get { return functie; }
            set { functie = value; }
        }
    }
}
