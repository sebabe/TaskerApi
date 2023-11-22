using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppTasks
{
    public class List
    {
        public class Query : IRequest<Result<List<AppTask>>> {
            
        }

        public class Handler : IRequestHandler<Query, Result<List<AppTask>>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
            }

            public async Task<Result<List<AppTask>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var appTasks = await _context.AppTasks.ToListAsync(cancellationToken);
                if (appTasks == null)
                {
                    return Result<List<AppTask>>.Failure("Not found");
                }
                return Result<List<AppTask>>.Success(await _context.AppTasks.ToListAsync(cancellationToken));
            }
        }
    }
}