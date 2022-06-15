using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Infrastructure.Data.Extentions
{
    public static class DbSetExtention
    {
        public static DbContext GetDbContext<TEntity>(this DbSet<TEntity> dbset) where TEntity : class
        {
            var infrastructure = dbset as  IInfrastructure<IServiceProvider>;
            var serviceProvider = infrastructure.Instance;

            var currentDbContect = serviceProvider.GetService(typeof(ICurrentDbContext)) as ICurrentDbContext;
            
            return currentDbContect.Context;
        }

        public static int Clear<TEntity>(this DbSet<TEntity> dbset) where TEntity : class
        {
            var dbcontext = dbset.GetDbContext();
            var relationalType = dbcontext.Model.FindEntityType(typeof(TEntity));
            var schema = string.IsNullOrEmpty(relationalType.GetSchema()) ? "dbo": relationalType.GetSchema();
            var tableName = string.IsNullOrEmpty(relationalType.GetTableName()) ? typeof(TEntity).Name : relationalType.GetTableName();
            var result = dbcontext.Database.ExecuteSqlRaw($"delete {schema}.{tableName}");
            return result;
        }
    }
}
