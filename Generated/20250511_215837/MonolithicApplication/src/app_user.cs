// This code defines a partial class 'app_user' which represents a user entity in the application
using System; // Importing the System namespace for basic .NET functionality
using System.Collections.Generic; // Importing the System.Collections.Generic namespace for using collections

namespace UnicornShopLegacy // Defining the namespace for the class
{
    public partial class app_user // Declaring the partial class 'app_user'
    {
        public System.Guid user_id { get; set; } // Property to store the unique identifier for the user
        public Nullable<byte> active { get; set; } // Property to store the active status of the user
        public string email { get; set; } // Property to store the email address of the user
        public string first_name { get; set; } // Property to store the first name of the user
        public string last_name { get; set; } // Property to store the last name of the user
        public string password { get; set; } // Property to store the password of the user
    }
}