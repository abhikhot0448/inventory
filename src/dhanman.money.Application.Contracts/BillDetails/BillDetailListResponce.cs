namespace dhanman.money.Application.Contracts.BillDetails;

public class BillDetailListResponce
{
    public BillDetailListResponce(IReadOnlyCollection<BillDetailResponce> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }

    public IReadOnlyCollection<BillDetailResponce> Items { get; }

    public string Cursor { get; }

}
