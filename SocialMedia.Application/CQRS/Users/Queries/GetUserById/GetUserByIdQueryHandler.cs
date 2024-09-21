using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Exeptions;
using SocialMedia.Application.Extentions;
using SocialMedia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.CQRS.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserProfileDTO?>
    {
        private readonly IDbContext _context;

        public GetUserByIdQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfileDTO?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                                     .Include(u => u.Posts)
                                     .Include(u => u.LikedPosts)
                                     .FirstOrDefaultAsync(user => user.Id == request.Id);

            if(user == null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }

            return user.FromUserToProfileDTO();

        }
    }
}
