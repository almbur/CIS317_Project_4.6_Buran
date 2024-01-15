// Class representing a user, extending the Product class
public class User : Product
{
    // Properties
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    // Parameterized constructor
    public User(int userID, string userName, string password, int productID, string productName, double price)
        : base(productID, productName, price)
    {
        UserID = userID;
        UserName = userName;
        Password = password;
    }

    // Override ToString method for custom string representation
    public override string ToString()
    {
        return $"UserID: {UserID}, UserName: {UserName}, {base.ToString()}";
    }
}
