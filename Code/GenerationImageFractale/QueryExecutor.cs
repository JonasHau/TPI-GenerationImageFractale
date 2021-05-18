using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace GenerationImageFractale
{
    //this code has been adapted from https://github.com/LouisRichard/GameLibrary/blob/master/Code/GameLibrary/DatabaseManager/ExecuteQuery.cs

    public class QueryExecutor
    {
        /// <summary>
        /// Executes a select query
        /// </summary>
        /// <param name="query">select query</param>
        /// <returns>query result</returns>
        internal static List<List<string>> Select(string query)
        {
            SQLiteCommand command = DatabaseConnector.OpenDatabase();
            List<List<string>> result = new List<List<string>>();
            List<string> fractal = new List<string>();
            //DataTable dt = new DataTable();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    //create the fractal
                    fractal.Clear();
                    fractal.Add(reader.GetInt32(0).ToString());
                    fractal.Add(reader.GetDouble(1).ToString());
                    fractal.Add(reader.GetDouble(2).ToString());
                    fractal.Add(reader.GetDouble(3).ToString());
                    fractal.Add(reader.GetDouble(4).ToString());
                    fractal.Add(reader.GetDouble(5).ToString());
                    fractal.Add(reader.GetDouble(6).ToString());

                    //add it to result
                    result.Add(new List<string>(fractal));
                }
                catch
                {
                    continue;
                }

            }

            //close db connection
            DatabaseConnector.CloseDatabase();
            return result;
        }

        /// <summary>
        /// Executes a insert query
        /// </summary>
        /// <param name="query">insert query</param>
        public static void Insert(string query)
        {
            SQLiteCommand command = DatabaseConnector.OpenDatabase();
            command.CommandText = query;
            command.ExecuteNonQuery(); //Execute the query

            DatabaseConnector.CloseDatabase();
        }

        /// <summary>
        /// Executes a delete query
        /// </summary>
        /// <param name="query">delete query</param>
        public static void Delete(string query)
        {
            //open db connection
            SQLiteCommand command = DatabaseConnector.OpenDatabase();
            command.CommandText = query;

            //Execute the query
            command.ExecuteNonQuery();

            //close db connection
            DatabaseConnector.CloseDatabase();
        }

        /// <summary>
        /// Executes a update query
        /// </summary>
        /// <param name="query">update query</param>
        public static void Update(string query)
        {
            //open db connection
            SQLiteCommand command = DatabaseConnector.OpenDatabase();
            command.CommandText = query;
            command.ExecuteNonQuery();

            //close db connection
            DatabaseConnector.CloseDatabase();
        }
    }
}