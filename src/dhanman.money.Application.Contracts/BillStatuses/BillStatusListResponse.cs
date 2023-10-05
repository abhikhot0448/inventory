namespace dhanman.money.Application.Contracts.BillStatuses;

public sealed class BillStatusListResponse
{
    #region Properties

    public IReadOnlyCollection<BillStatusResponse> Items { get; }

    public string Cursor { get; }
    #endregion

    #region Constructor

    public BillStatusListResponse(IReadOnlyCollection<BillStatusResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }
    #endregion
}
