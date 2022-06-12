using AspNetCoreSample.Application.Categories;
using AspNetCoreSample.Application.Products;
using AspNetCoreSample.Application.Products.Dto;
using AspNetCoreSample.Core.Entities;
using AspNetCoreSample.Core.Repositories;
using AspNetCoreSample.Core.Repositories.Base;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreSample.Application.Tests.Services
{

    public class ProductService_Tests
    {

        private Mock<IProductRepository> _mockProductRepo;
        

        private Mock<IProductService> _mockProductServ;
        


        public ProductService_Tests()
        {
            _mockProductRepo = new Mock<IProductRepository>();
 
            _mockProductServ = new Mock<IProductService>();
 
        }


        [Fact]
        public async Task Should_return_all_products()
        {
            var products = new List<Product>() { new Product(), new Product() };

            _mockProductRepo.Setup(repo => repo.GetAllAsync())
                .Returns(Task.FromResult<IReadOnlyList<Product>>(products));

            var productService = new ProductService(_mockProductRepo.Object);
            var productList = await productService.GetProductList();

            Assert.Equal(2, productList.Count());             
        }

        [Fact]
        public async Task Should_create_New_Product()
        {

            var product = new ProductDto() { ProductName = "Apple", Price = 100, CategoryId = 1 };
 
            _mockProductServ.Setup(r => r.CreateProduct(product))
                .Returns(Task.FromResult(product));
            var newProduct = _mockProductServ.Object.CreateProduct(product);

            _mockProductServ.Verify(x => x.CreateProduct(It.IsAny<ProductDto>()), Times.Once);
            Assert.NotNull(newProduct);
        }

        

    }
}
