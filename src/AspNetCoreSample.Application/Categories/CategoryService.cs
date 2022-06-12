using AspNetCoreSample.Application.Categories.Dto;
using AspNetCoreSample.Core.Entities;
using AspNetCoreSample.Core.Repositories;
using AutoMapper;

namespace AspNetCoreSample.Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryList()
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Category, CategoryDto>(); }).CreateMapper();

            var category = await _categoryRepository.GetAllAsync();
            var mapped = mapper.Map<IEnumerable<CategoryDto>>(category);
            return mapped;
        }
    }
}
