// Open the connection to the database using the existing model
using (var db = new UnicornShopEntities())
{
    // Create a new instance of the Product entity class
    var product = new Product
    {
        Name = "Unicorn Plushie",
        Price = 20.00,
        Quantity = 10
    };

    // Add the new product to the Products DbSet in the database context
    db.Products.Add(product);

    // Save the changes to the database
    db.SaveChanges();
}