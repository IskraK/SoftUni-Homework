using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        public Song Song { get; set; }

        [ForeignKey(nameof(Performer))]
        public int PerformerId { get; set; }
        public Performer Performer { get; set; }
    }
}


//•	SongId – integer, Primary Key
//•	Song – the performer’s song (required)
//•	PerformerId – integer, Primary Key
//•	Performer – the song’s performer (required)
