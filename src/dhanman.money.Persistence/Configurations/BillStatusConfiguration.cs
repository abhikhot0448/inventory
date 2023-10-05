using dhanman.money.Domain.Entities.BillStatuses;
using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace dhanman.money.Persistence.Configurations;

internal class BillStatusConfiguration : IEntityTypeConfiguration<BillStatus>
{
    public void Configure(EntityTypeBuilder<BillStatus> builder)
    {
        builder.ToTable(TableNames.BillStatuses);
        builder.HasKey(billStatus => billStatus.Id);

        builder.Property(billStatus => billStatus.Name)
        .HasColumnName("name")
        .HasMaxLength(Name.MaxLength)
        .IsRequired();

        builder.Property(billStatus => billStatus.CreatedOnUtc).HasColumnType("timestamp").IsRequired();

        builder.Property(billStatus => billStatus.ModifiedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(billStatus => billStatus.DeletedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(billStatus => billStatus.IsDeleted).HasDefaultValue(false).IsRequired();

        builder.HasQueryFilter(billStatus => !billStatus.IsDeleted);

    }
}
