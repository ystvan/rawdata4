using Microsoft.EntityFrameworkCore;
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

        public bool UpdateCategory(int id, string name, string description)
        {
            name.ThrowIfParameterIsNullOrWhiteSpace(nameof(name));
            description.ThrowIfParameterIsNullOrWhiteSpace(nameof(description));

            bool isSuccess = true;

            var match = _dbContext.Set<Category>().Find(id);

            if (match != null)
            {
                match.Name = name;
                match.Description = description;
                _dbContext.Entry(match).State = EntityState.Modified;
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
