using Application.Interfaces.ApplicationDatabaseContext;
using DomainModel.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Comands
{
    public class CreateResultCommand : IRequest<int>
    {
        public int AnswerId { get; set; }
        public int InterviewId { get; set; }

        public class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, int>
        {
            private readonly IInterviewContext _context;

            public CreateResultCommandHandler(IInterviewContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateResultCommand request, CancellationToken cancellationToken)
            {
                var result = new Result { AnswerId = request.AnswerId, InterviewId = request.InterviewId };
                _context.Results.Add(result);
                await _context.SaveChangesAsync();
                return _context.GetNextQuestionId(_context.Answers.Find(result.AnswerId).QuestionId);
            }
        }
    }
}
