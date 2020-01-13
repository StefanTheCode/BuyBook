using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Application.CQRS.Users.Command.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<UserModel>
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Age { get; set; }
    }
}
