using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfSystem.Models;

namespace ProfSystem.Data.Mappings
{
    public class ProfessionalMapping : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.ToTable("Professional");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasColumnName("Name").HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Phone).IsRequired().HasColumnName("Phone").HasColumnType("VARCHAR")
                .HasMaxLength(21);
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.Property(x => x.Rg).IsRequired().HasColumnName("Rg").HasColumnType("VARCHAR")
                .HasMaxLength(15);
            builder.HasIndex(x => x.Rg).IsUnique();

                builder.Property(x => x.Address).IsRequired().HasColumnName("Address").HasColumnType("NVARCHAR")
                .HasMaxLength(250);

            builder.Property(x => x.Wage).IsRequired().HasColumnName("Wage").HasColumnType("DECIMAL")
                .HasPrecision(18, 2);
            
            builder.Property(x => x.WageWithOvertime).IsRequired().HasColumnName("WageWithOvertime").HasColumnType("DECIMAL")
                .HasPrecision(18, 2).HasDefaultValue(0m);

            builder.Property(x => x.Hour).HasColumnName("Hour").HasColumnType("INT").HasDefaultValue(0);
        }
    }
}