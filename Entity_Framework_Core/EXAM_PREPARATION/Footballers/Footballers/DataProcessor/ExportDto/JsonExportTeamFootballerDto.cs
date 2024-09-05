namespace Footballers.DataProcessor.ExportDto;

using Footballers.Data.Models.Enums;
using Newtonsoft.Json;

public class JsonExportTeamFootballerDto
{
    [JsonProperty("FootballerName")]
    public string Name { get; set; } = null!;

    [JsonProperty("ContractStartDate")]
    public string ContractStartDate { get; set; } = null!;

    [JsonProperty("ContractEndDate")]
    public string ContractEndDate { get; set; } = null!;

    [JsonProperty("BestSkillType")]
    public string BestSkillType { get; set; } = null!;

    [JsonProperty("PositionType")]
    public string PositionType { get; set; } = null!;
}
