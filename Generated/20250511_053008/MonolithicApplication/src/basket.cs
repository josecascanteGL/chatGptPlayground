// Namespace declaration for the UnicornShopLegacy namespace
namespace UnicornShopLegacy
{
    // Importing necessary libraries
    using System;
    using System.Collections.Generic;

    // Declaring a partial class named basket
    public partial class basket
    {
        // Property to store the unique identifier of the basket
        public System.Guid basket_id { get; set; }

        // Property to store the unique identifier of the user associated with the basket
        public System.Guid user_id { get; set; }

        // Property to store the unique identifier of the unicorn in the basket
        public System.Guid unicorn_id { get; set; }

        // Property to store the creation date of the basket
        public System.DateTime creation_date { get; set; }
    }
}