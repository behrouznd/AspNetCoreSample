using AspNetCoreSample.Application.Base;
using AspNetCoreSample.Application.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Application.Products.Dto
{
    public class ProductDto : EntityDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
