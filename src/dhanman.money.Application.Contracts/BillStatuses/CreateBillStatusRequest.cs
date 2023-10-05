namespace dhanman.money.Application.Contracts.BillStatuses;

public sealed class CreateBillStatusRequest
{
    #region Constructor

    public CreateBillStatusRequest() => Name = string.Empty;

    #endregion

    #region Properties

    public Guid ClientId { get; set; }

    public string Name { get; set; }

	#endregion
}
