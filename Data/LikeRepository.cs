﻿using Microsoft.EntityFrameworkCore;
using perial_server.DTOs;
using perial_server.Entities;
using perial_server.Extensions;
using perial_server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perial_server.Data
{
    public class LikeRepository : ILikesRepository
    {
        private readonly DataContext _context;

        public LikeRepository(DataContext context)
        {
            _context = context;
        }
        //like methods
        public async Task<UserLike> GetUserLike(int sourceUserId, int likedUserId)
        {
            return await _context.Likes.FindAsync(sourceUserId, likedUserId);
        }

        public async Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId)
        {
            var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
            var likes = _context.Likes.AsQueryable();
            if(predicate == "liked")
            {
                likes = likes.Where(like => like.SourceUserId == userId);
                users = likes.Select(like => like.LikedUser);
            }
            if(predicate == "likedBy")
            {
                likes = likes.Where(like => like.LikedUserId == userId);
                users = likes.Select(like => like.SourceUser);
            }

            return await users.Select(user => new LikeDto
            {
                Username = user.UserName,
                Age = user.DateOfBirth.CalculateAge(),
                PhotoUrl = user.Photos.FirstOrDefault(p => p.IsMain).Url,
                City = user.City,
                Id = user.Id
            }).ToListAsync();
        }

        public async Task<AppUser> GetUserWithLikes(int userId)
        {
            return await _context.Users
                .Include(u => u.LikedUsers)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

        //dislike methods--------------------------------------------------------------------------------------------
        public async Task<UserDisLike> GetUserDislike(int sourceUserId, int dislikedUserId)
        {
            return await _context.DisLikes.FindAsync(sourceUserId, dislikedUserId);
        }

        public async Task<IEnumerable<DislikeDto>> GetUserDislikes(string predicate, int userId)
        {
            var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
            var dislikes = _context.DisLikes.AsQueryable();
            if (predicate == "disliked")
            {
                dislikes = dislikes.Where(dislike => dislike.SourceUserId == userId);
                users = dislikes.Select(dislike => dislike.DisLikedUser);
            }
            if (predicate == "dislikedBy")
            {
                dislikes = dislikes.Where(dislike => dislike.DisLikedUserId == userId);
                users = dislikes.Select(dislike => dislike.SourceUser);
            }

            return await users.Select(user => new DislikeDto
            {
                Username = user.UserName,
                Age = user.DateOfBirth.CalculateAge(),
                PhotoUrl = user.Photos.FirstOrDefault(p => p.IsMain).Url,
                City = user.City,
                Id = user.Id
            }).ToListAsync();
        }

        public async Task<AppUser> GetUserWithDislikes(int userId)
        {
            return await _context.Users
                .Include(u => u.DisLikedUsers)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
