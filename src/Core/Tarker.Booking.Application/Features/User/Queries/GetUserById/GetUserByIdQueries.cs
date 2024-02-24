using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.User.Queries.GetUserById
{
    public class GetUserByIdQueries : IGetUserByIdQueries
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByIdQueries(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByIdModel> Execute(int userId)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == userId);
            return _mapper.Map<GetUserByIdModel>(entity);
        }
    }
}