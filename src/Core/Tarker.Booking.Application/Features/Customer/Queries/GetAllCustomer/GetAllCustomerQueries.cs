using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerQueries : IGetAllCustomerQueries
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllCustomerQueries(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllCustomerModel>> Execute()
        {
            var listEntity = await _dataBaseService.Customer.ToListAsync();
            return _mapper.Map<List<GetAllCustomerModel>>(listEntity);  
        }
    }
}