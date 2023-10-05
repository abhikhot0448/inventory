using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using dhanman.money.Domain.Entities.BillDetails;

namespace dhanman.money.Persistence.Configurations;

internal class BillDetailConfigration : IEntityTypeConfiguration<BillDetail>
{
    public void Configure(EntityTypeBuilder<BillDetail> builder)
    {
        builder.ToTable(TableNames.BillDetails);
        builder.HasKey(billDetails => billDetails.Id);

        builder.Property(billDetails => billDetails.CreatedOnUtc).HasColumnType("timestamp").IsRequired();

        builder.Property(billDetails => billDetails.ModifiedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(billDetails => billDetails.DeletedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(billDetails => billDetails.IsDeleted).HasDefaultValue(false).IsRequired();

        builder.HasQueryFilter(billDetails => !billDetails.IsDeleted);
    }

}
