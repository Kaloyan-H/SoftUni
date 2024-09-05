using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;

using Common;
using Models;

public class StudentSystemContext : DbContext
{
	public StudentSystemContext() { }
	public StudentSystemContext(DbContextOptions options)
		: base(options) { }

	public DbSet<Course> Courses { get; set; } = null!;
	public DbSet<Homework> Homeworks { get; set; } = null!;
	public DbSet<Resource> Resources { get; set; } = null!;
	public DbSet<Student> Students { get; set; } = null!;
	public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
		}
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Student>(entity =>
		{
			entity
				.Property(e => e.PhoneNumber)
				.IsUnicode(false)
				.IsFixedLength();
		});

		modelBuilder.Entity<Course>(entity =>
		{

		});

		modelBuilder.Entity<Resource>(entity =>
		{
			entity
				.Property(e => e.Url)
				.IsUnicode(false);
		});

		modelBuilder.Entity<Homework>(entity =>
		{
			entity
				.Property(e => e.Content)
				.IsUnicode(false);
		});

		modelBuilder.Entity<StudentCourse>(entity =>
		{
			entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
		});
		// TODO: FluentAPI
	}
}