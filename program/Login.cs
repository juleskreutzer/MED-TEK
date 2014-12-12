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
    public partial class Login : Form
    {
        Connect verbinding = new Connect();
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
                }
                else if (login == "ambulance")
                {
                    // Open formulier van ambulance
                }
                else if (login == "apotheek")
                {
                    // Open formulier van apotheek
                }
                else if(login == "psycholoog")
                {
                    // Open formulier van psycholoog
                }
            }
            else
            {
                MessageBox.Show("Het inloggen is mislukt. Controleer uw gebruikersnaam en wachtwoord. Wanneer dit probleem zich blijf voordoen, neem dan contact op met uw systeem beheerder.");
            }
        }
    }
}
