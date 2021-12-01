using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ProducerImportDto
    {

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        [RegularExpression("[A-Z][a-z]+ [A-Z][a-z]+")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"\+359 [0-9]{3} [0-9]{3} [0-9]{3}")]
        public string PhoneNumber { get; set; }

        public AlbumImportDto[] Albums { get; set; }
    }

    public class AlbumImportDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}


//"Name": "Invalid",
//    "Pseudonym": "Rog",
//    "PhoneNumber": "+359 899 323 045",
//    "Albums": [
//      {
//        "Name": "The drawing board",
//        "ReleaseDate": "05/08/2018"
//      },
//      {
//    "Name": "For two songs",
//        "ReleaseDate": "13/09/2018"
//      }
//    ]


//Producer
//•	Id – integer, Primary Key
//•	Name– text with min length 3 and max length 30 (required)
//•	Pseudonym – text, consisting of two words separated with space and each word must start with one upper letter and continue with many lower-case letters (Example: "Bon Jovi")
//•	PhoneNumber – text, consisting only of three groups (separated by space) of three digits and starting always with "+359" (Example: "+359 887 234 267")
//•	Albums – collection of type Album


//Album
//•	Id – integer, Primary Key
//•	Name – text with min length 3 and max length 40 (required)
//•	ReleaseDate – Date(required)
//•	Price – calculated property(the sum of all song prices in the album)
//•	ProducerId – integer foreign key
//•	Producer – the album’s producer
//•	Songs – collection of all songs in the album 