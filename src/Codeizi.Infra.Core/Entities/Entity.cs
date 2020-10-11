namespace Codeizi.Infra.Core.Entities
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; }
    }
}