namespace dhanman.money.Application.Contracts.Vendors;

public sealed class CreateVendorRequest
{
    public CreateVendorRequest() => FirstName = string.Empty;

    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
}
