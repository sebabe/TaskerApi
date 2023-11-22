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
        public async Task<IActionResult> GetAppTasks(){
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppTask(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));    
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppTask(AppTask appTask){
            return HandleResult(await Mediator.Send(new Create.Command {AppTask = appTask}));
        }

        [HttpPut]
        public async Task<IActionResult> ChangeAppTask(Guid id, AppTask appTask){
            return HandleResult(await Mediator.Send(new Change.Command { Id = id, AppTask = appTask}));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppTask(Guid id){
            await Mediator.Send(new Delete.Command{Id = id});
            return Ok();
        }
    }
}