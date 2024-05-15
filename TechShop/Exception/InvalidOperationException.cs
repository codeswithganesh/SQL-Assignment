
namespace TechShop.Exception
{
    internal class InvalidOperationException:IOException
    {
        public InvalidOperationException(string message) : base(message)
        {
        }
    }
}
