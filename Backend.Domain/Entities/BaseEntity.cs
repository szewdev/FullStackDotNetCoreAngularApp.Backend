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
    public bool IsDeleted { get; private set; } = false;
    public bool IsActive => !IsDeleted;
    public bool IsModified => UpdatedAt != null;

    protected virtual void Update()
    {
        UpdatedAt = DateTimeOffset.Now;
    }

    protected void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTimeOffset.Now;
    }

    protected void Restore()
    {
        IsDeleted = false;
        UpdatedAt = DateTimeOffset.Now;
    }

}

