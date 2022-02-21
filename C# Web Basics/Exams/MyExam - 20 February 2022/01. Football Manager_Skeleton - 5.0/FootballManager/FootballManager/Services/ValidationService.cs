using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Services
{
    public class ValidationService : IValidationService
    {
        public (bool isValid, IEnumerable<string> errors) ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();
            var errors = new List<string>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            if (isValid)
            {
                return (isValid, null);
            }

            foreach (var error in errorResult)
            {
                errors.Add(error.ErrorMessage);
            }

            return (isValid, errors);
        }
    }
}
