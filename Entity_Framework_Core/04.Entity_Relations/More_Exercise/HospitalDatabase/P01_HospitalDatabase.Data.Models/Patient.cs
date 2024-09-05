namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Patient
{
    [Key]
    public int PatientId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PatientFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.PatientLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.PatientAddressMaxLength)]
    public string Address { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.PatientEmailMaxLength)]
    public string Email { get; set; } = null!;

    public bool HasInsurance { get; set; }
}