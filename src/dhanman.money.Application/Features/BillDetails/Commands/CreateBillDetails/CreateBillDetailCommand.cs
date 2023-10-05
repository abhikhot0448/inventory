using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.BillDetails.Commands.CreateBillDetails;

public sealed class CreateBillDetailCommand : ICommand<Result<EntityCreatedResponse>>
{

    public CreateBillDetailCommand(Guid billDetailId, Guid billHeaderId, string name, string description, decimal price, int quantity, decimal amount)
    {

        BillDetailId = billDetailId;
        BillHeaderId = billHeaderId;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        Amount = amount;

    }

    public CreateBillDetailCommand() { }

    public Guid BillDetailId { get; private set; }
    public Guid BillHeaderId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public decimal Amount { get; private set; }

}
