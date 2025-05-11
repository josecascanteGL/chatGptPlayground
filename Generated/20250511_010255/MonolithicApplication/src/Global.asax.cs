/*
 * In the Application_Start method, the code first checks if the database exists by creating a new instance of the UnishopEntities context.
 * If the database does not exist, it is created using context.Database.Create().
 * Next, a SqlConnection is created to connect directly to the database and execute a SQL statement to add a computed column 'year_model' to the 'inventory' table.
 * The SQL statement is executed using SqlDataAdapter to alter the table and add the computed column.
 * The code then reads the contents of the 'unicorns.csv' file into an array of strings using File.ReadAllLines.
 * For each line in the readText array, the code splits the line by ',' delimiter to extract the fields.
 * A new inventory object is created for each line, and the fields are assigned to the corresponding properties of the inventory object.
 * The new inventory objects are added to a list 'newunicorns'.
 * The list of new inventory objects is added to the context using context.inventories.AddRange(newunicorns).
 * Finally, the changes are saved to the database using context.SaveChanges().
 */