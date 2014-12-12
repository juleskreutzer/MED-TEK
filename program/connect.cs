using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace $safeprojectname$
{
    class Connect
    {
        // Fields
        public MySqlConnection connection;
        private string server; // Hostname
        private string user; // Database user name
        private string password; // Database password
        private string database; // Database name
        private string prefix = "rhbj_";

        public string locatie;

        // Constructor
        public Connect()
        {
            Initialize();
        }

        public MySqlConnection Initialize()
        {
            server = "XXX";
            user = "XXX";
            password = "XXX";
            database = "XXX";

            string connectionstring;
            connectionstring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";

            return connection = new MySqlConnection(connectionstring);
        }
        //open connection to database
        public bool Open_Connection()
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
        private bool Close_Connection()
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

        public void Execute(string sql)
        {
            string query = sql;

            this.Open_Connection();

            if(this.Open_Connection() == true)
            {
                // Command opzetten voor het uitvoeren van de query
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Query uitvoeren, er wordt geen waarde terug gegeven
                cmd.ExecuteNonQuery();
                this.Close_Connection();
            }
        }

        public string login(string username, string password)
        {

            // SQL-statement opstellen
            string sql = "SELECT naam FROM " + prefix + "locatie, " + prefix + "login WHERE " + prefix + "login.username = '" + username + "' AND " + prefix + "login.password = '" + password + "' AND " + prefix + "login.locatieID = " + prefix + "locatie.locatieID";

            if(this.Open_Connection() == true)
            {
                // Command opzetten voor het uitvoeren van de query
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        StringBuilder sb = new StringBuilder();
                        while(reader.Read())
                        {
                            sb.Append(reader.GetString(0)).ToString();
                        }
                        locatie = sb.ToString();
                        return sb.ToString();

                    }
                }
                this.Close_Connection();
            }
            else
            {
                string result = "Kon geen verbinding maken met database!";
                return result;
            }
        }
    }
}
