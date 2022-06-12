using AspNetCoreSample.Core.Entities;
using AspNetCoreSample.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
