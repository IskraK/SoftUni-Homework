﻿using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Purchase")]
    public class PurchaseExportDto
    {
        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }
        public GameExportDto Game { get; set; }
    }
}

//<Users>
//  <User username="mgraveson">
//    <Purchases>
//      <Purchase>
//        <Card>7991 7779 5123 9211</Card>
//        <Cvc>340</Cvc>
//        <Date>2017-08-31 17:09</Date>
//        <Game title="Counter-Strike: Global Offensive">
//          <Genre>Action</Genre>
//          <Price>12.49</Price>
//        </Game>
//      </Purchase>