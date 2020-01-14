using BuyBook.Application.Interfaces;
using BuyBook.Domain;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace BuyBook.Application.CQRS.Users.Query
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
    {
        private readonly IMongoDbContext _mongoDbContext;

        public GetAllUsersQueryHandler(IMongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _mongoDbContext.Users.FindAsync(x => x.Id != 0).Result.ToList();

            List<UserModel> newUsers = new List<UserModel>();

            foreach(var user in users)
            {
                newUsers.Add(new UserModel
                {
                    //Id = user.Id,
                    Age = user.Age,
                    Location = user.Location
                });
            }

            return newUsers;
        }
    }
}
