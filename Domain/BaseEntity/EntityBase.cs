namespace WebAPICRUD.Domain.BaseEntity
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTimeOffset CreatedOn { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset LastModifiedOn { get; set; } = DateTimeOffset.UtcNow;

        public void UpdateLastModified()
        {
            LastModifiedOn = DateTimeOffset.UtcNow;
        }
    }
}
