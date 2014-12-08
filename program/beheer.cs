using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public partial class beheer : Form
    {
        public beheer()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        // Fields

        // Onderstaande fields zijn een afkorting voor de tabel namen zoals ze in de database worden gebruikt
        private string patient = "rhbj_patient";

        connect verbinding = new connect();

        private void beheer_Load(object sender, EventArgs e)
        {
            if(!verbinding.OpenConnection())
            {
                MessageBox.Show("Er kon geen verbinding worden gemaakt met de database. Functies zijn beperkt beschikbaar.");
            }

        }

        private void btnResetUser_Click(object sender, EventArgs e)
        {

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
            // Waarden van de velden in een variabele zetten
            string voornaam = tbVoornamen.Text;
            string achternaam = tbAchternaam.Text;
            string DoB = Convert.ToString(dtpDoB.Text);
            int BSN = Convert.ToInt32(tbBSN.Text);
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
            if (voornaam == "")
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

            if(telefoon == "" && mobiel == "")
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
                /*
                verbinding.Insert_User(voornaam, achternaam, DoB, BSN, bloedgroep, pasfoto, email, telefoon, mobiel, adres, gemeente, provincie, pascode);
                MessageBox.Show("Het toevoegen van een nieuwe patient is succesvol gelukt!");
                verbinding = null;
                 */
            }
        }
    }
}
