namespace UnicornShopLegacy
{
    using System;  // Importing the System namespace
    using System.Collections.Generic;  // Importing the System.Collections.Generic namespace
    
    public partial class app_unicorn_basket  // Defining a partial class named app_unicorn_basket
    {
        public System.Guid basket_id { get; set; }  // Declaring a property basket_id of type Guid
        public System.Guid user_id { get; set; }  // Declaring a property user_id of type Guid
        public System.Guid unicorn_id { get; set; }  // Declaring a property unicorn_id of type Guid
        public System.DateTime creation_date { get; set; }  // Declaring a property creation_date of type DateTime
        public Nullable<byte> active { get; set; }  // Declaring a nullable property active of type byte
    }
}

// This code snippet is a C# class definition for the app_unicorn_basket class. The class contains properties for basket_id, user_id, unicorn_id, creation_date, and active. These properties are used to store information related to a user's unicorn basket. The properties are of types Guid, DateTime, and Nullable<byte>, which are commonly used data types in C#. The class is defined in the UnicornShopLegacy namespace.