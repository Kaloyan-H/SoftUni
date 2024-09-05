namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Enums;

public class Boardgame
{
    public Boardgame()
    {
        this.BoardgamesSellers = new HashSet<BoardgameSeller>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
    [MinLength(ValidationConstants.BoardgameNameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(
        ValidationConstants.BoardgameRatingMinValue,
        ValidationConstants.BoardgameRatingMaxValue)]
    public double Rating { get; set; }

    [Required]
    [Range(
        ValidationConstants.BoardgameYearPublishedMinValue,
        ValidationConstants.BoardgameYearPublishedMaxValue)]
    public int YearPublished { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    [Required]
    public string Mechanics { get; set; } = null!;

    // Foreign keys
    [Required]
    [ForeignKey(nameof(Creator))]
    public int CreatorId { get; set; }
    public virtual Creator Creator { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
}
