
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; 
        public string UserName { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public string? Description { get; set; }

        //public IList<Post> Posts { get; set; } = new List<Post>();

        public IList<PostLike> LikedPosts { get; set; } = new List<PostLike>();

        public IList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
