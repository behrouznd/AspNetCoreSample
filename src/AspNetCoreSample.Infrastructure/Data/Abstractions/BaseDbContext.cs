using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Infrastructure.Data.Abstractions
{
    public abstract class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
        public override int SaveChanges()
        {
            BeforeSave();
            var result = base.SaveChanges();
            AfterSave();
            return result;
        }

        public virtual void BeforeSave()
        {

        }

        public virtual void AfterSave()
        {

        }
    }
}
