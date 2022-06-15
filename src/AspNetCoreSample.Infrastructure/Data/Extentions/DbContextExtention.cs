using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Infrastructure.Data.Extentions
{
    public static class DbContextExtention
    {

        public static bool ContainsEntity<TEntity>(this DbContext dbContext) where  TEntity : class
        {
            return dbContext.Model.FindEntityType(typeof(TEntity)) != null;
        }

        public static int Clear<TEntity>(this DbContext dbContext) where TEntity : class
        {
            return dbContext.ContainsEntity<TEntity>() ? dbContext.Set<TEntity>().Clear() : 0;
        }

        public static IEnumerable<EntityEntry> GetChangedEntities(this DbContext dbContext , EntityState? entityState = null)
        {
            var entities = dbContext.ChangeTracker.Entries();
            if (entityState.HasValue)
                entities = entities.Where(c => c.State == entityState);
            return entities;
        }

        public static IEnumerable<EntityEntry> GetAddedOrModifiedEntities(this DbContext dbContext)
        {
            return dbContext.GetChangedEntities().Where(c => c.State == EntityState.Added || c.State == EntityState.Modified).ToList();
        }

        public static IEnumerable<EntityEntry> GetAddedEntities(this DbContext dbContext)
        {
            return dbContext.GetChangedEntities(EntityState.Added);
        }

        public static IEnumerable<EntityEntry> GetModifiedEntities(this DbContext dbContext)
        {
            return dbContext.GetChangedEntities(EntityState.Modified);
        }

        public static IEnumerable<EntityEntry> GetDeletedEntities(this DbContext dbContext)
        {
            return dbContext.GetChangedEntities(EntityState.Deleted);
        }
    }
}
