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
    public partial class Beheer_Overview : Form
    {
        public Beheer_Overview()
        {
            InitializeComponent();
        }

        private void Beheer_Overview_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(200, 200, 200);
        }


        // Onderstaande event handlers roepen een nieuw formulier aan. Afhankelijk van wat de gebruiker wilt doen
        // Er zijn 3 verschillende formulieren
        // Beheer_Insert -> Dit formulier maakt het mogelijk om gegevens toe te voegen in de database
        // Beheer_Update -> Dit formulier maakt het mogelijk om gegevens te wijzigen in de database
        // Beheer_Delete -> Dit formulier maakt het mogelijk om gegevens te verwijderen in de database
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Beheer_Insert insert = new Beheer_Insert();
            insert.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Beheer_Update update = new Beheer_Update();
            update.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Beheer_Delete delete = new Beheer_Delete();
            delete.Show();
        }
    }
}
