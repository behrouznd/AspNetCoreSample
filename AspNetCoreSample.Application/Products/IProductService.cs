using AspNetCoreSample.Application.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Application.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductList();
        Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId);
        Task<ProductDto> CreateProduct(ProductDto productDto);
        Task UpdateProduct(ProductDto productDto);
        Task DeleteProduct(ProductDto productDto);

    }
}
