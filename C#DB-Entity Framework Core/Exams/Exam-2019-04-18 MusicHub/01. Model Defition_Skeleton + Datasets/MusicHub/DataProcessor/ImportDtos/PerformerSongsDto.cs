using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class PerformerSongsDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Range(18,70)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Range(typeof(decimal),"0", "79228162514264337593543950335")]
        [XmlElement("NetWorth")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public SongDto[] PerformerSongs { get; set; }

    }

    [XmlType("Song")]
    public class SongDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

//< Performer >
//    < FirstName > Gennifer </ FirstName >
//    < LastName > Lopez </ LastName >
//    < Age > 38 </ Age >
//    < NetWorth > 5531 </ NetWorth >
//    < PerformersSongs >
//      < Song id = "3" />
//      < Song id = "4" />
//      < Song id = "5" />
//</ PerformersSongs >


//•	Id – integer, Primary Key
//•	FirstName– text with min length 3 and max length 20 (required) 
//•	LastName– text with min length 3 and max length 20 (required) 
//•	Age – integer(in range between 18 and 70)(required)
//•	NetWorth – decimal(non - negative, minimum value: 0)(required)
//•	PerformerSongs - collection of type SongPerformer