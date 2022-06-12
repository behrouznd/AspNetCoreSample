using AspNetCoreSample.Application.Base;
using AspNetCoreSample.Application.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Application.Categories.Dto
{
    public class CategoryDto : EntityDto
    {
        public string CategoryName { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
    }
}
