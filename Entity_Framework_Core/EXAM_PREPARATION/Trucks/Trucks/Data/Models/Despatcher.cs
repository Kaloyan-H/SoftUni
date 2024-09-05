namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;
using Trucks.Data.Common;

public class Despatcher
{
    public Despatcher()
    {
        this.Trucks = new HashSet<Truck>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.DespatcherNameMaxLength)]
    [MinLength(ValidationConstants.DespatcherNameMinLength)]
    public string Name { get; set; } = null!;

    public string? Position { get; set; }

    // Navigation properties
    public virtual ICollection<Truck> Trucks { get; set; }
}
