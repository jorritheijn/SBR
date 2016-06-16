using RBS.Enums;
using RBS.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RBS
{
    public partial class TafelOverzicht : Form
    {
        private int RefreshTime = 15;

        private Timer RefreshTimer;

        private Dictionary<BestelStatus, string> StatusMeldingen = new Dictionary<BestelStatus, string>() {
            { BestelStatus.Besteld, "Loopt" },
            { BestelStatus.Gereed, "Gereed" },
            { BestelStatus.Onbekend, String.Empty }
        };

        private int LaatstGeklikteTafel;

        /// <summary>
        /// Constructor van het TafelOverzicht component.
        /// </summary>
        public TafelOverzicht()
        {
            InitializeComponent();

            // Zeker weten dat alle data goed staat
            Ingelogde.Text = UserHelper.Gebruiker.Username;
            UpdateOverzicht();
            UpdateTafelStatussen();

            contextMenuStrip1.ItemClicked += contextMenuStrip1_ItemClicked;
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
        /// Zoek een label op naam.
        /// </summary>
        /// <param name="naam">Naam van de label</param>
        /// <returns>Gevonden label of null wanneer niet gevonden</returns>
        public Label ZoekLabel(string naam)
        {
            var resultaat = this.Controls.Find(naam, true);

            if (resultaat.Length == 0)
            {
                return null;
            }

            return resultaat[0] as Label;
        }

        /// <summary>
        /// Update het tafeloverzicht met de statussen.
        /// </summary>
        public void UpdateOverzicht()
        {
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
            
            // Voorbeeld om een tafel op te halen
            //var t = DataHelper.TafelDao.GetTafel(Convert.ToInt32(tafelID));
        }

        /// <summary>
        /// Switch voor het dropdown-menu
        /// </summary>
        /// <param name="sender">Het geklikte item</param>
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
                    this.Close();
                    break;
                case "Bestelling plaatsen":
                    var bestellen = new BestelScherm(LaatstGeklikteTafel);
                    bestellen.Show();
                    this.Close();
                    break;
                case "Uitgeserveerd":
                    DataHelper.BestellingDao.UpdateTafelBestellingen(LaatstGeklikteTafel, BestelStatus.Uitgeserveerd);
                    UpdateTafelStatussen();
                    break;
            }
        }

        /// <summary>
        /// Uitlogbutton
        /// </summary>
        /// <param name="sender">De geklikte button</param>
        /// <param name="e">Klik argumenten</param>
        private void LogUitBtn_Click(object sender, EventArgs e)
        {
            InlogScherm Inloggen = new InlogScherm();

            UserHelper.Uitloggen();

            Inloggen.Show();
            Hide();
        }

        /// <summary>
        /// Tafeloverzicht timer update
        /// </summary>
        /// <param name="sender">Automatisch updaten</param>
        /// <param name="e"></param>
        private void TafelOverzicht_Load(object sender, EventArgs e)
        {
            RefreshTimer = new Timer();
            RefreshTimer.Interval = RefreshTime * 1000;
            RefreshTimer.Tick += UpdateTafelStatussen_Tick;
            RefreshTimer.Start();
        }

        /// <summary>
        /// Update Tafelstatussen (loopt, gereed, uitgeserveerd)
        /// </summary>
        /// <param name="sender">automatisch updaten</param>
        /// <param name="e">updatetafelstatussen</param>
        private void UpdateTafelStatussen_Tick(object sender, EventArgs e)
        {
            UpdateTafelStatussen();
        }

        /// <summary>
        /// Update de tafelstatus (zoek de labels)
        /// </summary>
        private void UpdateTafelStatussen()
        {
            var bestellingen = DataHelper.BestellingDao.GetAllNonClosedBestellingen();
            int i = 1;

            for (; i <= 10; i++)
            {
                var label = ZoekLabel("lbl_Tafel" + i);
                var status = FilterStatus(i, bestellingen);

                label.Text = StatusMeldingen[status];
            }
        }

        /// <summary>
        /// Als de form wordt gesloten zal de refreshtimer niet doorgaan
        /// </summary>
        /// <param name="sender">gesloten form</param>
        private void TafelOverzicht_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshTimer.Stop();
            RefreshTimer.Dispose();
        }

        /// <summary>
        /// Alle statussen worden bekeken en de statussen worden gereturnt.
        /// </summary>
        /// <param name="tafelId">Kijk via tafelId</param>
        /// <returns>De status</returns>
        private BestelStatus FilterStatus(int tafelId, List<Bestelling> bestellingen)
        {
            BestelStatus status = BestelStatus.Onbekend;

            foreach (var bestelling in bestellingen)
            {
                if (bestelling.tafelId == tafelId && bestelling.status > status)
                {
                    status = bestelling.status;
                }
            }

            return status;
        }
    }
}
