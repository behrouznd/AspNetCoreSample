using AspNetCoreSample.Application.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Application.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoryList();

    }
}
