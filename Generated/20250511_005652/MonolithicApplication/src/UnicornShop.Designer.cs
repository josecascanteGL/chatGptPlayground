public partial class UnicornShopLegacyEntities : DbContext
{
    public UnicornShopLegacyEntities()
        : base("name=UnicornShopLegacyEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Product> Products { get; set; }
}

// This class represents the Entity Framework DbContext for the Unicorn Shop Legacy database.
// It includes DbSet properties for the Customer, Order, and Product entities.
// The constructor initializes the context with the connection string name "UnicornShopLegacyEntities".
// The OnModelCreating method is overridden to throw an exception, indicating that Code First is not intended to be used.
// DbSet properties are used to interact with the corresponding database tables for the entities.