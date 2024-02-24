using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.Configuration.Exceptions;
using Tarker.Booking.Application.Features.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Features.Booking.Queries.GetAllBooking;
using Tarker.Booking.Application.Features.Booking.Queries.GetBookingByDocumentNumber;
using Tarker.Booking.Application.Features.Booking.Queries.GetBookingByType;

namespace Tarker.Booking.Api.Controllers
{
    [ApiController]
    [Route("api/v1/booking")]
    public class BookingController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateBookingModel model,
            [FromServices] ICreateBookingCommand createBookingCommand,
            [FromServices] IValidator<CreateBookingModel> validator
        )
        {

            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createBookingCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllBookingQueries getAllBookingQueries
        )
        {
            var data = await getAllBookingQueries.Execute();

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get_type")]
        public async Task<IActionResult> GetTypeBooking(
            [FromQuery] string bookingType,
            [FromServices] IGetBookingByTypeQueries getBookingByTypeQueries
        )
        {
            if (bookingType.Equals(""))
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            var data = await getBookingByTypeQueries.Execute(bookingType);

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get_documentNumber")]
        public async Task<IActionResult> GetDocumentNumber(
            [FromQuery] string documentNumber,
            [FromServices] IGetBookingByDocumentNumberQueries getBookingByDocumentNumberQueries
        )
        {
            if (documentNumber.Equals(""))
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            var data = await getBookingByDocumentNumberQueries.Execute(documentNumber);

            return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

        }

    }
}