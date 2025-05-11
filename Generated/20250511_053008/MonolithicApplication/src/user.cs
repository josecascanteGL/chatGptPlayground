// Namespace declaration for UnicornShopLegacy
namespace UnicornShopLegacy
{
    // Import necessary libraries
    using System;
    using System.Collections.Generic;
    
    // Declare a partial class named user
    public partial class user
    {
        // Declare public properties for user_id, email, first_name, last_name, and password
        public System.Guid user_id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
    }
}