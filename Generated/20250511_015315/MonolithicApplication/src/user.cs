// Namespace declaration for the UnicornShopLegacy project
namespace UnicornShopLegacy
{
    // Importing necessary libraries
    using System;
    using System.Collections.Generic;

    // Declaring a partial class user
    public partial class user
    {
        // Public property to hold the user ID of type Guid
        public System.Guid user_id { get; set; }
        
        // Public property to hold the email of the user
        public string email { get; set; }
        
        // Public property to hold the first name of the user
        public string first_name { get; set; }
        
        // Public property to hold the last name of the user
        public string last_name { get; set; }
        
        // Public property to hold the password of the user
        public string password { get; set; }
    }
}