﻿
namespace SocialMedia.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public IList<Post> Posts { get; set; } = new List<Post>();

        public IList<PostLike> LikedPosts { get; set; } = new List<PostLike>();

        public IList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
