using dhanman.money.Domain.Abstarctions;
using FluentValidation;

namespace dhanman.money.Application.Features.BillDetails.Commands.CreateBillDetails;

public class CreateBillDetailCommandValidator : AbstractValidator<CreateBillDetailCommand>
{
    public CreateBillDetailCommandValidator(IBillDetailRepository billDetailRepository)
    {
        RuleFor(bd => bd.Name).MustAsync(async (name, _) =>
        {
            return !string.IsNullOrEmpty(name);
        }).WithMessage("Bill detail Name is required");

        RuleFor(bd => bd.Description).MustAsync(async (description, _) =>
        {
            return !string.IsNullOrEmpty(description);
        }).WithMessage("Bill detail Description is required");

        RuleFor(bd => bd.Price).MustAsync(async (price, _) =>
        {
            return price >= 0m;
        }).WithMessage("Bill detail price should be equal to or greater than zero");

        RuleFor(bd => bd.Quantity).MustAsync(async (quantity, _) =>
        {
            return quantity >= 0;
        }).WithMessage("Bill detail Quantity should be equal to or greater than zero");

        RuleFor(bd => bd.Amount).MustAsync(async (amount, _) =>
        {
            return amount >= 0m;
        }).WithMessage("Bill detail Amount should be equal to or greater than zero");
    }
}
