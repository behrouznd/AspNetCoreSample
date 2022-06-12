namespace AspNetCoreSample.Core.Entities.Base
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
