using CarBook.Application.Authors.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _metiator;

        public AuthorController(IMediator metiator)
        {
            _metiator = metiator;
        }

        [HttpGet]

        public async Task<IActionResult> AuthorList()
        {
            var values = await _metiator.Send(new GetAuthorQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> AuthorById(int id)
        {
            var values = await _metiator.Send(new GetAuthorByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            await _metiator.Send(command);
            return Ok(command);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            await _metiator.Send(command);
            return Ok(command);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteAuthor(RemoveAuthorCommand command)
        {
            await _metiator.Send(command);
            return Ok(command);
        }
    }
}
