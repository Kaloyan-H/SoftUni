namespace Footballers.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;
using static System.Net.Mime.MediaTypeNames;

public class Coach
{
    public Coach()
    {
        this.Footballers = new HashSet<Footballer>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(ValidationConstants.CoachNameMaxLength)]
    [MinLength(ValidationConstants.CoachNameMinLength)]
    public string Name { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<Footballer> Footballers { get; set; }
}

//•	Id – integer, Primary Key
//•	Name – text with length[2, 40] (required)
//•	Nationality – text(required)
//•	Footballers – collection of type Footballer
