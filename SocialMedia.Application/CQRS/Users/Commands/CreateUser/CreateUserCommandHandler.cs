using MediatR;
using SocialMedia.Application.Interfaces;
using SocialMedia.Core.Models;


namespace SocialMedia.Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IDbContext _context;

        public CreateUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Email = request.Email,
                Password = request.Password,
                UserName = request.UserName,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
