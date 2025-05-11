namespace UnicornShopLegacy
{
    using System;
    using System.Collections.Generic;
    
    public partial class app_user
    {
        // Define properties for the user_id, active, email, first_name, last_name, and password
        public System.Guid user_id { get; set; }
        public Nullable<byte> active { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
    }
} 

In this code, a class named "app_user" is defined with properties for user information such as user_id, active status, email, first name, last name, and password. These properties will be used to store and manipulate user data in the UnicornShopLegacy application.