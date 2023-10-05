namespace dhanman.money.Application.Contracts.VendorTypes;

public sealed class CreateVendorTypeRequest
{
    public CreateVendorTypeRequest() => Name = string.Empty;

    public Guid ClientId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
