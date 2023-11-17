using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.AppTasks
{
    public class Delete
    {
        public class Command : IRequest{
            public Guid Id { get; set; }
        }

        public class Handle : IRequestHandler<Command>
        {
        private readonly DataContext _context;
            public Handle(DataContext context)
            {
            _context = context;
            }

            async Task IRequestHandler<Command>.Handle(Command request, CancellationToken cancellationToken)
            {
                var appTask = await _context.AppTasks.FindAsync(request.Id);
                _context.AppTasks.Remove(appTask);
            }
        }
    }
}