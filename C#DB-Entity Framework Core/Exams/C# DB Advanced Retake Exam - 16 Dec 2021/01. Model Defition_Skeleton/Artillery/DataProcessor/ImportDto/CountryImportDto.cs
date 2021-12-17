using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class CountryImportDto
    {
        [Required]
        [MaxLength(60)]
        [MinLength(4)]
        [XmlElement("CountryName")]
        public string CountryName { get; set; }

        [Range(50000,10000000)]
        [XmlElement("ArmySize")]
        public int ArmySize { get; set; }
    }
}


//•	Id – integer, Primary Key
//•	CountryName – text with length [4, 60] (required)
//•	ArmySize – integer in the range[50_000….10_000_000] (required)
//•	CountriesGuns – a collection of CountryGun
