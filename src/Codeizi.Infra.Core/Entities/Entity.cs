namespace Codeizi.Infra.Core.Entities
{
    public abstract class Entity<TKey>
    {
        protected TKey Id { get; }
    }
}