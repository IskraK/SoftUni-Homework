using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class SongImportDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Required]
        [XmlElement("CreatedOn")]
        public string CreatedOn { get; set; }

        [Required]
        [XmlElement("Genre")]
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        public int? AlbumId { get; set; }

        public int WriterId { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

    }
}


//< Song >
//    < Name > What Goes Around</Name>
//       <Duration>00:03:23 </ Duration >

//       < CreatedOn > 21 / 12 / 2018 </ CreatedOn >

//       < Genre > Blues </ Genre >

//       < AlbumId > 2 </ AlbumId >

//       < WriterId > 2 </ WriterId >

//       < Price > 12 </ Price >

//     </ Song >


//•	Id – integer, Primary Key
//•	Name – text with min length 3 and max length 20 (required)
//•	Duration – TimeSpan(required)
//•	CreatedOn – Date(required)
//•	Genre ¬– Genre enumeration with possible values: "Blues, Rap, PopMusic, Rock, Jazz"(required)
//•	AlbumId– integer foreign key
//•	Album– the song’s album
//•	WriterId - integer, foreign key (required)
//•	Writer – the song’s writer
//•	Price – decimal (non-negative, minimum value: 0) (required)
//•	SongPerformers - collection of type SongPerformer