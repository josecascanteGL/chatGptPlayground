```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicornShopLegacy.Tests
{
    internal class FakeUserDbSet : FakeDbSet<user>
    {
        // Override the Find method to find a user entity in the database based on key values
        public override user Find(params object[] keyValues)
        {
            // Ensure that there is only one key for the Unicorn entity
            Debug.Assert(keyValues.Length == 1, "There should be only one key for Unicorn entity");
            var targetEmail = keyValues[0]; // Extract the target email from the key values

            // Check if the target email is null, return null if it is
            if (targetEmail == null)
            {
                return null;
            }

            var data = this.Local; // Get the local data from the DbSet
            // Find and return the first user whose email matches the target email
            return data.FirstOrDefault<user>(u => u.email == targetEmail);
        }

        // Override the FindAsync method to asynchronously find a user entity in the database based on key values
        public override Task<user> FindAsync(params object[] keyValues)
        {
            // Return a completed Task with the result of Find method
            return Task.FromResult(this.Find(keyValues));
        }
    }
}
```