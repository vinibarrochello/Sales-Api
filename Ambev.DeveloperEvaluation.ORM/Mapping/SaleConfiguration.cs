using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.SaleNumber)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasIndex(x => x.SaleNumber)
            .IsUnique();

            builder.Property(x => x.SaleDate)
            .IsRequired();

            builder.Property(x => x.UserId)
            .IsRequired();

            builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(x => x.BranchName)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(x => x.TotalAmount)
            .HasPrecision(18, 2);

            builder.Property(x => x.IsCancelled)
            .IsRequired();

            builder.Property(x => x.CreatedAt)
            .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(x => x.SaleId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
