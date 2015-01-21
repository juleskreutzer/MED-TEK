using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MED_TEK
{
    public partial class Psycholoog : Form
    {
        Connect verbinding;
        public Psycholoog(Connect _verbinding)
        {
            InitializeComponent();
            verbinding = _verbinding;
        }

        Select select = new Select();
        Miscellaneous overig = new Miscellaneous();

        private void refresh_data()
        {
            var patientgegevens = select.Select_Patient_Auto(verbinding.patientID);
            var ziekteoverzicht = select.Select_Ziekteoverzicht(verbinding.patientID);
            var medicatieoverzicht = select.Select_Medicatie(verbinding.patientID);
            var vorigeafspraken = select.Select_Afspraak(verbinding.patientID);

            int i = 0;
            int j = 0;
            int a = 0;
            int x = 0;
            int o = 0;

            for (i = 0; i < 1; ++i)
            {
                for (j = 0; j < patientgegevens.Count; ++j)
                {
                    Dictionary<string, object> row = patientgegevens[j];
                    tbVoorNamen.Text = (string) row["voornamen"];
                    tbAchternaam.Text = (string) row["achternaam"];
                    string date = (string) row["geboortedatum"];
                    dtpGeboorte.Text = date;
                    tbAdres.Text = (string) row["adres"];
                }

                for (a = 0; a < ziekteoverzicht.Count; ++a)
                {
                    Dictionary<string, object> row = ziekteoverzicht[a];
                    lbZiektes.Items.Add(row["naam"]);
                }

                for (x = 0; x < medicatieoverzicht.Count; ++x)
                {
                    Dictionary<string, object> row = medicatieoverzicht[x];
                    lbMedicatie.Items.Add(row["naam"]);
                }

                for (o = 0; o < vorigeafspraken.Count; ++o)
                {
                    Dictionary<string, object> row = vorigeafspraken[x];
                    lbVorigeAfspraken.Items.Add(row["medicatieID"] + " - " + row["locatieID"] + " - " + row["datum"]);
                }
            }
        }

        private void Psycholoog_Load(object sender, EventArgs e)
        {
            refresh_data();
        }
    }
}
