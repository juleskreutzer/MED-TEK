﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    class Update
    {
        Connect verbinding = new Connect();
        string prefix = "rhbj_";

        public void Update_Patient(string voornamen, string achternaam, string geboortedatum, string bsn, string bloedgroep, string pasfoto, string email, string telefoon, string mobiel, string adres, string gemeente, string provincie, string pascode)
        {
            // Deze methode werkt de gegevens van de patient bij
            
        }

        public void Update_Medicijn(string naam, string gebruik, string bijwerking)
        {
            // Deze methode werkt de gegevens van een medicijn bij

        }

        public void Update_Medicatie(int medicatieID, int patientID, int medicijnID, string gebruiktstart, string gebruikeinde, string hoeveelheid)
        {
            // Deze methode werkt de gegevens van een medicatie bij

        }

        public void Update_Afspraak(string medicatieID, string patientID, string datum, string tijd, string actief)
        {
            // Deze methode werkt de gegevens van een afspraak bij

        }

        public void Update_Ziekte()
        {
            // Deze methode werkt een ziekte bij

        }

        public void Update_Ziekteoverzicht()
        {
            // Deze methode werkt een ziekteoverzicht bij

        }
    }
}
