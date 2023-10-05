namespace dhanman.money.Application.Contracts.Bill;

public class BillListResponse
{
    #region Constructor
    public BillListResponse(IReadOnlyCollection<BillResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }
    #endregion

    #region Properties
    public IReadOnlyCollection<BillResponse> Items { get; }

    public string Cursor { get; }
    #endregion

}
