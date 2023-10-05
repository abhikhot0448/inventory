using dhanman.money.Domain.Abstarctions;
using FluentValidation;

namespace dhanman.money.Application.Features.VendorTypes.Commands.CreateVendorTypes;

public class CreateVendorTypeCommandValidator : AbstractValidator<CreateVendorTypeCommand>
{
    public CreateVendorTypeCommandValidator(IVendorTypeRepository vendorTypeRepository)
    {
       RuleFor (vt => vt.Name).MustAsync(async (name, _) =>
            {
            return !string.IsNullOrEmpty(name);
        }).WithMessage("The Name of VendorType is required");

        RuleFor(vt => vt.Description).MustAsync(async (description, _) =>
        {
            return !string.IsNullOrEmpty(description);
        }).WithMessage("The Description of VendorType is required");
    }
}