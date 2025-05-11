// Namespace declaration for the UnicornShopLegacy
namespace UnicornShopLegacy
{
    // Importing necessary libraries
    using System;
    using System.Collections.Generic;
    
    // Partial class definition for the user class
    public partial class user
    {
        // Property for storing user ID as a Guid data type
        public System.Guid user_id { get; set; }
        
        // Property for storing user email as a string data type
        public string email { get; set; }
        
        // Property for storing user first name as a string data type
        public string first_name { get; set; }
        
        // Property for storing user last name as a string data type
        public string last_name { get; set; }
        
        // Property for storing user password as a string data type
        public string password { get; set; }
    }
}