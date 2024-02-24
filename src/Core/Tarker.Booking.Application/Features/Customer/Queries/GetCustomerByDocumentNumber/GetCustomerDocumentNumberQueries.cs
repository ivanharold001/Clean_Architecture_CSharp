using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerDocumentNumberQueries : IGetCustomerDocumentNumberQueries
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerDocumentNumberQueries(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerDocumentNumberModel> Execute(string documentNumber)
        {
            var customerDocumentNumber = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.DocumentNumber.Equals(documentNumber));

            return _mapper.Map<GetCustomerDocumentNumberModel>(customerDocumentNumber);
        }
    }
}