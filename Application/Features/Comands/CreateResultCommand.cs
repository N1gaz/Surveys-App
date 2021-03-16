using Application.Interfaces.ApplicationDatabaseContext;
using DomainModel.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Features.Comands
{
    /// <summary>
    /// Request to application what creates new Result record
    /// </summary>
    public class CreateResultCommand : IRequest<int>
    {
        /// <summary>
        /// Argument in request body means answer 
        /// </summary>
        public int AnswerId { get; set; }
        /// <summary>
        /// Argument in request body means interview 
        /// </summary>
        public int InterviewId { get; set; }
        private class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, int>
        {
            private readonly IInterviewContext _context;
            /// <summary>
            /// .ctor
            /// </summary>
            /// <param name="context">Application context what implements IInterviewContext</param>
            public CreateResultCommandHandler(IInterviewContext context)
            {
                _context = context;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns>Next question id</returns>
            public async Task<int> Handle(CreateResultCommand request, CancellationToken cancellationToken)
            {


                var result = new Result { AnswerId = request.AnswerId, InterviewId = request.InterviewId };

                _context.Results.Add(result);
                await _context.SaveChangesAsync();

                return GetNextQuestionId(_context.Answers.Find(result.AnswerId).QuestionId);
            }

            private int GetNextQuestionId(int questionId)
            {
                var curQuestion = _context.Questions.Find(questionId);
                var result = _context.Questions.
                    Where(a => a.SurveyId == curQuestion.SurveyId && a.Number == curQuestion.Number + 1).
                    FirstOrDefault();

                return result != null ? result.Id : 0;
            }
        }
    }
}
