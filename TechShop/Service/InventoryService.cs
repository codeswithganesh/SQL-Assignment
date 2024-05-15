
using TechShop.Model;
using TechShop.Repository;

namespace TechShop.Service
{ 
    internal class InventoryService:IInventoryService
    {
    readonly IInventoryRepository _inventoryRepository;
    public InventoryService()
    {
        _inventoryRepository = new InventoryRepository();
    }
    public void GetProduct()
        {
            Console.WriteLine("Enter the InventoryId:");
            int id=int.Parse(Console.ReadLine());
        string result=_inventoryRepository.GetProduct(id);
        if(result != null)
        {
            Console.WriteLine($"The Product Associated with the {id} is {result}");
        }
        else
        {
            Console.WriteLine("Cannot find the Product with Inputed Id");
        }

        }
        public void GetQuantityInStock()
        {
            Console.WriteLine("Enter the InventoryId:");
            int id = int.Parse(Console.ReadLine());
            int result=_inventoryRepository.GetQuantityInStock(id);
            if (result > 0)
            {
                Console.WriteLine($"The QuantityInStock associated with the InventoryId{id} is ::{result}");
            }
            else
            {
                Console.WriteLine($"Stock is {result}");
            }

        }

        public void AddToInventory()
        {
            Inventory inventory=new Inventory();
            Console.WriteLine("Enter the InventoryId");
            inventory.InventoryID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the ProductId");
            inventory.Product.ProductID= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the QuantityInStock");
            inventory.QuantityInStock= int.Parse(Console.ReadLine());
            inventory.LastStockUpdate= DateTime.Now;
            int status = _inventoryRepository.AddToInventory(inventory);
            if(status>0)
            {
                Console.WriteLine($"{status} rows Inserted Sucessfully");
            }
            else
            {
                Console.WriteLine("No rows Inserted");
            }
        }

        public void RemoveFromInventory()
        {
            Console.WriteLine("Enter the Quantity");
            int quantity=int.Parse(Console.ReadLine());
            int result=_inventoryRepository.RemoveFromInventory(quantity);
            Console.WriteLine($"{result} rows removed ");
        }

        public void UpdateStockQuantity()
        {
            Console.WriteLine("Enter the InventorryId") ;
            int id=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Updated Quantity");
            int quantity = int.Parse(Console.ReadLine());
            int result=_inventoryRepository.UpdateStockQuantity(quantity,id);
            Console.WriteLine($"{result} rows Updated");

        }

        public void IsProductAvailable()
        {
            Console.WriteLine("Enter the Quantity TO Check");
            int quantity= int.Parse(Console.ReadLine());
            int result=_inventoryRepository.IsProductAvailable(quantity);
            if(result>0)
            {
                Console.WriteLine($" Yes Products avilable with the stock of {quantity}");
            }
            else
            {
                Console.WriteLine("Not Present");
            }
        }

        public void GetInventoryValue()
        {
            double result = _inventoryRepository.GetInventoryValue();
            Console.WriteLine($"Inventory Value is {result}");
        }

        public void ListLowStockProducts()
        {
            List<string> products = new List<string>();
            Console.WriteLine("Enter the Threshold Value for the Quantity");
            int value=int.Parse(Console.ReadLine());
            products=_inventoryRepository.ListLowStockProducts(value);
            Console.WriteLine($"The Products with the threshold value less than {value} is::");
            foreach (string product in products)
            {
                Console.WriteLine(product);
             }
        }
        public void ListOutOfStockProducts()
        {
            List<string> products = new List<string>();
            products = _inventoryRepository.ListOutOfStockProducts();
            Console.WriteLine($"The Products with Out of Stock is::");
            foreach (string product in products)
            {
                Console.WriteLine(product);
            }
        }

         public void ListAllProducts()
        {
            List<string> products = new List<string>();
            products = _inventoryRepository.ListAllProducts();
            Console.WriteLine("The Inventory PRoducts with thier Quantity is::");
            foreach (string product in products)
            {
                Console.WriteLine(product);
            }

        }
    }
}

