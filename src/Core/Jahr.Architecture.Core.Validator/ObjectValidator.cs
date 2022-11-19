using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jahr.Architecture.Core.Validator;

/// <summary>
/// Evaluates object properties 
/// </summary>
public class ObjectValidator
{
    /// <summary>
    /// Error messages collections
    /// </summary>
    private readonly IList<ValidationResult> ValidationResult;

    public ObjectValidator()
    {
        ValidationResult = new List<ValidationResult>();
    }

    /// <summary>
    /// Evaluates object
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public bool IsValid
    {
        get
        {
            return Validate();
        }
    }

    /// <summary>
    /// Returns the list of error messages 
    /// </summary>
    public string ValidationResultAsString()
    {
        StringBuilder builder = new StringBuilder();
        foreach (var item in ValidationResult)
        {
            builder.AppendLine($"[{item.MemberNames.FirstOrDefault()}]: {item.ErrorMessage}");
        }

        return builder.ToString();
    }

    private bool Validate()
    {
        var validationContext = new ValidationContext(this, null, null);
        System.ComponentModel.DataAnnotations.Validator.TryValidateObject(this, validationContext, ValidationResult, true);

        return ValidationResult.Count == default;
    }
}
