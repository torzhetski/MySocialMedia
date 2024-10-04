using SocialMedia.Application.DTOs.UserDTOs;
using SocialMedia.Core.Models;

namespace SocialMedia.Application.Mappers
{
    public static class UserMapper
    {
        public static UserProfileDTO FromUserToProfileDTO(this User user)
        {
            return new UserProfileDTO() 
            { 
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Avatar = user.Avatar,
                Posts = user.Posts.Select(post => post.FromPostToSummaryDTO()).ToList(),
                LikedPosts = user.LikedPosts.Select(postlike => postlike.FromPostLikeToDTO()).ToList(),
            };
            
        }

        public static UserSummaryDTO FromUserToSummaryDTO (this User user)
        {
            return new UserSummaryDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
                Avatar = user.Avatar,
            };
        }
    }
}
