using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Interfaces;
using SocialMedia.Application.Mappers;

namespace SocialMedia.Application.CQRS.Posts.Queries.GetRecentPosts
{
    public class GetRecentPostsQueryHandler : IRequestHandler<GetRecentPostsQuery, List<PostSummaryDTO>>
    {
        private readonly IDbContext _context;

        public GetRecentPostsQueryHandler(IDbContext context) 
        {
            _context = context;
        }

        public async Task<List<PostSummaryDTO>> Handle(GetRecentPostsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Posts
                                       .OrderByDescending(post => post.Created)
                                       .Skip((request.PageNumber - 1) * request.PageSize)
                                       .Take(request.PageSize)
                                       .Select(post => post.FromPostToSummaryDTO())
                                       .ToListAsync();
        }
    }
}
