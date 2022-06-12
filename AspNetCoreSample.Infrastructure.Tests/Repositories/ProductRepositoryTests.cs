using AspNetCoreSample.Core.Entities;
using AspNetCoreSample.Infrastructure.Data;
using AspNetCoreSample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreSample.Infrastructure.Tests.Repositories
{
    public class ProductRepositoryTests
    {

        private AspNetCoreSampleContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AspNetCoreSampleContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
            var dbContext = new AspNetCoreSampleContext(options);
            return dbContext;
        }


        [Fact]
        public async Task Should_Remove_Product()
        {

            var dbContext = CreateDbContext();
            var productRepo = new ProductRepository(dbContext);
            var product = new Product { ProductName = "Apple", Price = 100 };

            var result = await productRepo.AddAsync(product);
            await productRepo.DeleteAsync(product);
            var isExists = dbContext.Products.Any(p => p.Id == result.Id);

            Assert.False(isExists);

            dbContext.Dispose();
        }

        [Fact]

        public async void Should_update_a_product()
        {
            var expected = 200;
            var dbContext = CreateDbContext();
            var productRepo = new ProductRepository(dbContext);
            var product = new Product { ProductName = "Apple", Price = 100 };

            var result = await productRepo.AddAsync(product);
            result.Price = expected;
            await productRepo.UpdateAsync(result);
            result = dbContext.Products.First(p => p.Id == result.Id);

            Assert.Equal(expected, result.Price);

            dbContext.Dispose();
        }
    }
}
