using RBS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBS
{
    public partial class InlogScherm : Form
    {
        /// <summary>
        /// Aantal karakters voor de pincode
        /// </summary>
        int Karakters = 4;

        /// <summary>
        /// Huidige code
        /// </summary>
        string Code = "";

        /// <summary>
        /// Constructor van het InlogScherm component
        /// </summary>
        public InlogScherm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Update de code intern en update zorgt dat de view ververst wordt
        /// </summary>
        /// <param name="code">De code</param>
        public void UpdateCode(string code)
        {
            Code = code;

            UpdateView();
        }

        /// <summary>
        /// Zoek een label op naam.
        /// </summary>
        /// <param name="naam">Naam van het label</param>
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
        /// Update de view om te laten zien hoeveel tekens er ingevoerd zijn.
        /// </summary>
        public void UpdateView()
        {
            for (int i = 0; i < Karakters; i++)
            {
                var label = ZoekLabel("code" + i);

                if (i < Code.Length)
                {
                    label.Text = "*";
                }
                else
                {
                    label.Text = ".";
                }
            }
        }

        /// <summary>
        /// Voegt een cijfer toe aan de code en zoekt de werknemer als
        /// het aantal karakters van een code is bereikt.
        /// </summary>
        /// <param name="sender">De cijfer knop</param>
        /// <param name="e">De klik argumenten</param>
        public void Cijfer_Click(object sender, EventArgs e)
        {
            if (Code.Length == 4)
            {
                return;
            }

            var cijferButton = sender as Button;

            // Als er op de button geklikt wordt wordt de naam vb. cijfer1 veranderd door
            // 1 door de Name.Replace (haalt cijfer weg uit de naam) en maakt hiervan het teken
            string teken = cijferButton.Name.Replace("cijfer", "");

            UpdateCode(Code + teken);

            // Zolang de code niet 4 cijfers bevat blijf tekens toevoegen
            if (Code.Length != 4)
            {
                return;
            }

            // Werknemer zoeken op basis van de pincode
            if (UserHelper.Inloggen(Code))
            {
                var gebruiker = UserHelper.Gebruiker;
                Form view = null;

                switch (gebruiker.Functie)
                {
                    case "Manager":
                        view = new PersoneelsBeheer();
                        break;
                    case "Keuken":
                        view = new KeukenScherm();
                        break;
                    case "Bar":
                        view = new BarScherm();
                        break;
                    case "Bediening":
                        view = new TafelOverzicht();
                        break;
                    default:
                        Console.WriteLine("Ongeldige functie");
                        break;
                }

                if (view != null)
                {
                    view.Show();
                    Hide();
                }
            }

            UpdateCode("");
        }
    }
}
