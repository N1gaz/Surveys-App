using Application.Features.Comands;
using Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace SurveysWebApi.Controllers
{
    /// <summary>
    /// API controller for acess to application
    /// </summary>
    [Route("")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IMediator _mediator;
        /// <summary>
        /// Mediator property
        /// </summary>
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        /// <summary>
        /// This method tries to return question by HttpGet. Returns 404 when we have invalid id.
        /// </summary>
        /// <param name="id">question id</param>
        /// <returns>Question object in Json or 404</returns>
        [HttpGet("question/{id:int}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetQuestionByIdQuery { Id = id }));
            }
            catch(ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// This method tries to add Answer result in database application. Returns 400 if comand is invalid by
        /// AnswerId or
        /// InterviewId
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Next question Id or 400</returns>
        [HttpPost("answer")]
        public async Task<IActionResult> PostAnswerResult(CreateResultCommand command)
        {
            
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
