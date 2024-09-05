namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Data.Common;

[XmlType("Truck")]
public class XmlImportDespatcherTruckDto
{
    //[Required]
    [MaxLength(ValidationConstants.TruckRegistrationNumberLength)]
    [MinLength(ValidationConstants.TruckRegistrationNumberLength)]
    [RegularExpression(@"^[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
    [XmlElement("RegistrationNumber")]
    public string? RegistrationNumber { get; set; } // May be optional and not required

    [Required]
    [MaxLength(ValidationConstants.TruckVinNumberLength)]
    [MinLength(ValidationConstants.TruckVinNumberLength)]
    [XmlElement("VinNumber")]
    public string? VinNumber { get; set; }

    [Required]
    [Range(ValidationConstants.TruckTankCapacityMinValue, ValidationConstants.TruckTankCapacityMaxValue)]
    [XmlElement("TankCapacity")]
    public int? TankCapacity { get; set; }

    [Required]
    [Range(ValidationConstants.TruckCargoCapacityMinValue, ValidationConstants.TruckCargoCapacityMaxValue)]
    [XmlElement("CargoCapacity")]
    public int? CargoCapacity { get; set; }

    [Required]
    [XmlElement("CategoryType")]
    public int? CategoryType { get; set; }

    [Required]
    [XmlElement("MakeType")]
    public int? MakeType { get; set; }
}
