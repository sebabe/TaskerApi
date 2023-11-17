using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.AppTasks
{
    public class Create
    {
        public class Command : IRequest{
            public AppTask AppTask { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.AppTask).SetValidator(new AppTaskValidator());
            }
        }

        public class Handler : IRequestHandler<Command>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.AppTasks.Add(request.AppTask);
                await _context.SaveChangesAsync();
            }
        }
    }
}