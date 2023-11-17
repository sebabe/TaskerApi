using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.AppTasks
{
    public class Details
    {
        public class Query : IRequest<AppTask>{
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, AppTask>
        {
        private readonly DataContext _context;
        
            public Handler(DataContext context)
            {
            _context = context;
            
            }

            public async Task<AppTask> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.AppTasks.FindAsync(request.Id);
            }
        }
    }
}