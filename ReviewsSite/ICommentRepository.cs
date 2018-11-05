using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentsForReviewId(int reviewId);
        void Create(Comment comment);
    }
}
