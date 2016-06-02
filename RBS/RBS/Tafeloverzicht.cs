using RBS.Enums;
using RBS.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RBS
{
    public partial class TafelOverzicht : Form
    {
        /// <summary>
        /// Constructor van het TafelOverzicht component.
        /// </summary>
        public TafelOverzicht()
        {
            InitializeComponent();

            //checkt welke context menu geklikt is
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip1_ItemClicked);
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
            var list = DataHelper.TafelDao.GetAll();

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
        /// 
        int tafelId;
        private void TafelButton_Click(object sender, EventArgs e)
        {
            var tafelButton = sender as Button;

            // Als er op de button geklikt wordt wordt de naam vb. tafel1 veranderd door
            // 1 door de Name.Replace (haalt tafel weg uit de naam) en maakt hiervan het tafelID
            tafelId = int.Parse(tafelButton.Name.Replace("Tafel", ""));

            //Keuze menu locatie onder tafel knop
            Point point = new Point(0, tafelButton.Height);
            point = tafelButton.PointToScreen(point);
            contextMenuStrip1.Show(point);

            // TODO: Ga naar bestel scherm en geef tafelID mee
            Console.WriteLine("Geklikt op tafel " + tafelId);

            // Voorbeeld om een tafel op te halen
            //var t = DataHelper.TafelDao.GetTafel(Convert.ToInt32(tafelID));
        }

        //click handler voor menu strip
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem Afrekenen = e.ClickedItem;
            System.Diagnostics.Debug.WriteLine("balls");
            Afrekenen afrekenen = new Afrekenen(tafelId);
            afrekenen.Show();
        }

        private void LogUitBttn_Click(object sender, EventArgs e)
        {
            InlogScherm Check = new InlogScherm();
            Check.Show();
            Hide();
        }
    }
}
