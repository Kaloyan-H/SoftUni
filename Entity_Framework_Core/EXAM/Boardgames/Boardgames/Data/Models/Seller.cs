namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Seller
{
    public Seller()
    {
        this.BoardgamesSellers = new HashSet<BoardgameSeller>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.SellerNameMaxLength)]
    [MinLength(ValidationConstants.SellerNameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.SellerAddressMaxLength)]
    [MinLength(ValidationConstants.SellerAddressMinLength)]
    public string Address { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    [RegularExpression(@"^www\.[A-Za-z0-9-]{1,}\.com$")]
    public string Website { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
}
