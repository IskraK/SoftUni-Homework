using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ManufacturerImportDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(4)]
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        [XmlElement("Founded")]
        public string Founded { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	ManufacturerName – unique text with length [4…40] (required)
//•	Founded – text with length [10…100] (required)
//•	Guns – a collection of Gun