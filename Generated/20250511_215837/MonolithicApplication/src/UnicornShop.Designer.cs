// Initialize the UnicornShopEntities context which represents the database
UnicornShopEntities context = new UnicornShopEntities();

// Query the context to retrieve all Product entities from the database
var products = context.Products.ToList();

// Loop through each product in the products list
foreach (var product in products)
{
    // Print out the ID and Name of each product
    Console.WriteLine("Product ID: " + product.ID + " - Name: " + product.Name);
}