using System.Threading.Tasks;
using BuyBook.Application.CQRS.Users.Command.CreateUserCommand;
using BuyBook.Application.CQRS.Users.Command.DeleteUserCommand;
using BuyBook.Application.CQRS.Users.Command.UpdateUserCommand;
using BuyBook.Application.CQRS.Users.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuyBook.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody]CreateUserCommand createUser)
        {
            var result = _mediator.Send(createUser);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser([FromBody]UpdateUserCommand updateUser)
        {
            var result = _mediator.Send(updateUser);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser([FromBody]DeleteUserCommand deleteUser)
        {
            var result = _mediator.Send(deleteUser);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var result = _mediator.Send(new GetAllUsersQuery());

            return Ok(result);
        }
    }
}