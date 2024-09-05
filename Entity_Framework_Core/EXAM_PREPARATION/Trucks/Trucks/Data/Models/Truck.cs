namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;
using Enums;

public class Truck
{
    public Truck()
    {
        this.ClientsTrucks = new HashSet<ClientTruck>();
    }

    [Key]
    public int Id { get; set; }

    //[Required]
    [MaxLength(ValidationConstants.TruckRegistrationNumberLength)]
    [MinLength(ValidationConstants.TruckRegistrationNumberLength)]
    [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$")]
    public string? RegistrationNumber { get; set; }/* = null!;*/ // May be optional and not required

    [Required]
    [MaxLength(ValidationConstants.TruckVinNumberLength)]
    [MinLength(ValidationConstants.TruckVinNumberLength)]
    public string VinNumber { get; set; } = null!;

    [Required]
    [Range(ValidationConstants.TruckTankCapacityMinValue, ValidationConstants.TruckTankCapacityMaxValue)]
    public int TankCapacity { get; set; }

    [Required]
    [Range(ValidationConstants.TruckCargoCapacityMinValue, ValidationConstants.TruckCargoCapacityMaxValue)]
    public int CargoCapacity { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    [Required]
    public MakeType MakeType { get; set; }

    // Foreign keys
    [Required]
    [ForeignKey(nameof(Despatcher))]
    public int DespatcherId { get; set; }
    public virtual Despatcher Despatcher { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
}

