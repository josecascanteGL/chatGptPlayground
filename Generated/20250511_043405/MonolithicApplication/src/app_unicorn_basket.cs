```c#
namespace UnicornShopLegacy
{
    using System;
    using System.Collections.Generic;
    
    // Partial class representing the app_unicorn_basket entity
    public partial class app_unicorn_basket
    {
        // Properties representing the various attributes of the basket entity
        public System.Guid basket_id { get; set; } // Unique identifier for the basket
        public System.Guid user_id { get; set; } // Identifier for the user associated with the basket
        public System.Guid unicorn_id { get; set; } // Identifier for the unicorn in the basket
        public System.DateTime creation_date { get; set; } // Date and time when the basket was created
        public Nullable<byte> active { get; set; } // Indicates if the basket is active or not
    }
}
```

In this code snippet, a partial class `app_unicorn_basket` is defined within the `UnicornShopLegacy` namespace. This class represents the entity of a basket in the Unicorn Shop legacy system. Each property within the class corresponds to a specific attribute of the basket entity such as `basket_id`, `user_id`, `unicorn_id`, `creation_date`, and `active`. The properties are defined with their respective data types such as `System.Guid` for unique identifiers and `System.DateTime` for date and time values. The `active` property is a nullable byte, allowing it to be null or contain a byte value.

The purpose of this class is to model the basket entity, defining its attributes and their data types for use within the legacy system.