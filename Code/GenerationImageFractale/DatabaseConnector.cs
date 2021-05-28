using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerationImageFractale
{
    //this code has been adapted from https://github.com/LouisRichard/GameLibrary/blob/master/Code/GameLibrary/DatabaseManager/DbConnector.cs

    /// <summary>
    /// This class handles the db connection
    /// </summary>
    public class DatabaseConnector
    {
        /// <summary>
        /// Opens the database
        /// </summary>
        /// <returns>SQLite statement to be executed statement against the db</returns>
        public static SQLiteCommand OpenDatabase()
        {
            bool createTable = false;

            if (!File.Exists("GenerationImageFractale.db3"))
            {
                CreateDatabase();
                createTable = true;
            }

            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=GenerationImageFractale.db3");
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(conn);

            conn.Open();

            if (createTable)
            {
                CreateTable(cmd);
            }
            return cmd;
        }

        /// <summary>
        /// Closes the database
        /// </summary>
        public static void CloseDatabase()
        {
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=GenerationImageFractale.db3");
            conn.Close();
        }

        /// <summary>
        /// Creates the database
        /// </summary>
        public static void CreateDatabase()
        {
            System.Data.SQLite.SQLiteConnection.CreateFile(Path.Combine(Directory.GetCurrentDirectory(), "GenerationImageFractale.db3")); //Create the database
        }

        /// <summary>
        /// Creates the table
        /// </summary>
        /// <param name="cmd"></param>
        public static void CreateTable(SQLiteCommand cmd)
        {

            string createTableQuery = @"
                BEGIN TRANSACTION;
                CREATE TABLE 'Fractals' (
	                'id'	INTEGER NOT NULL UNIQUE,
	                'indexFractal'	INTEGER NOT NULL,
	                'xMin'	REAL NOT NULL,
	                'xMax'	REAL NOT NULL,
	                'yMin'	REAL NOT NULL,
	                'yMax'	REAL NOT NULL,
	                'cReal'	REAL,
	                'cImaginary'	REAL,
	                PRIMARY KEY('id' AUTOINCREMENT)
                );
                COMMIT;";

            cmd.CommandText = createTableQuery;
            cmd.ExecuteNonQuery();
        }
    }
}
