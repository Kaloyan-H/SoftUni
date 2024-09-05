namespace Footballers.Data.Models;

using Footballers.Data.Common;
using System.ComponentModel.DataAnnotations;

public class Team
{
    public Team()
    {
        this.TeamsFootballers = new HashSet<TeamFootballer>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(ValidationConstants.TeamNameMaxLength)]
    [MinLength(ValidationConstants.TeamNameMinLength)]
    [RegularExpression(@"^[a-zA-Z0-9\s\.\-]+$")]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstants.TeamNationalityMaxLength)]
    [MinLength(ValidationConstants.TeamNationalityMinLength)]
    public string Nationality { get; set; } = null!;

    public int Trophies { get; set; }

    // Navigation properties
    public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
}

//•	Id – integer, Primary Key
//•	Name – text with length [3, 40]. Should contain letters (lower and upper case), digits, spaces, a dot sign ('.') and a dash ('-'). (required)
//•	Nationality – text with length [2, 40] (required)
//•	Trophies – integer(required)
//•	TeamsFootballers – collection of type TeamFootballer