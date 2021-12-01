using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ExportDtos
{
    [XmlType("Song")]
    public class SongExportDto
    {
        [XmlElement("SongName")]
        public string SongName { get; set; }

        [XmlElement("Writer")]
        public string WriterName { get; set; }

        [XmlElement("Performer")]
        public string PerformerFullname { get; set; }

        [XmlElement("AlbumProducer")]
        public string AlbumProducerName { get; set; }

        [XmlElement("Duration")]
        public string Duration { get; set; }
    }
}

//< Songs >
//  < Song >
//    < SongName > Away </ SongName >
//    < Writer > Norina Renihan </ Writer >
//    < Performer > Lula Zuan </ Performer >
//    < AlbumProducer > Georgi Milkov </ AlbumProducer >
//    < Duration > 00:05:35 </ Duration >
//</ Song >

