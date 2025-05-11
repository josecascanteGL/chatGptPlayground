```csharp
        private IUnishopEntities unishopEntitiesContext;

        public UserController()
        {
            // Initialize the database context with the default constructor
            this.unishopEntitiesContext = new UnishopEntities();
        }

        public UserController(IUnishopEntities databaseContext)
        {
            // Initialize the database context with the injected database context
            this.unishopEntitiesContext = databaseContext;
        }

        public IQueryable<user> GetUsers()
        {
            // Get all users from the database context
            return this.unishopEntitiesContext.users;
        }

        // POST: api/User
        [ResponseType(typeof(user))]
        public async Task<IHttpActionResult> PostUser([FromBody] user user)
        {
            // Check if the email is valid or already exists in the database
            var search = from u in this.unishopEntitiesContext.users
                                where u.email == user.email
                         select u;

            if (user.email.IsNullOrWhiteSpace() || !user.email.Contains('@') || !user.email.Contains('.') || search.Count() != 0)
            {
                // Return a bad request if email is invalid or already exists
                return this.BadRequest();
            }

            // Generate a salt and hash the password
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(user.password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            user.password = Convert.ToBase64String(hashBytes);

            // Assign a new unique user id, add user to the database context, and save changes
            user.user_id = Guid.NewGuid();
            this.unishopEntitiesContext.users.Add(user);
            await this.unishopEntitiesContext.SaveChangesAsync();

            // Return the created user with HTTP status code 201 (Created)
            return this.CreatedAtRoute("DefaultApi", new { id = user.user_id }, user);
        }

        // POST: api/user/login
        [Route("api/user/login")]
        [HttpPost]
        public async Task<IHttpActionResult> PostLogin([FromBody] user login)
        {
            // Find the user based on the login email
            var search = from u in this.unishopEntitiesContext.users
                               where u.email == login.email
                               select u;

            if (search.Count() == 0)
            {
                // Return 404 Not Found if user is not found
                return this.NotFound();
            }

            // Retrieve the user from the search result
            var user = search.First();

            // Retrieve the stored hashed password for the user
            byte[] hashBytes = Convert.FromBase64String(user.password);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            
            // Generate a hash based on the provided password and salt
            var pbkdf2 = new Rfc2898DeriveBytes(login.password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Compare the generated hash with the stored hash
            bool match = true;
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    match = false;
                }
            }

            if (!match)
            {
                // Return a bad request if the passwords do not match
                return this.BadRequest();
            }

            // Return the user information if login is successful
            return this.Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose the database context when needed
                this.unishopEntitiesContext.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool UserExists(Guid id)
        {
            // Check if a user with the provided id exists in the database context
            return this.unishopEntitiesContext.users.Count(e => e.user_id == id) > 0;
        }
```