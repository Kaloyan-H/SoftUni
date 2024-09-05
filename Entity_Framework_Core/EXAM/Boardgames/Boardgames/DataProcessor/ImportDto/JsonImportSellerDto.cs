using Boardgames.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto;

public class JsonImportSellerDto
{
    [Required]
    [MaxLength(ValidationConstants.SellerNameMaxLength)]
    [MinLength(ValidationConstants.SellerNameMinLength)]
    [JsonProperty("Name")]
    public string? Name { get; set; }

    [Required]
    [MaxLength(ValidationConstants.SellerAddressMaxLength)]
    [MinLength(ValidationConstants.SellerAddressMinLength)]
    [JsonProperty("Address")]
    public string? Address { get; set; }

    [Required]
    [JsonProperty("Country")]
    public string? Country { get; set; }

    [Required]
    [RegularExpression(@"^www\.[A-Za-z0-9-]{1,}\.com$")]
    [JsonProperty("Website")]
    public string? Website { get; set; }

    [JsonProperty("Boardgames")]
    public int[] BoardgameIds { get; set; } = null!;
}
