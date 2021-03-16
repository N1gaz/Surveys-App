﻿using Application.Features.Comands;
using Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
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
            try
            {
                return Ok(await Mediator.Send(new GetQuestionByIdQuery { Id = id }));
            }
            catch(ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

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