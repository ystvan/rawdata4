using Northwind.Shared;

namespace Northwind.Data.Repositories
{
    public class CategoryRepository : EntityFrameworkRepository<Category>
    {
        public CategoryRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
        }
    }
}
