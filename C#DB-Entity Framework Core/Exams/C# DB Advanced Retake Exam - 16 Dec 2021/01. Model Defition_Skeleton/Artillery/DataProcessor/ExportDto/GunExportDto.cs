﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class GunExportDto
    {
        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; }

        [XmlAttribute("GunType")]
        public string GunType { get; set; }

        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }

        [XmlAttribute("BarrelLength")]
        public double BarrelLength { get; set; }

        [XmlAttribute("Range")]
        public int Range { get; set; }

        [XmlArray("Countries")]
        public CountryDto[] Countries { get; set; }
    }

    [XmlType("Country")]
    public class CountryDto
    {
        [XmlAttribute("Country")]
        public string Country { get; set; }

        [XmlAttribute("ArmySize")]
        public int ArmySize { get; set; }
    }
}


//< Guns >
//  < Gun Manufacturer = "Krupp" GunType = "Mortar" GunWeight = "1291272" BarrelLength = "8.31" Range = "14258" >
//             < Countries >
//               < Country Country = "Sweden" ArmySize = "5437337" />
//               < Country Country = "Portugal" ArmySize = "9523599" />
//             </ Countries >
//   </ Gun >
