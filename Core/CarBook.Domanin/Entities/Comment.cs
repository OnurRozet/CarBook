using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domanin.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}
