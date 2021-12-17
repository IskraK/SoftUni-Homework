
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells.ToArray()
                .Where(s => s.ShellWeight > shellWeight)
                .OrderBy(s => s.ShellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                    .Where(g => (int)g.GunType == 3)
                    .OrderByDescending(g => g.GunWeight)
                    .Select(g => new
                    {
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range"
                    })
                })
                .ToArray();

            string shellsJson = JsonConvert.SerializeObject(shells, Formatting.Indented);

            return shellsJson;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GunExportDto[]), new XmlRootAttribute("Guns"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new GunExportDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    BarrelLength = g.BarrelLength,
                    GunWeight = g.GunWeight,
                    Range = g.Range,
                    Countries = g.CountriesGuns.Where(c => c.Country.ArmySize > 4500000)
                    .Select(c => new CountryDto()
                    {
                        Country = c.Country.CountryName,
                        ArmySize = c.Country.ArmySize
                    })
                    .OrderBy(c => c.ArmySize)
                    .ToArray()
                })
                .OrderBy(g => g.BarrelLength)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, guns, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}


