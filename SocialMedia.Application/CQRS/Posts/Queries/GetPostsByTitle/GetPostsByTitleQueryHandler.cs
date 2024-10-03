using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Interfaces;
using SocialMedia.Application.Mappers;

namespace SocialMedia.Application.CQRS.Posts.Queries.GetPostsByTitle
{
    public class GetPostsByTitleQueryHandler : IRequestHandler<GetPostsByTitleQuery, List<PostSummaryDTO>>
    {
        private readonly IDbContext _context;

        public GetPostsByTitleQueryHandler (IDbContext context)
        {
            _context = context;
        }   

        public async Task<List<PostSummaryDTO>> Handle(GetPostsByTitleQuery request, CancellationToken cancellationToken)
        {
            
            return await _context.Posts
                                       .Where(post => post.Title.Contains(request.Title))
                                       .OrderByDescending(post => post.Created)
                                       .Skip((request.PageNumber - 1) * request.PageSize)
                                       .Take(request.PageSize)
                                       .Select(post => post.FromPostToSummaryDTO())                                 
                                       .ToListAsync();
        }
    }
}
