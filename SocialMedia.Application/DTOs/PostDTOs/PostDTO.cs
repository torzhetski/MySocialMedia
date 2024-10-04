using SocialMedia.Application.DTOs.UserDTOs;

namespace SocialMedia.Application.DTOs.PostDTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public int AmountOfLikes { get; set; }

        public UserSummaryDTO User { get; set; }
    }
}
