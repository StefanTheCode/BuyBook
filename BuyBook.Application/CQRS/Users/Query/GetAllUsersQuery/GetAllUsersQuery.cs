using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.Application.CQRS.Users.Query
{
    public class GetAllUsersQuery : IRequest<List<UserModel>>
    {
    }
}
