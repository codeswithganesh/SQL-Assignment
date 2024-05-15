

using System.Diagnostics;
using TechShop.Model;

namespace TechShop.Repository
{
    internal interface IProductsRepository
    {
        public List<Products> GetProductDetails();
        public int UpdateProductInfo(Products product);

        public int IsProductInStock(int productid);

        public bool IsValidProductInfo(string productName, double price);



    }
}
