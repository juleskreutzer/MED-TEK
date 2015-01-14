﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MED_TEK
{
    class Update
    {
        Connect verbinding = new Connect();
        string prefix = "rhbj_";

        public void Update_Patient(int patientID, string voornamen, string achternaam, string geboortedatum, string bsn, string bloedgroep, string pasfoto, string email, string telefoon, string mobiel, string adres, string gemeente, string provincie, string pascode)
        {
            // Deze methode werkt de gegevens van de patient bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "patient SET voornamen = '" + voornamen + "', achternaam = '" + achternaam +
                           "', geboortedatum = '" + geboortedatum + "', bsn = '" + bsn + "', bloedgroep = '" + bloedgroep +
                           "', pasfoto = '" + pasfoto + "', email = '" + email + "', mobiel = '" + mobiel + "', adres = '" +
                           adres + "', gemeente = '" + gemeente + "', provincie = '" + provincie + "', pascode = '" + pascode +
                           "' WHERE  patientID = '" + patientID + "'";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }

        public void Update_Medicijn(int medicijnID, string naam, string gebruik, string bijwerking)
        {
            // Deze methode werkt de gegevens van een medicijn bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "medicijn SET naam = '" + naam + "', gebruik = '" + gebruik +
                           "', bijwerking = '" + bijwerking + "' WHERE medicijnID = '" + medicijnID + "'";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }

        public void Update_Medicatie(int medicatieID, int patientID, int medicijnID, string gebruiktstart, string gebruikeinde, string hoeveelheid)
        {
            // Deze methode werkt de gegevens van een medicatie bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "medicatie SET medicatieID = " + medicatieID + ", patientID = " +
                           patientID + ", medicijnID = " + medicijnID + ", gebruikstart = " + gebruiktstart +
                           ", gebruikeinde = " + gebruikeinde + "";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }

        public void Update_Afspraak(string medicatieID, string patientID, string datum, string tijd, string actief)
        {
            // Deze methode werkt de gegevens van een afspraak bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "afspraak SET medicatieID = " + medicatieID + ", patientID = " +
                           patientID + ", datum = " + datum + ", tijd = " + tijd + ", actief = " + actief + "";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }

        public void Update_Afspraak_actief(string medicatieID, string actief)
        {
            string sql = "Update " + prefix + "medicatie SET actief = '" + actief + "' WHERE medicatieID = '" + medicatieID + "'";

            verbinding.Execute(sql);
        }

        public void Update_Ziekte(int ziekteID, string naam)
        {
            // Deze methode werkt een ziekte bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "ziekte SET naam = '" + naam + "' WHERE ziekteID = '" + ziekteID + "'";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }

        public void Update_Ziekteoverzicht(string ziekteID, string patientID)
        {
            // Deze methode werkt een ziekteoverzicht bij

            //string query aanmaken welke naar de database gaat
            string query = " UPDATE " + prefix + "ziekteoverzicht SET ziekteID = " + ziekteID + ", patientID = " +
                           patientID + "";

            //Nu de query uitvoering dmv execute
            verbinding.Execute(query);

        }

        public void Update_User(string username, string password)
        {
            // Deze methode werkt de gegevens van een gebruik bij om in te loggen bij Smart Patient

            string sql = "UPDATE " + prefix + "login SET password = '" + password + "' WHERE username = '" + username + "'";

            verbinding.Execute(sql);
        }
    }
}
