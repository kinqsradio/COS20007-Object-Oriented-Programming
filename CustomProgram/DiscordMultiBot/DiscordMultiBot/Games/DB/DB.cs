using DiscordMultiBot.Games.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games.DB
{
    public class DB
    {
        public MySqlConnection connection;
        public MySqlCommand command;  
        

        public void PrepareSQLConnection(string sqlString)
        {
            string connectionString = Factory.Instance().InstantiateJson("sql");

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = sqlString;
        }

        public void ExecuteSql(string sqlString)
        {
            PrepareSQLConnection(sqlString);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public string GetId(string sqlSelect)
        {
            PrepareSQLConnection(sqlSelect);
            MySqlDataReader sqldr = command.ExecuteReader();
            
            if (sqldr.HasRows)
                while (sqldr.Read())
                {
                    string id = sqldr["userId"].ToString();
                    connection.Close();
                    return id;
                }

            connection.Close();
            return null;
        }

        public PlayerDB FetchPreviousResults(string memberId)
        {
            string sqlSelect = $"select * from ScoreList where userId = " + memberId;
            PrepareSQLConnection(sqlSelect);
            MySqlDataReader sqldr = command.ExecuteReader();

            if (sqldr.HasRows)
                while (sqldr.Read())
                {
                    string userId = sqldr["userId"].ToString();
                    int wins = Convert.ToInt32(sqldr["wins"].ToString());
                    int losses = Convert.ToInt32(sqldr["losses"].ToString());
                    int ties = Convert.ToInt32(sqldr["ties"].ToString());
                    connection.Close();
                    return new PlayerDB(userId, wins, losses, ties);
                }

            return new PlayerDB("", 0, 0, 0);
        }
    }
}
