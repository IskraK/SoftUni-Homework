using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserImportDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]+\s{1}[A-Z][a-z]+$")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(3,103)]
        public int Age { get; set; }

        [MinLength(1)]
        public CardImportDto[] Cards { get; set; }

        public class CardImportDto
        {
            [Required]
            [RegularExpression(@"^[\d]{4}\s[\d]{4}\s[\d]{4}\s[\d]{4}$")]
            public string Number { get; set; }

            [Required]
            [RegularExpression("[0-9]{3}")]
            public string Cvc { get; set; }

            [EnumDataType(typeof(CardType))]
            [Required]
            public CardType? Type { get; set; }

        }
    }
}


//Card
//•	Id – integer, Primary Key
//•	Number – text, which consists of 4 pairs of 4 digits, separated by spaces (ex. “1234 5678 9012 3456”) (required)
//•	Cvc – text, which consists of 3 digits (ex. “123”) (required)
//•	Type – enumeration of type CardType, with possible values (“Debit”, “Credit”) (required)
//•	UserId – integer, foreign key(required)
//•	User – the card’s user (required)
//•	Purchases – collection of type Purchase

//User
//•	Id – integer, Primary Key
//•	Username – text with length [3, 20] (required)
//•	FullName – text, which has two words, consisting of Latin letters. Both start with an upper letter and are followed by lower letters. The two words are separated by a single space (ex. "John Smith") (required)
//•	Email – text(required)
//•	Age – integer in the range[3, 103] (required)
//•	Cards – collection of type Card


//"FullName": "Invalid Invalidman",
//    "Username": "",
//    "Email": "invalid@invalid.com",
//    "Age": 20,
//    "Cards": [
//      {
//        "Number": "1111 1111 1111 1111",
//        "CVC": "111",
//        "Type": "Debit"
//      }
//    ]
