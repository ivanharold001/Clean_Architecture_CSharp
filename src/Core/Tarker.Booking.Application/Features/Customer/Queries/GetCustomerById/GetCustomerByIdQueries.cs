using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Application.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQueries : IGetCustomerByIdQueries
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueries(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdModel> Execute(int customerId)
        {
            var customerEntity = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);

            return _mapper.Map<GetCustomerByIdModel>(customerEntity);
        }
    }
}