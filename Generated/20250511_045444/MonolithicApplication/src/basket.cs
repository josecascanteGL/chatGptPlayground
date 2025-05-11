// Namespace declaration
namespace UnicornShopLegacy
{
    // Using directives for necessary libraries
    using System;
    using System.Collections.Generic;
    
    // Partial class definition for the 'basket' class
    public partial class basket
    {
        // Properties for basket_id, user_id, unicorn_id, and creation_date with their respective data types
        public System.Guid basket_id { get; set; }
        public System.Guid user_id { get; set; }
        public System.Guid unicorn_id { get; set; }
        public System.DateTime creation_date { get; set; }
    }
}