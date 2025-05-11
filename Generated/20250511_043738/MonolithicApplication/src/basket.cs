// Namespace declaration for the UnicornShopLegacy namespace
namespace UnicornShopLegacy
{
    // Import statements for using System and System.Collections.Generic namespaces

    // Partial class declaration for the basket class
    public partial class basket
    {
        // Property declaration for basket_id of type System.Guid
        public System.Guid basket_id { get; set; }
        
        // Property declaration for user_id of type System.Guid
        public System.Guid user_id { get; set; }
        
        // Property declaration for unicorn_id of type System.Guid
        public System.Guid unicorn_id { get; set; }
        
        // Property declaration for creation_date of type System.DateTime
        public System.DateTime creation_date { get; set; }
    }
}