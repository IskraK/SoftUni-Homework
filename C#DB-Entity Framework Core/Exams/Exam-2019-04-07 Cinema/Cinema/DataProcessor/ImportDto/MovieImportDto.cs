using Cinema.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class MovieImportDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public Genre? Genre { get; set; }

        [Required]
        public string Duration { get; set; }

        [Range(typeof(double), "1", "10")]
        public double Rating { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Director { get; set; }

    }
}

//{
//    "Title": "Little Big Man",
//    "Genre": "Western",
//    "Duration": "01:58:00",
//    "Rating": 28,
//    "Director": "Duffie Abrahamson"
//  },
