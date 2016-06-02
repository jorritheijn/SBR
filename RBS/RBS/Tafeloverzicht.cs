using RBS.Enums;
using RBS.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RBS
{
    public partial class TafelOverzicht : Form
    {
        private int LaatstGeklikteTafel;

        /// <summary>
        /// Constructor van het TafelOverzicht component.
        /// </summary>
        public TafelOverzicht()
        {
            InitializeComponent();
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
        /// Wanneer er op een tafel geklikt wordt opent het context menu.
        /// </summary>
        /// <param name="sender">De geklikte button</param>
        /// <param name="e">Klik argumenten</param>
        /// 
        private void TafelButton_Click(object sender, EventArgs e)
        {
            var tafelButton = sender as Button;

            // Als er op de button geklikt wordt wordt de naam vb. tafel1 veranderd door
            // 1 door de Name.Replace (haalt tafel weg uit de naam) en maakt hiervan het tafelID
            LaatstGeklikteTafel = int.Parse(tafelButton.Name.Replace("Tafel", ""));

            //Keuze menu voor betreffende tafel
            Point ptLowerLeft = new Point(0, tafelButton.Height);
            ptLowerLeft = tafelButton.PointToScreen(ptLowerLeft);

            contextMenuStrip1.Show(ptLowerLeft);
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip1_ItemClicked);
        }

        /// <summary>
        /// Hierin staan de opties van de menustrip en de navigatie naar de gewenste optie.
        /// </summary>
        /// <param name="sender">De geklikte menu optie</param>
        /// <param name="e">klik argumenten</param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;

            switch (item.Text)
            {
                case "Bezet zetten":
                    DataHelper.TafelDao.UpdateTafel(LaatstGeklikteTafel, TafelStatus.Bezet);
                    UpdateOverzicht();
                    break;
                case "Vrij zetten":
                    DataHelper.TafelDao.UpdateTafel(LaatstGeklikteTafel, TafelStatus.Vrij);
                    UpdateOverzicht();
                    break;
                case "Afrekenen":
                    var afrekenen = new Afrekenen(LaatstGeklikteTafel);
                    afrekenen.Show();
                    break;
                case "Bestelling plaatsen":
                    var bestellen = new BestelScherm(LaatstGeklikteTafel);
                    bestellen.Show();
                    break;
            }
        }

        /// <summary>
        /// Als er op de uitlogbutton wordt geklikt, logt de gebruiker uit mbv de userhelper.
        /// </summary>
        /// <param name="sender">de geklikte button</param>
        /// <param name="e">klik argumenten/param>
        private void LogUitBtn_Click(object sender, EventArgs e)
        {
            InlogScherm Inloggen = new InlogScherm();

            UserHelper.Uitloggen();

            Inloggen.Show();
            Hide();
        }
    }
}
