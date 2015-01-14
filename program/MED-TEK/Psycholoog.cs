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
    public partial class Psycholoog : Form
    {
        Connect verbinding;
        public Psycholoog(Connect _verbinding)
        {
            InitializeComponent();
            verbinding = _verbinding;
        }

        Select select = new Select();
        Miscellaneous overig = new Miscellaneous();

        private void refresh_data()
        {
            var patientgegevens = select.Select_Patient_Auto(verbinding.patientID);
            var ziekteoverzicht = select.Select_Ziekteoverzicht(verbinding.patientID);

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
            }
        }
    }
}
