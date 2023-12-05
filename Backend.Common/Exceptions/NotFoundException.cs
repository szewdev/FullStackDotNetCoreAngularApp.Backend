using Backend.Common.Constants;

namespace Backend.Common.Exceptions;

public class NotFoundException(string message = ExceptionMessagesConstants.NotFound) : Exception(message)
{
}
