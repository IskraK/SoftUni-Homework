using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Issues
{
    public class AddIssueFormModel
    {
        public string CarId { get; set; }

        [MinLength(5, ErrorMessage = "{0} must be at least {1} characters")]
        public string Description { get; set; }
    }
}
