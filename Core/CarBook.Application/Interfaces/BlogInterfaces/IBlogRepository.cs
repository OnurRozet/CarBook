using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetLast3BlogWithAuthor();
        List<Blog> GetALlBlogsWithAuthor();

        List<Blog> GetBlogWithAuthorId(int id);
    }
}
