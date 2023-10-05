namespace dhanman.money.Domain.Authorization.Attributes;

public sealed class LinkedToModuleAttribute : Attribute
{
    public LinkedToModuleAttribute(PaidModules paidModules) => PaidModules = paidModules;

    public PaidModules PaidModules { get; }
}
