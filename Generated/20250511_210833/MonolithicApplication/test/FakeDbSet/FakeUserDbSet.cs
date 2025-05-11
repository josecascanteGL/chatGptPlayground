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
    internal class FakeUserDbSet : FakeDbSet<user>
    {
        // Override the base Find method to find a user in the database by their email
        public override user Find(params object[] keyValues)
        {
            // Ensure that only one key is provided for the Unicorn entity
            Debug.Assert(keyValues.Length == 1, "There should be only one key for Unicorn entity");
            var targetEmail = keyValues[0];

            // If the email is null, return null
            if (targetEmail == null)
            {
                return null;
            }

            // Get the data from the local DbSet and find the user with the matching email
            var data = this.Local;
            return data.FirstOrDefault<user>(u => u.email == targetEmail);
        }

        // Override the base FindAsync method to asynchronously find a user in the database by their email
        public override Task<user> FindAsync(params object[] keyValues)
        {
            // Call the synchronous Find method and return the result wrapped in a task
            return Task.FromResult(this.Find(keyValues));
        }
    }
}