﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Runtime.Serialization;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LudoServer
{
    [DataContract]
    public class datahelper
    {

        string connectionInfo = @"server=athena01.fhict.local;
                                userid=dbi290916;
                                password=LKnPL35NH1;
                                database=dbi290916;
                                Convert Zero DateTime = True;
                                Allow Zero DateTime = True;";

        [DataMember]
        public MySqlConnection connection { get; set; }

        public datahelper()
        {
            connection = new MySqlConnection(connectionInfo);
        }


        public Player IsUser(string username, string password)
        {
            Player player = null;
            string sql = "SELECT password FROM users WHERE name = '"+username+"'";
            MySqlCommand command = new MySqlCommand(sql,connection);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string pass = "";
                if (reader.Read())
                {
                    pass = Convert.ToString(reader["password"]);

                    player = new Player(username);
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
            return player;

            }
        public void RegisterPlayer(string username, string password)
        {
            string sql = "INSERT INTO users(name,password) VALUES ('"+username+"','"+password+"')";
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