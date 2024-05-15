using TechShop.Service;
using TechShop.TechShopApp;
namespace TechShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderService osd=new OrderService();
            osd.CancelOrder();
            //Application app = new Application();
            //app.Run();




        }
    }
}
