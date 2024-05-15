using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTask
{
    internal class DuplicateProductHandling
    {
      
            private List<Product> products;

            public DuplicateProductHandling()
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
        }
    }

}
}
