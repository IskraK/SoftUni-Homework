using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public interface IValidationService
    {
        (bool isValid, IEnumerable<string> errors) ValidateModel(object model);
    }
}
