using SMS.Data.Models;
using System.Collections.Generic;

namespace SMS.Models
{
    public class LoggedInIndexViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
