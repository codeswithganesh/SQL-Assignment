using System;
using System.Threading.Channels;
using TechShop.Model;
using TechShop.Repository;
namespace TechShop.Service
{
    internal class ProductService:IProductService
    {
        readonly IProductsRepository _productsRepository;
        public ProductService()
        {
            _productsRepository = new ProductRepository();
        }
        public void GetProductDetails()
        {
            List<Products> products = _productsRepository.GetProductDetails();
            foreach (Products product in products)
            {
                Console.WriteLine(product);
            }

        }
        public void UpdateProductInfo()
        {
            try
            {
                Products products = new Products();
                Console.WriteLine("Enter the ProductId");
                products.ProductID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the ProductNAme");
                products.ProductName = Console.ReadLine();
                Console.WriteLine("Enter the Upadted Descrption for Product");
                products.Description = Console.ReadLine();
                Console.WriteLine("Enter the Updated Product Price");
                products.Price = double.Parse(Console.ReadLine());
                int status = _productsRepository.UpdateProductInfo(products);
                if (status > 0)
                {
                    Console.WriteLine($"{status} Rows Updated Sucessfully");
                }
                else
                {
                    Console.WriteLine("Not updated please check your input  try after some time");
                }

            }
            catch(InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void IsProductInStock()
        {
            Console.WriteLine("Enter the ProductId");
            int id= int.Parse(Console.ReadLine());
            int result=_productsRepository.IsProductInStock(id);
            if(result>0)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

       

        }
    }

