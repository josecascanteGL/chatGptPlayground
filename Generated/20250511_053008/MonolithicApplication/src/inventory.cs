namespace UnicornShopLegacy
{
    // Import necessary libraries for data handling
    using System;
    using System.Collections.Generic;

    // Define a "partial" class named inventory to represent a unicorn item in the shop
    public partial class inventory
    {
        // Define properties for the attributes of a unicorn item
        // Each property has a getter and a setter method for accessing and modifying the data
        public System.Guid unicorn_id { get; set; } // Unique identifier for the unicorn item
        public string name { get; set; } // Name of the unicorn item
        public string description { get; set; } // Description of the unicorn item
        public Nullable<decimal> price { get; set; } // Price of the unicorn item
        public string image { get; set; } // Image URL of the unicorn item
        public Nullable<System.DateTime> date_create { get; set; } // Date when the unicorn item was created
    }
}