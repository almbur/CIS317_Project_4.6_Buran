/*******************************************************************
* Name: Almaz Buran
* Date: Jan 14, 2024
* Assignment: CIS317 Week 4 GP – Project
*
* Main application class.
*/
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Almaz Buran - CIS 317; Week 4 PA 4.6");

        // Initialize the database and create tables
        DatabaseInitializer.InitializeDatabase();

        // Creating instances of User, Product, and ShoppingCart
        User user = new User(1, "JohnDoe", "securePassword", 101, "Smartphone", 599.99);

        Product product = new Product(102, "Laptop", 1299.99);

        ShoppingCart cart = new ShoppingCart(103, "Shopping Cart", 0.08);

        // Adding products to the shopping cart
        cart.AddToCart(user);
        cart.AddToCart(product);

        // Displaying information
        Console.WriteLine("User Information:");
        Console.WriteLine(user);

        Console.WriteLine("\nProduct Information:");
        Console.WriteLine(product);

        Console.WriteLine("\nShopping Cart Information:");
        Console.WriteLine($"Tax: {cart.Tax:P}");
        Console.WriteLine($"Total Price: {cart.TotalPrice:C}");

        // Simulating checkout
        double totalPriceAfterCheckout = cart.Checkout();
        Console.WriteLine($"\nTotal Price after Checkout: {totalPriceAfterCheckout:C}");

        // Clearing the shopping cart
        cart.ClearCart();
        Console.WriteLine("\nShopping Cart Cleared.");

        // Keeping the console window open until a key is pressed
        Console.ReadKey();
    }
}