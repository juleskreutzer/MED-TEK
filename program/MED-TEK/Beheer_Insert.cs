﻿using System;
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
    public partial class Beheer_Insert : Form
    {
        public Beheer_Insert()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        // Fields
        Connect verbinding = new Connect();
        Insert insert = new Insert();
        Miscellaneous overig = new Miscellaneous();
        Select select = new Select();

        private void beheer_Load(object sender, EventArgs e)
        {
            refresh();

            // custom format instellen voor tijd van een afspraak en tijd op 00:00 zetten
            dtpTijd.CustomFormat = "HH : mm";
            dtpTijd.Text = "00:00";

            // Custom format instellen voor het opslaan van de datum gebruikstart en gebruikeind in de database
            dtpGebruikStart.CustomFormat = "dd / MM / yyyy";
            dtpGebruikEind.CustomFormat = "dd / MM / yyyy";

            // OPVRAGEN GEGEVENS VOOR TOEKENNEN ZIEKTE AAN PATIENT EN TOEKENNEN MEDICATIE AAN PATIENT
            var dataPatientNaam = select.Select_Patient_Naam();
            var dataZiekteNaam = select.Select_Ziekte();
            var dataMedicijnNaam = select.Select_Medicijn();

            int a = 0;

            for (a = 0; a < 1; ++a)
            {
                for (int i = 0; i < dataPatientNaam.Count; ++i)
                {
                    Dictionary<string, object> row = dataPatientNaam[i];

                    cbPatient.Items.Add("ID " + row["patientID"] + " - " + row["voornamen"] + " " + row["achternaam"]);
                    cbPatientMedicatie.Items.Add("ID " + row["patientID"] + " - " + row["voornamen"] + " " + row["achternaam"]);
                }

                for(int j = 0; j < dataZiekteNaam.Count; ++j)
                {
                    Dictionary<string, object> row = dataZiekteNaam[j];

                    cbZiekte.Items.Add("ID " + row["ziekteID"] + " - " + row["naam"]);
                }

                for (int c = 0; c < dataMedicijnNaam.Count; ++c)
                {
                    Dictionary<string, object> row = dataMedicijnNaam[c];

                    cbMedicijn.Items.Add("ID " + row["medicijnID"] + " - " + row["naam"]);
                }
            }
            // EINDE OPVRAGEN GEGEVENS VOOR TOEKENNEN ZIEKTE AAN PATIENT

            // OPVRAGEN GEGEVENS VOOR MAKEN NIEUWE AFSPRAAK
            var dataMedicatie = select.Select_Medicatie_All();
            var dataLocatie = select.Select_Locatie();

            int b = 0;
            for (b = 0; b < 1; ++b)
            {
                for (int i = 0; i < dataMedicatie.Count; ++i)
                {
                    Dictionary<string, object> row = dataMedicatie[i];

                    cbMedicatie.Items.Add("ID " + row["medicatieID"] + " - " + row["naam"] + " - " + row["voornamen"] + " " + row["achternaam"]);
                }
                for(int j = 0; j < dataLocatie.Count; ++j)
                {
                    Dictionary<string, object> row = dataLocatie[j];

                    cbLocAfspraak.Items.Add("ID " + row["locatieID"] + " - " + row["naam"]);
                }
            }



        }

        public void refresh()
        {
            // Gegevens opnieuw laden in form

            // Listbox legen zodat dezelfde gegevens niet meerdere keren in listbox staan
            lbZiekte.Items.Clear();
            lbMedicijn.Items.Clear();

            // Ziektes bekend in database ophalen en weergegeven in listbox
            var dataziekte = select.Select_Ziekte();
            var datamedicijn = select.Select_Medicijn();
            int i = 0;

            for (i = 0; i < 1; ++i)
            {
                for (int j = 0; j < dataziekte.Count; ++j)
                {
                    Dictionary<string, object> row = dataziekte[j];

                    lbZiekte.Items.Add((string)row["naam"]);
                    lbZiekte.Items.Add("\n");

                }

                for (int k = 0; k < datamedicijn.Count; ++k)
                {
                    Dictionary<string, object> row = datamedicijn[k];

                    lbMedicijn.Items.Add((string)row["naam"]);
                    lbMedicijn.Items.Add("\n");

                }
            }


        }

        private void btnResetUser_Click(object sender, EventArgs e)
        {
            // Alle velden voor toevoegen van nieuwe patient leegmaken

            // Alle velden leeg maken zodat gegevens opnieuw ingevuld kunnen worden
            tbVoornamen.Text = "";
            tbAchternaam.Text = "";
            dtpDoB.Text = "";
            tbBSN.Text = "";
            tbBloedgroep.Text = "";
            tbPasfoto.Text = "";
            tbEmail.Text = "";
            tbTelefoon.Text = "";
            tbMobiel.Text = "";
            tbAdres.Text = "";
            tbGemeente.Text = "";
            tbProvincie.Text = "";
            tbPascode.Text = "";
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            // Nieuwe patient toevoegen aan database

            // Waarden van de velden in een variabele zetten
            string voornamen = tbVoornamen.Text;
            string achternaam = tbAchternaam.Text;
            string DoB = Convert.ToString(dtpDoB.Text);
            string BSN = tbBSN.Text;
            string bloedgroep = tbBloedgroep.Text;
            string pasfoto = tbPasfoto.Text;
            string email = tbEmail.Text;
            string telefoon = tbTelefoon.Text;
            string mobiel = tbMobiel.Text;
            string adres = tbAdres.Text;
            string gemeente = tbGemeente.Text;
            string provincie = tbProvincie.Text;
            string pascode = tbPascode.Text;

            // Patient kan enkel toegevoegd worden wanneer int error == 0
            int error = 0;

            // Controleren op fouten
            if (voornamen == "")
            {
                ++error;
                MessageBox.Show("Voornamen mogen helaas niet leeg gelaten worden!");
            }

            if (achternaam == "")
            {
                ++error;
                MessageBox.Show("Achternaam mag helaas niet leeg gelaten worden!");
            }

            if(DoB == "")
            {
                ++error;
                MessageBox.Show("De geboortedatum van de nieuwe patient moet ingevoerd worden!");
            }

            if (Convert.ToString(BSN) == "")
            {
                ++error;
                MessageBox.Show("Het BSN moet ingevuld worden!");
            }

            if(bloedgroep == "")
            {
                ++error;
                MessageBox.Show("De bloedgroep van de patient moet ingevuld worden!");
            }

            if(pasfoto == "")
            {
                ++error;
                MessageBox.Show("Er moet een link worden opgegeven voor een pasfoto!");
            }

            if (email == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om een email adres op te geven!");
            }

            if(Convert.ToString(telefoon) == "" && Convert.ToString(mobiel) == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om een telefoon of mobiel nummer op te geven!");
            }

            if (adres == "")
            {
                ++error;
                MessageBox.Show("Er moet een adres worden ingevuld voor een nieuwe patient!");
            }

            if(gemeente == "")
            {
                ++error;
                MessageBox.Show("Er moet een gemeente worden ingevuld voor een nieuwe patient!");
            }

            if (provincie == "")
            {
                ++error;
                MessageBox.Show("Er moet een provincie worden opgegeven voor een nieuwe patient!");
            }

            if(pascode =="")
            {
                ++error;
                MessageBox.Show("Er moet een pascode worden gekoppeld aan de patient voordat deze kan worden toegevoegd!");
            }

            if (error == 0)
            {
                insert.Insert_Patient(voornamen, achternaam, DoB, BSN, bloedgroep, pasfoto, email, telefoon, mobiel, adres, gemeente, provincie, pascode);
                MessageBox.Show("Gegevens zijn succesvol toegevoegd in de database");
            }
            else
            {
                MessageBox.Show("Er zijn fouten opgetreden waardoor de gegevens niet kunnen worden toegevoegd in de database");
            }
        }

        private void btnAddZiekte_Click(object sender, EventArgs e)
        {
            // Ziekte toevoegen aan database
            string naam = tbZiekte.Text;

            if(naam == "")
            {
                MessageBox.Show("Er moet een naam van de ziekte worden opgegeven voordat deze kan worden toegevoegd.");
            }
            else
            {
                insert.Insert_Ziekte(naam);
                tbZiekte.Text = "";
                MessageBox.Show("De ziekte is succesvol toegevoegd!");
            }

            refresh();
        }

        private void btnResetZiekte_Click(object sender, EventArgs e)
        {
            // tbZiekte leeg maken
            tbZiekte.Text = "";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            scan scan = new scan();
            scan.Show();
        }

        private void btNewUser_Click(object sender, EventArgs e)
        {
            // Nieuwe gebruiker toevoegen waarmee kan worden ingelogd
            string username = tbUsername.Text;
            string password = overig.versleutel(tbPassword.Text);
            string locatie = cbLocatie.Text;
            int locatieID = 0;

            if (locatie == "Doctor")
            {
                locatieID = 1;
            }
            else if (locatie == "Ambulance")
            {
                locatieID = 2;
            }
            else if (locatie == "Apotheek")
            {
                locatieID = 3;
            }
            else if (locatie == "Psycholoog")
            {
                locatieID = 4;
            }
            else if (locatie == "Beheer")
            {
                locatieID = 5;
            }

            if(locatieID != 0)
            {
                insert.Insert_User(username, password, locatieID);
                tbUsername.Text = "";
                tbPassword.Text = "";
                cbLocatie.Text = "";
                MessageBox.Show("Nieuwe gebruiker toegevoegd!");
            }
            else
            {
                MessageBox.Show("Kan geen nieuwe gebruiker toevoegen!");
            }

        }

        private void btnResetMedicijn_Click(object sender, EventArgs e)
        {
            // tbmedicijn leeg maken
            tbmedicijn.Text = "";
        }

        private void btnAddMedicijn_Click(object sender, EventArgs e)
        {
            // Medicijn toevoegen aan database

            string medicijn = tbmedicijn.Text;
            string gebruik = tbMedicijnGebruik.Text;
            string bijwerking = tbMedicijnBijwerking.Text;

            if(medicijn != "" && gebruik != "" && bijwerking != "")
            {
                insert.Insert_Medicijn(medicijn, gebruik, bijwerking);
                MessageBox.Show("Nieuw medicijn is toegevoegd!");
            }
            else
            {
                MessageBox.Show("Het medicijn kan niet worden toegevoegd aan de database. Alle velden moeten worden ingevuld of er is een ander probleem ogetreden");
            }

            refresh();
        }

        private void btnKoppelZiekte_Click(object sender, EventArgs e)
        {
            // Ziekte aan patient koppelen

            string patientIDstring = (string)cbPatient.SelectedItem;
            string ziekteIDstring = (string)cbZiekte.SelectedItem;

            if (patientIDstring == "")
            {
                MessageBox.Show("Selecteer een patient");
            }
            else if(ziekteIDstring == "")
            {
                MessageBox.Show("Selecteer een ziekte");
            }
            else
            {
                int patientID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", patientIDstring));
                int ziekteID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", ziekteIDstring));

                insert.Insert_Ziekteoverzicht(ziekteID, patientID);
                MessageBox.Show("De ziekte is met succes toegewezen aan de patient.");
            }


        }

        private void btnClearAfspraak_Click(object sender, EventArgs e)
        {
            // alle velden voor afspraak leeg maken
            cbMedicatie.Text = "";
            cbLocAfspraak.Text = "";
            dtpAfspraak.Text = "";
            dtpTijd.Text = "00 : 00";
            cbActief.Checked = false;
        }

        private void btnAfspraak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Waarde check box: " + cbActief.Checked);
        }

        private void btnMedicatieToevoegen_Click(object sender, EventArgs e)
        {
            // Toevoegen van medicatie voor een patient aan de database

            string patientIDstring = (string)cbPatientMedicatie.SelectedItem;
            string medicijnIDstring = (string)cbMedicijn.SelectedItem;

            if (patientIDstring == "")
            {
                MessageBox.Show("Selecteerd een patient voordat deze bewerking kan worden voltooid");
            }
            if (medicijnIDstring == "")
            {
                MessageBox.Show("Selecteer een medicijn voordat deze bewerking kan worden voltooid");
            }

            // ID opvragen van patient en medicijn voordat het opgeslagen wordt in database
            int patientID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", patientIDstring));
            int medicijnID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", medicijnIDstring));

            string hoeveelheid = tbHoeveelheid.Text;

            if (hoeveelheid == "")
            {
                MessageBox.Show("Er moet een hoeveelheid worden opgegeven");
            }

            string GebruikStart = dtpGebruikStart.Text;
            string GebruikEind = dtpGebruikEind.Text;

            insert.Insert_Medicatie(patientID, medicijnID, GebruikStart, GebruikEind, hoeveelheid);
            MessageBox.Show("De medicatie is met succes opgeslagen voor de patient!");

        }

    }
}
