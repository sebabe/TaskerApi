using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.AppTasks
{
    public class Change
    {
        public class Command : IRequest{
            public Guid Id { get; set; }
            public AppTask AppTask { get; set; }
        }

        public class Handle : IRequestHandler<Command>
        {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
            public Handle(DataContext context, IMapper mapper)
            {
            _mapper = mapper;
            _context = context;
            }

           async Task IRequestHandler<Command>.Handle(Command request, CancellationToken cancellationToken)
            {
                var oldAppTask = await _context.AppTasks.FindAsync(request.Id);
                _mapper.Map(request.AppTask, oldAppTask);

                await _context.SaveChangesAsync();
            }
        }
    }
}