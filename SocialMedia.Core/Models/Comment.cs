
namespace SocialMedia.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public DateTime Created { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User? User { get; set; }

        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
