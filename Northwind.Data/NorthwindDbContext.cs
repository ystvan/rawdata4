using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Shared;

namespace Northwind.Data
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;db=assignment4;uid=postgres;pwd=password");
        }

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
           : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(ConfigureCategory);            
            builder.Entity<Product>(ConfigureProduct);
            builder.Entity<Order>(ConfigureOrder);
            builder.Entity<OrderDetails>(ConfigureOrderDetails);
            builder.HasSequence<int>("OrderNumbers").StartsAt(9).IncrementsBy(1);
        }

        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("categories");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("categoryid")
                .HasDefaultValueSql("nextval('\"OrderNumbers\"')");               

            builder
                .Property(x => x.Name)
                .HasColumnName("categoryname");

            builder
                .Property(x => x.Description)
                .HasColumnName("description");
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("products");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("productid");

            builder
                .Property(x => x.Name)
                .HasColumnName("productname");

            builder
                .Property(x => x.UnitInStock)
                .HasColumnName("unitinstock");

            builder
                .Property(x => x.UnitPrice)
                .HasColumnName("unitprice");

            builder
                .Property(x => x.QuantityPerUnit)
                .HasColumnName("quantityperunit");

            builder
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureOrder(EntityTypeBuilder<Order> builder) 
        {
            builder
                .ToTable("orders");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Date)
                .HasColumnName("orderdate");

            builder
                .Property(x => x.Required)
                .HasColumnName("requireddate");

            builder
                .Property(x => x.Shipped)
                .HasColumnName("shippeddate");

            builder
                .Property(x => x.Freight)
                .HasColumnName("freight");

            builder
                .Property(x => x.ShipName)
                .HasColumnName("shipname");

            builder
                .Property(x => x.ShipCity)
                .HasColumnName("shipcity");
        }

        private void ConfigureOrderDetails(EntityTypeBuilder<OrderDetails> builder)
        {
            builder
                .ToTable("orderdetails");

            builder
                .HasKey(x => new { x.ProductId, x.OrderId });

            builder
                .Property(x => x.ProductId)
                .HasColumnName("productid");

            builder
                .Property(x => x.OrderId)
                .HasColumnName("orderid");

            builder
                .Property(x => x.UnitPrice)
                .HasColumnName("unitprice");

            builder
                .Property(x => x.Quantity)
                .HasColumnName("quantity");

            builder
                .Property(x => x.Discount)
                .HasColumnName("discount");
        }
    }
}
