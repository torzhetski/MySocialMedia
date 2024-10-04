using SocialMedia.Application.DTOs.PostDTOs;
using SocialMedia.Application.DTOs.UserDTOs;

namespace SocialMedia.Application.DTOs.PostLikeDTOs
{
    public class PostLikeDTO
    {
        public int PostId { get; set; }
        public PostSummaryDTO? PostSummary { get; set; }

        public int UserId { get; set; }
        public UserSummaryDTO? UserSummary { get; set; }
    }
}
