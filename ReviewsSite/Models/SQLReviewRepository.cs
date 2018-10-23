using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Models
{
    public class SQLReviewRepository : Repository<Review>, IReviewRepository
    {
        public SQLReviewRepository(Context context) : base(context)
        {

        }
    }
}
