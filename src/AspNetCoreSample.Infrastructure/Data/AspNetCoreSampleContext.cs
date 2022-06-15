using AspNetCoreSample.Core.Entities;
using AspNetCoreSample.Infrastructure.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Infrastructure.Data
{
    public class AspNetCoreSampleContext : BaseDbContext
    {
        public AspNetCoreSampleContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
