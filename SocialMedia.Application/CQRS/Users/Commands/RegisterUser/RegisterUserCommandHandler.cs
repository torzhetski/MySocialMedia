using MediatR;
using SocialMedia.Application.Interfaces;
using SocialMedia.Core.Models;

namespace SocialMedia.Application.CQRS.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Email = request.Email,
                PasswordHash = _passwordHasher.Generate(request.Password),
                UserName = request.UserName,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }


    }
}
