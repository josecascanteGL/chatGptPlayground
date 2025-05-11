namespace UnicornShopLegacy
{
    using System; // Importing the System namespace
    using System.Collections.Generic; // Importing the generic collections namespace
    
    public partial class inventory
    {
        public System.Guid unicorn_id { get; set; } // Declaring a property for storing the unique identifier of a unicorn
        public string name { get; set; } // Declaring a property for storing the name of a unicorn
        public string description { get; set; } // Declaring a property for storing the description of a unicorn
        public Nullable<decimal> price { get; set; } // Declaring a property for storing the price of a unicorn
        public string image { get; set; } // Declaring a property for storing the image URL of a unicorn
        public Nullable<System.DateTime> date_create { get; set; } // Declaring a property for storing the creation date of a unicorn
    }
}