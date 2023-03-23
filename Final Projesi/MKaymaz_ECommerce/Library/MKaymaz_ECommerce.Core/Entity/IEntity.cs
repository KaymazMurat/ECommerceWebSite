namespace MKaymaz_ECommerce.Core.Entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
