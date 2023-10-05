using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Bill;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.Bills.Commands.CreateBill;

public class CreateBillCommand : ICommand<Result<EntityCreatedResponse>>
{
    #region Properties
    public Guid ClientId { get; private set; }
    public Guid BillId { get; private set; }
    public Guid VendorId { get; private set; }
    public Guid CoaId { get; private set; }
    public decimal Discount { get; private set; }
    public string BillNumber { get; private set; }
    public string Currency { get; private set; }
    public DateTime BillDate { get; private set; }
    public int? PaymentTerm { get; private set; }
    public Guid BillStatusId { get; private set; }
    public Guid BillPaymentId { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public decimal Tax { get; private set; }
    public string Note { get; private set; }
    public List<BillLine> Lines { get; private set; }
    #endregion

    #region Constructor
    public CreateBillCommand(
       Guid id,
       Guid clientId,
       Guid billPaymentId,
       string billNumber,
       DateTime dueDate,
       DateTime billDate,
       Guid billStatusId,
       Guid vendorId,
       int? paymentTerm,
       decimal tax,
       string note,
       string currency,
       decimal totalAmount,
       decimal discount,
       List<BillLine> lines)
    {
        BillId = id;
        ClientId = clientId;
        BillPaymentId = billPaymentId;
        BillNumber = billNumber;
        DueDate = dueDate;
        BillDate = billDate;
        BillStatusId = billStatusId;
        VendorId = vendorId;
        PaymentTerm = paymentTerm;
        Tax = tax;
        Note = note;
        Currency = currency;
        TotalAmount = totalAmount;
        Discount = discount;
        Lines = lines;

    }

    public CreateBillCommand() { }
    #endregion
   
}
