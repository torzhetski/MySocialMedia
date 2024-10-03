using SocialMedia.Core.Models;

namespace SocialMedia.Application.CQRS.Posts.Queries
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
