﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data.OleDb;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace LudoServer
{
    [DataContract]
    public class DataHelper
    {

        string connectionInfo = @"server=athena01.fhict.local;
                                  userid=dbi290916;
                                  password=LKnPL35NHl;
                                  database=dbi290916;
                                  Convert Zero Datetime = True;
                                  Allow Zero DateTime = True;";
        [DataMember]
        public MySqlConnection connection { get; set; }

        public DataHelper()
        {
            connection = new MySqlConnection(connectionInfo);

        }

        User isUser(string username, string password)
        {
            User user = null;
            string sql = "SELECT password FROM users WHERE name = '" + username + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string pass = "";
                if (reader.Read())
                {
                    pass = Convert.ToString(reader["password"]);

                    user = new User(username);
                }
            }
            catch
            {

                throw;
            }
            finally
            {

                connection.Close();
            }
            return user;
        }
        public void RegisterPlayer(string username, string password)
        {

            string sql = "INSERT INTO users (name,password) VALUES ('" + username + "','" + password + "')";


            MySqlCommand command = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                command.ExecuteReader();
            }
            catch
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
