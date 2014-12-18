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
    public partial class scan : Form
    {

        //Fields
        string prefix = "rhbj_";

        public scan()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            webBrowser1.Navigate("http://www.fontys.nl");

           

        }

        // Fields
        Connect verbinding = new Connect();


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbScan.Enabled = true;
            tbScan.Text = "";
        }

        private void beheer_Click(object sender, EventArgs e)
        {
            

            // Nieuw formulier aanmaken voor beheer van programma
            Beheer_Insert admin = new Beheer_Insert();

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tbScan.Text.Length == 10)
            {
                timer1.Stop();
                tbScan.Enabled = false;
                // Alle tekens zijn Ingevoerd, methode aanroepen om de nodige gegevens erbij op te zoeken
                string pascode = tbScan.Text;
                string sql = "SELECT patientID, pasfoto FROM " + prefix + "patient WHERE pascode = '" + pascode + "'"; 
                List<string> result = verbinding.Execute_values(sql);
                MessageBox.Show("Waarde 1 (positie 0) van de list: " + result[0] + "\nWaarde 2 (positie 1) van de lijst: " + result[1]);


            }

        }
    }
}
