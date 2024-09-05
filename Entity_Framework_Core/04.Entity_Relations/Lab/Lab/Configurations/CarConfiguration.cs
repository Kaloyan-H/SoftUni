using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Lab.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> modelBuilder)
        {
            modelBuilder
                .HasKey(c => c.CarPrimaryId);

            modelBuilder
                 .ToTable("SpecialCar");

            modelBuilder
                .Property(c => c.Make)
                .HasColumnName("Brand")
                .HasColumnType("varchar(250)")
                .IsRequired();

            modelBuilder
                .Ignore(c => c.BusinessSpecific);
        }
    }
}
