
namespace SocialMedia.Core.Models
{
    public class PostLike
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int PostId { get; set; }
        public Post? Post { get; set; }

        public override bool Equals(object? obj)
        {
            return ((PostLike)obj).UserId == UserId && ((PostLike)obj).PostId == PostId;
        }

        public override int GetHashCode()
        {
            return  HashCode.Combine(UserId,PostId);
        }
    }
}
