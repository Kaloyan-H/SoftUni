namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Diagnose // Should be diagnosis
{
    [Key]
    public int DiagnoseId { get; set; }

    [Required]
    [MaxLength()]
    public string Name { get; set; }
}
