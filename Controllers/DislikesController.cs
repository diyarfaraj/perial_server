using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using perial_server.DTOs;
using perial_server.Extensions;
using perial_server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perial_server.Controllers
{
    public class DislikesController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly ILikesRepository _likesRepository;

        public DislikesController(IUserRepository userRepository, ILikesRepository likesRepository)
        {
            _userRepository = userRepository;
            _likesRepository = likesRepository;
        }
        //dislike methods

        [HttpPost("{username}")]
        public async Task<ActionResult> AddDislike(string username)
        {
            var sourceUserId = User.GetUserId();
            var dislikedUser = await _userRepository.GetUserByUsernameAsync(username);
            var sourceUser = await _likesRepository.GetUserWithDislikes(sourceUserId);
            if (dislikedUser == null) return NotFound();
            if (sourceUser.UserName == username) return BadRequest("You can not dislike youself");
            var userDislike = await _likesRepository.GetUserDislike(sourceUserId, dislikedUser.Id);
            if (userDislike != null) return BadRequest("You already disliked this user");
            userDislike = new Entities.UserDisLike
            {
                SourceUserId = sourceUserId,
                DisLikedUserId = dislikedUser.Id
            };
            sourceUser.DisLikedUsers.Add(userDislike);
            if (await _userRepository.SaveAllAsync()) return Ok();
            return BadRequest("failed to dislike user");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DislikeDto>>> GetUserDislikes(string predicate)
        {
            var users = await _likesRepository.GetUserDislikes(predicate, User.GetUserId());
            return Ok(users);
        }
    }
}
