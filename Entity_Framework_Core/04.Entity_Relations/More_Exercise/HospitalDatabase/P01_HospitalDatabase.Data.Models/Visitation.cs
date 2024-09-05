namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Visitation
{
    [Key]
    public int VisitationId { get; set; }

    public DateTime Date { get; set; }

    [Required]
    [MaxLength(ValidationConstants.VisitationCommentsMaxLength)]
    public string Comments { get; set; } = null!;

    // Foreign keys
    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; } // May break judge
    public virtual Doctor Doctor { get; set; } = null!;

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; } = null!;
}
