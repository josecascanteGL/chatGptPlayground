// Namespace declaration for the UnicornShopLegacy namespace
namespace UnicornShopLegacy
{
    // Importing necessary libraries for the class
    using System;
    using System.Collections.Generic;
    
    // Defining a partial class named inventory
    public partial class inventory
    {
        // Declaring properties for the inventory class
        public System.Guid unicorn_id { get; set; } // Property for storing the unique identifier of a unicorn
        public string name { get; set; } // Property for storing the name of a unicorn
        public string description { get; set; } // Property for storing the description of a unicorn
        public Nullable<decimal> price { get; set; } // Property for storing the price of a unicorn
        public string image { get; set; } // Property for storing the image path of a unicorn
        public Nullable<System.DateTime> date_create { get; set; } // Property for storing the creation date of a unicorn
    }
}