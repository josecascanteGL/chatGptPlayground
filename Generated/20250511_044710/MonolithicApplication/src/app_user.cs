// Namespace declaration for the UnicornShopLegacy project
namespace UnicornShopLegacy
{
    // Importing necessary namespaces
    using System;
    using System.Collections.Generic;
    
    // Partial class definition for the app_user class
    public partial class app_user
    {
        // Property to store a unique identifier for the user
        public System.Guid user_id { get; set; }
        
        // Property to store a nullable byte indicating if the user is active
        public Nullable<byte> active { get; set; }
        
        // Property to store the email address of the user
        public string email { get; set; }
        
        // Property to store the first name of the user
        public string first_name { get; set; }
        
        // Property to store the last name of the user
        public string last_name { get; set; }
        
        // Property to store the password of the user
        public string password { get; set; }
    }
}