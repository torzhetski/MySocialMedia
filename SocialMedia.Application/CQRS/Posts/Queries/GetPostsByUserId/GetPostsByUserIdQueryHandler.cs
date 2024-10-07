using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.DTOs.PostDTOs;
using SocialMedia.Application.Interfaces;
using SocialMedia.Application.Mappers;

namespace SocialMedia.Application.CQRS.Posts.Queries.GetPostsByUserId
{
    public class GetPostsByUserIdQueryHandler : IRequestHandler<GetPostsByUserIdQuery, List<PostSummaryDTO>>
    {
        private readonly IDbContext _context;

        public GetPostsByUserIdQueryHandler(IDbContext context) 
        {
            _context = context;
        }

        public async Task<List<PostSummaryDTO>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var posts = await _context.Posts
                                      .Where(post => post.UserId == request.UserId)
                                      .Select(post => post.FromPostToSummaryDTO())
                                      .ToListAsync();
            return posts;
        }
    }
}
