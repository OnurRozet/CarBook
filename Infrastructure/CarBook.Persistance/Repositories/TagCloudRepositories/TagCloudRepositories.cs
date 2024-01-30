using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domanin.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.TagCloudRepositories
{
    public class TagCloudRepositories : ITagCloud
    {
        private readonly CarBookContext _context;

        public TagCloudRepositories(CarBookContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudWithBlogs()
        {
           var values = _context.TagClouds.Include(x=>x.Blog).ToList();
            return values;  
        }

        public List<TagCloud> GetTagCloudWithByBlogId(int id)
        {
            var values = _context.TagClouds.Include(x=>x.Blog).Where(x=>x.BlogId==id).ToList();
            return values;
        }
    }
}
