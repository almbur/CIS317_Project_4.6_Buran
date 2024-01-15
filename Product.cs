/*******************************************************************
* Name: Almaz Buran
* Date: Jan 7, 2024
* Assignment: CIS317 Week 3 PA 3.7
*
* Class Car is a base class that includes properties for User and ShoppingCard.
* It also overrides of the IPurchasable Interface.
*/
public class Product : IPurchasable
{
    // Properties
    public int ProductID { get; set; }
    public string? ProductName { get; set; }
    public double Price { get; set; }

    // Parameterized constructor
    public Product(int productID, string productName, double price)
    {
        ProductID = productID;
        ProductName = productName;
        Price = price;
    }

    // Override ToString method for custom string representation
    public override string ToString()
    {
        return $"ProductID: {ProductID}, ProductName: {ProductName}, Price: {Price:C}";
    }
}
