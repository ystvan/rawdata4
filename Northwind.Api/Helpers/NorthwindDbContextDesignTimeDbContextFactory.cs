using Microsoft.EntityFrameworkCore;
using Northwind.Data;

namespace Northwind.Api.Helpers
{
    public class NorthwindDbContextDesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<NorthwindDbContext>
    {
        protected override NorthwindDbContext CreateNewInstance(DbContextOptions<NorthwindDbContext> options)
        {
            return new NorthwindDbContext(options);
        }
    }
}
