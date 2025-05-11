// Namespace declaration for the UnicornShopLegacy namespace
namespace UnicornShopLegacy
{
    // Importing necessary libraries
    using System;
    using System.Collections.Generic;

    // Partial class definition for the app_user class
    public partial class app_user
    {
        // Property for storing the user_id as a Guid type
        public System.Guid user_id { get; set; }
        
        // Property for storing the active status as a Nullable byte
        public Nullable<byte> active { get; set; }
        
        // Property for storing the email address as a string
        public string email { get; set; }
        
        // Property for storing the first name as a string
        public string first_name { get; set; }
        
        // Property for storing the last name as a string
        public string last_name { get; set; }
        
        // Property for storing the password as a string
        public string password { get; set; }
    }
}