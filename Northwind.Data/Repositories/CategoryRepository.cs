using Northwind.Shared;

namespace Northwind.Data.Repositories
{
    public class CategoryRepository : EntityFrameworkRepository<Category>
    {
        public CategoryRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
        }

        public Category AddByNameAndDescription(string name, string description)
        {
            var category = new Category { Name = name, Description = description };

            _dbContext.Set<Category>().Add(category);
            _dbContext.SaveChanges();

            return category;
        }
        public bool DeleteCategory(int id)
        {
            bool isSuccess = true;

            var match = _dbContext.Set<Category>().Find(id);
            if (match != null)
            {
                _dbContext.Set<Category>().Remove(match);
                _dbContext.SaveChanges();

                return isSuccess;
            }
            else
            {
                return !isSuccess;
            }            
        }
    }
}
