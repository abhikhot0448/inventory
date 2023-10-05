using dhanman.money.Domain.Abstarctions;
using FluentValidation;

namespace dhanman.money.Application.Features.Vendors.Commands.CreateVendor;

public class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand>
{
    public CreateVendorCommandValidator(IVendorRepository vendorRepository)
    {
        RuleFor(c => c.FirstName).MustAsync(async (firstName, _) =>
        {
            return !string.IsNullOrEmpty(firstName);
        }).WithMessage("The First Name of Vendor is required");

        RuleFor(c => c.LastName).MustAsync(async (lastName, _) =>
        {
            return !string.IsNullOrEmpty(lastName);
        }).WithMessage("The Last Name of Vendor is required");

        RuleFor(c => c.Email).MustAsync(async (email, _) =>
        {
            return await vendorRepository.IsEmailUniqueAsync(email);
        }).WithMessage("The email of Vendor must be unique");
    }
}