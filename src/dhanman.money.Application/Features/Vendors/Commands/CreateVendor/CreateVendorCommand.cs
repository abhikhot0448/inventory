using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.Vendors.Commands.CreateVendor
{
    public sealed class CreateVendorCommand : ICommand<Result<EntityCreatedResponse>>
    {
        public CreateVendorCommand(Guid vendorId, Guid clientId, string firstName, string lastName, string email)
        {
            VendorId = vendorId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ClientId = clientId;
        }

        public Guid VendorId { get; }

        public string FirstName { get; }
        public Guid ClientId { get; }

        public string LastName { get; }

        public string Email { get; }

    } 
}
