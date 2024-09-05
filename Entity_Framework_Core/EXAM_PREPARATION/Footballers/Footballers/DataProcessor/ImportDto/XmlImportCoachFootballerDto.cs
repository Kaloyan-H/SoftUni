namespace Footballers.DataProcessor.ImportDto;

using Footballers.Data.Common;
using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Footballer")]
public class XmlImportCoachFootballerDto
{
    [Required]
    [MaxLength(ValidationConstants.FootballerNameMaxLength)]
    [MinLength(ValidationConstants.FootballerNameMinLength)]
    [XmlElement("Name")]
    public string? Name { get; set; }

    [Required]
    [XmlElement("ContractStartDate")]
    public string? ContractStartDate { get; set; }

    [Required]
    [XmlElement("ContractEndDate")]
    public string? ContractEndDate { get; set; }

    [Required]
    [XmlElement("BestSkillType")]
    public int? BestSkillType { get; set; }

    [Required]
    [XmlElement("PositionType")]
    public int? PositionType { get; set; }
}
