namespace dhanman.money.Application.Contracts.Vendors;

public sealed class VendorListResponse
{
    public VendorListResponse(IReadOnlyCollection<VendorResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }

    public IReadOnlyCollection<VendorResponse> Items { get; }

    public string Cursor { get; }
}
