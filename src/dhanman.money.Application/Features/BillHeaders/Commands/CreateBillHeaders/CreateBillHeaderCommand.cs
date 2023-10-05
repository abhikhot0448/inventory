using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.BillHeaders.Commands.CreateBillHeaders;

public sealed class CreateBillHeaderCommand : ICommand<Result<EntityCreatedResponse>>
{

    public CreateBillHeaderCommand(Guid billHeaderId, Guid coaId, Guid clientId, string billNumber, int paymentTerm, Guid billPaymentId, Guid billStatusId, decimal totalAmount, decimal tax, string note, string currency, decimal discount, DateTime billDate)
    {
        CoaId = coaId;
        ClientId = clientId;
        BillNumber = billNumber;
        PaymentTerm = paymentTerm;
        BillStatusId = billStatusId;
        BillPaymentId = billPaymentId;
        BillHeaderId = billHeaderId;
        TotalAmount = totalAmount;
        Tax = tax;
        Note = note;
        Currency = currency;
        Discount = discount;
        BillDate = billDate;
    }

    public Guid BillHeaderId { get; private set; }
    public Guid CoaId { get; private set; }
    public string Currency { get; private set; }
    public Guid VendorId { get; private set; }
    public string BillNumber { get; private set; }
    public DateTime BillDate { get; private set; }
    public int PaymentTerm { get; private set; }
    public Guid BillStatusId { get; private set; }
    public Guid BillPaymentId { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public decimal Tax { get; private set; }
    public decimal Discount { get; private set; }
    public string Note { get; private set; }
    public Guid ClientId { get; private set; }
    public Guid UserId { get; set; }

}

