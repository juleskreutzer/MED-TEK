using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MED_TEK
{
    class Delete
    {

        Connect verbinding = new Connect();
        string prefix = "rhbj_";

        public void Delete_Medicijn(int medicijnID)
        {
            // Verwijder een medicijn wat gelijk is aan het opgegeven medicijnID

            string query = " DELETE FROM " + prefix + "medicijn WHERE medicijnID = '" + medicijnID + "'";

            verbinding.Execute(query);


        }

        public void Delete_Afspraak(int medicatieID, string patientID, string datum)
        {
            // verwijder een afspraak wat gelijk is aan het opgegeven medicatieID, patientID en datum

            string query = " DELETE FROM Afspraak" + prefix + "afspraak" + medicatieID + patientID + datum +
                           " WHERE medicatieID = " + medicatieID + " AND patientID = " + patientID + " AND datum = " +
                           datum;

            verbinding.Execute(query);

        }

        public void Delete_Ziekte(int ziekteID)
        {
            // Verwijder een ziekte wat gelijk is aan het opgegeven ziekteID

            string query = " DELETE FROM Ziekte " + prefix + "ziekte " + ziekteID + "WHERE ziekteID = " + ziekteID;

            verbinding.Execute(query);

        }

        public void Delete_Ziekteoverzicht(int ziekteID, string patientID)
        {
            // Verwijder een ziekteoverzicht wat gelijk is aan de opgegeven waarden

            string query = " DELETE FROM Ziekteoverzicht" + prefix + "ziekteoverzicht" + ziekteID + patientID +
                           " WHERE ziekteID = " + ziekteID + " AND patientID = " + patientID;

            verbinding.Execute(query);

        }

    }
}
