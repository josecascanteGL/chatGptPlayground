// Create a new instance of UnicornShopLegacyEntities
UnicornShopLegacyEntities db = new UnicornShopLegacyEntities();

// Get all the items from the Products table where the price is greater than 50
var expensiveItems = db.Products.Where(p => p.Price > 50).ToList();

// Loop through each expensive item and print out its name and price
foreach (var item in expensiveItems)
{
    Console.WriteLine("Name: " + item.Name + ", Price: " + item.Price);
}