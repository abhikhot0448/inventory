using dhanman.money.Domain.Abstarctions;
using FluentValidation;

namespace dhanman.money.Application.Features.BillStatuses.Commands.CreateBillStatus;

public class CreateBillStatusCommandValidator : AbstractValidator<CreateBillStatusCommand>
{

    #region Constructor

    public CreateBillStatusCommandValidator(IBillStatusRepository billStatusRepository)
    {
        RuleFor(bs => bs.Name).MustAsync(async (name, _) =>
        {
            return !string.IsNullOrEmpty(name);
        }).WithMessage("Bill Status Name is required");
    }

    #endregion

}
