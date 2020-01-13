using BuyBook.Application.Interfaces;
using BuyBook.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyBook.Application.CQRS.Users.Command.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserModel>
    {
        private readonly IBuyBookDbContext _buyBookContext;

        public UpdateUserCommandHandler(IBuyBookDbContext buyBookContext)
        {
            _buyBookContext = buyBookContext;
        }

        public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User currentUser = _buyBookContext.User.Find(request.Id);

            if (currentUser != null)
            {
                currentUser.Location = request.Location;
                currentUser.Age = request.Age;

                if (_buyBookContext.SaveChanges() == 1)
                {
                    return new UserModel { Id = currentUser.Id, Age = currentUser.Age, Location = currentUser.Location };
                }
            }

            return null;
        }
    }
}
