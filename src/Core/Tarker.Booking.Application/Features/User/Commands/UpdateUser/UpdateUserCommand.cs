
using AutoMapper;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateUserModel> Execute(UpdateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
            _dataBaseService.User.Update(entity);
            await _dataBaseService.SaveAsync();

            return model;
        }
    }
}