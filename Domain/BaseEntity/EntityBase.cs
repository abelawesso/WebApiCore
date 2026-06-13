namespace WebAPICRUD.Domain.BaseEntity
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTimeOffset CreatedOn { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset LastModifiedOn { get; set; } = DateTimeOffset.UtcNow;
        public bool IsDeleted { get; private set; }
        public DateTimeOffset DeletedOn { get; private set;}

        public void UpdateLastModified()
        {
            LastModifiedOn = DateTimeOffset.UtcNow;
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
            DeletedOn = DateTimeOffset.UtcNow;
        }
    }
}
