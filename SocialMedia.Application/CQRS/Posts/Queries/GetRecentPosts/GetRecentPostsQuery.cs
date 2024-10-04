using MediatR;
using SocialMedia.Application.DTOs.PostDTOs;

namespace SocialMedia.Application.CQRS.Posts.Queries.GetRecentPosts
{
    public class GetRecentPostsQuery : IRequest<List<PostSummaryDTO>>
    {
        public int PageSize { get; } = 15;
        public int PageNumber { get; set; } = 1;
    }
}
