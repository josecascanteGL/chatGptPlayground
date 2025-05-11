namespace UnicornShopLegacy
{
    using System; // Importing the System namespace
    using System.Collections.Generic; // Importing the System.Collections.Generic namespace
    
    public partial class inventory // Creating a partial class named inventory
    {
        public System.Guid unicorn_id { get; set; } // Declaring a property named unicorn_id of type Guid
        public string name { get; set; } // Declaring a property named name of type string
        public string description { get; set; } // Declaring a property named description of type string
        public Nullable<decimal> price { get; set; } // Declaring a property named price of type Nullable<decimal>
        public string image { get; set; } // Declaring a property named image of type string
        public Nullable<System.DateTime> date_create { get; set; } // Declaring a property named date_create of type Nullable<DateTime>
    }
}