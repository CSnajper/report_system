using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Add MySql Library
using MySql.Data.MySqlClient;

namespace Zgloszenia
{
    class DBConnect
    {
        private MySqlConnection connection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        public static void SetDataBase(string _server, string _database, string _uid, string _password)
        {
            server = _server;
            database = _database;
            uid = _uid;
            password = _password;
        }

        public bool TworzStruktureTabel()
        {
            Konfiguracja_1.AktualnyEtap(1);
            if(this.OpenConnection() == true)
            {
                Konfiguracja_1.AktualnyEtap(2);

                //tworzenie tabeli uzytkownicy
                string query_uzytwkonicy = String.Format("CREATE TABLE IF NOT EXISTS zgloszenia_uzytkownicy " +
                    "(`id` INT(4) NOT NULL AUTO_INCREMENT, `login` VARCHAR(48) NOT NULL, `haslo` VARCHAR(24) NOT NULL, " + 
                    "`poziom` INT(3) NOT NULL DEFAULT 1, rozpatrzone_zgloszenia INT(6) DEFAULT 0," + 
                    "czas_online INT(9) DEFAULT 0, PRIMARY KEY (`id`), UNIQUE KEY(`login`)) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;");
                Konfiguracja_1.AktualnyEtap(3);
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query_uzytwkonicy;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
                //tworzenie tabeli zgloszenia
                string query_zgloszenia = String.Format("CREATE TABLE IF NOT EXISTS zgloszenia_zgloszenia " + 
                    "(`id` INT(4) NOT NULL AUTO_INCREMENT, `tresc_zgloszenia` VARCHAR(128) NOT NULL, `serwer` VARCHAR(48) NOT NULL, `zgloszony` VARCHAR(48) NOT NULL," +
                    " `ip_zgloszonego` VARCHAR(48) NOT NULL, `zglaszajacy` VARCHAR(48) NOT NULL, `ip_zglaszajacego` VARCHAR(48) NOT NULL," +
                    " `data_zgloszenia` datetime NOT NULL, `typ_serwera` INT(5) NOT NULL, " + 
                    "`ip_serwera` VARCHAR(64) NOT NULL, `rozwiazane` INT(1) NOT NULL DEFAULT 0, PRIMARY KEY (`id`)) " + 
                    "ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;");
                Konfiguracja_1.AktualnyEtap(4);
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query_zgloszenia;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
                //tworzenie tabeli logi
                string query_logi = String.Format("CREATE TABLE IF NOT EXISTS zgloszenia_logi " + 
                    "(`id` INT(6) NOT NULL AUTO_INCREMENT, `nick` VARCHAR(48) NOT NULL, `ip` VARCHAR(64) NOT NULL, `akcja` VARCHAR(128) NOT NULL, " + 
                    "`data` timestamp DEFAULT CURRENT_TIMESTAMP, PRIMARY KEY (`id`)) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;");
                Konfiguracja_1.AktualnyEtap(5);
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query_logi;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
                Konfiguracja_1.AktualnyEtap(6);
            }

            return true;
        }

        //Initialize values
        private void Initialize()
        {
            //server = "mysql-683577.vipserv.org";
            //database = "csnajper_zglos";
            //uid = "csnajper_zglos";
            //password = "pop123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Nie można połączyć się z bazą danych.\nSprawdź poprawność danych", "Konfiguracja bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;

                    case 1045:
                        MessageBox.Show("Błędne hasło/nazwa użytkownika.\nPopraw dane i spróbuj ponownie", "Konfiguracja bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                }
                return false;
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
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Logowanie uzytkownika do systemu zgloszen
        public bool Zaloguj(string login, string haslo)
        {
            string query = String.Format("SELECT * FROM `zgloszenia_uzytkownicy` WHERE Login='{0}'", login);
            //Open connection
            if (this.OpenConnection() == true)
            {
                string haslo_z_bazy;
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                if(dataReader.Read())
                {
                    haslo_z_bazy = !dataReader.IsDBNull(2) ? dataReader.GetString(2) : null;
                    if(haslo.Equals(haslo_z_bazy, StringComparison.Ordinal))
                    {
                        User.id = dataReader.GetString(0);
                        User.login = dataReader.GetString(1);
                        User.haslo = dataReader.GetString(2);
                        User.poziom = dataReader.GetInt32(3);
                        User.ilosc_zatwierdzonych_zgloszen = dataReader.GetInt32(4);
                        User.czas_online = dataReader.GetInt32(5);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Podane hasło i/lub login są błędne!", "Błąd logowania!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Podane hasło i/lub login są błędne!", "Błąd logowania!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //close Data Reader
                dataReader.Close();
                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return false;
            }
            else
            {
                MessageBox.Show("Could not connect to databese");
                return false;
            }
        }

        public String[][] PobierzZgloszenia()
        {
            UsunPrzedawnioneZgloszenia();
            string query = "SELECT * FROM `zgloszenia_zgloszenia` WHERE `rozwiazane` = '0' ORDER BY `id` DESC LIMIT 20";

            //Create a list to store the result
            String[][] lista_zgloszen = new String[20][];
            for (int i = 0; i < 20; i++ )
                lista_zgloszen[i] = new String[10];

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                int counter = 0;
                while (dataReader.Read())
                {
                    if (counter >= 20)  break;
                    lista_zgloszen[counter][0] = dataReader.GetString(0);
                    lista_zgloszen[counter][1] = dataReader.GetString(1);
                    lista_zgloszen[counter][2] = dataReader.GetString(2);
                    lista_zgloszen[counter][3] = dataReader.GetString(3);
                    lista_zgloszen[counter][4] = dataReader.GetString(4);
                    lista_zgloszen[counter][5] = dataReader.GetString(5);
                    lista_zgloszen[counter][6] = dataReader.GetString(6);
                    lista_zgloszen[counter][7] = dataReader.GetString(7);
                    lista_zgloszen[counter][8] = dataReader.GetString(8);
                    lista_zgloszen[counter][9] = dataReader.GetString(9);
                    counter++;
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return lista_zgloszen;
            }
            else
            {
                MessageBox.Show("Could not connect to databese");
                return null;
            }
        }

        public String[][] PobierzUzytkownikow()
        {
            string query;
            if(User.poziom == 3)
                query = "SELECT * FROM `zgloszenia_uzytkownicy`";
            else
                query = "SELECT * FROM `zgloszenia_uzytkownicy` WHERE `poziom` = '1'";

            //Create a list to store the result
            String[][] lista_uzytkownikow = new String[20][];
            for (int i = 0; i < 20; i++)
                lista_uzytkownikow[i] = new String[6];

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                int counter = 0;
                while (dataReader.Read())
                {
                    if (counter <= 20)
                    {
                        lista_uzytkownikow[counter][0] = dataReader.GetString(0);
                        lista_uzytkownikow[counter][1] = dataReader.GetString(1);
                        lista_uzytkownikow[counter][2] = dataReader.GetString(2);
                        lista_uzytkownikow[counter][3] = dataReader.GetString(3);
                        lista_uzytkownikow[counter][4] = dataReader.GetString(4);
                        lista_uzytkownikow[counter][5] = dataReader.GetString(5);
                        counter++;
                    }
                    else break;
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return lista_uzytkownikow;
            }
            else
            {
                MessageBox.Show("Could not connect to databese");
                return null;
            }
        }

        public bool AtkualizujUzytkownika(string [] info)
        {
            string query = "UPDATE `zgloszenia_uzytkownicy` SET `login`='" + info[1] + "', `haslo`='" + info[2] + "', `rozpatrzone_zgloszenia`='" + info[3] + "', `czas_online`='" + info[4] + "', `poziom`='" + info[5] + "' WHERE id='" + info[0] + "'";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return false;
        }

        public bool UsunUzytkownika(string id)
        {
            string query = "DELETE FROM `zgloszenia_uzytkownicy` WHERE `id`='" + id + "'";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return false;
        }

        public bool DodajUzytkownika(string[] tab)
        {
            string query = "INSERT INTO `zgloszenia_uzytkownicy` (`login`,`haslo`,`poziom`) VALUES ('" + tab[0] + "','" + tab[1] + "','" + tab[2] + "')";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return false;
        }

        public bool ZatwierdzZgloszenie(string id)
        {
            string query = "UPDATE `zgloszenia_zgloszenia` SET `rozwiazane` = '1' WHERE id='" + id + "'";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return false;
        }
        public void DodajZatwierdzenieZgloszenia(string id)
        {
            User.ilosc_zatwierdzonych_zgloszen++;
            User.ilosc_zatwierdzonych_zgloszen_w_sesji++;
            string query = "UPDATE `zgloszenia_uzytkownicy` SET `rozpatrzone_zgloszenia` = `rozpatrzone_zgloszenia`+'1' WHERE id='" + id + "'";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DodajMinuteOnline(string id)
        {
            string query = "UPDATE `zgloszenia_uzytkownicy` SET `czas_online` = `czas_online`+'60' WHERE id='" + id + "'";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool ZmianaHasla(string id, string haslo)
        {
            string query = "UPDATE `zgloszenia_uzytkownicy` SET `haslo` ='" + haslo + "' WHERE id='" + id + "'";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

            return true;
        }

        internal void DodajCzasOnline(string id, int czas_online)
        {
            string query = "UPDATE `zgloszenia_uzytkownicy` SET `czas_online`='" + czas_online.ToString() + "' WHERE `id`='" + id + "'";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void UsunPrzedawnioneZgloszenia()
        {
            DateTime teraz = DateTime.Now;
            //ustalamy czas po jakim przedawnione zgloszenia sa usuwane
            TimeSpan czas_przedawnienia = new TimeSpan(0, 10, 0);
            DateTime data_finalna = teraz - czas_przedawnienia;
            string query = "UPDATE `zgloszenia_zgloszenia` SET `rozwiazane` = '1' WHERE `data_zgloszenia` < '" + data_finalna + "'";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



























        //Select statement
        public List<string> Select()
        {
            string query = "SELECT * FROM test_test2";

            //Create a list to store the result
            List<string> list = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                int counter = 0;
                while (dataReader.Read())
                {

                    list.Add(dataReader["id"] + "");
                    list.Add(dataReader["imie"] + "");
                    list.Add(dataReader["wiek"] + "");
                    counter++;
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                MessageBox.Show("Could not connect to databese");
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM test_test2";
            int Count = 0;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return -1;
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO test_test (kolumna1, kolumna2) VALUES('3', '4')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE test_test SET kolumna1='5', kolumna2='6'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
    }
}
