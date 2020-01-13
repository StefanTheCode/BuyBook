using BuyBook.Application.Interfaces;
using BuyBook.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BuyBook.Application.CQRS.Users.Command.DeleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserModel>
    {
        private readonly IBuyBookDbContext _buyBookContext;

        public DeleteUserCommandHandler(IBuyBookDbContext buyBookContext)
        {
            _buyBookContext = buyBookContext;
        }

        public async Task<UserModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User currentUser = _buyBookContext.User.Find(request.Id);
            UserModel returnUser;

            if (currentUser != null)
            {
                returnUser = new UserModel { Id = currentUser.Id, Age = currentUser.Age, Location = currentUser.Location };

                _buyBookContext.User.Remove(currentUser);

                if (_buyBookContext.SaveChanges() == 1)
                {
                    return returnUser;
                }
            }

            return null;
        }
    }
}
