using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS.Helpers
{
    class DataHelper
    {
        private static SqlConnection _connection;
        public static SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
                    _connection = new SqlConnection(connString);
                }

                return _connection;
            }
        }

        private static BestellingDAO _bestellingDao;
        public static BestellingDAO BestellingDao
        {
            get
            {
                if (_bestellingDao == null)
                {
                    _bestellingDao = new BestellingDAO(Connection);
                }

                return _bestellingDao;
            }
        }

        private static PersoneelDAO _personeelDao;
        public static PersoneelDAO PersoneelDao
        {
            get
            {
                if (_personeelDao == null)
                {
                    _personeelDao = new PersoneelDAO(Connection);
                }

                return _personeelDao;
            }
        }

        private static ProductDAO _productDao;
        public static ProductDAO ProductDao
        {
            get
            {
                if (_productDao == null)
                {
                    _productDao = new ProductDAO(Connection);
                }

                return _productDao;
            }
        }

        private static TafelDAO _tafelDao;
        public static TafelDAO TafelDao
        {
            get
            {
                if (_tafelDao == null)
                {
                    _tafelDao = new TafelDAO();
                }

                return _tafelDao;
            }
        }
    }
}
