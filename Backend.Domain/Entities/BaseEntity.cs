using Backend.Domain.Exceptions;

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

    public void Delete()
    {
        if (IsDeleted) throw new EntityAlreadyDeletedException($"The entity of type {GetType().Name} with ID {Id} is already deleted.");
        IsDeleted = true;
        UpdatedAt = DateTimeOffset.Now;
    }

    public void Restore()
    {
        if (!IsDeleted) throw new EntityNotDeletedException($"The entity of type {GetType().Name} with ID {Id} is already active.");
        IsDeleted = false;
        UpdatedAt = DateTimeOffset.Now;
    }

}

