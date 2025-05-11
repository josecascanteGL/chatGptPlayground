// Namespace and using directives for the UnicornShopLegacy project
namespace UnicornShopLegacy
{
    // Class definition for the inventory class
    public partial class inventory
    {
        // Properties for the inventory class to store unicorn details
        public System.Guid unicorn_id { get; set; } // Property to store the unique identifier of the unicorn
        public string name { get; set; } // Property to store the name of the unicorn
        public string description { get; set; } // Property to store the description of the unicorn
        public Nullable<decimal> price { get; set; } // Property to store the price of the unicorn
        public string image { get; set; } // Property to store the image filename of the unicorn
        public Nullable<System.DateTime> date_create { get; set; } // Property to store the creation date of the unicorn
    }
}