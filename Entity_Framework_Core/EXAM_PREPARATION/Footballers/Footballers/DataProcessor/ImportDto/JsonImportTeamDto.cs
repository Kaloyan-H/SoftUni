namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using Data.Common;

public class JsonImportTeamDto
{
    public JsonImportTeamDto()
    {
        this.FootballerIds = new HashSet<int>();
    }

    [Required]
    [MaxLength(ValidationConstants.TeamNameMaxLength)]
    [MinLength(ValidationConstants.TeamNameMinLength)]
    [RegularExpression(@"^[a-zA-Z0-9\s\.\-]+$")]
    [JsonProperty("Name")]
    public string? Name { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TeamNationalityMaxLength)]
    [MinLength(ValidationConstants.TeamNationalityMinLength)]
    [JsonProperty("Nationality")]
    public string? Nationality { get; set; } = null!;

    [Required]
    [JsonProperty("Trophies")]
    public int? Trophies { get; set; }

    [Required]
    [JsonProperty("Footballers")]
    public ICollection<int> FootballerIds { get; set; }
}
