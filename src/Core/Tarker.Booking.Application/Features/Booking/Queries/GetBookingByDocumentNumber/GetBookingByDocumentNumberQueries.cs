using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.Booking.Queries.GetBookingByDocumentNumber
{
    public class GetBookingByDocumentNumberQueries : IGetBookingByDocumentNumberQueries
    {
        private readonly IDataBaseService _dataBaseService;

        public GetBookingByDocumentNumberQueries(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber)
        {
            var result = await _dataBaseService.Booking
                .Join(_dataBaseService.Customer,
                      booking => booking.CustomerId,
                      customer => customer.CustomerId,
                      (booking, customer) => new { Booking = booking, Customer = customer })
                .Where(x => x.Customer.DocumentNumber == documentNumber)
                .Select(x => new GetBookingByDocumentNumberModel
                {
                    Code = x.Booking.Code,
                    RegisterDate = x.Booking.RegisterDate,
                    Type = x.Booking.Type
                })
                .ToListAsync();

            return result;
        }
    }
}