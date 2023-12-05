namespace Backend.Domain.Exceptions;

public class EntityNotDeletedException(string message) : Exception(message)
{
}
