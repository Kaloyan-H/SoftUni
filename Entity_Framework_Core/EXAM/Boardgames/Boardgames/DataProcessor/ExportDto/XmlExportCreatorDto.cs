namespace Boardgames.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Creator")]
public class XmlExportCreatorDto
{
    [XmlAttribute("BoardgamesCount")]
    public int BoardgamesCount { get; set; } // May need to be string

    [XmlElement("CreatorName")]
    public string Name { get; set; } = null!;

    [XmlArray("Boardgames")]
    public XmlExportCreatorBoardgameDto[] Boardgames { get; set; } = null!;
}
