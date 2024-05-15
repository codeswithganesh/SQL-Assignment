

using TechShop.Model;

namespace TechShop.Service
{
    internal interface IProductService
    {
        public void GetProductDetails();
        public void UpdateProductInfo();
        public void IsProductInStock();
        
    }
}
