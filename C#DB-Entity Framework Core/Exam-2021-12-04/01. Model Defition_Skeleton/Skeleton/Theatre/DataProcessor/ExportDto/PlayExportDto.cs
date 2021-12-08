using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class PlayExportDto
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }

        [XmlAttribute("Duration")]
        public string Duration { get; set; }

        [XmlAttribute("Rating")]
        public string Rating { get; set; }

        [XmlAttribute("Genre")]
        public string Genre { get; set; }

        [XmlArray("Actors")]
        public ActorDto[] Actors { get; set; }
    }

    [XmlType("Actor")]
    public class ActorDto
    {
        [XmlAttribute("FullName")]
        public string FullName { get; set; }

        [XmlAttribute("MainCharacter")]
        public string MainCharacter { get; set; }
    }
}


//[XmlType("Play")]
//public class ExportPlayDto
//{
//    [XmlAttribute("Title")]
//    public string Title { get; set; }

//    [XmlAttribute("Duration")]
//    public string Duration { get; set; }

//    [XmlAttribute("Rating")]
//    public string Rating { get; set; }

//    [XmlAttribute("Genre")]
//    public string Genre { get; set; }

//    [XmlArray("Actors")]
//    public ExportActorDto[] Actors { get; set; }
//}

//[XmlType("Actor")]
//public class ExportActorDto
//{
//    [XmlAttribute("FullName")]
//    public string FullName { get; set; }

//    [XmlAttribute("MainCharacter")]
//    public string MainCharacter { get; set; }
//}