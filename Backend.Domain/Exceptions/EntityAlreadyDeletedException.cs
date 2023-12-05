using Backend.Common.Constants;

namespace Backend.Domain.Exceptions;

public class EntityAlreadyDeletedException(string message = ExceptionMessagesConstants.AlreadyDeleted) : DomainException(message)
{
}
