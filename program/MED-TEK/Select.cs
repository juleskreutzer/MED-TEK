using System;
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

        /*
        public List<string> Select_Patient_Arts(int patientID)
        {
            // Deze methode retourneerd de gegevens van een patient die belangrijk zijn voor een arts
           string sql = "SELECT * FROM " + prefix + "patient";
          
          
          

        }

        public List<> Select_Patient_Apotheek(int patientID)
        {
            // Deze methode retourneerd de gegevens van een patient die belangrijk zijn voor een arts
        }

        public List<> Select_Patient_Auto(int patientID)
        {
            // Deze methode retourneerd de gegevens van een patient die belangrijk zijn voor een ambulancebroeder

        }

        public List<> Select_Patient_Psycholoog(int patientID)
        {
            // Deze methode retourneerd de gegevens van een patient die belangrijk zijn voor een psycholoog

        }

        public List<> Select_Medicijn()
        {
            // Deze methode retourneerd alle medicijnen die zijn opgeslagen in de database

        }

        public List<> Select_Medicatie(int patientID)
        {
            // Deze methode retourneerd alle medicijnen die een patient gebruikt

        }

        public List<> Select_Afspraak(int actief)
        {
            // Deze methode retourneerd alle afspraken, afhankelijk of ze actief zijn of niet

        }

       **/

        public List<Dictionary<string, object>> Select_Ziekte()
        {
            // Deze methode retourneerd alle ziektes die opgeslagen zijn in de database
            string sql = "SELECT naam FROM " + prefix + "ziekte";
            
            var data = Connect.ExecuteQuery(sql);
            return data;
             

        }
        /*
        public List<> Select_Ziekteoverzicht(int patientID)
        {
            // Deze methode retourneerd alle ziektes die gekoppeld zijn aan een patient

        }
         * */
       
    }
}
