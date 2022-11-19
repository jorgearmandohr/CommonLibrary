using Jahr.Architecture.Core.Validator;
using System.ComponentModel.DataAnnotations;

namespace Jahr.Architecture.Core.Tests.Models
{
    public class ExampleModel : ObjectValidator
    {
        [Range(1, int.MaxValue, ErrorMessage = "El valor cumple con el rago permitido")]
        public int SomeNumberField { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string SomeTextField { get; set; }

        [EmailAddress(ErrorMessage = "El valor ingresado no tiene formato de email")]
        public string EmailField { get; set; }
    }
}
