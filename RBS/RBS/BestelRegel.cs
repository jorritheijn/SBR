using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBS
{
    /// <summary>
    /// Klasse voor het maken van (deel)bestellingen
    /// </summary>
    public class BestelRegel
    {
        private int tafelId, productId, aantal, bestelId, status, id;
        private string comment;

        public BestelRegel(int tafelId, int productId, int aantal, int bestelId, string comment, int status, int id)
        {
            this.tafelId = tafelId;
            this.productId = productId;
            this.aantal = aantal;
            this.bestelId = bestelId;
            this.comment = comment;
            this.status = status;
            this.id = id;
        }

        /// <summary>
        /// Constructor zonder id en status voor het invoegen van bestelRegels naar de database
        /// </summary>
        /// <param name="tafelId">ID van de tafel</param>
        /// <param name="productId">ID van het product</param>
        /// <param name="aantal">Hoeveel er van hetzelfde product wordt besteld</param>
        /// <param name="bestelId">ID van de lopende bestelling</param>
        /// <param name="comment">Opmerking specifiek aan het product</param>
        /// <remarks>Bij het invoeren wordt status altijd op 1 gesteld
        /// ID wordt op 0 gezet om null errors te voorkomen</remarks>
        public BestelRegel(int tafelId, int productId, int aantal, int bestelId, string comment)
        {
            this.tafelId = tafelId;
            this.productId = productId;
            this.aantal = aantal;
            this.bestelId = bestelId;
            this.comment = comment;
            status = 1;
            id = 0;
        }

        /// <summary>
        /// Get/set van het tafelId
        /// </summary>
        public int TafelId
        {
            get { return tafelId; }
            set { tafelId = value; }
        }

        /// <summary>
        /// Get/set van het productId
        /// </summary>
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        /// <summary>
        /// Get/set van het aantal
        /// </summary>
        public int Aantal
        {
            get { return aantal; }
            set { aantal = value; }
        }

        /// <summary>
        /// Get/set van het bestelId
        /// </summary>
        public int BestelId
        {
            get { return bestelId; }
            set { bestelId = value; }
        }

        /// <summary>
        /// Get/set van de opmerking
        /// </summary>
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        /// <summary>
        /// Get/set van de status van de bestelling
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Get/set van het Id van de bestelRegel
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
