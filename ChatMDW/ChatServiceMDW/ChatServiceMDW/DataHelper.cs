using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;



namespace ChatServiceMDW
{
    class DataHelper
    {
        private OleDbConnection connection;

        //username as a parameter in the constructor
        public DataHelper()
        {
            //this is for access to an ACCESS databse
            String info = "Provider=Microsoft.ACE.OLEDB.12.0";

            String databaseInfo = "DataSource";

            String connectionInfo = info + ";" + databaseInfo;
            connection = new OleDbConnection();

        }
        public Player isUser(string username, string password)
        {
            Player player = null;

            String sql = "Select statement";
            OleDbCommand command = new OleDbCommand(sql,connection);
            try
            {
                //connection.Open;
                OleDbDataReader reader = command.ExecuteReader();

                reader.Read();


            }
            catch
            {


            }
            finally
            {
                //conection.Close();
            }
            return player;
        }

    }
}
