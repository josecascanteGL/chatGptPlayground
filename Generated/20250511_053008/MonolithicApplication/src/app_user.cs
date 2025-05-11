// Namespace declaration
namespace UnicornShopLegacy
{
    // Import necessary libraries
    using System;
    using System.Collections.Generic;

    // Partial class definition for app_user
    public partial class app_user
    {
        // Properties representing columns in the database table
        public System.Guid user_id { get; set; }
        public Nullable<byte> active { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
    }
}