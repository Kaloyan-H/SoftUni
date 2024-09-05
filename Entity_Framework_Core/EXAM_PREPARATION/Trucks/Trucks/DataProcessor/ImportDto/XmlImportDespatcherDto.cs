namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Common;

[XmlType("Despatcher")]
public class XmlImportDespatcherDto
{
    [Required]
    [MaxLength(ValidationConstants.DespatcherNameMaxLength)]
    [MinLength(ValidationConstants.DespatcherNameMinLength)]
    [XmlElement("Name")]
    public string? Name { get; set; }

    [Required]
    [XmlElement("Position")]
    public string? Position { get; set; }

    [XmlArray("Trucks")]
    public XmlImportDespatcherTruckDto[] Trucks { get; set; } = null!; // Idk if it should be an array or ICollection
}
