using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ExportDto
{
    [XmlType("Customer")]
    public class CustomerExportDto
    {
        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }

        [XmlAttribute("LastName")]
        public string LastName { get; set; }

        [XmlElement("SpentMoney")]
        public decimal SpentMoney { get; set; }

        [XmlElement("SpentTime")]
        public string SpentTime { get; set; }
    }
}

//< Customer FirstName = "Marjy" LastName = "Starbeck" >
//       < SpentMoney > 82.65 </ SpentMoney >
//       < SpentTime > 17:04:00 </ SpentTime >
//</ Customer >
//< Customer FirstName = "Jerrie" LastName = "O\'Carroll" >
//      < SpentMoney > 67.13 </ SpentMoney >
//      < SpentTime > 13:40:00 </ SpentTime >
//</ Customer >
