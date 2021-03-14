using perial_server.DTOs;
using perial_server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perial_server.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);
        Task<AppUser> GetUserWithLikes(int userId);
        Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);
        //dislike
        Task<UserDisLike> GetUserDislike(int sourceUserId, int likedUserId);
        Task<AppUser> GetUserWithDislikes(int userId);
        Task<IEnumerable<DislikeDto>> GetUserDislikes(string predicate, int userId);

    }
}
