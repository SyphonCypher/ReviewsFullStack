using Microsoft.AspNetCore.Mvc;
using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController: ControllerBase
    {
        private ITagRepository tagRepo;

        public TagController(ITagRepository tagRepo)
        {
            this.tagRepo = tagRepo;
        }

        [HttpGet("{reviewId}")]
        public IEnumerable<Tag> Get(int reviewId)
        {
            return tagRepo.GetTagsForReviewId(reviewId);
        }

        [HttpPost]
        public bool Post([FromBody] Tag newTag)
        {
            newTag.CreatedAt = DateTime.UtcNow;
            tagRepo.Create(newTag);
            return true;
        }
    }
}
