namespace Catalog.API.Exceptions
{
    public class ProductNotFoundException: Exception
    {
        public ProductNotFoundException(): base("Not found!")
        {

        }
    }
}
