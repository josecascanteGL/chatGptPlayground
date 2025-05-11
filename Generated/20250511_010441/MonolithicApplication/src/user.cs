// This section includes the necessary using directives for the namespace
// System namespace is used for fundamental data types and basic functionalities
// System.Collections.Generic namespace is used for generic collections such as List, Dictionary, etc.

namespace UnicornShopLegacy
{
    using System;
    using System.Collections.Generic;
    
    // This class represents a user entity in the Unicorn Shop application
    public partial class user
    {
        // Properties representing the user attributes with their respective data types
        public System.Guid user_id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
    }
}