using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace $safeprojectname$
{
    class connect
    {
        // Fields
        private MySqlConnection connection;
        private string server; // Hostname
        private string user; // Database user name
        private string password; // Database password
        private string database; // Database name
        private string prefix = "rhbj_";

        // Constructor
        public connect()
        {
            Initialize();
        }

        public void Initialize()
        {
            server = "92.48.206.233";
            user = "eu186781_test";
            password = "kreutzer";
            database = "eu186781_test";

            string connectionstring;
            connectionstring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionstring); 
        }
        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true; // verbinding gelukt
            }
            catch (MySqlException ex)
            {
                // Error handling voor verbinding met database
                switch (ex.Number)
                {
                    case 0:
                        // Verbinding met database kon niet tot stand worden gebracht
                        Console.WriteLine("Verbinding mislukt! Kan niet verbinden met server, klopt de host en database naam?");
                        break;

                    case 1045:
                        // Verbinding met database is mislukt, verkeerd wachtwoord of gebruikersnaam
                        Console.WriteLine("Verbinding mislukt! Kan niet verbinden met server, klopt de gebruikersnaam en het wachtwoord?");
                        break;
                }
                return false; // verbinding mislukt
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Sluiten van verbinding mislukt: " + ex);
                return false;
            }
        }

        //Insert statement
        public void Insert_User(string voornamen, string achternaam, string geboortedatum, string email, int telefoon, string adres, string gemeente, string provincie, int bsn, string pasfoto, string bloedgroep, long mobiel, string pascode)
        {
            string query = "INSERT INTO " + prefix + "patient (voornamen, achternaam, geboortedatum, email, telefoon, adres, gemeente, provincie, bsn, pasfoto, bloedgroep, mobiel, pascode) VALUES ('" + voornamen + "','" + achternaam + "','" + geboortedatum + "','" + email + "','" + telefoon + "','" + adres + "','" + gemeente + "','" + provincie + "','" + bsn + "','" + pasfoto + "','" + bloedgroep + "','" + mobiel + "','" + pascode + "')";

            if(this.OpenConnection() == true)
            {
                // commando opzeten voor het uitvoeren van de query
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Query uitvoeren en geen waarde terug geven, kijk maar naad VOID in -- public void Insert_User -- ;)
                cmd.ExecuteNonQuery();

                // Verbinding sluiten want die hebben we niet meer nodig.
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        
    }
}
