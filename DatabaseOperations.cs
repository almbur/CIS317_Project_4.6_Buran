/*******************************************************************
* Name: Almaz Buran
* Date: Jan 14, 2024
* Assignment: CIS317 Week 4 GP – Project
*
* Class to handle all interactions with the Users table in the
* database, including creating the table if it doesn't exist and all
* CRUD (Create, Read Update, Delete) operations on the People table.
* Note that the interactions are all done using standard SQL syntax
* that is then executed by the SQLite library.
*/

using System.Data.SQLite;
public class DatabaseOperations
{
    private const string databaseName = "AlmazBuran.db";

    // Method to create the Users table
    public static void CreateTable(SQLiteConnection conn)
    {
        string sql = @"CREATE TABLE IF NOT EXISTS Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        ProductID INTEGER,
                        ProductName TEXT,
                        Price REAL,
                        FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
                    );";

        using (SQLiteCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }

    // Method to add a user to the Users table
    public static void AddUser(SQLiteConnection conn, User user)
    {
        string sql = $"INSERT INTO Users(UserName, Password, ProductID, ProductName, Price) " +
                     $"VALUES('{user.UserName}', '{user.Password}', {user.ProductID}, '{user.ProductName}', {user.Price})";

        using (SQLiteCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }

    // Method to update a user in the Users table
    public static void UpdateUser(SQLiteConnection conn, User user)
    {
        string sql = $"UPDATE Users SET UserName='{user.UserName}', Password='{user.Password}', " +
                     $"ProductID={user.ProductID}, ProductName='{user.ProductName}', Price={user.Price} " +
                     $"WHERE UserID={user.UserID}";

        using (SQLiteCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }

    // Method to delete a user from the Users table
    public static void DeleteUser(SQLiteConnection conn, int userID)
    {
        string sql = $"DELETE FROM Users WHERE UserID={userID}";

        using (SQLiteCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }

    // Method to get all users from the Users table
 public static List<User> GetAllUsers(SQLiteConnection conn)
{
    List<User> users = new List<User>();

    string getAllUsersQuery = "SELECT * FROM Users;";

    using (SQLiteCommand getAllUsersCommand = new SQLiteCommand(getAllUsersQuery, conn))
    {
        conn.Open();

        using (SQLiteDataReader reader = getAllUsersCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                users.Add(new User(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    reader.GetString(4),
                    reader.GetDouble(5)
                ));
            }
        }
    }

    return users;
}

}
