using AspNetCoreSample.Application.Products.Dto;
using AspNetCoreSample.Core.Entities;
using AspNetCoreSample.Core.Repositories;
using AutoMapper;

namespace AspNetCoreSample.Application.Products
{
 
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task<ProductDto> CreateProduct(ProductDto productDto)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<ProductDto, Product>(); }).CreateMapper();           
            var mappedEntity = mapper.Map<ProductDto, Product>(productDto);
            var newEntity = await _productRepository.AddAsync(mappedEntity);

            var newMappedEntity = mapper.Map<Product, ProductDto>(newEntity);
            return newMappedEntity;

        }

        public async Task DeleteProduct(ProductDto productDto)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<ProductDto, Product>(); }).CreateMapper();
            var deletedProduct = mapper.Map<ProductDto, Product>(productDto);
            await _productRepository.DeleteAsync(deletedProduct);
        }

        public async Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Product, ProductDto>(); }).CreateMapper();
            var productList = await _productRepository.GetAsync(x => x.CategoryId == categoryId);
            var mapped = mapper.Map<IEnumerable<Product>, IEnumerable< ProductDto>> (productList);
            return mapped;
        }

        public async Task<IEnumerable<ProductDto>> GetProductList()
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<Product, ProductDto>(); }).CreateMapper();
            var productList = await _productRepository.GetAllAsync();
            var mapped = mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<ProductDto, Product>(); }).CreateMapper();
            var editProduct = await _productRepository.GetByIdAsync(productDto.Id);
            mapper.Map<ProductDto, Product>(productDto, editProduct);
            await _productRepository.UpdateAsync(editProduct);
        }
    }
}
