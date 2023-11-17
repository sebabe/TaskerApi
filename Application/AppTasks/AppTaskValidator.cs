using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.AppTasks
{
    public class AppTaskValidator : AbstractValidator<AppTask>
    {
        public AppTaskValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.CreateDate).NotEmpty();
        }
    }
}