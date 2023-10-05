namespace dhanman.money.Application.Contracts.BillPayments;

public class BillPaymentListResponse
{
    #region Properties 

    public string Cursor { get; }
    public IReadOnlyCollection<BillPaymentResponse> Items { get; }
    #endregion


    #region Constructor

    public BillPaymentListResponse(IReadOnlyCollection<BillPaymentResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }
    #endregion

    #region Method 

    
    #endregion
}
