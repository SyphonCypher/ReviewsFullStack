using Microsoft.AspNetCore.Mvc;
using ReviewsSite.Models;
using System;
using System.Collections.Generic;

namespace ReviewsSite.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentRepository commentRepo;

        public CommentsController(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        [HttpGet("{reviewId}")]
        public IEnumerable<Comment> Get(int reviewId)
        {
            return commentRepo.GetCommentsForReviewId(reviewId);
        }

        [HttpPost]
        public bool Post([FromBody] Comment newComment)
        {
            newComment.CreatedAt = DateTime.UtcNow;
            commentRepo.Create(newComment);
            return true;
        }
    }
}
