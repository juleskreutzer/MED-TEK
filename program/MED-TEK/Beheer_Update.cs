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
    public partial class Beheer_Update : Form
    {
        // Fields 
        Select select = new Select();
        Connect verbinding = new Connect();
        Update update = new Update();
        Miscellaneous overig = new Miscellaneous();

        int ziekteID;

        public Beheer_Update()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Beheer_Update_Load(object sender, EventArgs e)
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
            // Zorgen dat alle elementen van data worden voorzien, voor zover dat nodig is
            refresh();


        }

        public void refresh()
        {
            // form elementen van data voorzien.
            var ziekte = select.Select_Ziekte();

            for (int i = 0; i < 1; ++i)
            {
                for (int a = 0; a < ziekte.Count; ++a)
                {
                    Dictionary<string, object> row = ziekte[a];
                    cbZiekte.Items.Add("ID " + row["ziekteID"] + " - " + row["naam"] + ".");
                }
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            int pascode = Convert.ToInt32(tbCode.Text);
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
            }
        }

        private void btnChangeZiekte_Click(object sender, EventArgs e)
        {
            string data = Convert.ToString(cbZiekte.SelectedItem);
            ziekteID = Convert.ToInt32(overig.GetSubstringByString("ID ", " -", data));
            string ziekteNaam = overig.GetSubstringByString(" - ", ".", data);

            btnChangeZiekte.Enabled = false;
            tbZiekte.Text = ziekteNaam;

            // Veld en knop mogen nu gebruikt worden, dus enabled = true
            tbZiekte.Enabled = true;
            btnUpdateZiekte.Enabled = true;
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
            }

        }
    }
}
