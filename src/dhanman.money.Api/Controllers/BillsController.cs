using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Api.Contracts;
using dhanman.money.Api.Infrastructure;
using dhanman.money.Application.Contracts.Bill;
using dhanman.money.Application.Contracts.BillDetails;
using dhanman.money.Application.Contracts.BillHeaders;
using dhanman.money.Application.Contracts.BillPayments;
using dhanman.money.Application.Contracts.BillStatuses;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.BillDetails.Commands.CreateBillDetails;
using dhanman.money.Application.Features.BillDetails.Queries;
using dhanman.money.Application.Features.BillHeaders.Commands.CreateBillHeaders;
using dhanman.money.Application.Features.BillHeaders.Queries;
using dhanman.money.Application.Features.BillPayments.Queries;
using dhanman.money.Application.Features.Bills.Commands.CreateBill;
using dhanman.money.Application.Features.Bills.Queries;
using dhanman.money.Application.Features.BillStatuses.Commands.CreateBillStatus;
using dhanman.money.Application.Features.BillStatuses.Queries;
using dhanman.money.Application.Features.CreateBillPayment.Commands.CreateBillPayment;
using dhanman.money.Domain;
using Dhanman.Sales.Application.Contracts.BillPayments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dhanman.money.Api.Controllers
{
    public class BillsController : ApiController
    {
        public BillsController(IMediator mediator)
           : base(mediator)
        {

        }
        #region Bills

        [HttpPost(ApiRoutes.Bills.CreateBill)]
        [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateBill([FromBody] CreateBillRequest? request) =>
             await Result.Create(request, Errors.General.BadRequest)
            .Map(value => new CreateBillCommand(
                Guid.NewGuid(),
                 value.ClientId,
                 value.BillPaymentId,
                 value.BillNumber,
                 value.DueDate,
                 value.BillDate,
                 value.BillStatusId,
                 value.VendorId,
                 value.PaymentTerm,
                 value.Tax,
                 value.Note,
                 value.Currency,
                 value.TotalAmount,
                 value.Discount,
                 value.Lines))
             .Bind(command => Mediator.Send(command))
                   .Match(Ok, BadRequest);


        [HttpGet(ApiRoutes.Bills.GetAllBills)]
        [ProducesResponseType(typeof(BillListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBills(Guid clientId) =>
          await Result.Success(new GetAllBillsQuery(clientId))
          .Bind(query => Mediator.Send(query))
          .Match(Ok, NotFound);

        #endregion

        #region Bill Header

        [HttpGet(ApiRoutes.BillHeaders.GetAllBillHeaders)]
        [ProducesResponseType(typeof(BillHeaderListResponce), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBillHeaderes(Guid clientId) =>
        await Result.Success(new GetAllBillHeadersQuery(clientId))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);

        [HttpGet(ApiRoutes.BillHeaders.GetBillHeaderesById)]
        [ProducesResponseType(typeof(BillHeaderResponce), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBillHeaderesById(Guid id) =>
        await Result.Success(new GetBillHeaderByIdQuery(id))
           .Bind(query => Mediator.Send(query))
           .Match(Ok, NotFound);

        [HttpPost(ApiRoutes.BillHeaders.CreateBillHeaders)]
        [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateBillHeaders([FromBody] CreateBillHeaderRequest? request) =>
            await Result.Create(request, Errors.General.BadRequest)
                .Map(value => new CreateBillHeaderCommand(
                    Guid.NewGuid(),
                    value.CoaId,
                    value.ClientId,
                    value.BillNumber,
                    value.PaymentTerm,
                    value.BillPaymentId,
                    value.BillStatusId,
                    value.TotalAmount,
                    value.Tax,
                    value.Note,
                    value.Currency,
                    value.Discount,
                    value.BillDate
                    ))
                .Bind(command => Mediator.Send(command))
               .Match(Ok, BadRequest);

        #endregion

        #region Bill Detail

        [HttpGet(ApiRoutes.BillDetails.GetAllBillDetails)]
        [ProducesResponseType(typeof(BillDetailListResponce), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBillDetails(Guid billHeaderId) =>
        await Result.Success(new GetAllBillDetailsQuery(billHeaderId))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);

        [HttpGet(ApiRoutes.BillDetails.GetBillDetailsById)]
        [ProducesResponseType(typeof(BillDetailResponce), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBillDetailsById(Guid id) =>
       await Result.Success(new GetBillDetailByIdQuery(id))
           .Bind(query => Mediator.Send(query))
           .Match(Ok, NotFound);

        [HttpPost(ApiRoutes.BillDetails.CreateBillDetails)]
        [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateBillDetails([FromBody] CreateBillDetailRequest? request) =>
            await Result.Create(request, Errors.General.BadRequest)
                .Map(value => new CreateBillDetailCommand(
                    Guid.NewGuid(),
                    value.BillHeaderId,
                    value.Name,
                    value.Description,
                    value.Price,
                    value.Quantity,
                    value.Amount))
                .Bind(command => Mediator.Send(command))
               .Match(Ok, BadRequest);

        #endregion

        #region Bill Status

        [HttpPost(ApiRoutes.BillStatuses.CreateBillStatus)]
        [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateBillStatus([FromBody] CreateBillStatusRequest? request) =>
            await Result.Create(request, Errors.General.BadRequest)
                .Map(value => new CreateBillStatusCommand(
                    Guid.NewGuid(),
                    value.ClientId,
                    value.Name
                   ))
                .Bind(command => Mediator.Send(command))
               .Match(Ok, BadRequest);


        [HttpGet(ApiRoutes.BillStatuses.GetBillStatusById)]
        [ProducesResponseType(typeof(BillStatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBillStatusById(Guid id) =>
       await Result.Success(new GetBillStatusByIdQuery(id))
           .Bind(query => Mediator.Send(query))
           .Match(Ok, NotFound);

        #endregion

        #region Bill Payment

        [HttpGet(ApiRoutes.BillPayments.GetBillPaymentsById)]
        [ProducesResponseType(typeof(BillPaymentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBillPaymentsById(Guid id) =>
        await Result.Success(new GetBillPaymentByIdQuery(id))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);


        [HttpGet(ApiRoutes.BillPayments.GetBillPayments)]
        [ProducesResponseType(typeof(BillPaymentListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBillPayments() =>
        await Result.Success(new GetAllBillPaymentsQuery())
        .Bind(query => Mediator.Send(query))
        .Match(Ok, NotFound);
                 

        [HttpPost(ApiRoutes.BillPayments.CreateBillPayments)]
        [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateBillPayment([FromBody] CreateBillPaymentRequest? request) =>
               await Result.Create(request, Errors.General.BadRequest)
                   .Map(value => new CreateBillPaymentCommand(
                       Guid.NewGuid(),
                       value.ClientId,
                       value.Amount,
                       value.BillHeaderId,
                       value.TransactionId,
                       value.COAId))
                   .Bind(command => Mediator.Send(command))
                  .Match(Ok, BadRequest);
        #endregion
    }
}

