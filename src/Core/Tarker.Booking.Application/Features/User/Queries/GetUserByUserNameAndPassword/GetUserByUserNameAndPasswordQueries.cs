using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordQueries : IGetUserByUserNameAndPasswordQueries
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByUserNameAndPasswordQueries(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string password)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserName.Equals(userName) && x.Password.Equals(password));

            return _mapper.Map<GetUserByUserNameAndPasswordModel>(entity);
        }
    }
}