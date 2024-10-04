using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Exeptions;
using SocialMedia.Application.Interfaces;
using SocialMedia.Core.Models;
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
            var user = await _context.Users
                                            .Include(user => user.LikedPosts)
                                            .FirstOrDefaultAsync(user => user.Id == request.Id);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }

            user.Name = request.Name ?? user.Name;
            user.UserName = request.UserName ?? user.UserName;
            user.Avatar = request.Avatar ?? user.Avatar;

            if (request.LikedPostId != null)
            {
                var likedPost = new PostLike()
                {
                    PostId = (int)request.LikedPostId,
                    UserId = user.Id
                };

                if (user.LikedPosts.Contains(likedPost))
                {
                    user.LikedPosts.Remove(likedPost);
                }
                else
                {
                    user.LikedPosts.Add(
                                new PostLike()
                                {
                                    PostId = (int)request.LikedPostId,
                                    UserId = user.Id
                                });
                }
            }
            

            await _context.SaveChangesAsync();
            return  user.Id;
        }
    }
}
