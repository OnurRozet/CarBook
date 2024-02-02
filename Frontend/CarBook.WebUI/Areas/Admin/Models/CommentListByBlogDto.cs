using CarBook.Domanin.Entities;

namespace CarBook.WebUI.Areas.Admin.Models
{
    public class CommentListByBlogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
        public int BlogId { get; set; }
     
    }
}
