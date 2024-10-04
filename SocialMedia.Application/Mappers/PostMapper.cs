using SocialMedia.Application.DTOs.PostDTOs;
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

        public static PostDTO FromPostToPostDTO(this Post post) 
        {
            return new PostDTO
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Description = post.Description,
                Created = post.Created,
                AmountOfLikes = post.AmountOfLikes,
                User = post.User.FromUserToSummaryDTO(),
            };
        }
    }
}
