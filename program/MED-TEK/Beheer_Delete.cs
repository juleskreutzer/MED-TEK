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
    public partial class Beheer_Delete : Form
    {
        Select select = new Select();
        Connect verbinding = new Connect();

        public Beheer_Delete()
        {
            InitializeComponent();
        }

        private void Beheer_Delete_Load(object sender, EventArgs e)
        {
            cbSelecteerZiektePatient.Enabled = false;
            btnVerwijderZiektePatient.Enabled = false;

            // Gegevens in formulier verversen
            refresh();

        }

        private void refresh()
        {
            var medicijnen = select.Select_Medicijn();
            var ziekte = select.Select_Ziekte();
            var afspraak = select.Select_Afspraak_All();

            for(int i = 0; i < 1; ++i)
            {
                for(int a = 0; a < medicijnen.Count; ++a)
                {
                    Dictionary<string, object> row = medicijnen[a];
                    lbOverzichtMedicijnen.Items.Add(row["naam"]);
                    cbSelectMedicijn.Items.Add("ID " + row["medicijnID"] + " - " + row["naam"]);
                }
                for(int b = 0; b < ziekte.Count; ++b)
                {
                    Dictionary<string, object> row = ziekte[b];
                    lbOverzichtZiekte.Items.Add(row["naam"]);
                    cbSelectZiekte.Items.Add("ID " + row["ziekteID"] + " - " + row["naam"]);
                }
                for(int c = 0; c < afspraak.Count; ++c)
                {
                    Dictionary<string, object> row = afspraak[c];
                    cbSelectAfspraak.Items.Add("ID " + row["medicatieID"] + " - " + row["voornamen"] + " " + row["achternaam"]);
                }
            }
        }
    }
}
