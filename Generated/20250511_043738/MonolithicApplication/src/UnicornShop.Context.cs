// This code defines the structure of the UnishopEntities class which inherits from DbContext
// The constructor initializes the UnishopEntities with a connection string named UnishopEntities
// The OnModelCreating method is overridden to throw an UnintentionalCodeFirstException, indicating that code-first migrations are not allowed
// Three DbSet properties are declared for the entities basket, user, and inventory to interact with the corresponding tables in the database