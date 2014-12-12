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

namespace $safeprojectname$
{
    public partial class scan : Form
    {

        //Fields
        

        public scan()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

        }

        // Fields
        Connect verbinding = new Connect();


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void beheer_Click(object sender, EventArgs e)
        {
            

            // Nieuw formulier aanmaken voor beheer van programma
            beheer admin = new beheer();

            // Formulier tonen
            admin.Show();

            // Huidig venster sluiten
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            string result = verbinding.login(username, password);

            if(result != "")
            {
                MessageBox.Show("Login succesvol! Locatie: " + result);
            }
            else
            {
                MessageBox.Show("Login niet gelukt!");
            }
        }
    }
}
