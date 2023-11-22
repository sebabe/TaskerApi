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
    public class Details
    {
        public class Query : IRequest<Result<AppTask>>{
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<AppTask>>
        {
        private readonly DataContext _context;
        
            public Handler(DataContext context)
            {
            _context = context;
            
            }

            public async Task<Result<AppTask>> Handle(Query request, CancellationToken cancellationToken)
            {
                var appTask = await _context.AppTasks.FindAsync(request.Id);
                if (appTask == null)
                {
                    return Result<AppTask>.Failure("Not found");
                }
                return Result<AppTask>.Success(appTask);
            }
        }
    }
}