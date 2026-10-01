using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.ToTable("SaleProducts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.SaleId)
            .IsRequired();

            builder.Property(x => x.ProductId)
            .IsRequired();

            builder.Property(x => x.ProductName)
            .IsRequired()
            .HasMaxLength(200);

            builder.Property(x => x.Quantity)
            .IsRequired();

            builder.Property(x => x.UnitPrice)
            .HasPrecision(18, 2);

            builder.Property(x => x.DiscountPercentage)
            .HasPrecision(5, 2);

            builder.Property(x => x.DiscountAmount)
            .HasPrecision(18, 2);

            builder.Property(x => x.TotalAmount)
            .HasPrecision(18, 2);

            builder.Property(x => x.IsCancelled)
            .IsRequired();

            builder.Property(x => x.CreatedAt)
            .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.HasOne<Sale>()
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.SaleId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
