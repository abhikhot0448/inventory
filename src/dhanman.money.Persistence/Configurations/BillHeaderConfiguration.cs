using dhanman.money.Domain.Entities.BillHeaders;
using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dhanman.money.Persistence.Configurations;

internal sealed class BillHeaderConfiguration : IEntityTypeConfiguration<BillHeader>
{
    public void Configure(EntityTypeBuilder<BillHeader> builder)
    {
        builder.ToTable(TableNames.BillHeaders);
        builder.HasKey(billHeaders => billHeaders.Id);

        builder.Property(billHeaders => billHeaders.CreatedOnUtc).HasColumnType("timestamp").IsRequired();

        builder.Property(billHeaders => billHeaders.ModifiedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(billHeaders => billHeaders.DeletedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(billHeaders => billHeaders.IsDeleted).HasDefaultValue(false).IsRequired();

        builder.HasQueryFilter(billHeaders => !billHeaders.IsDeleted);
    }
}
