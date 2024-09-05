namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Player
{
    public Player()
    {
        this.PlayersStatistics = new HashSet<PlayerStatistic>();
    }

    [Key]
    public int PlayerId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PlayerNameMaxLength)]
    public string Name { get; set; } = null!;

    public int SquadNumber { get; set; }

    // SQL Type -> BIT
    public bool IsInjured { get; set; }

    // Foreign keys

    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; } // WARNING: May break Judge EDIT: Did break Judge :D
    public virtual Team Team { get; set; } = null!;

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }
    public virtual Position Position { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
}

