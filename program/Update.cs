using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class Update
    {
        Connect verbinding = new Connect();
        string prefix = "rhbj_";

        public void Update_Patient(string voornamen, string achternaam, string geboortedatum, string bsn, string bloedgroep, string pasfoto, string email, string telefoon, string mobiel, string adres, string gemeente, string provincie, string pascode)
        {
            // Deze methode werkt de gegevens van de patient bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "patient (voornamen, achternaam, geboortedatum, bsn, bloedgroep, pasfoto, email, telefoon, mobiel, adres, gemeente, provincie, pascode) VALUES ('" + voornamen + "','" + achternaam + "','" + geboortedatum + "','" + bsn + "','" + bloedgroep + "','" + pasfoto + "','" + email + "','" + telefoon + "','" + mobiel + "','" + adres + "','" + gemeente + "','" + provincie + "','" + pascode + "')";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);
            
        }

        public void Update_Medicijn(string naam, string gebruik, string bijwerking)
        {
            // Deze methode werkt de gegevens van een medicijn bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "medicijn (naam, gebruik, bijwerking) VALUES ('" + naam + "','" + gebruik + "','" + bijwerking + "')";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }

        public void Update_Medicatie(int medicatieID, int patientID, int medicijnID, string gebruiktstart, string gebruikeinde, string hoeveelheid)
        {
            // Deze methode werkt de gegevens van een medicatie bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "medicatie (medicatieID, patientID, medicijnID, gebruikstart, gebruikeinde, hoeveelheid) VALUES ('" + medicatieID + "','" + patientID + "','" + medicijnID + "','" + gebruiktstart + "','" + gebruikeinde + "','" + hoeveelheid + "')";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }

        public void Update_Afspraak(string medicatieID, string patientID, string datum, string tijd, string actief)
        {
            // Deze methode werkt de gegevens van een afspraak bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "afspraak (medicatieID, patientID, datum, tijd, actief) VALUES ('" + medicatieID + "','" + patientID + "','" + datum + "','" + tijd + "','" + actief + "')";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }

        public void Update_Ziekte(string naam)
        {
            // Deze methode werkt een ziekte bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "ziekte (naam) VALUES ('" + naam + "')";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }

        public void Update_Ziekteoverzicht(string ziekteID, string patientID)
        {
            // Deze methode werkt een ziekteoverzicht bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "ziekteoverzicht (ziekteID, patientID) VALUES ('" + ziekteID + "','" + patientID + "')";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }
    }
}
