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
        Insert insert = new Insert();
        public Psycholoog(Connect _verbinding)
        {
            InitializeComponent();
            verbinding = _verbinding;
        }

        Select select = new Select();
        Miscellaneous overig = new Miscellaneous();

        private void refresh_data()
        {
            var patientgegevens = select.Select_Patient_Psycholoog(verbinding.patientID);
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
                    Dictionary<string, object> row = vorigeafspraken[o];
                    lbVorigeAfspraken.Items.Add(row["naam"] + " - " + row["locatienaam"] + " - " + row["datum"]);
                }
                
                // Pasfoto van patient laten zien in picturebox
                pbPasfoto.Load(verbinding.pasfoto);
                // pasfoto passend maken voor picturebox
                pbPasfoto.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void Psycholoog_Load(object sender, EventArgs e)
        {
            // custom format instellen voor tijd van een afspraak en tijd op 00:00 zetten
            dtpTijd.CustomFormat = "HH : mm";
            dtpTijd.Text = "00:00";

            var dataLocatie = select.Select_Locatie();

            int b = 0;
            for (b = 0; b < 1; ++b)
            {
                for (int j = 0; j < dataLocatie.Count; ++j)
                {
                    Dictionary<string, object> row = dataLocatie[j];

                    cbLocAfspraak.Items.Add("ID " + row["locatieID"] + " - " + row["locatienaam"]);
                }
            }
            
            refresh_data();

        }

        private void btnAfspraak_Click(object sender, EventArgs e)
        {
            
            
            string locatieIDstring = overig.GetSubstringByString("ID ", " -", Convert.ToString(cbLocAfspraak.SelectedItem));
            string datum = dtpAfspraak.Text;
            string tijd = dtpTijd.Text;
            bool actief = cbActief.Checked;

            int error = 0;

            if (locatieIDstring == "" || datum == "" || tijd == "")
            {
                ++error;
                MessageBox.Show("Je bent wat gegevens vergeten, loop ze nog eens na!");
            }
            else
            {
                if (error == 0)
                {
                    if (actief)
                    {
                        
                        int locatieID = Convert.ToInt32(locatieIDstring);
                        int medicatieID = 0;
                        int actiefenzo = Convert.ToInt32(actief);
                        insert.Insert_Afspraak(medicatieID, locatieID, datum, tijd, actiefenzo);
                        MessageBox.Show("Afspraak is succesvol toegevoegd!");

                    }
                    else
                    {
                        int locatieID = Convert.ToInt32(locatieIDstring);
                        int medicatieID = 0;
                        int actiefenzo = Convert.ToInt32(actief);
                        insert.Insert_Afspraak(medicatieID, locatieID, datum, tijd, actiefenzo);
                        MessageBox.Show("Afspraak is succesvol toegevoegd!");
                    }
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Patient afmelden
            // Gegevens weghalen en scan form weergeven

            verbinding.patientID = 0; // int, dus null gaat niet
            verbinding.pasfoto = null;

            scan scan = new scan(verbinding);
            this.Hide();
            scan.Show();
        }

        private void linkProgramAfmelden_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            verbinding.locatie = null;
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        
    }
}
