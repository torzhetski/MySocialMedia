using MediatR;
using SocialMedia.Application.DTOs.PostDTOs;

namespace SocialMedia.Application.CQRS.Posts.Queries.GetPostsByUserId
{
    public class GetPostsByUserIdQuery : IRequest<List<PostSummaryDTO>>
    {
        public int UserId { get; set; }
    }
}
