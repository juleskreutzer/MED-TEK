using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; // Dit wordt gebruikt om gegevens te versleutelen

namespace $safeprojectname$
{
    public partial class Login : Form
    {
        Connect verbinding = new Connect();
        Miscellaneous overig = new Miscellaneous();
        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; 
        }

        private void lblForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Neem contact op met de systeem beheerder.");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string login = verbinding.login(username, password);

            if(login != "")
            {
               // De methode login() geeft een locatie terug
               // Controleer bij welke locatie wordt aangemeld en open het bijbehorende formulier
                if (login == "doctor")
                {
                    // Open formulier van doctor
                    this.Hide();
                    Doctor doctor = new Doctor();
                    doctor.Show();
                }
                else if (login == "ambulance")
                {
                    // Open formulier van ambulance
                    this.Hide();
                    Ambulance ambulance = new Ambulance();
                    ambulance.Show();
                }
                else if (login == "apotheek")
                {
                    // Open formulier van apotheek
                    this.Hide();
                    Apotheek apotheek = new Apotheek();
                    apotheek.Show();
                }
                else if(login == "psycholoog")
                {
                    // Open formulier van psycholoog
                    this.Hide();
                    Psycholoog psycholoog = new Psycholoog();
                    psycholoog.Show();
                }
                else if(login == "beheer")
                {
                    // Open formulier van beheer   
                    this.Hide();
                    beheer beheer = new beheer();
                    beheer.Show();
                }
            }
            else
            {
                tbUsername.Text = "";
                tbPassword.Text = "";
                MessageBox.Show("Het inloggen is mislukt. Controleer uw gebruikersnaam en wachtwoord. Wanneer dit probleem zich blijf voordoen, neem dan contact op met uw systeem beheerder.");
            }
        }
    }
}
