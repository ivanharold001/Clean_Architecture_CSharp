using AutoMapper;
using Tarker.Booking.Application.Features.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Features.Booking.Queries.GetAllBooking;
using Tarker.Booking.Application.Features.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Features.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Features.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.Features.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.Features.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Features.User.Commands.CreateUser;
using Tarker.Booking.Application.Features.User.Commands.UpdateUser;
using Tarker.Booking.Application.Features.User.Queries.GetAllUser;
using Tarker.Booking.Application.Features.User.Queries.GetUserById;
using Tarker.Booking.Application.Features.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerDocumentNumberModel>().ReverseMap();
            #endregion

            #region  Booking
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();
            #endregion
        }
    }
}