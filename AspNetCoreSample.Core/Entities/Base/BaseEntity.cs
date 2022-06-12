namespace AspNetCoreSample.Core.Entities.Base
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
