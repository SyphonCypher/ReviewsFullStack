using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Descrip { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
