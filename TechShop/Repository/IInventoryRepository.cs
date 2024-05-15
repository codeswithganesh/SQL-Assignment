using TechShop.Model;
namespace TechShop.Repository
{
    internal interface IInventoryRepository
    {
        public string GetProduct(int id);
        public int GetQuantityInStock(int id);

        public int AddToInventory(Inventory inventory);

        public int RemoveFromInventory(int quantity);

        public int UpdateStockQuantity(int newQuantity, int inventoryid);

        public int IsProductAvailable(int quantityToCheck);

        public double GetInventoryValue();

        public List<string> ListLowStockProducts(int threshold);

        public List<string> ListOutOfStockProducts();

        public List<string> ListAllProducts();
    }


}
