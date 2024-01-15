/*******************************************************************
* Name: Almaz Buran
* Date: Jan 14, 2024
* Assignment: CIS317 Week 4 GP – Project
*
* This Class initializies Database to be created
*/

using System.Data.SQLite;
public class DatabaseInitializer
{
    public static void InitializeDatabase()
    {
        const string databaseName = "AlmazBuran.db";

        // Create or connect to the SQLite database
        using (SQLiteConnection conn = SQLiteDatabase.Connect(databaseName))
        {
            conn.Open();

            // Create tables
            DatabaseOperations.CreateTable(conn);

            // Close the connection
            conn.Close();
        }
    }
}