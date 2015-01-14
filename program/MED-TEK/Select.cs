﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace MED_TEK
{
    class Select
    {
        
        // Instantie aanmaken voor verbinding met database
        Connect verbinding = new Connect();
        // Elke databasetabel heeft een prefix
        string prefix = "rhbj_";

        public List<Dictionary<string, object>> Select_Patient_Naam()
        {
            string sql = "SELECT patientID, voornamen, achternaam FROM " + prefix + "patient";

            // var wilt zeggen dat C# zelf het juiste type van de variabele zoekt
            // ExecuteQuery is een static class binnen de Connect klasse
            // ExecuteQuery moet dus op een andere manier worden aangeroepen
            var data = Connect.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_Patient_Arts(int patientID)
        {
            // Deze methode retourneerd de gegevens van een patient die belangrijk zijn voor een arts
            string sql = "SELECT * FROM " + prefix + "patient";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_Patient_Apotheek(int patientID)
        {
            // Deze methode retourneerd de gegevens van een patient die belangrijk zijn voor een arts
            string sql = "";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_Patient_Auto(int patientID)
        {
            // Deze methode retourneerd de gegevens van een patient die belangrijk zijn voor een ambulancebroeder
            string sql = "SELECT voornamen, achternaam, geboortedatum, bloedgroep, pasfoto FROM " + prefix + "patient WHERE patientID = " + patientID;

            var data = Connect.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_Patient_Psycholoog(int patientID)
        {
            // Deze methode retourneerd de gegevens van een patient die belangrijk zijn voor een psycholoog
            string sql = "";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_Patient_All(string pascode)
        {
            // Deze methode retourneerd alle patientgegevens. Enkel gebruiken in het beheer gedeelte!
            string sql = "SELECT * FROM " + prefix + "patient WHERE pascode = '" + pascode + "'";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_PatientID(string pascode)
        {
            string sql = "SELECT patientID FROM " + prefix + "patient WHERE pascode = '" + pascode + "'";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_Medicijn()
        {
            // Deze methode retourneerd alle medicijnen die zijn opgeslagen in de database
            string sql = "SELECT medicijnID, naam FROM " + prefix + "medicijn ORDER BY naam ASC";

            var data = Connect.ExecuteQuery(sql);
            return data;

        }

        public List<Dictionary<string, object>> Select_Medicijn_Data(int medicijnID)
        {
            string sql = "SELECT naam, gebruik, bijwerking FROM " + prefix + "medicijn WHERE medicijnID = '" + medicijnID + "'";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }


        public List<Dictionary<string, object>> Select_Medicatie(int patientID)
        {
            // Deze methode retourneerd alle medicijnen die een patient gebruikt

            string sql = "SELECT " + prefix + "medicijn.naam FROM " + prefix + "medicijn, " + prefix + "medicatie WHERE  " + prefix + "medicatie.medicatieID = " + prefix + "medicijn.medicijnID AND " + prefix + "medicatie.patientID = '" + patientID + "'";

            var data = Connect.ExecuteQuery(sql);
            return data;

        }

        public List<Dictionary<string, object>> Select_Medicatie_All()
        {
            // Deze methode retourneerd alle medicijnen voor alle patienten

            string sql = "SELECT '" + prefix + "medicatie.medicatieID', '" + prefix + "patient.voornamen', '" + prefix + "patient.achternaam', '" + prefix + "medicijn.naam' FROM " + prefix + "patient, " + prefix + "medicijn WHERE '" + prefix + "medicatie.medicijnID' = '" + prefix + "medicijn.medicijnID' AND '" + prefix + "medicatie.patientID' = '" + prefix + "patient.patientID'";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_Afspraak(int actief)
        {
            // Deze methode retourneerd alle afspraken, afhankelijk of ze actief zijn of niet

            string sql = "SELECT locatie.naam, medicatie.naam, afspraak.datum, afspraak.tijd, afspraak.actief FROM " + prefix + "afspraak, " + prefix + "locatie, " + prefix + "medicatie WHERE afspraak.medicatieID = medicatie.medicatieID AND afspraak.locatieID = locatie.locatieID";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }


        public List<Dictionary<string, object>> Select_Ziekte()
        {
            // Deze methode retourneerd alle ziektes die opgeslagen zijn in de database
            string sql = "SELECT ziekteID, naam FROM " + prefix + "ziekte ORDER BY naam ASC";
            
            var data = Connect.ExecuteQuery(sql);
            return data;
             

        }


        public List<Dictionary<string, object>> Select_Ziekteoverzicht(int patientID)
        {
            // Deze methode retourneerd alle ziektes die gekoppeld zijn aan een patient
            string sql = "SELECT " + prefix + "ziekte.naam FROM " + prefix + "ziekte, " + prefix + "ziekteoverzicht WHERE " + prefix + "ziekteoverzicht.ziekteID = " + prefix + "ziekte.ziekteID AND " + prefix + "ziekteoverzicht.patientID = '" + patientID + "'";

            var data = Connect.ExecuteQuery(sql);
            return data;

        }

        public List<Dictionary<string, object>> Select_Locatie()
        {
            // Deze methode retourneerd een lijst van alle locaties in de database met bijbehorende ID
            string sql = "SELECT * FROM " + prefix + "locatie";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_User_Name()
        {
            // Deze methode retourneerd een lijst van alle gebruikersnamen voor het inloggen bij Smart Patient
            string sql = "SELECT username FROM " + prefix + "login";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_User_Password(string username)
        {
            string sql = "SELECT password FROM " + prefix + "login WHERE username = '" + username + "'";

            var data = Connect.ExecuteQuery(sql);
            return data;
        }
       
    }
}
