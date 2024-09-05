namespace Boardgames.DataProcessor.ExportDto;

using Newtonsoft.Json;

public class JsonExportSellerDto
{
    [JsonProperty("Name")]
    public string Name { get; set; } = null!;

    [JsonProperty("Website")]
    public string Website { get; set; } = null!;

    [JsonProperty("Boardgames")]
    public ICollection<JsonExportSellerBoardgameDto> Boardgames { get; set; } = null!;
}
