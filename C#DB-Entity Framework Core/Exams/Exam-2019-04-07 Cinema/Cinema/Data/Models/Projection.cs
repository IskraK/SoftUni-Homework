using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Data.Models
{
    public class Projection
    {
        public Projection()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey(nameof(Hall))]
        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	MovieId – integer, foreign key (required)
//•	Movie – the projection’s movie
//•	HallId – integer, foreign key (required)
//•	Hall – the projection’s hall 
//•	DateTime - DateTime (required)
//•	Tickets - collection of type Ticket
