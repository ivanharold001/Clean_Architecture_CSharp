using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.Configuration;
using Tarker.Booking.Application.Features.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Features.Booking.Queries.GetAllBooking;
using Tarker.Booking.Application.Features.Booking.Queries.GetBookingByDocumentNumber;
using Tarker.Booking.Application.Features.Booking.Queries.GetBookingByType;
using Tarker.Booking.Application.Features.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Features.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.Features.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.Features.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.Features.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.Features.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Features.User.Commands.CreateUser;
using Tarker.Booking.Application.Features.User.Commands.DeleteUser;
using Tarker.Booking.Application.Features.User.Commands.UpdateUser;
using Tarker.Booking.Application.Features.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.Features.User.Queries.GetAllUser;
using Tarker.Booking.Application.Features.User.Queries.GetUserById;
using Tarker.Booking.Application.Features.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Application.Validators.Booking;
using Tarker.Booking.Application.Validators.Customer;
using Tarker.Booking.Application.Validators.User;

namespace Tarker.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            #region User
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
            services.AddTransient<IGetAllUserQueries, GetAllUserQueries>();
            services.AddTransient<IGetUserByIdQueries, GetUserByIdQueries>();
            services.AddTransient<IGetUserByUserNameAndPasswordQueries, GetUserByUserNameAndPasswordQueries>();
            #endregion

            #region Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
            services.AddTransient<IGetAllCustomerQueries, GetAllCustomerQueries>();
            services.AddTransient<IGetCustomerByIdQueries, GetCustomerByIdQueries>();
            services.AddTransient<IGetCustomerDocumentNumberQueries, GetCustomerDocumentNumberQueries>();
            #endregion

            #region Booking
            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            services.AddTransient<IGetAllBookingQueries, GetAllBookingQueries>();
            services.AddTransient<IGetBookingByDocumentNumberQueries, GetBookingByDocumentNumberQueries>();
            services.AddTransient<IGetBookingByTypeQueries, GetBookingByTypeQueries>();
            #endregion

            #region Validator
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidation>();
            services.AddScoped<IValidator<(string, string)>, GetUserByUserNameAndPasswordValidator>();
            services.AddScoped<IValidator<CreateCustomerModel>, CreateCustomerValidator>();
            services.AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerValidator>();
            services.AddScoped<IValidator<CreateBookingModel>, CreateBookingValidator>();
            #endregion

            return services;
        }
    }
}