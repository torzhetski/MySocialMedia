using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Exeptions;
using SocialMedia.Application.Interfaces;
using SocialMedia.Core.Models;

namespace SocialMedia.Application.CQRS.Posts.Queries.GetPostById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Post>
    {
        private readonly IDbContext _context;

        public GetPostByIdQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                                     .Include(u => u.Comments)
                                     .Include(u => u.LikedUsers)
                                     .Include(u => u.User)
                                     .FirstOrDefaultAsync(post => post.Id == request.Id);
            if (post == null) 
            {
                throw new NotFoundException(nameof(post), request.Id);  
            }
            return post;
                                      
        }
    }
}
