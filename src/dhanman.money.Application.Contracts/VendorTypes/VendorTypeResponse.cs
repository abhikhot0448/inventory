namespace dhanman.money.Application.Contracts.VendorTypes;

public sealed class VendorTypeResponse 
{
    public VendorTypeResponse(
        Guid id,
        Guid clientId,
        string name,
        string description
        )
    {
        Id = id;
        ClientId = clientId;
        Name = name;
        Description = description;
    }

    public Guid Id { get; }
    public Guid ClientId { get; }
    public string Name { get; }
    public string Description { get; }
}
