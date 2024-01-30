using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domanin.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

		public List<Blog> GetALlBlogsWithAuthor()
		{
			var values = _context.Blogs.Include(b => b.Author).Include(c=>c.Category).ToList();
            return values;
		}

        public List<Blog> GetBlogWithAuthorId(int id)
        {
            var values = _context.Blogs.Include(x=>x.Author).Where(x=>x.BlogID == id).ToList();
            return values;
        }

        public  List<Blog> GetLast3BlogWithAuthor()
        {
            var values =  _context.Blogs.OrderByDescending(x=>x.BlogID).Take(3).Include(x=>x.Author).ToList();
            return values;
        }
    }
}
