
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteUserCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int userId)
        {
            var userExists = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == userId);
            if (userExists == null)
                return false;

            _dataBaseService.User.Remove(userExists);

            return await _dataBaseService.SaveAsync();
        }
    }
}