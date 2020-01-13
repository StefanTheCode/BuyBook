using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyBook.Application.CQRS.Users.Query
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
    {
        public Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
