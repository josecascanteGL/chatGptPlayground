namespace UnicornShopLegacy
{
    // Import necessary namespaces
    using System;
    using System.Collections.Generic;

    // Define a partial class app_unicorn_basket
    public partial class app_unicorn_basket
    {
        // Define properties for basket_id, user_id, unicorn_id, creation_date, and active
        public System.Guid basket_id { get; set; }
        public System.Guid user_id { get; set; }
        public System.Guid unicorn_id { get; set; }
        public System.DateTime creation_date { get; set; }
        public Nullable<byte> active { get; set; }
    }
}