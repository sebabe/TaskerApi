using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.AppTasks
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>{
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var appTask = await _context.AppTasks.FindAsync(request.Id);
                if (appTask == null)
                {
                    return Result<Unit>.Failure("Item not found");
                }
                _context.AppTasks.Remove(appTask);
                return Result<Unit>.Success(Unit.Value);
                
            }
        }
    }
}