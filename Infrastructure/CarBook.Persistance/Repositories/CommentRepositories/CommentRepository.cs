using CarBook.Application.Features.RepositoryPattern.CommentRepositories;
using CarBook.Domanin.Entities;
using CarBook.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CommentRepositories
{
  
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
          private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Comment entity)
        {
            _context.Comments.Remove(entity);
            _context.SaveChanges() ;
        }

        public List<Comment> GetAll()
        {
           return _context.Comments.Select(x=> new Comment { Id = x.Id,
           BlogId = x.BlogId,
           CommentDate = x.CommentDate,
           CommentText = x.CommentText,
           Name = x.Name,
           }).ToList();
        }

        public Comment GetById(int id)
        {
            var value = _context.Comments.FirstOrDefault(x=> x.Id == id);
            return value;
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);   
            _context.SaveChanges();
        }
    }
}
