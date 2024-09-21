using MediatR;
using SocialMedia.Application.Exeptions;
using SocialMedia.Application.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SocialMedia.Application.CQRS.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IDbContext _context;

        public UpdateUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }

            user.Name = request.Name ?? user.Name;
            user.UserName = request.UserName ?? user.UserName;
            user.Avatar = request.Avatar ?? user.Avatar;

            await _context.SaveChangesAsync();
            return  user.Id;
        }
    }
}
