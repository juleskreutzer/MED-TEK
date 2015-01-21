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
    public partial class Apotheek : Form
    {
        Connect verbinding;
        int medicatieID;
        public Apotheek(Connect _verbinding)
        {
            InitializeComponent();
            verbinding = _verbinding;
        }

        private void Apotheek_Load(object sender, EventArgs e)
        {
            refresh_data();
        }

        Select select = new Select();
        Miscellaneous overig = new Miscellaneous();
        private Update update = new Update();
        private void refresh_data()
        {
            //benodigde patiëntgegevens ophalen en weergeven
            var patientgegevens = select.Select_Patient_Apotheek(verbinding.patientID);
            var medicatiegegevens = select.Select_Medicatie(verbinding.patientID);
            var medicijngegevens = select.Select_Medicijn();

            int i = 0;
            int j = 0;
            int a = 0;
            int z = 0;

            for (i = 0; i < 1; ++i)
            {
                for (j = 0; j < patientgegevens.Count; ++j)
                {
                    Dictionary<string, object> row = patientgegevens[j];
                    tbVoorNamen.Text = (string) row["voornamen"];
                    tbAchternaam.Text = (string) row["achternaam"];
                    string date = (string) row["geboortedatum"];
                    dtpGeboorte.Text = date;
                    tbAdres.Text = (string) row["adres"];
                    pbPasfoto.Load(verbinding.pasfoto);
                }

                for (a = 0; a < medicatiegegevens.Count; ++a)
                {
                    Dictionary<string, object> row = medicatiegegevens[a];
                    tbGebruiksStart.Text = (string) row["gebruikstart"];
                    tbGebruiksEinde.Text = (string) row["gebruikeind"];
                    tbHoeveelheid.Text = (string) row["hoeveelheid"];
                    medicatieID = Convert.ToInt32(row["medicatieID"]);


                }

                for (z = 0; z < medicijngegevens.Count; ++z)
                {
                    Dictionary<string, object> row = medicijngegevens[z];
                    tbNaamMedicijn.Text = (string) row["naam"];
                    lbGebruikMedicijn.Text = (string) row["gebruik"];
                    lbBijwerkingenMedicijn.Text = (string) row["bijwerking"];

                    
                }

                if (cbOpgehaald.Checked)
                {
                    int actief = 1;
                    update.Update_Afspraak_actief(Convert.ToString(medicatieID), Convert.ToString(actief));
                    MessageBox.Show("Afspraak is geupdate.");
                }
                // Pasfoto van patient laten zien in picturebox
                pbPasfoto.Load(verbinding.pasfoto);
                // pasfoto passend maken voor picturebox
                pbPasfoto.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void cbOpgehaald_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
