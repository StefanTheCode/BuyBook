using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Application.CQRS.Users.Command.DeleteUserCommand
{
    public class DeleteUserCommand : IRequest<UserModel>
    {
        public int Id { get; set; }
    }
}
