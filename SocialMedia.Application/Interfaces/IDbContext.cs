using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Models;

namespace SocialMedia.Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<PostLike> PostLikes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
