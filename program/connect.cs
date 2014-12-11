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

        // Constructor
        public Connect()
        {
            Initialize();
        }

        public MySqlConnection Initialize()
        {
            server = "+++";
            user = "+++";
            password = "+++";
            database = "+++";

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

            if(this.Open_Connection() == true)
            {
                // Command opzetten voor het uitvoeren van de query
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Query uitvoeren, er wordt geen waarde terug gegeven
                cmd.ExecuteNonQuery();
            }
        }

        public bool login(string username, string password)
        {

            // SQL-statement opstellen
            string sql = "SELECT username, password FROM " + prefix + "login WHERE username = '" + username + "' AND password = '" + password + "'"; 

            if(this.Open_Connection() == true)
            {
                // Command opzetten voor het uitvoeren van de query
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                MySqlDataReader dr = cmd.ExecuteReader();
                int count = 0;
                while(dr.Read())
                {
                    count = count + 1;
                }

                if(count == 1)
                {
                    // Login is gelukt!
                    return true;
                }
                else
                {
                    // Login is niet gelukt!
                    return false;
                    this.Close_Connection();
                }    
            }
            else
            {
                return false;
            }

        }
    }
}
