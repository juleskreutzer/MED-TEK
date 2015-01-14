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
        public Apotheek(Connect _verbinding)
        {
            InitializeComponent();
            verbinding = _verbinding;
        }

        private void Apotheek_Load(object sender, EventArgs e)
        {

        }

        Select select = new Select();
        Miscellaneous overig = new Miscellaneous();

        private void refresh_data()
        {
            //benodigde patiëntgegevens ophalen en weergeven
            var patientgegevens = select.Select_Patient_Auto(verbinding.patientID);
            var medicatiegegevens = select.Select_Medicatie(verbinding.patientID);

            int i = 0;
            int j = 0;
            int a = 0;

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
                }

                for (a = 0; a < medicatiegegevens.Count; ++a)
                {
                    Dictionary<string, object> row = medicatiegegevens[a];
                    
                }
            }
        }
    }
}
