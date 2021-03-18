using Application.Interfaces.ApplicationDatabaseContext;
using DomainModel.Entities;
using MediatR;
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
            private readonly IQuestionsAccessable _context;

            public GetQuestionByIdQueryHandler(IQuestionsAccessable context)
            {
                _context = context;
            }
            public async Task<Question> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.GetQuestionById(request.Id);
            }
        }
    }
}
