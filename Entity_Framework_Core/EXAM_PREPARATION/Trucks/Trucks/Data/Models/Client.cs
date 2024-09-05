namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;
using Trucks.Data.Common;

public class Client
{
    public Client()
    {
        this.ClientsTrucks = new HashSet<ClientTruck>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ClientNameMaxLength)]
    [MinLength(ValidationConstants.ClientNameMinlength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.ClientNationalityMaxLength)]
    [MinLength(ValidationConstants.ClientNationalityMinLength)]
    public string Nationality { get; set; } = null!;

    [Required]
    public string Type { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
}
