// Namespace declaration
namespace UnicornShopLegacy
{
    // Importing necessary libraries
    using System;
    using System.Collections.Generic;

    // Partial class declaration for user
    public partial class user
    {
        // Properties declaration for user class
        public System.Guid user_id { get; set; } // Property for user's unique identifier
        public string email { get; set; } // Property for user's email address
        public string first_name { get; set; } // Property for user's first name
        public string last_name { get; set; } // Property for user's last name
        public string password { get; set; } // Property for user's password
    }
}