namespace Footballers.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Enums;

public class Footballer
{
    public Footballer()
    {
        this.TeamsFootballers = new HashSet<TeamFootballer>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(ValidationConstants.FootballerNameMaxLength)]
    [MinLength(ValidationConstants.FootballerNameMinLength)]
    public string Name { get; set; } = null!;

    public DateTime ContractStartDate { get; set; }

    public DateTime ContractEndDate { get; set; }

    public PositionType PositionType { get; set; }

    public BestSkillType BestSkillType { get; set; }

    // Foreign keys
    [ForeignKey(nameof(Coach))]
    public int CoachId { get; set; }
    public virtual Coach Coach { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
}

//•	Id – integer, Primary Key
//•	Name – text with length[2, 40] (required)
//•	ContractStartDate – date and time(required)
//•	ContractEndDate – date and time(required)
//•	Position - enumeration of type PositionType, with possible values(Goalkeeper, Defender, Midfielder, Forward) (required)
//•	BestSkill – enumeration of type BestSkillType, with possible values(Defence, Dribble, Pass, Shoot, Speed) (required)
//•	CoachId – integer, foreign key(required)
//•	Coach – Coach 
//•	TeamsFootballers – collection of type TeamFootballer

