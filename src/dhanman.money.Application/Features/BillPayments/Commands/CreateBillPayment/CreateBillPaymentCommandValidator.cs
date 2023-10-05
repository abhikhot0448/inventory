using dhanman.money.Application.Features.CreateBillPayment.Commands.CreateBillPayment;
using dhanman.money.Domain.Abstarctions;
using dhanman.money.Domain.Entities.BillPayments;
using FluentValidation;

namespace dhanman.money.Application.Features.BillPayments.Commands
{
    public class CreateInvoicePaymentCommandValidator : AbstractValidator<CreateBillPaymentCommand>
    {

        #region Constructor

        public CreateInvoicePaymentCommandValidator(IBillPaymentRepository billPaymentRepository)
        {
            RuleFor(c => c.Amount).MustAsync(async (amount, _) =>
            {
                return !string.IsNullOrEmpty(amount.ToString());
            }).WithMessage("The amount is required");

            RuleFor(c => c.BillHeaderId).MustAsync(async (billHeaderId, _) =>
            {
                return !string.IsNullOrEmpty(billHeaderId.ToString());
            }).WithMessage("The Bill Header Id Number is required");

            RuleFor(c => c.TransactionId).MustAsync(async (transactionId, _) =>
            {
                return !string.IsNullOrEmpty(transactionId.ToString());
            }).WithMessage("The Transaction Id is required");

            RuleFor(c => c.COAId).MustAsync(async (cOAId, _) =>
            {
                return !string.IsNullOrEmpty(cOAId.ToString()); 
            }).WithMessage("The COA Id must be unique");

            RuleFor(c => c.ClientId).MustAsync(async (clientId, _) =>
            {
                return !string.IsNullOrEmpty(clientId.ToString());
            }).WithMessage("The Client Id must be unique");
        }
        #endregion
    }
}
