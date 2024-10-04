using SocialMedia.Application.DTOs.PostDTOs;
using SocialMedia.Application.DTOs.PostLikeDTOs;

namespace SocialMedia.Application.DTOs.UserDTOs
{
    public class UserProfileDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string? Avatar { get; set; }

        public IList<PostSummaryDTO> Posts { get; set; }

        public IList<PostLikeDTO> LikedPosts { get; set; }
    }
}
