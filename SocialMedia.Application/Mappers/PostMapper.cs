using SocialMedia.Application.CQRS.Posts.Queries;
using SocialMedia.Core.Models;

namespace SocialMedia.Application.Mappers
{
    public static class PostMapper
    {
        public static PostSummaryDTO FromPostToSummaryDTO(this Post post)
        {
            return new PostSummaryDTO
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                UserId = post.UserId,
                Created = post.Created,
            };
        }
    }
}
