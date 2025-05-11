```c#
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
    internal class FakeBasketDbSet : FakeDbSet<basket>
    {
        // Override the Find method from the base class
        public override basket Find(params object[] keyValues)
        {
            // Ensure that there is only one key for the Unicorn entity
            Debug.Assert(keyValues.Length == 1, "There should be only one key for Unicorn entity");
            var targetId = keyValues[0] as Guid?;

            // If the targetId is null, return null
            if (targetId == null)
            {
                return null;
            }

            // Get the data from the local collection
            var data = this.Local;
            // Find and return the first basket item where the basket_id matches the targetId
            return data.FirstOrDefault<basket>(u => u.basket_id == targetId);
        }

        // Override the FindAsync method from the base class
        public override Task<basket> FindAsync(params object[] keyValues)
        {
            // Return a completed Task with the result of Find method
            return Task.FromResult(this.Find(keyValues));
        }
    }
}
```