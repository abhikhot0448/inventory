namespace dhanman.money.Application.Contracts.VendorTypes;

public sealed class VendorTypeListResponse
{
    public VendorTypeListResponse(IReadOnlyCollection<VendorTypeResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }
    public IReadOnlyCollection<VendorTypeResponse> Items { get; }

    public string Cursor { get; }
}
