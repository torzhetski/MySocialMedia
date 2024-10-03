using SocialMedia.Core.Models;

namespace SocialMedia.Application.CQRS.Users.Queries.GetUserById
{
    public class UserProfileDTO
    {
        public int Id { get; set; }         
        public string UserName { get; set; }  
        public string Name { get; set; }     
        public string? Avatar { get; set; }

        public IList<Post> Posts { get; set; }

        public IList<PostLike> LikedPosts { get; set; }
    }
}
