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
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnicornShopLegacy.Tests
{
    internal class FakeUnicornDbSet : FakeDbSet<inventory>
    {
        // Override the Find method to search for a specific unicorn entity
        public override inventory Find(params object[] keyValues)
        {
            // Check if only one key is provided for the unicorn entity
            Debug.Assert(keyValues.Length == 1, "There should be only one key for Unicorn entity");

            // Extract the target ID from the keyValues array
            var targetId = keyValues[0] as Guid?;

            // If the target ID is null, return null
            if (targetId == null)
            {
                return null;
            }

            // Return the first unicorn entity with matching ID from the local collection
            return this.Local.FirstOrDefault<inventory>(u => u.unicorn_id == targetId);
        }

        // Override the FindAsync method for asynchronous search of a unicorn entity
        public override Task<inventory> FindAsync(params object[] keyValues)
        {
            // Return a completed task with the result of Find method
            return Task.FromResult(this.Find(keyValues));
        }
    }
}