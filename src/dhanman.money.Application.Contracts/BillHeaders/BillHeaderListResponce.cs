namespace dhanman.money.Application.Contracts.BillHeaders;

public class BillHeaderListResponce
{
    public BillHeaderListResponce(IReadOnlyCollection<BillHeaderResponce> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }

    public IReadOnlyCollection<BillHeaderResponce> Items { get; }

    public string Cursor { get; }
}

