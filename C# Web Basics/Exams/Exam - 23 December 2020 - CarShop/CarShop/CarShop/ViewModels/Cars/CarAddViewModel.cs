using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels.Cars
{
    public class CarAddViewModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Model { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }

        [RegularExpression("[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        public string PlateNumber { get; set; }
    }
}
