using Backend.Common.Constants;

namespace Backend.Domain.Exceptions;

public class EntityNotDeletedException(string message = ExceptionMessagesConstants.AlreadyActive) : DomainException(message)
{
}
