// Namespace declaration for the UnicornShopLegacy project
namespace UnicornShopLegacy
{
    // Importing necessary namespaces
    using System;
    using System.Collections.Generic;
    
    // Partial class definition for the app_user class
    public partial class app_user
    {
        // Property to store the user ID as a Guid data type
        public System.Guid user_id { get; set; }
        
        // Property to store the active status of the user as a nullable byte
        public Nullable<byte> active { get; set; }
        
        // Property to store the email address of the user as a string
        public string email { get; set; }
        
        // Property to store the first name of the user as a string
        public string first_name { get; set; }
        
        // Property to store the last name of the user as a string
        public string last_name { get; set; }
        
        // Property to store the password of the user as a string
        public string password { get; set; }
    }
}