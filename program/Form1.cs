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
    public partial class Form1 : Form
    {

        //Fields
        

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

        }

        // Fields
        connect verbinding = new connect();


        private void Form1_Load(object sender, EventArgs e)
        {
            if(!verbinding.OpenConnection())
            {
                MessageBox.Show("Er kon geen verbinding worden gemaakt met de database. Functies zijn beperkt beschikbaar.");
            }
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
        }
    }
}
