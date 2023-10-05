using dhanman.money.Domain.Entities.BillPayments;
using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dhanman.money.Persistence.Configurations;

internal sealed class BillPaymentsConfiguration : IEntityTypeConfiguration<BillPayment>
{
    public void Configure(EntityTypeBuilder<BillPayment> builder)
    {
        builder.ToTable(TableNames.BillPayments);
        builder.HasKey(billPayments => billPayments.Id);

        builder.Property(billPayments => billPayments.Amount)
            .HasColumnName("amount").HasColumnType("decimal")
        .IsRequired();

        builder.Property(billPayments => billPayments.BillHeaderId).HasColumnName("bill_header_id").IsRequired();

        builder.Property(billPayments => billPayments.TransactionId).HasColumnName("transaction_id").IsRequired();

        builder.Property(billPayments => billPayments.COAId).HasColumnName("coa_id").IsRequired();

        builder.Property(billPayments => billPayments.CreatedOnUtc).HasColumnType("timestamp").IsRequired();

        builder.Property(billPayments => billPayments.ModifiedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(billPayments => billPayments.DeletedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(billPayments => billPayments.IsDeleted).HasDefaultValue(false).IsRequired();

        builder.HasQueryFilter(billPayments => !billPayments.IsDeleted);
    }
}
