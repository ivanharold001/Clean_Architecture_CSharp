using AutoMapper;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Application.Features.Booking.Commands.CreateBooking
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateBookingCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateBookingModel> Execute(CreateBookingModel model)
        {
            var entity = _mapper.Map<BookingEntity>(model);
            await _dataBaseService.Booking.AddAsync(entity);
            await _dataBaseService.SaveAsync();

            return model;
        }
    }
}