using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.Booking.Queries.GetAllBooking
{
    public class GetAllBookingQueries : IGetAllBookingQueries
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllBookingQueries(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllBookingModel>> Execute()
        {
            var result = await _dataBaseService.Booking
                .Join(_dataBaseService.Customer,
                      booking => booking.CustomerId,
                      customer => customer.CustomerId,
                      (booking, customer) => new GetAllBookingModel
                      {
                          BookingId = booking.BookingId,
                          Code = booking.Code,
                          RegisterDate = booking.RegisterDate,
                          Type = booking.Type,
                          CustomerFullName = customer.FullName,
                          CustomerDocumentNumber = customer.DocumentNumber
                      })
                .ToListAsync();

            return result;
        }
    }
}