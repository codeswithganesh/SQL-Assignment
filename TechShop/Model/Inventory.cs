

namespace TechShop.Model
{
    internal class Inventory
    {
        private int inventoryId;
        private Products product;
        private int quantityInStock;
        private DateTime lastStockUpdate;

        public int InventoryID
        {
            get { return inventoryId; }
            set { inventoryId = value; }
        }

        public Products Product
        {
            get { return product; }
            set { product = value; }
        }

        public int QuantityInStock
        {
            get { return quantityInStock; }
            set { quantityInStock = value; }
        }

        public DateTime LastStockUpdate
        {
            get { return lastStockUpdate; }
            set { lastStockUpdate = value; }
        }
        public Inventory()
        {
            
        }

        public Inventory(int inventoryId, Products product, int quantityInStock, DateTime lastStockUpdate)
        {
            InventoryID = inventoryId;
            Product = product;
            QuantityInStock = quantityInStock;
            LastStockUpdate = lastStockUpdate;
        }


        public override string ToString()
        {
            return $"InventoryId:{inventoryId}\nProduct{product.ProductName}\nQuantityInStock{QuantityInStock}\nLastStockUpdate{LastStockUpdate}";
        }

    }
}
