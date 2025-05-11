// Include necessary using directives
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnicornShopLegacy
{
    // Define class OrderProcessor
    public class OrderProcessor
    {
        // Define method ProcessOrder with List of Order parameter
        public void ProcessOrder(List<Order> orders)
        {
            // Loop through each Order object in the orders List
            foreach (var order in orders)
            {
                // Check if Order total is greater than 1000
                if (order.Total > 1000)
                {
                    // Create a new instance of HighValueOrder and assign the current Order object
                    HighValueOrder highValueOrder = new HighValueOrder(order);
                    // Process the high value order
                    highValueOrder.Process();
                }
                else
                {
                    // Process the regular order
                    order.Process();
                }
            }
        }
    }
}