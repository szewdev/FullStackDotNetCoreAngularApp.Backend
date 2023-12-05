using Backend.Common.Constants;

namespace Backend.Application.Exceptions;

public class NotFoundException(string message = ExceptionMessagesConstants.NotFound) : Exception(message)
{
}
