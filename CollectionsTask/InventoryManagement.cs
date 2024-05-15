using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTask
{
    public class Inventory
    {
        public int ProductId { get; set; }
        public int QuantityInStock { get; set; }
        // Other properties as needed
    }
    internal class InventoryManagement
    {
        
            private SortedList<int, Inventory> inventoryList;

            public InventoryManagement()
            {
                inventoryList = new SortedList<int, Inventory>();
            }

            public void AddOrUpdateInventory(int productId, int quantity)
            {
                if (inventoryList.ContainsKey(productId))
                    inventoryList[productId].QuantityInStock += quantity;
                else
                    inventoryList.Add(productId, new Inventory { ProductId = productId, QuantityInStock = quantity });
            }

            // Additional methods for inventory management as needed
        }
    }


