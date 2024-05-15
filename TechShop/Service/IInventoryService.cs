using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Service
{
    internal interface IInventoryService
    {
        public void GetProduct();
        public void GetQuantityInStock();
        public void AddToInventory();
        public void RemoveFromInventory();
        public void UpdateStockQuantity();

        public void IsProductAvailable();
        public void GetInventoryValue();

        public void ListLowStockProducts();
        public void ListOutOfStockProducts();

        public void ListAllProducts();
    }
}
