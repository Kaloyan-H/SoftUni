namespace Boardgames.Data.Models;

using Boardgames.Common;
using System.ComponentModel.DataAnnotations;

public class Creator
{
    public Creator()
    {
        this.Boardgames = new HashSet<Boardgame>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.CreatorFirstNameMaxLength)]
    [MinLength(ValidationConstants.CreatorFirstNameMinLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.CreatorLastNameMaxLength)]
    [MinLength(ValidationConstants.CreatorLastNameMinLength)]
    public string LastName { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<Boardgame> Boardgames { get; set; }
}
