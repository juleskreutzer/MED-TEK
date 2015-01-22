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
        Select select = new Select();
        Miscellaneous overig = new Miscellaneous();

        public Doctor(Connect _verbinding)
        {
            InitializeComponent();
            verbinding = _verbinding;
            WindowState = FormWindowState.Maximized;
        }

        private void Doctor_Load(object sender, EventArgs e)
        {   
            // Custom format instellen voor dateTimePickers voor een juiste verwerking in database
            dtpGebruikEind.Format = DateTimePickerFormat.Custom;
            dtpGebruikEind.CustomFormat = "yyyy-MM-dd";
            dtpGebruikStart.Format = DateTimePickerFormat.Custom;
            dtpGebruikStart.CustomFormat = "yyyy-MM-dd";

            dtpAfspraak.Format = DateTimePickerFormat.Custom;
            dtpAfspraak.CustomFormat = "yyyy-MM-dd";

            refresh_data();
        }

        private void refresh_data()
        {
            var dataZiekteNaam = select.Select_Ziekte();
            var dataLocatie = select.Select_Locatie();
            var medicijnNaam = select.Select_Medicijn_Data(verbinding.patientID);

            for (int x = 0; x < 1; ++x)
            {
                for (int c = 0; c < 1; ++c)
                {
                    for (int j = 0; j < dataLocatie.Count; ++j)
                    {
                        Dictionary<string, object> row = dataLocatie[j];

                        cbLocAfspraak.Items.Add("ID " + row["locatieID"] + " - " + row["locatienaam"]);
                    }
                }

                
                for (int a = 0; a < medicijnNaam.Count; ++a)
                {
                    Dictionary<string, object> row = medicijnNaam[a];
                    cbMedicijn.Items.Add("ID " + row["medicijnID"] + " - " + row["naam"] + " - " + row["gebruik"] + " - " + row["bijwerking"]);
                }

                for (int b = 0; b < dataZiekteNaam.Count; ++b)
                {
                    Dictionary<string, object> row = dataZiekteNaam[b];

                    cbZiekte.Items.Add("ID " + row["ziekteID"] + " - " + row["naam"]);
                }
            }

            var patientgegevens = select.Select_Patient_Arts(verbinding.patientID);
            var ziekteoverzicht = select.Select_Ziekteoverzicht(verbinding.patientID);
            var medicatieoverzicht = select.Select_Medicatie(verbinding.patientID);
            var dataMedicijnNaam = select.Select_Medicijn();

            for (int i = 0; i < 1; ++i)
            {
                for (int j = 0; j < patientgegevens.Count; ++j)
                {
                    Dictionary<string, object> row = patientgegevens[j];
                    tbVoorNamen.Text = (string)row["voornamen"];
                    tbAchternaam.Text = (string)row["achternaam"];
                    lbPatientNaam.Text = (string) row["voornamen"] + " " + (string) row["achternaam"];
                    lblPatientNamen2.Text = (string) row["voornamen"] + " " + (string) row["achternaam"];
                    string date = (string)row["geboortedatum"];
                    dtpGeboorte.Text = date;
                    tbAdres.Text = (string)row["adres"];
                    tbBloedGroep.Text = (string) row["bloedgroep"];
                }

                for (int a = 0; a < ziekteoverzicht.Count; ++a)
                {
                    Dictionary<string, object> row = ziekteoverzicht[a];
                    lbZiektes.Items.Add(row["naam"]);
                }

                for (int x = 0; x < medicatieoverzicht.Count; ++x)
                {
                    Dictionary<string, object> row = medicatieoverzicht[x];
                    lbMedicatie.Items.Add(row["naam"]);
                    cbMedicatieAfspraak.Items.Add(row["naam"]);
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

        private void btnMedicatieToevoegen_Click_1(object sender, EventArgs e)
        {
            string medicijnIDstring = (string) cbMedicijn.SelectedItem;
            string hoeveelheid = tbHoeveelheid.Text;


            if (medicijnIDstring == "")
            {
                MessageBox.Show("Selecteer een medicijn voordat deze bewerking kan worden voltooid");
            }
            else if (hoeveelheid == "")
            {
                MessageBox.Show("Er moet een hoeveelheid worden opgegeven");
            }
            else
            {


                // ID opvragen van patient en medicijn voordat het opgeslagen wordt in database
                int medicijnID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", medicijnIDstring));
                string GebruikStart = dtpGebruikStart.Text;
                string GebruikEind = dtpGebruikEind.Text;

                insert.Insert_Medicatie(verbinding.patientID, medicijnID, GebruikStart, GebruikEind, hoeveelheid);
                MessageBox.Show("De medicatie is met succes opgeslagen voor de patient!");
            }
        }

        private void linkAfmelden_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            verbinding.patientID = 0; // int, dus null gaat niet
            verbinding.pasfoto = null;

            scan scan = new scan(verbinding);
            this.Hide();
            scan.Show();
        }

        private void linkProgramAfmelden_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            verbinding.locatie = null;
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void btnKoppelZiekte_Click(object sender, EventArgs e)
        {
            // Ziekte aan patient koppelen

            string ziekteIDstring = Convert.ToString(cbZiekte.SelectedItem);



            if (ziekteIDstring == "")
            {
                MessageBox.Show("Selecteer een ziekte");
            }
            else
            {
                int patientID = verbinding.patientID;
                int ziekteID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", ziekteIDstring));
                string symptomen = tbSymptomen.Text;

                insert.Insert_Ziekteoverzicht(ziekteID, patientID, symptomen);
                MessageBox.Show("De ziekte is met succes toegewezen aan de patient.");
            }
        }

        private void Doctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
