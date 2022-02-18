using System.Collections.Generic;

namespace CarShop.Services
{
    public interface IValidationService
    {
        (bool isValid, IEnumerable<string> errors) ValidateModel(object model);
    }
}
