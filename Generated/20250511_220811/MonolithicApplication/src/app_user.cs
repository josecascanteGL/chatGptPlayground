//Namespace declaration for the UnicornShopLegacy namespace
namespace UnicornShopLegacy
{
    //Importing necessary libraries
    using System;
    using System.Collections.Generic;
    
    //Creating a partial class named app_user
    public partial class app_user
    {
        //Defining properties for the app_user class
        public System.Guid user_id { get; set; } //Property for storing user id as Guid
        public Nullable<byte> active { get; set; } //Property for storing user's active status as Nullable byte
        public string email { get; set; } //Property for storing user's email as string
        public string first_name { get; set; } //Property for storing user's first name as string
        public string last_name { get; set; } //Property for storing user's last name as string
        public string password { get; set; } //Property for storing user's password as string
    }
}