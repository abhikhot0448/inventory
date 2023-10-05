namespace dhanman.money.Application.Contracts.Common;

public sealed class EntityCreatedResponse
{
    public EntityCreatedResponse(Guid id) => Id = id;

    public Guid Id { get; }
}
