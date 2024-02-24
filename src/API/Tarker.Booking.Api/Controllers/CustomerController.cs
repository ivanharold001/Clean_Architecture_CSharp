using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Configuration.Exceptions;
using Tarker.Booking.Application.Features.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Features.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.Features.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Features.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.Features.Customer.Queries.GetCustomerByDocumentNumber;

namespace Tarker.Booking.Api.Controllers
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerModel model,
            [FromServices] ICreateCustomerCommand createCustomerCommand,
            [FromServices] IValidator<CreateCustomerModel> validator
        )
        {

            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createCustomerCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateCustomerModel model,
            [FromServices] IUpdateCustomerCommand updateCustomerCommand,
            [FromServices] IValidator<UpdateCustomerModel> validator
        )
        {

            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateCustomerCommand.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(
            int customerId,
            [FromServices] IDeleteCustomerCommand deleteCustomerCommand
        )
        {
            if (customerId == 0)
                StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await deleteCustomerCommand.Execute(customerId);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllCustomerQueries getAllCustomerQueries
        )
        {
            var data = await getAllCustomerQueries.Execute();

            if (data == null)
                StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, data));
            
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get_by_documentNumber/{documentNumber}")]
        public async Task<IActionResult> GetByDocumentNumber(
            string documentNumber,
            [FromServices] IGetCustomerDocumentNumberQueries getCustomerDocumentNumberQueries
        )
        {
            if (documentNumber.Equals("0"))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getCustomerDocumentNumberQueries.Execute(documentNumber);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}