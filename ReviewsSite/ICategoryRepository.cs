using ReviewsSite.Models;
using System.Collections.Generic;

namespace ReviewsSite.Controllers
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
    }
}