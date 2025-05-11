namespace UnicornShopLegacy
{
    using System;
    using System.Collections.Generic;
    
    // Partial class representing the Unicorn Basket entity
    public partial class app_unicorn_basket
    {
        // Properties representing basket_id, user_id, unicorn_id, creation_date, and active status
        public System.Guid basket_id { get; set; }
        public System.Guid user_id { get; set; }
        public System.Guid unicorn_id { get; set; }
        public System.DateTime creation_date { get; set; }
        public Nullable<byte> active { get; set; }
    }
}