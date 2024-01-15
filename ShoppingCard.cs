// Class representing a shopping cart
public class ShoppingCart : IPurchasable
{
    // Properties
    public int ShoppingCartID { get; set; }
    public string CartName { get; set; }
    public double Tax { get; set; }
    public double TotalPrice { get; set; }
    private List<IPurchasable> Items { get; set; }

    public double Price => throw new NotImplementedException();

    // Parameterized constructor
    public ShoppingCart(int shoppingCartID, string cartName, double tax)
    {
        ShoppingCartID = shoppingCartID;
        CartName = cartName;
        Tax = tax;
        Items = new List<IPurchasable>();
    }

    // Method to add an item to the cart
    public void AddToCart(IPurchasable item)
    {
        Items.Add(item);
        CalculateTotalPrice();
    }

    // Method to calculate the total price of items in the cart
    private void CalculateTotalPrice()
    {
        TotalPrice = Items.Sum(item => item.Price) * (1 + Tax);
    }

    // Method to clear the cart
    public void ClearCart()
    {
        Items.Clear();
        CalculateTotalPrice();
    }

    // Method to perform checkout
    public double Checkout()
    {
        // Simulate the checkout process (e.g., payment, order confirmation)
        // In a real system, you would perform actual payment processing and order placement.
        Console.WriteLine("Simulating Checkout Process...");

        // Returning the total price after checkout
        return TotalPrice;
    }
}
