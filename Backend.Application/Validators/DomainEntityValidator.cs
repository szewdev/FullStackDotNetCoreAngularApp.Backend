using System.ComponentModel.DataAnnotations;

namespace Backend.Application.Validators;

public static class DomainEntityValidator
{
    public static bool Validate<T>(T entity)
        where T : class
    {
        return Validate(entity, out _);
    }

    public static bool Validate<T>(T entity, out string validationResults)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(entity);

        var context = new ValidationContext(entity, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(entity, context, results, true);
        validationResults = GetValidationErrorMessage(results);

        return isValid;
    }

    private static string GetValidationErrorMessage(IEnumerable<ValidationResult> validationResults)
    {
        return string.Join("; ", validationResults.SelectMany(vr => vr.MemberNames.Select(mn => $"[{mn}] {vr.ErrorMessage}")));
    }

}

