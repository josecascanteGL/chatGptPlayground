namespace UnicornShopLegacy
{
    // Importing necessary libraries
    using System;
    using System.Collections.Generic;

    // Creating a partial class for the app_unicorn_basket entity
    public partial class app_unicorn_basket
    {
        // Declaring properties for the app_unicorn_basket entity
        // Each property represents a column in the database table for app_unicorn_basket
        public System.Guid basket_id { get; set; } // Unique identifier for the basket
        public System.Guid user_id { get; set; } // Unique identifier for the user
        public System.Guid unicorn_id { get; set; } // Unique identifier for the unicorn
        public System.DateTime creation_date { get; set; } // Date and time when the basket was created
        public Nullable<byte> active { get; set; } // Indicates if the basket is currently active (nullable byte allows for null value)
    }
}