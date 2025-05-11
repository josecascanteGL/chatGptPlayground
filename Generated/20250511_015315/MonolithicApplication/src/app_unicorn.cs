// This section declares the namespace UnicornShopLegacy and imports necessary libraries
// It defines a partial class app_unicorn with properties for a Unicorn entity

namespace UnicornShopLegacy
{
    using System; // Importing the System namespace for basic functionalities
    using System.Collections.Generic; // Importing the System.Collections.Generic namespace for generic collections
    
    public partial class app_unicorn // Declaring a partial class for the Unicorn entity
    {
        // Declaring properties for the Unicorn entity with appropriate data types
        public System.Guid unicorn_id { get; set; } // Property for the ID of the unicorn, using Guid data type
        public Nullable<byte> active { get; set; } // Property for the active status of the unicorn, using Nullable byte data type
        public string name { get; set; } // Property for the name of the unicorn, using string data type
        public string description { get; set; } // Property for the description of the unicorn, using string data type
        public Nullable<decimal> price { get; set; } // Property for the price of the unicorn, using Nullable decimal data type
        public string image { get; set; } // Property for the image of the unicorn, using string data type
        public Nullable<System.DateTime> date_create { get; set; } // Property for the creation date of the unicorn, using Nullable DateTime data type
    }
}