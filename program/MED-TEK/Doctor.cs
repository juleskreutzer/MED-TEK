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
    public partial class Doctor : Form
    {
        Connect verbinding;
        Insert insert = new Insert();
        public Doctor(Connect _verbinding)
        {
            InitializeComponent();
            verbinding = _verbinding;
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            var dataLocatie = select.Select_Locatie();
            var medicijnNaam = select.Select_Medicijn_Data(verbinding.patientID);

            int b = 0;
            for (b = 0; b < 1; ++b)
            {
                for (int j = 0; j < dataLocatie.Count; ++j)
                {
                    Dictionary<string, object> row = dataLocatie[j];

                    cbLocAfspraak.Items.Add("ID " + row["locatieID"] + " - " + row["locatienaam"]);
                }
            }

            var patientgegevens = select.Select_Patient_Arts(verbinding.patientID);
            var dataPatientNaam = select.Select_Patient_Naam();
            var dataZiekteNaam = select.Select_Ziekte();

            int a = 0;
            for (a = 0; a < 1; ++a)
            {
                for (int j = 0; j < patientgegevens.Count; ++j)
                {
                    Dictionary<string, object> row = patientgegevens[j];
                    cbPatientMedicatie.Items.Add("ID " + row["patientID"] + " - " + row["voornamen"] + " " + row["achternaam"]);

                }
                for (int j = 0; j < medicijnNaam.Count; ++j)
                {
                    Dictionary<string, object> row = medicijnNaam[j];
                    cbMedicijn.Items.Add("ID " + row["medicijnID"] + " - " + row["naam"] + " - " + row["gebruik"] + " - " + row["bijwerking"]);
                }
                for (int i = 0; i < dataPatientNaam.Count; ++i)
                {
                    Dictionary<string, object> row = dataPatientNaam[i];

                    cbPatient.Items.Add("ID " + row["patientID"] + " - " + row["voornamen"] + " " + row["achternaam"]);
                    cbPatientMedicatie.Items.Add("ID " + row["patientID"] + " - " + row["voornamen"] + " " + row["achternaam"]);
                }

                for (int j = 0; j < dataZiekteNaam.Count; ++j)
                {
                    Dictionary<string, object> row = dataZiekteNaam[j];

                    cbZiekte.Items.Add("ID " + row["ziekteID"] + " - " + row["naam"]);
                }
            }
            
            refresh_data();
        }

        Select select = new Select();
        Miscellaneous overig = new Miscellaneous();
        private void refresh_data()
        {
            var patientgegevens = select.Select_Patient_Arts(verbinding.patientID);
            var ziekteoverzicht = select.Select_Ziekteoverzicht(verbinding.patientID);
            var medicatieoverzicht = select.Select_Medicatie(verbinding.patientID);
            var dataMedicijnNaam = select.Select_Medicijn();
            

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
                    tbVoorNamen.Text = (string)row["voornamen"];
                    tbAchternaam.Text = (string)row["achternaam"];
                    string date = (string)row["geboortedatum"];
                    dtpGeboorte.Text = date;
                    tbAdres.Text = (string)row["adres"];
                    tbBloedGroep.Text = (string) row["bloedgroep"];
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

                for (int c = 0; c < dataMedicijnNaam.Count; ++c)
                {
                    Dictionary<string, object> row = dataMedicijnNaam[c];

                    cbMedicijn.Items.Add("ID " + row["medicijnID"] + " - " + row["naam"]);
                }

                

                // Pasfoto van patient laten zien in picturebox
                pbPasfoto.Load(verbinding.pasfoto);
                // pasfoto passend maken voor picturebox
                pbPasfoto.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnMedicatieToevoegen_Click(object sender, EventArgs e)
        {
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

        private void cbActief_CheckedChanged(object sender, EventArgs e)
        {

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

        private void btnClearAfspraak_Click(object sender, EventArgs e)
        {
            cbLocAfspraak.Text = "";
            dtpTijd.Text = "00:00";
        }

        private void linkAfmelden_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void cbLocAfspraak_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddZiekte_Click(object sender, EventArgs e)
        {
            // Ziekte toevoegen aan database
            string naam = tbZiekte.Text;

            if (naam == "")
            {
                MessageBox.Show("Er moet een naam van de ziekte worden opgegeven voordat deze kan worden toegevoegd.");
            }
            else
            {
                insert.Insert_Ziekte(naam);
                tbZiekte.Text = "";
                MessageBox.Show("De ziekte is succesvol toegevoegd!");
            }

            refresh_data();
        }

        private void btnResetZiekte_Click(object sender, EventArgs e)
        {
            // tbZiekte leeg maken
            tbZiekte.Text = "";
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
            else if (ziekteIDstring == "")
            {
                MessageBox.Show("Selecteer een ziekte");
            }
            else
            {
                int patientID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", patientIDstring));
                int ziekteID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", ziekteIDstring));
                string symptomen = tbSymptomen.Text;

                insert.Insert_Ziekteoverzicht(ziekteID, patientID, symptomen);
                MessageBox.Show("De ziekte is met succes toegewezen aan de patient.");
            }

        }
    }
}
