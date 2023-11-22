using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.AppTasks
{
    public class Change
    {
        public class Command : IRequest<Result<Unit>>{
            public Guid Id { get; set; }
            public AppTask AppTask { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
            _mapper = mapper;
            _context = context;
            }

           public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var oldAppTask = await _context.AppTasks.FindAsync(request.Id);
                if (oldAppTask == null)
                {
                    Result<Unit>.Failure("Item not found");
                }
                _mapper.Map(request.AppTask, oldAppTask);

                var result = await _context.SaveChangesAsync() > 0;
                if (!result)
                {
                    return Result<Unit>.Failure("Proble with saving changes");
                }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}