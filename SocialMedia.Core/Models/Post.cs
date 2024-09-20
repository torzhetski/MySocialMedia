using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Core.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        [NotMapped]
        public int AmountOfLikes => LikedUsers.Count;

        public int UserId { get; set; }
        public User? User { get; set; }

        public IList<Comment> Comments { get; set; } = new List<Comment>();

        public IList<PostLike> LikedUsers { get; set; } = new List<PostLike>();
    }
}
