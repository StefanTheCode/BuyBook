using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Application.CQRS.Users.Command.CreateUserCommand
{
    public class CreateUserCommand : IRequest<UserModel>
    {
        public string Location { get; set; }
        public string Age { get; set; }
    }
}
