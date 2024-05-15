

namespace TechShop.Exception
{
    internal class InvalidDataException : IOException
    {
        public InvalidDataException(string message) : base(message)
        {
        }
    }
}
