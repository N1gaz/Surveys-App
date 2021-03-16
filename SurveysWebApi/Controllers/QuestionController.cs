using Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace SurveysWebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("question/{id:int}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            return Ok(await Mediator.Send(new GetQuestionByIdQuery { Id = id}));
        }
    }
}
