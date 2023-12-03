namespace Backend.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        UniqueId = Guid.NewGuid();
        CreatedAt = DateTimeOffset.Now;
    }

    public int Id { get; }
    public Guid UniqueId { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive => !IsDeleted;
    public bool IsModified => UpdatedAt != null;

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Restore()
    {
        IsDeleted = false;
    }

}

