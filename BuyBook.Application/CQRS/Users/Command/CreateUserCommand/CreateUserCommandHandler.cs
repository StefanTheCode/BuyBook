using BuyBook.Application.Interfaces;
using BuyBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyBook.Application.CQRS.Users.Command.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserModel>
    {
        private readonly IBuyBookDbContext _buyBookContext;
        
        public CreateUserCommandHandler(IBuyBookDbContext context)
        {
            _buyBookContext = context;
        }

        public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User { Age = request.Age, Location = request.Location }; //Create Mapper

            _buyBookContext.User.Add(user);

            if (_buyBookContext.SaveChanges() == 1)
            {
                return new UserModel
                {
                    Id = user.Id,
                    Age = user.Age,
                    Location = user.Location
                };
            }

            return null;
        }
    }
}
