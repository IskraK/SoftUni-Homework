using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class CustomerTicketImportDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Range(12, 110)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [XmlElement("Balance")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public TicketImportDto[] Tickets { get; set; }
    }

    [XmlType("Ticket")]
    public class TicketImportDto
    {
        [XmlElement("ProjectionId")]
        public int ProjectionId { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}

//< Customers >
//  < Customer >
//    < FirstName > Randi </ FirstName >
//    < LastName > Ferraraccio </ LastName >
//    < Age > 20 </ Age >
//    < Balance > 59.44 </ Balance >
//    < Tickets >
//      < Ticket >
//        < ProjectionId > 1 </ ProjectionId >
//        < Price > 7 </ Price >
//      </ Ticket >
//      < Ticket >
//        < ProjectionId > 1 </ ProjectionId >
//        < Price > 15 </ Price >
//      </ Ticket >
