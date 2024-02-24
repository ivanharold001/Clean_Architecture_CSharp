using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordCommand : IUpdateUserPasswordCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public UpdateUserPasswordCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
            var userExists = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == model.UserId);

            if (userExists == null)
                return false;

            userExists.Password = model.Password;

            return await _dataBaseService.SaveAsync();
        }
    }
}