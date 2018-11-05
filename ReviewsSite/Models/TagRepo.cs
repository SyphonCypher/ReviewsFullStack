using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Models
{
    public class TagRepo : Repository<Tag>, ITagRepository
    {
        public TagRepo(Context db) :base(db)
        { }

        public IEnumerable<Tag> GetTagsForReviewId(int reviewId)
        {
            //List<Tag> matchingTags = new List<Tag>();
            //foreach (var tag in GetAll()) {
            //    foreach (var rt in tag.ReviewTags) {
            //        matchingTags.Add(rt.Tag);
            //    }
            //}
            var query = from tags in GetAll()
                        from reviewTags in tags.ReviewTags
                        where reviewTags.ReviewId == reviewId
                        orderby tags.Title
                        select reviewTags.Tag;
            return query.ToList();
        }
    }
}
