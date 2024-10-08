﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Models;

namespace SocialMedia.DataBase.EntityTypeConfiguration
{
    public class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
    {
        public void Configure(EntityTypeBuilder<PostLike> builder)
        {
            builder.HasKey(pl => new { pl.UserId, pl.PostId });

            builder.HasOne(pl => pl.User)
                   .WithMany(u => u.LikedPosts)
                   .HasForeignKey(pl => pl.UserId);

            builder.HasOne(pl => pl.Post)
                   .WithMany(p => p.LikedUsers)
                   .HasForeignKey(pl => pl.PostId);
        }
    }
}
