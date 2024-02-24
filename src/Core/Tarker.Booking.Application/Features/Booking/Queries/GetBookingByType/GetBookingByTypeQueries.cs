using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.Booking.Queries.GetBookingByType
{
    public class GetBookingByTypeQueries : IGetBookingByTypeQueries
    {
        private readonly IDataBaseService _dataBaseService;

        public GetBookingByTypeQueries(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingByTypeModel>> Execute(string bookingType)
        {
            var result = await _dataBaseService.Booking
                .Join(_dataBaseService.Customer,
                      booking => booking.CustomerId,
                      customer => customer.CustomerId,
                      (booking, customer) => new { Booking = booking, Customer = customer })
                .Where(x => x.Booking.Type.Equals(bookingType))
                .Select(x => new GetBookingByTypeModel
                {
                    RegisterDate = x.Booking.RegisterDate,
                    Code = x.Booking.Code,
                    Type = x.Booking.Type,
                    CustomerFullName = x.Customer.FullName,
                    CustomerDocumentNumber = x.Customer.DocumentNumber
                }).ToListAsync();

            return result;
        }
    }
}