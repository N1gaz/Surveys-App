using Application.Interfaces.ApplicationDatabaseContext;
using DomainModel.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    /// <summary>
    /// Request to application what returns question by id
    /// </summary>
    public class GetQuestionByIdQuery : IRequest<Question>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        private class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, Question>
        {
            private readonly IInterviewContext _context;

            /// <summary>
            /// .ctor
            /// </summary>
            /// <param name="context">Application context what implements IInterviewContext</param>
            public GetQuestionByIdQueryHandler(IInterviewContext context)
            {
                _context = context;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns>Task cotains Question object</returns>
            public async Task<Question> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Questions.FindAsync(request.Id);

                if(result == null)
                {
                    throw new ArgumentException("Невеный номер вопроса");
                }

                result.Answers = await _context.Answers.Where(a => a.QuestionId == result.Id).ToListAsync();
                return result;
            }
        }
    }
}
