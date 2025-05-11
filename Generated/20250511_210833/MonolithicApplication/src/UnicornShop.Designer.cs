// Create a new instance of the UnicornShopEntities context
UnicornShopEntities context = new UnicornShopEntities();

// Retrieve all products from the Products table in the database
var products = context.Products.ToList();

// Loop through each product in the products list
foreach (var product in products)
{
    // Display the product ID and product name in the console
    Console.WriteLine("Product ID: " + product.ProductID + " - Product Name: " + product.ProductName);
}