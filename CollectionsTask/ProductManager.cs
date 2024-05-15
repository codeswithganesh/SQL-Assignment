using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTask
{
    internal class ProductManager
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string SKU { get; set; }
            // Other properties as needed
        }
        public class ProductManager
        {
            private List<Product> products;

            public ProductManager()
            {
                products = new List<Product>();
            }

            public void Add(Product product)
            {
                if (products.Any(p => p.Name == product.Name || p.SKU == product.SKU))
                {
                    throw new InvalidOperationException("Product with the same name or SKU already exists.");
                }

                products.Add(product);
            }

            // Custom search method using LINQ queries
            public List<Product> Search(string keyword)
            {
                return products.Where(p => p.Name.Contains(keyword) || p.SKU.Contains(keyword)).ToList();
            }
        }
    }

}
}
