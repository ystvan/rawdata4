using Northwind.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Data.Repositories
{
    public class ProductRepository : EntityFrameworkRepository<Product>
    {
        public ProductRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
        }
    }
}
