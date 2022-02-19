using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models.Trips
{
    public class TripViewModel
    {

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public string DepartureTime { get; set; }

        public string ImagePath { get; set; }

        [Range(2,6)]
        public int Seats { get; set; }

        [StringLength(80,ErrorMessage = "Description must be less 80 characters")]
        public string Description { get; set; }
    }
}
