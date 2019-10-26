using Northwind.Shared;

namespace Northwind.Data.Repositories.Generics
{
    public class ProductRepository : EntityFrameworkRepository<Product>
    {
        public ProductRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
        }
    }
}
