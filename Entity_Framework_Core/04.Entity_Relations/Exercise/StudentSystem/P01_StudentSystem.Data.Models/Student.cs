namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Student
{
    public Student()
    {
        this.StudentsCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.StudentNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstants.StudentPhoneNumberLength)] // Is fixed length with FluentAPI
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    // Navigation properties
#warning: May need to change nav propery name
    public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = null!;

    public virtual ICollection<Homework> Homeworks { get; set; }
}