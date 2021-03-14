using Microsoft.EntityFrameworkCore;
using perial_server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perial_server.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users{ get; set; }
        public DbSet<UserLike> Likes { get; set; }
        public DbSet<UserDisLike> DisLikes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //like
            builder.Entity<UserLike>()
                .HasKey(k => new { k.SourceUserId, k.LikedUserId });
            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserLike>()
                .HasOne(s => s.LikedUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.LikedUserId)
                .OnDelete(DeleteBehavior.Cascade);
            //dislike
            builder.Entity<UserDisLike>()
                .HasKey(k => new { k.SourceUserId, k.DisLikedUserId });
            builder.Entity<UserDisLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.DisLikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserDisLike>()
                .HasOne(s => s.DisLikedUser)
                .WithMany(l => l.DisLikedByUsers)
                .HasForeignKey(s => s.DisLikedUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
