using SocialMedia.Core.Models;

namespace SocialMedia.Application.DTOs.PostDTOs
{
    public class PostSummaryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
