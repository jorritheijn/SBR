using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS.Helpers
{
    class UserHelper
    {
        public static Personeel Gebruiker = null;

        public static bool IsIngelogd
        {
            get { return Gebruiker != null; }
        }

        public static bool Inloggen(string pincode)
        {
            var werknemer = DataHelper.PersoneelDao.GetByPincode(pincode);

            if (werknemer != null)
            {
                Gebruiker = werknemer;
            }

            return IsIngelogd;
        }

        public static void Uitloggen()
        {
            Gebruiker = null;
        }
    }
}
