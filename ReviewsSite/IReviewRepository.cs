using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
        Review FindById(int id);
    }
}
