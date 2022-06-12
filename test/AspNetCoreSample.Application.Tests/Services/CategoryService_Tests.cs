using AspNetCoreSample.Application.Categories;
using AspNetCoreSample.Application.Categories.Dto;
using AspNetCoreSample.Core.Entities;
using AspNetCoreSample.Core.Repositories;
using AspNetCoreSample.Core.Repositories.Base;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreSample.Application.Tests.Services
{
    public class CategoryService_Tests
    {
        private Mock<ICategoryService> _mockCategoryServ;
        private Mock<ICategoryRepository> _mockCategoryRepo;


        public CategoryService_Tests()
        {
            _mockCategoryServ = new Mock<ICategoryService>();
            _mockCategoryRepo = new Mock<ICategoryRepository>();
        }

        [Fact]
        public async Task Should_return_all_products()
        {
            var categories = new List<Category>() { new Category(), new Category() };

            _mockCategoryRepo.Setup(repo => repo.GetAllAsync())
                .Returns(Task.FromResult<IReadOnlyList<Category>>(categories));

            var categoryService = new CategoryService(_mockCategoryRepo.Object);
            var productList = await categoryService.GetCategoryList();

            Assert.Equal(2, productList.Count());
        }
    }
}
