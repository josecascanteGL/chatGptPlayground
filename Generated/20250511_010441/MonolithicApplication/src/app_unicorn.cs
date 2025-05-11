//Namespace declaration for the UnicornShopLegacy namespace
namespace UnicornShopLegacy
{
    // Importing the necessary libraries
    using System;
    using System.Collections.Generic;
    
    // Partial class definition for app_unicorn
    public partial class app_unicorn
    {
        // Declaration of properties for the app_unicorn class
        public System.Guid unicorn_id { get; set; } // Property for storing the unique identifier of the unicorn
        public Nullable<byte> active { get; set; } // Property for storing the active status of the unicorn
        public string name { get; set; } // Property for storing the name of the unicorn
        public string description { get; set; } // Property for storing the description of the unicorn
        public Nullable<decimal> price { get; set; } // Property for storing the price of the unicorn
        public string image { get; set; } // Property for storing the image file path of the unicorn
        public Nullable<System.DateTime> date_create { get; set; } // Property for storing the creation date of the unicorn
    }
}