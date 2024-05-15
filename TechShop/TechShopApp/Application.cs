

using TechShop.Service;

namespace TechShop.TechShopApp
{
    internal class Application
    {
        public void Run()
        {
            CustomerService cs=new CustomerService();
            ProductService ps=new ProductService(); 
            OrderService ors=new OrderService();
            OrderDetailsServie ods=new OrderDetailsServie();
            InventoryService ins=new InventoryService();

            bool flag = true;
            while (flag)
            {
                
                bool flag1 = true;
                Console.WriteLine("----------------------------Welcome to the TechShop Menu-----------------------");
                Console.WriteLine("1.CustomerInterface\n2.ProductInterface\n3.OrderInterface\n4.OrderDetailInterface\n5.InventoryInterface\n6.Exit");
                Console.WriteLine("Choose any One Option");
                int input=int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:

                        while(flag1)
                        {
                            Console.WriteLine("Welcome to the Customer Interface");
                            Console.WriteLine("1.CalculateTotalOrders\n2.GetCustomerDetails\n3.UpdateCustomerInfo\n4.Back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1=int.Parse(Console.ReadLine());
                            switch(input1)
                            {
                                case 1:
                                    cs.CalculateTotalOrders();
                                    break;

                                case 2:
                                    cs.GetCustomerDetails();
                                    break;
                                case 3:
                                    cs.UpdateCustomerInfo();
                                    break;
                                case 4:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;
                       
                    case 2:
                        while (flag1)
                        {
                        Console.WriteLine("Welcome to the Product Interface");
                        Console.WriteLine("1.GetProductDetails\n2.UpdateProductInfo\n3.IsProductInStock\n4.back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ps.GetProductDetails();
                                    break;

                                case 2:
                                    ps.UpdateProductInfo();
                                    break;
                                case 3:
                                    ps.IsProductInStock();
                                    break;
                                case 4:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        while (flag1)
                        {
                            Console.WriteLine("Welcome to the Order Interface");
                            Console.WriteLine("1.CalculateTotalAmount\n2.GetOrderDetails\n3.UpdateOrderStatus\n4.CancelOrder\n5.back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ors.CalculateTotalAmount();
                                    break;

                                case 2:
                                    ors.GetOrderDetails();
                                    break;
                                case 3:
                                    ors.UpdateOrderStatus();
                                    break;
                                case 4:
                                    ors.CancelOrder();
                                    break;

                                case 5:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;

                    case 4:
                        while (flag1)
                        {
                            Console.WriteLine("Welcome to the OrderDetail Interface");
                            Console.WriteLine("1.CalculateSubtotal\n2.GetOrderDetailInfo\n3.UpdateQuantity\n4.AddDiscount\n5.back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ods.CalculateSubtotal();
                                    break;

                                case 2:
                                    ods.GetOrderDetailInfo();
                                    break;
                                case 3:
                                    ods.UpdateQuantity();
                                    break;
                                case 4:
                                    Console.WriteLine("Not done yet");
                                    break;

                                case 5:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;
                    case 5:
                        while (flag1)
                        {
                            Console.WriteLine("Welcome to the Inventory Interface");
                            Console.WriteLine(@"1.GetProduct\n2.GetQuantityInStock\n3.AddToInventory\n4.RemoveFromInventory
                                \n5.UpdateStockQuantity\n6.IsProductAvailable\n7.GetInventoryValue\n8.ListLowStockProducts\n9.ListOutOfStockProducts\n10.ListAllProducts\n11.back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    ins.GetProduct();
                                    break;

                                case 2:
                                    ins.GetQuantityInStock();
                                    break;
                                case 3:
                                    ins.AddToInventory();
                                    break;
                                case 4:
                                    ins.RemoveFromInventory();
                                    break;

                                case 5:
                                    ins.UpdateStockQuantity();
                                    break;
                                case 6:
                                    ins.IsProductAvailable();
                                    break;
                                case 7:
                                    ins.GetInventoryValue();
                                    break;
                                case 8:
                                    ins.ListLowStockProducts();
                                    break;
                                case 9:
                                    ins.ListOutOfStockProducts();
                                    break;
                                case 10:
                                    ins.ListAllProducts();
                                    break;
                                case 11:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;
                   
                    
                    case 6:
                        flag=false;
                        break;
                    default:
                        Console.WriteLine("Enter the Appropriate option");
                        break;


                }

            }

            
        }
    }
}
