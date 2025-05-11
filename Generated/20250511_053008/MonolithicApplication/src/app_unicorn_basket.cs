// Namespace declaration for the UnicornShopLegacy namespace
namespace UnicornShopLegacy
{
    // Importing necessary libraries
    using System;
    using System.Collections.Generic;

    // Partial class definition for app_unicorn_basket
    public partial class app_unicorn_basket
    {
        // Property for holding the basket ID of type Guid
        public System.Guid basket_id { get; set; }
        
        // Property for holding the user ID of type Guid
        public System.Guid user_id { get; set; }
        
        // Property for holding the unicorn ID of type Guid
        public System.Guid unicorn_id { get; set; }
        
        // Property for holding the creation date of type DateTime
        public System.DateTime creation_date { get; set; }
        
        // Property for holding the active status as a nullable byte
        public Nullable<byte> active { get; set; }
    }
}