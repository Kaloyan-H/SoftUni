namespace Boardgames.DataProcessor.ImportDto;

using Common;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Boardgame")]
public class XmlImportCreatorBoardgameDto
{
    [Required]
    [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
    [MinLength(ValidationConstants.BoardgameNameMinLength)]
    [XmlElement("Name")]
    public string? Name { get; set; }

    [Required]
    [Range(
        ValidationConstants.BoardgameRatingMinValue,
        ValidationConstants.BoardgameRatingMaxValue)]
    [XmlElement("Rating")]
    public double? Rating { get; set; }

    [Required]
    [Range(
        ValidationConstants.BoardgameYearPublishedMinValue,
        ValidationConstants.BoardgameYearPublishedMaxValue)]
    [XmlElement("YearPublished")]
    public int? YearPublished { get; set; }

    [Required]
    [XmlElement("CategoryType")]
    public int? CategoryType { get; set; }

    [Required]
    [XmlElement("Mechanics")]
    public string? Mechanics { get; set; }
}
