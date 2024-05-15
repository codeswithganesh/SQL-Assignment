using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTask
{
    internal class HandlingInventories
    {
        
            // Existing code

            // Method to update inventory quantities when orders are processed
            public void UpdateInventory(Order order, InventoryManagement inventoryManager)
            {
                foreach (var item in order.Items)
                {
                    inventoryManager.AddOrUpdateInventory(item.ProductId, -item.Quantity);
                }
            }
        }
    }

}
}
