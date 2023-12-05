namespace Backend.Domain.Exceptions;

public class EntityAlreadyDeletedException(string message) : Exception(message)
{
}
