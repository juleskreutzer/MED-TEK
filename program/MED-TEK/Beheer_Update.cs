using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace MED_TEK
{
    public partial class Beheer_Update : Form
    {
        // Fields 
        Select select = new Select();
        Connect verbinding = new Connect();
        Update update = new Update();
        Miscellaneous overig = new Miscellaneous();

        string userpassword;

        int ziekteID;

        public Beheer_Update()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Beheer_Update_Load(object sender, EventArgs e)
        {
            // Zorgen dat alle elementen van data worden voorzien, voor zover dat nodig is
            refresh();

            // Format van DTP aanpassen zodat er geen fouten onstaan met verwerking van SQL
            dtpDoB.Format = DateTimePickerFormat.Custom;
            dtpDoB.CustomFormat = "yyyy-MM-dd";


        }

        public void refresh()
        {
            // alle textboxes van patientgegevens uitschakelen, totdat patient gegevens worden opgehaald.
            tbVoornamen.Enabled = false;
            tbAchternaam.Enabled = false;
            dtpDoB.Enabled = false;
            tbBsn.Enabled = false;
            tbBloedgroep.Enabled = false;
            tbPasfoto.Enabled = false;
            tbEmail.Enabled = false;
            tbMobiel.Enabled = false;
            tbTelefoon.Enabled = false;
            tbAdres.Enabled = false;
            tbGemeente.Enabled = false;
            tbProvincie.Enabled = false;
            tbPascode.Enabled = false;
            tbZiekte.Enabled = false;
            btnUpdateZiekte.Enabled = false;
            btnUpdatePatient.Enabled = false;
            tbMedicijnNaam.Enabled = false;
            tbGebruikMedicijn.Enabled = false;
            tbBijwerkingMedicijn.Enabled = false;
            btnUpdateMedicijn.Enabled = false;

            // Gebruiker aanpassen
            tbPwdNew.Enabled = false;
            tbPwdNewRepeat.Enabled = false;
            tbPwdOld.Enabled = false;
            btnUpdatePwd.Enabled = false;

            // form elementen van data voorzien.
            var ziekte = select.Select_Ziekte();
            var medicijn = select.Select_Medicijn();
            var user = select.Select_User_Name();

            for (int i = 0; i < 1; ++i)
            {
                for (int a = 0; a < ziekte.Count; ++a)
                {
                    Dictionary<string, object> row = ziekte[a];
                    cbZiekte.Items.Add("ID " + row["ziekteID"] + " - " + row["naam"] + ".");
                }
                for (int b = 0; b < medicijn.Count; ++b)
                {
                    Dictionary<string, object> row = medicijn[b];
                    cbSelectMedicijn.Items.Add("ID " + row["medicijnID"] + " - " + row["naam"] + ".");
                }
                for(int c = 0; c < user.Count; ++c)
                {
                    Dictionary<string, object> row = user[c];
                    cbSelectUser.Items.Add(row["username"]);
                }
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            string pascode = tbCode.Text;
            var data = select.Select_Patient_All(pascode);

            for (int i = 0; i < data.Count; ++i)
            {
                Dictionary<string, object> row = data[i];
                tbVoornamen.Text = row["voornamen"].ToString();
                tbAchternaam.Text = row["achternaam"].ToString();
                dtpDoB.Text = row["geboortedatum"].ToString();
                tbBsn.Text = row["bsn"].ToString();
                tbBloedgroep.Text = row["bloedgroep"].ToString();
                tbPasfoto.Text = row["pasfoto"].ToString();
                tbEmail.Text = row["email"].ToString();
                tbMobiel.Text = row["mobiel"].ToString();
                tbTelefoon.Text = row["telefoon"].ToString();
                tbAdres.Text = row["adres"].ToString();
                tbGemeente.Text = row["gemeente"].ToString();
                tbProvincie.Text = row["provincie"].ToString();
                tbPascode.Text = row["pascode"].ToString();

                verbinding.patientID = Convert.ToInt32(row["patientID"]);

                tbVoornamen.Enabled = true;
                tbAchternaam.Enabled = true;
                dtpDoB.Enabled = true;
                tbBsn.Enabled = true;
                tbBloedgroep.Enabled = true;
                tbPasfoto.Enabled = true;
                tbEmail.Enabled = true;
                tbMobiel.Enabled = true;
                tbTelefoon.Enabled = true;
                tbAdres.Enabled = true;
                tbGemeente.Enabled = true;
                tbProvincie.Enabled = true;
                tbPascode.Enabled = true;

                tbCode.Enabled = false;
                btnActivate.Enabled = false;
                btnUpdatePatient.Enabled = true;

            }

        }

        private void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            int error = 0;

            string voornamen = tbVoornamen.Text;
            string achternaam = tbAchternaam.Text;
            string DoB = dtpDoB.Text;
            string bsn = tbBsn.Text;
            string bloedgroep = tbBloedgroep.Text;
            string pasfoto = tbPasfoto.Text;
            string email = tbEmail.Text;
            string mobiel = tbMobiel.Text;
            string telefoon = tbTelefoon.Text;
            string adres = tbAdres.Text;
            string gemeente = tbGemeente.Text;
            string provincie = tbProvincie.Text;
            string pascode = tbPascode.Text;

            if (voornamen == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om de voornamen van de patient op te geven!");
            }
            if (achternaam == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om de achternaam van de patient op te gegeven!");
            }
            if (DoB == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht de geboortedatum van de patient op te geven!");
            }
            if (Convert.ToString(bsn) == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om het BSN nummer van de patient op te geven!");
            }
            if(bloedgroep == "" )
            {
                ++error;
                MessageBox.Show("Het is verplicht om de bloedgroep van de patient op te geven!");
            }
            if(pasfoto == "" )
            {
                ++error;
                MessageBox.Show("Het is verplicht om een link naar de pasfoto op te geven!");
            }
            if(email == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om een email adres van de patient op te geven!");
            }
            if (mobiel == "" || telefoon == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om een mobielnummer of telefoonnummer van de patient op te geven!");
            }
            if (adres == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om het adres van de patient op te geven!");
            }
            if(gemeente == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om de gemeente op te geven waar de patient in woont!");
            }
            if (provincie == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om de provincie op te geven waar de patient in woont!");
            }
            if (Convert.ToString(pascode) == "")
            {
                ++error;
                MessageBox.Show("Het is verplicht om de pascode van de patient op te geven!");
            }

            if (error == 0)
            {
                update.Update_Patient(verbinding.patientID, voornamen, achternaam, DoB, bsn, bloedgroep, pasfoto, email, telefoon, mobiel, adres, gemeente, provincie, pascode);
                MessageBox.Show("De patientgegevens zijn succesvol bijgewerkt!");

                refresh();
            }
        }

        private void btnChangeZiekte_Click(object sender, EventArgs e)
        {
            if (cbZiekte.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een ziekte voordat u kunt verder gaan.");
            }
            else
            {
                string data = Convert.ToString(cbZiekte.SelectedItem);
                ziekteID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", data));
                string ziekteNaam = overig.GetSubstringByString(" - ", ".", data);

                btnChangeZiekte.Enabled = false;
                cbZiekte.Enabled = false;
                tbZiekte.Text = ziekteNaam;

                // Veld en knop mogen nu gebruikt worden, dus enabled = true
                tbZiekte.Enabled = true;
                btnUpdateZiekte.Enabled = true;
            }
        }

        private void btnUpdateZiekte_Click(object sender, EventArgs e)
        {
            string ziekte = tbZiekte.Text;
            
            int error = 0;
            
            if(ziekte == "")
            {
                ++error;
                MessageBox.Show("Voer een naam van de ziekte in!");
            }

            if (error == 0)
            {
                update.Update_Ziekte(ziekteID, ziekte);
                MessageBox.Show("De ziekte is succesvol bijgewerk!");

                refresh();

                cbZiekte.Enabled = true;
                btnChangeZiekte.Enabled = true;

                tbZiekte.Enabled = false;
                btnUpdateZiekte.Enabled = false;
            }

        }

        private void btnChangeMedicijn_Click(object sender, EventArgs e)
        {
            if (cbSelectMedicijn.SelectedItem == null)
            {
                MessageBox.Show("Selecteer eerst een medicijn voordat deze bewerkt kan worden!");
            }
            else
            {
                string data = Convert.ToString(cbSelectMedicijn.SelectedItem);
                string medicijnID = overig.GetSubstringByString("ID ", " -", data);
                cbSelectMedicijn.Enabled = false;
                btnChangeMedicijn.Enabled = false;

                // Elementen voor bewerken medicijn activeren
                tbMedicijnNaam.Enabled = true;
                tbBijwerkingMedicijn.Enabled = true;
                tbGebruikMedicijn.Enabled = true;
                btnUpdateMedicijn.Enabled = true;

                // We weten het medicijn ID, juiste elementen vullen met gegevens
                var medicijn = select.Select_Medicijn_Data(Convert.ToInt32(medicijnID));

                for (int i = 0; i < medicijn.Count; ++i)
                {
                    Dictionary<string, object> row = medicijn[i];
                    tbMedicijnNaam.Text = row["naam"].ToString();
                    tbGebruikMedicijn.Text = row["gebruik"].ToString();
                    tbBijwerkingMedicijn.Text = row["bijwerking"].ToString();
                }
            }
        }

        private void btnUpdateMedicijn_Click(object sender, EventArgs e)
        {
            string naam = tbMedicijnNaam.Text;
            string gebruik = tbGebruikMedicijn.Text;
            string bijwerking = tbBijwerkingMedicijn.Text;

            int error = 0;

            if(naam == "")
            {
                ++error;
                MessageBox.Show("Geef een naam op van de medicijn!");
            }
            if (gebruik == "")
            {
                ++error;
                MessageBox.Show("Geef het gebruik van het medicijn op!");
            }
            if (bijwerking == "")
            {
                ++error;
                MessageBox.Show("Geef een bijwerking voor het medicijn op!");
            }

            if(error == 0)
            {
                int medicijnID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", cbSelectMedicijn.Text));
                update.Update_Medicijn(medicijnID, naam, gebruik, bijwerking);
                MessageBox.Show("Medicijn succesvol aangepast!");

                refresh();
            }
        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            if (cbSelectUser.SelectedItem != null)
            {
                tbUsername.Text = cbSelectUser.Text;
                cbSelectUser.Enabled = false;
                btnChangeUser.Enabled = false;

                tbUsername.Enabled = true;
                tbPwdNew.Enabled = true;
                tbPwdNewRepeat.Enabled = true;
                tbPwdOld.Enabled = true;
                btnUpdatePwd.Enabled = true;

                var data = select.Select_User_Password(Convert.ToString(cbSelectUser.SelectedItem));

                for(int i = 0; i < data.Count; ++i)
                {
                    Dictionary<string, object> row = data[i];
                    userpassword = (string)(row["password"]);
                }
            }
        }

        private void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            string oldpassword = overig.versleutel(tbPwdOld.Text);
            string newPwd = overig.versleutel(tbPwdNew.Text);
            string newPwdCheck = overig.versleutel(tbPwdNewRepeat.Text);
            string username = tbUsername.Text;

            int error = 0;

            if (oldpassword == "")
            {
                ++error;
                MessageBox.Show("Vul het oude wachtwoord in!");
            }
            if (oldpassword != userpassword)
            {
                ++error;
                MessageBox.Show("Het oude wachtwoord is onjuist.");
            }
            if(newPwd == "")
            {
                ++error;
                MessageBox.Show("Vul een nieuw wachtwoord in!");
            }
            if(newPwdCheck == "")
            {
                ++error;
                MessageBox.Show("Herhaal het wachtwoord opnieuw.");
            }
            if (newPwd != newPwdCheck)
            {
                ++error;
                MessageBox.Show("Beide nieuwe wachtwoorden komen niet overeen.");
            }

            if(error == 0)
            {
                string password = newPwd;
                update.Update_User(username, password);
                MessageBox.Show("Het wachtwoord is succesvol gewijzigd!");

                refresh();
            }
        }

        private void tbPascodeMedicatie_TextChanged(object sender, EventArgs e)
        {
            if(tbPascodeMedicatie.TextLength == 8)
            {
                var medicatie = select.Select_PatientID(Convert.ToString(tbPascodeMedicatie.Text);

                for(int i = 0; i < medicatie.Count; ++i)
                {

                }
            }
        }

    }
}
