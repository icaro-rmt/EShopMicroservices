using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPrecongfiguredProducts());

            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPrecongfiguredProducts() => new List<Product>() {
            new Product()
            {
                Id = new Guid("207cf9dc-32a2-4e5f-9126-ae29fb08d4f2"),
                Name = "Samsung Galaxy S21",
                Description = "Flagship smartphone from Samsung with powerful specifications.",
                ImageFile = "galaxy_s21.jpg",
                Price = 899.99M,
                Category = new List<string>{"Smartphone"},
            },
            new Product()
            {
                Id = new Guid("bfb92e1e-4f25-4a6f-841d-684b4c42ef24"),
                Name = "Google Pixel 6",
                Description = "Google's latest Pixel phone known for its exceptional camera capabilities.",
                ImageFile = "pixel6.jpg",
                Price = 799.00M,
                Category = new List<string>{"Smartphone"},
            },
            new Product()
            {
                Id = new Guid("d13637e3-d268-4a30-81c2-38e10c18db1b"),
                Name = "Apple Watch Series 7",
                Description = "The newest Apple Watch with advanced health and fitness features.",
                ImageFile = "apple_watch_series7.jpg",
                Price = 399.00M,
                Category = new List<string>{"Smartwatch"},
            },
            new Product()
            {
                Id = new Guid("e4c18f7b-6a7a-4da5-9d14-ae48a622ab58"),
                Name = "Samsung Galaxy Watch 4",
                Description = "Samsung's latest smartwatch with a sleek design and comprehensive health tracking.",
                ImageFile = "galaxy_watch4.jpg",
                Price = 349.99M,
                Category = new List<string>{"Smartwatch"},
            },
            new Product()
            {
                Id = new Guid("f7b9e25b-82d0-4ef3-a3f2-50a67b663a94"),
                Name = "Dell XPS 15",
                Description = "High-performance laptop with a stunning display and powerful hardware.",
                ImageFile = "dell_xps15.jpg",
                Price = 1699.99M,
                Category = new List<string>{"Laptop"},
            },
            new Product()
            {
                Id = new Guid("9fc34a5d-8e4d-4d86-b12d-76c5e79b92a0"),
                Name = "MacBook Pro 16-inch",
                Description = "Apple's professional-grade laptop with exceptional performance and battery life.",
                ImageFile = "macbook_pro16.jpg",
                Price = 2399.00M,
                Category = new List<string>{"Laptop"},
            },
        };
    }
}
