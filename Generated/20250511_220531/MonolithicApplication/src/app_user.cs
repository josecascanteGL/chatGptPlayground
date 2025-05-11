// Namespace declaration for the UnicornShopLegacy namespace
namespace UnicornShopLegacy
{
    // Importing necessary libraries
    using System;
    using System.Collections.Generic;
    
    // Partial class definition for app_user
    public partial class app_user
    {
        // Property for user_id of type Guid
        public System.Guid user_id { get; set; }
        
        // Property for active status of type Nullable<byte>
        public Nullable<byte> active { get; set; }
        
        // Property for email of type string
        public string email { get; set; }
        
        // Property for first_name of type string
        public string first_name { get; set; }
        
        // Property for last_name of type string
        public string last_name { get; set; }
        
        // Property for password of type string
        public string password { get; set; }
    }
}