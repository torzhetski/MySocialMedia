using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Interfaces;
using SocialMedia.Core.Models;
using SocialMedia.DataBase.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DataBase
{
    public class SocialMediaDbContext : DbContext, IDbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Post> Posts {  get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<PostLike> PostLikes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostLikeConfiguration()); 
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
