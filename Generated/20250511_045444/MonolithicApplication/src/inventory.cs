// Namespace declaration for the UnicornShopLegacy namespace
namespace UnicornShopLegacy
{
    // Import necessary libraries for the code
    using System;
    // Import the System.Collections.Generic namespace
    
    // Define a partial class named 'inventory'
    public partial class inventory
    {
        // Define properties for the inventory class
        public System.Guid unicorn_id { get; set; } // Property to store the unique identifier of the unicorn
        public string name { get; set; } // Property to store the name of the unicorn
        public string description { get; set; } // Property to store a description of the unicorn
        public Nullable<decimal> price { get; set; } // Property to store the price of the unicorn
        public string image { get; set; } // Property to store the image path of the unicorn
        public Nullable<System.DateTime> date_create { get; set; } // Property to store the creation date of the unicorn
    }
}