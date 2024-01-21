using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entityForUpdate = await _repository.GetByIdAsync(request.TestimonialId);
            if (entityForUpdate != null)
            {
                entityForUpdate.Name = request.Name;
                entityForUpdate.Comment = request.Comment;
                entityForUpdate.Title = request.Title;
                entityForUpdate.ImageUrl = request.ImageUrl;
                await _repository.UpdateAsync(entityForUpdate);
            }
        }
    }
}
