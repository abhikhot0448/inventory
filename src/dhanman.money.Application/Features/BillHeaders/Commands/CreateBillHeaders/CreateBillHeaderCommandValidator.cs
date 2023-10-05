using dhanman.money.Domain.Abstarctions;
using FluentValidation;

namespace dhanman.money.Application.Features.BillHeaders.Commands.CreateBillHeaders;

public class CreateBillHeaderCommandValidator : AbstractValidator<CreateBillHeaderCommand>
{
    public CreateBillHeaderCommandValidator(IBillHeaderRepositroy billHeaderRepositroy)
    {
        RuleFor(bh => bh.Currency).MustAsync(async (currency, _) =>
        {
            return !string.IsNullOrEmpty(currency);
        }).WithMessage("The Currency is required in BillHeader");

        RuleFor(bh => bh.BillNumber).MustAsync(async (billNumber, _) =>
        {
            return !string.IsNullOrEmpty(billNumber);
        }).WithMessage("The BillNumber is required in BillHeader");

        RuleFor(bh => bh.BillDate).MustAsync(async (billDate, _) =>
        {
            return !string.IsNullOrEmpty(billDate.ToString());
        }).WithMessage("The Bill Date is required in BillHeader");

        RuleFor(bh => bh.PaymentTerm).MustAsync(async (paymentTerm, _) =>
        {
            return paymentTerm >= 0;
        }).WithMessage("The positive Payment Term is required in BillHeader");

        RuleFor(bh => bh.DueDate).MustAsync(async (dueDate, _) =>
        {
            return !string.IsNullOrEmpty(dueDate.ToString());
        }).WithMessage("The Due Date is required in BillHeader");

        RuleFor(bh => bh.Note).MustAsync(async (note, _) =>
        {
            return !string.IsNullOrEmpty(note);
        }).WithMessage("The Note is required in BillHeader");

        RuleFor(bh => bh.TotalAmount).MustAsync(async (totalAmount, _) =>
        {
            return totalAmount >= 0m;
        }).WithMessage("The positive Total Amount is required in BillHeader");

        RuleFor(bh => bh.Tax).MustAsync(async (tax, _) =>
        {
            return tax >= 0m;
        }).WithMessage("The positive Tax value is required in BillHeader");

        RuleFor(bh => bh.Discount).MustAsync(async (discount, _) =>
        {
            return discount >= 0m;
        }).WithMessage("The positive Discount value is required in BillHeader");
       
    }
}