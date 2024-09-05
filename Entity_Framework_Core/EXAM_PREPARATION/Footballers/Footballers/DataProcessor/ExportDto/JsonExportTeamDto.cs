namespace Footballers.DataProcessor.ExportDto;

using Newtonsoft.Json;

public class JsonExportTeamDto
{
    public JsonExportTeamDto()
    {
        this.Footballers = new HashSet<JsonExportTeamFootballerDto>();
    }

    [JsonProperty("Name")]
    public string Name { get; set; } = null!;

    [JsonProperty("Footballers")]
    public ICollection<JsonExportTeamFootballerDto> Footballers { get; set; }
}
