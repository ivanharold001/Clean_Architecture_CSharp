
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;

namespace Tarker.Booking.Application.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteCustomerCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int customerId)
        {
            var deleteCustomer = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);

            if (deleteCustomer == null)
                return false;

            _dataBaseService.Customer.Remove(deleteCustomer);
            
            return await _dataBaseService.SaveAsync();
        }
    }
}