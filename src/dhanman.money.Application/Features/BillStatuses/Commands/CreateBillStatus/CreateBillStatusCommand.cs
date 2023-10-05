using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.BillStatuses.Commands.CreateBillStatus;

public sealed class CreateBillStatusCommand : ICommand<Result<EntityCreatedResponse>>
{

    #region Constructor

    public CreateBillStatusCommand(Guid billStatusId,Guid clientId,string name)
    {
        BillStatusId = billStatusId;
        ClientId = clientId;
        Name = name;
    }

    public CreateBillStatusCommand() { }
   
    #endregion

    #region Properties

    public Guid BillStatusId { get; private set; }

	public string Name { get; private set; }

	public Guid ClientId { get; private set; }
	#endregion
}
