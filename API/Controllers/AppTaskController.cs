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
        public async Task<IActionResult> GetAppTask(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));    
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppTask(AppTask appTask){
            await Mediator.Send(new Create.Command {AppTask = appTask});
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppTask(Guid id){
            await Mediator.Send(new Delete.Command{Id = id});
            return Ok();
        }
    }
}