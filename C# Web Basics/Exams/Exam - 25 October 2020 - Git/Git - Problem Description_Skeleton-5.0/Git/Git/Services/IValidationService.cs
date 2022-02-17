using System.Collections.Generic;

namespace Git.Services
{
    public interface IValidationService
    {
        (bool isValid, IEnumerable<string> errors) ValidateModel(object model);
    }
}
