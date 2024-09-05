namespace Footballers.DataProcessor.ImportDto;

using Footballers.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Coach")]
public class XmlImportCoachDto
{
    [Required]
    [MaxLength(ValidationConstants.CoachNameMaxLength)]
    [MinLength(ValidationConstants.CoachNameMinLength)]
    [XmlElement("Name")]
    public string? Name { get; set; }

    [Required]
    [XmlElement("Nationality")]
    public string? Nationality { get; set; }

    [XmlArray("Footballers")]
    public XmlImportCoachFootballerDto[] Footballers { get; set; } = null!;
}
