using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Tarker.Booking.Application.Configuration.Exceptions;
using Tarker.Booking.Application.Features.User.Commands.CreateUser;
using Tarker.Booking.Application.Features.User.Commands.DeleteUser;
using Tarker.Booking.Application.Features.User.Commands.UpdateUser;
using Tarker.Booking.Application.Features.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.Features.User.Queries.GetAllUser;
using Tarker.Booking.Application.Features.User.Queries.GetUserById;
using Tarker.Booking.Application.Features.User.Queries.GetUserByUserNameAndPassword;

namespace Tarker.Booking.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserModel model,
            [FromServices] ICreateUserCommand createUserCommand,
            [FromServices] IValidator<CreateUserModel> validator
        )
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createUserCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserModel model,
            [FromServices] IUpdateUserCommand updateUserCommand,
            [FromServices] IValidator<UpdateUserModel> validator
        )
        {

            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateUserCommand.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpPut("update_password")]
        public async Task<IActionResult> UpdatePassword(
            [FromBody] UpdateUserPasswordModel model,
            [FromServices] IUpdateUserPasswordCommand updateUserPasswordCommand,
            [FromServices] IValidator<UpdateUserPasswordModel> validator
        )
        {

            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateUserPasswordCommand.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> Delete(
            int userId,
            [FromServices] IDeleteUserCommand deleteUserCommand
        )
        {
            if (userId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await deleteUserCommand.Execute(userId);

            if (!data)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllUserQueries getAllUserQueries
        )
        {
            var data = await getAllUserQueries.Execute();

            if (data.IsNullOrEmpty())
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get_id/{userId}")]
        public async Task<IActionResult> GetById(
            int userId,
            [FromServices] IGetUserByIdQueries getUserByIdQueries
        )
        {
            var data = await getUserByIdQueries.Execute(userId);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get_username_password/{userName}/{password}")]
        public async Task<IActionResult> GetByUserNameAndPassword(
            string userName, string password,
            [FromServices] IGetUserByUserNameAndPasswordQueries getUserByUserNameAndPasswordQueries,
            [FromServices] IValidator<(string, string)> validator
        )
        {

            var validate = await validator.ValidateAsync((userName, password));

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await getUserByUserNameAndPasswordQueries.Execute(userName, password);

            if (data == null)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}