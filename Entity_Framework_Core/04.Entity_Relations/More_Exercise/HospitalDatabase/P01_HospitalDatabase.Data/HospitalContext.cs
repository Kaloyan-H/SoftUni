namespace P01_HospitalDatabase.Data;

using Microsoft.EntityFrameworkCore;

using Common;
using P01_HospitalDatabase.Data.Models;

public class HospitalContext : DbContext
{
    public HospitalContext() { }
    public HospitalContext(DbContextOptions options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(entity =>
        {
            entity
                .Property(e => e.Email)
                .IsUnicode(false);
        });
    }
}