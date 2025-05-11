```csharp
/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * SPDX-License-Identifier: MIT-0
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify,
 * merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicornShopLegacy.Tests
{
    internal class FakeUserDbSet : FakeDbSet<user> // Inherits from FakeDbSet of type user
    {
        public override user Find(params object[] keyValues) // Override the Find method to search for specified key values
        {
            Debug.Assert(keyValues.Length == 1, "There should be only one key for Unicorn entity"); // Ensure only one key is provided
            var targetEmail = keyValues[0]; // Get the target email key
            
            if (targetEmail == null) // If target email is null, return null
            {
                return null;
            }

            var data = this.Local; // Get the local data
            return data.FirstOrDefault<user>(u => u.email == targetEmail); // Find and return the first user matching the target email
        }

        public override Task<user> FindAsync(params object[] keyValues) // Override FindAsync method for asynchronous operation
        {
            return Task.FromResult(this.Find(keyValues)); // Return a completed Task with the result of the Find method
        }
    }
}
```