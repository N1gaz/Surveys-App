using Application.Interfaces;
using DomainModel.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Comands
{
    public class CreateAnswerCommand : IRequest<int>
    {
        public int QuestionId { get; init; }
        public string AnswerText { get; set; }
        public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, int>
        {
            private readonly IDbContext _context;

            public CreateAnswerCommandHandler(IDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
            {
                var answer = new Answer { QuestionId = request.QuestionId, AnswerText = request.AnswerText };
                _context.Answers.Add(answer);

                return _context.GetNextQuestionId(request.QuestionId);
            }
        }


    }
}
