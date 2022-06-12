using AspNetCoreSample.Core.Entities;
using AspNetCoreSample.Core.Repositories;
using AspNetCoreSample.Infrastructure.Data;
using AspNetCoreSample.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        public CategoryRepository(AspNetCoreSampleContext dbContext) : base(dbContext)
        {
        }
    }
}
