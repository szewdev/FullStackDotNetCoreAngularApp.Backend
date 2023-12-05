using Backend.Common.Constants;
using System.Text;

namespace Backend.Common.Exceptions;

public class ValidationException(string details, string message = ExceptionMessagesConstants.ValidationException) : Exception(WithDetails(details, message))
{
    private static string WithDetails(string details, string message)
    {
        StringBuilder sb = new();
        sb.Append(message);
        sb.Append(' ');
        sb.Append(details);
        return sb.ToString();
    }
}