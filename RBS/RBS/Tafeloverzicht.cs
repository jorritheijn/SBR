using RBS.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RBS
{
    public partial class TafelOverzicht : Form
    {
        /// <summary>
        /// Data Access Object voor de tafels.
        /// </summary>
        public TafelDAO dao;

        /// <summary>
        /// Constructor van het TafelOverzicht component.
        /// </summary>
        public TafelOverzicht()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor van het TafelOverzicht component met DAO.
        /// </summary>
        public TafelOverzicht(TafelDAO dao)
        {
            InitializeComponent();

            this.dao = dao;

            UpdateOverzicht();
        }

        /// <summary>
        /// Zoek een button op naam.
        /// </summary>
        /// <param name="naam">Naam van de button</param>
        /// <returns>Gevonden button of null wanneer niet gevonden</returns>
        public Button ZoekButton(string naam)
        {
            var resultaat = this.Controls.Find(naam, true);

            if (resultaat.Length == 0)
            {
                return null;
            }

            return resultaat[0] as Button;
        }

        /// <summary>
        /// Update het tafeloverzicht met de statussen.
        /// </summary>
        public void UpdateOverzicht() {
            var list = dao.GetAll();

            // Loop alle tafels langs
            foreach (Tafel tafel in list)
            {
                var tafelButton = ZoekButton("tafel" + tafel.ID);

                // Ga door met de volgende tafel als de button niet gevonden wordt
                if (tafelButton == null)
                {
                    continue;
                }

                // Zet de achtergrondkleur die bij de status hoort
                if (tafel.Status == TafelStatus.Vrij)
                {
                    tafelButton.BackColor = Color.White;
                }
                else
                {
                    tafelButton.BackColor = Color.DarkRed;
                }
            }
        }

        /// <summary>
        /// Wanneer er op een tafel geklikt wordt verwijst deze naar het
        /// bestelformulier.
        /// </summary>
        /// <param name="sender">De geklikte button</param>
        /// <param name="e">Klik argumenten</param>
        private void TafelButton_Click(object sender, EventArgs e)
        {
            var tafelButton = sender as Button;

            // Als er op de button geklikt wordt wordt de naam vb. tafel1 veranderd door
            // 1 door de Name.Replace (haalt tafel weg uit de naam) en maakt hiervan het tafelID
            string tafelID = tafelButton.Name.Replace("Tafel", "");

            // TODO: Ga naar bestel scherm en geef tafelID mee
            Console.WriteLine("Geklikt op tafel " + tafelID);

            // Voorbeeld om een tafel op te halen
            // var t = dao.GetTafel(Convert.ToInt32(tafelID));
        }
    }
}
