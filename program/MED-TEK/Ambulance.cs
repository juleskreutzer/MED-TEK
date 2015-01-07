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
    public partial class Ambulance : Form
    {
        public Ambulance()
        {
            InitializeComponent();
        }

        Select select = new Select();
        Connect verbinding = new Connect();

        private void refresh_data()
        {
            var patientgegevens = select.Select_Patient_Auto(verbinding.patientID);
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
