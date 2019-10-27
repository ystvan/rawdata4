using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Data.Repositories;
using Northwind.Shared;
using System;
using System.Linq;
using Xunit;

namespace DataServiceTests
{
    public class DataServiceTests
    {

        public DataServiceTests()
        {
            var options = new DbContextOptionsBuilder<NorthwindDbContext>()
                 .UseNpgsql("host=localhost;db=assignment4;uid=postgres;pwd=password")
                 .Options;
            northwindDbContext = new NorthwindDbContext(options);
        }

        public NorthwindDbContext northwindDbContext { get; }

        /* Categories */

        [Fact]
        public void Category_Object_HasIdNameAndDescription()
        {
            var category = new Category();
            Assert.Equal(0, category.Id);
            Assert.Null(category.Name);
            Assert.Null(category.Description);
        }

        [Fact]
        public void GetAllCategories_NoArgument_ReturnsAllCategories()
        {
            var service = new CategoryRepository(northwindDbContext);
            var categories = service.ListAll();
            Assert.Equal(8, categories.Count());
            Assert.Equal("Beverages", categories.First().Name);
        }

        [Fact]
        public void GetCategory_ValidId_ReturnsCategoryObject()
        {
            var service = new CategoryRepository(northwindDbContext);
            var category = service.GetById(1);
            Assert.Equal("Beverages", category.Name);
        }

        [Fact]
        public void CreateCategory_ValidData_CreteCategoryAndRetunsNewObject()
        {
            var service = new CategoryRepository(northwindDbContext);
            var category = service.AddByNameAndDescription("Test", "CreateCategory_ValidData_CreteCategoryAndRetunsNewObject");
            Assert.True(category.Id > 0);
            Assert.Equal("Test", category.Name);
            Assert.Equal("CreateCategory_ValidData_CreteCategoryAndRetunsNewObject", category.Description);

            // cleanup
            service.DeleteCategory(category.Id);
        }

        //[Fact]
        //public void DeleteCategory_ValidId_RemoveTheCategory()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var category = service.CreateCategory("Test", "DeleteCategory_ValidId_RemoveTheCategory");
        //    var result = service.DeleteCategory(category.Id);
        //    Assert.True(result);
        //    category = service.GetCategory(category.Id);
        //    Assert.Null(category);
        //}

        //[Fact]
        //public void DeleteCategory_InvalidId_ReturnsFalse()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var result = service.DeleteCategory(-1);
        //    Assert.False(result);
        //}

        //[Fact]
        //public void UpdateCategory_NewNameAndDescription_UpdateWithNewValues()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var category = service.CreateCategory("TestingUpdate", "UpdateCategory_NewNameAndDescription_UpdateWithNewValues");

        //    var result = service.UpdateCategory(category.Id, "UpdatedName", "UpdatedDescription");
        //    Assert.True(result);

        //    category = service.GetCategory(category.Id);

        //    Assert.Equal("UpdatedName", category.Name);
        //    Assert.Equal("UpdatedDescription", category.Description);

        //    // cleanup
        //    service.DeleteCategory(category.Id);
        //}

        //[Fact]
        //public void UpdateCategory_InvalidID_ReturnsFalse()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var result = service.UpdateCategory(-1, "UpdatedName", "UpdatedDescription");
        //    Assert.False(result);
        //}


        ///* products */

        //[Fact]
        //public void Product_Object_HasIdNameUnitPriceQuantityPerUnitAndUnitsInStock()
        //{
        //    var product = new Product();
        //    Assert.Equal(0, product.Id);
        //    Assert.Null(product.Name);
        //    Assert.Equal(0.0, product.UnitPrice);
        //    Assert.Null(product.QuantityPerUnit);
        //    Assert.Equal(0, product.UnitInStock);
        //}

        //[Fact]
        //public void GetProduct_ValidId_ReturnsProductWithCategory()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var product = service.GetProduct(1);
        //    Assert.Equal("Chai", product.Name);
        //    Assert.Equal("Beverages", product.Category.Name);
        //}

        //[Fact]
        //public void GetProductsByCategory_ValidId_ReturnsProductWithCategory()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var products = service.GetProductByCategory(1);
        //    Assert.Equal(12, products.Count);
        //    Assert.Equal("Chai", products.First().Name);
        //    Assert.Equal("Beverages", products.First().CategoryName);
        //    Assert.Equal("Lakkalikööri", products.Last().Name);
        //}

        //[Fact]
        //public void GetProduct_NameSubString_ReturnsProductsThatMachesTheSubString()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var products = service.GetProductByName("em");
        //    Assert.Equal(4, products.Count);
        //    Assert.Equal("NuNuCa Nuß-Nougat-Creme", products.First().ProductName);
        //    Assert.Equal("Flotemysost", products.Last().ProductName);
        //}

        ///* orders */
        //[Fact]
        //public void Order_Object_HasIdDatesAndOrderDetails()
        //{
        //    var order = new Order();
        //    Assert.Equal(0, order.Id);
        //    Assert.Equal(new DateTime(), order.Date);
        //    Assert.Equal(new DateTime(), order.Required);
        //    Assert.Null(order.OrderDetails);
        //    Assert.Null(order.ShipName);
        //    Assert.Null(order.ShipCity);
        //}

        //[Fact]
        //public void GetOrder_ValidId_ReturnsCompleteOrder()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var order = service.GetOrder(10248);
        //    Assert.Equal(3, order.OrderDetails.Count);
        //    Assert.Equal("Queso Cabrales", order.OrderDetails.First().Product.Name);
        //    Assert.Equal("Dairy Products", order.OrderDetails.First().Product.Category.Name);
        //}

        //[Fact]
        //public void GetOrders()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var orders = service.GetOrders();
        //    Assert.Equal(830, orders.Count);
        //}


        ///* orderdetails */
        //[Fact]
        //public void OrderDetails_Object_HasOrderProductUnitPriceQuantityAndDiscount()
        //{
        //    var orderDetails = new OrderDetails();
        //    Assert.Equal(0, orderDetails.OrderId);
        //    Assert.Null(orderDetails.Order);
        //    Assert.Equal(0, orderDetails.ProductId);
        //    Assert.Null(orderDetails.Product);
        //    Assert.Equal(0.0, orderDetails.UnitPrice);
        //    Assert.Equal(0.0, orderDetails.Quantity);
        //    Assert.Equal(0.0, orderDetails.Discount);
        //}

        //[Fact]
        //public void GetOrderDetailByOrderId_ValidId_ReturnsProductNameUnitPriceAndQuantity()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var orderDetails = service.GetOrderDetailsByOrderId(10248);
        //    Assert.Equal(3, orderDetails.Count);
        //    Assert.Equal("Queso Cabrales", orderDetails.First().Product.Name);
        //    Assert.Equal(14, orderDetails.First().UnitPrice);
        //    Assert.Equal(12, orderDetails.First().Quantity);
        //}

        //[Fact]
        //public void GetOrderDetailByProductId_ValidId_ReturnsOrderDateUnitPriceAndQuantity()
        //{
        //    var service = new EntityFrameworkRepository();
        //    var orderDetails = service.GetOrderDetailsByProductId(11);
        //    Assert.Equal(38, orderDetails.Count);
        //    Assert.Equal("1997-05-06", orderDetails.First().Order.Date.ToString("yyyy-MM-dd"));
        //    Assert.Equal(21, orderDetails.First().UnitPrice);
        //    Assert.Equal(3, orderDetails.First().Quantity);
        //}
    }
}
