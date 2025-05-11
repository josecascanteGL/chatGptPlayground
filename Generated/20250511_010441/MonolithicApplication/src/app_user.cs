// Namespace declaration for the UnicornShopLegacy project
namespace UnicornShopLegacy
{
    // Importing necessary libraries for the code
    using System;
    using System.Collections.Generic;
    
    // Declaring a partial class named app_user
    public partial class app_user
    {
        // Declaring public properties for the app_user class
        // These properties represent different attributes of a user
        public System.Guid user_id { get; set; } // Unique identifier for the user
        public Nullable<byte> active { get; set; } // Indicator of the user's active status
        public string email { get; set; } // Email address of the user
        public string first_name { get; set; } // First name of the user
        public string last_name { get; set; } // Last name of the user
        public string password { get; set; } // Password of the user
    }
}