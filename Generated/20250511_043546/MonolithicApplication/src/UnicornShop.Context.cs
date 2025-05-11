// This code is defining the structure of the UnishopEntities class which is a DbContext in Entity Framework.
// The constructor initializes the UnishopEntities class with the connection string "UnishopEntities".
// The OnModelCreating method is overridden to throw an UnintentionalCodeFirstException, preventing accidental code-first migrations.
// Three DbSets are defined for the entities: basket, user, and inventory.
// These DbSets will represent tables in the database and allow querying and manipulating the data.