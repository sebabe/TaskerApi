using Application.AppTasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AppTaskController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<AppTask>>> GetAppTasks(){
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppTask>> GetAppTask(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
    }
}