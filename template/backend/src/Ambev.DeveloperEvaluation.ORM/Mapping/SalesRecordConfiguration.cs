using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SalesRecordConfiguration : IEntityTypeConfiguration<SalesRecords>
    {
        public void Configure(EntityTypeBuilder<SalesRecords> builder)
        {
         
            builder.ToTable("SalesRecords");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(s => s.SaleNumber).IsRequired().HasMaxLength(50);
            builder.Property(s => s.SaleDate).IsRequired();
            builder.Property(s => s.Customer).IsRequired().HasMaxLength(100);
            builder.Property(s => s.TotalSaleAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.Branch).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Quantity).IsRequired();
            builder.Property(s => s.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.Discount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.TotalItemAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.IsCancelled).IsRequired();
            builder.Ignore(s => s.TotalPrice);
            builder.HasMany(s => s.Items)
                   .WithOne()
                   .HasForeignKey("SalesRecordsId")
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
