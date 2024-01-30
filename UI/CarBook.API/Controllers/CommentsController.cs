using CarBook.Application.Features.RepositoryPattern.CommentRepositories;
using CarBook.Domanin.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentsController(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _repository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CommentListById(int id)
        {
            var values = _repository.GetById(id);
            return Ok(values);
        }

        [HttpPost]

        public IActionResult CreateComment (Comment comment) 
        {
            _repository.Create(comment);
            return Ok(comment);
        }

        [HttpDelete]

        public IActionResult DeleteComment(Comment comment)
        {
            _repository.Delete(comment);
            return Ok(comment);
        }

        [HttpPut]

        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok(comment);
        }
    }
}
