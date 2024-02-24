using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.User.Queries.GetAllUser
{
    public class GetAllUserQueries : IGetAllUserQueries
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllUserQueries(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllUserModel>> Execute()
        {
            var listEntity = await _dataBaseService.User.ToListAsync();
            return _mapper.Map<List<GetAllUserModel>>(listEntity);
        }
    }
}