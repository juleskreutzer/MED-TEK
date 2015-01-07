using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MED_TEK
{
    public partial class Ambulance : Form
    {
        Connect verbinding;
        public Ambulance(Connect _verbinding)
        {
            InitializeComponent();
            verbinding = _verbinding;

            refresh_data();
        }

        Select select = new Select();
        Miscellaneous overig = new Miscellaneous();

        private void refresh_data()
        {
            // Benodigde patientgegevens voor ambulance ophalen en weergeven
            var patientgegevens = select.Select_Patient_Auto(verbinding.patientID);
            int i = 0;
            for (i = 0; i < patientgegevens.Count; ++i)
            {
                Dictionary<string, object> row = patientgegevens[i];
                tbVoornamen.Text = (string)row["voornamen"];
                tbAchternaam.Text = (string)row["achternaam"];
                tbBloedgroep.Text = (string)row["bloedgroep"];
                string date = (string)row["geboortedatum"];
                dtpDoB.Text = date;
            }

            // Pasfoto van patient laten zien in picturebox
            pbPasfoto.Load(verbinding.pasfoto);
            // pasfoto passend maken voor picturebox
            pbPasfoto.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Ambulance_Load(object sender, EventArgs e)
        {
            tbVoornamen.Enabled = false;
            tbAchternaam.Enabled = false;
            tbBloedgroep.Enabled = false;
            dtpDoB.Enabled = false;
            pbPasfoto.Enabled = false;
            lbZiektes.Enabled = false;
            lbMedicatie.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 255, 255);
        }
    }
}
