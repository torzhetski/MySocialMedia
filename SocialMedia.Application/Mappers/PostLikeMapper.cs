using SocialMedia.Application.DTOs.PostLikeDTOs;
using SocialMedia.Core.Models;

namespace SocialMedia.Application.Mappers
{
    public static class PostLikeMapper
    {
        public static PostLikeDTO FromPostLikeToDTO (this PostLike postLike)
        {
            return new PostLikeDTO
            {
                PostId = postLike.PostId,
                PostSummary = postLike.Post.FromPostToSummaryDTO(),
                UserId = postLike.UserId,
                UserSummary = postLike.User.FromUserToSummaryDTO(),
            };
        }
    }
}
