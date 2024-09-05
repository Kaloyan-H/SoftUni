namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Boardgames.Data.Models;
using Common;

[XmlType("Creator")]
public class XmlImportCreatorDto
{
    [Required]
    [MaxLength(ValidationConstants.CreatorFirstNameMaxLength)]
    [MinLength(ValidationConstants.CreatorFirstNameMinLength)]
    [XmlElement("FirstName")]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(ValidationConstants.CreatorLastNameMaxLength)]
    [MinLength(ValidationConstants.CreatorLastNameMinLength)]
    [XmlElement("LastName")]
    public string? LastName { get; set; }

    [XmlArray("Boardgames")]
    public XmlImportCreatorBoardgameDto[] Boardgames { get; set; } = null!;
}
