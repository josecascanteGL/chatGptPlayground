// Namespace declaration for the UnicornShopLegacy namespace
namespace UnicornShopLegacy
{
    // Importing necessary classes from the System namespace
    using System;
    using System.Collections.Generic;
    
    // Partial class user declaration
    public partial class user
    {
        // Declaration of public property user_id of type Guid
        public System.Guid user_id { get; set; }
        
        // Declaration of public property email of type string
        public string email { get; set; }
        
        // Declaration of public property first_name of type string
        public string first_name { get; set; }
        
        // Declaration of public property last_name of type string
        public string last_name { get; set; }
        
        // Declaration of public property password of type string
        public string password { get; set; }
    }
}