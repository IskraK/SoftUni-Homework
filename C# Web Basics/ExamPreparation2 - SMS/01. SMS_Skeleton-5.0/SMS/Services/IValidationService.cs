using System.Collections.Generic;

namespace SMS.Services
{
    public interface IValidationService
    {
        (bool isValid, IEnumerable<string> errors) ValidateModel(object model);
    }
}
