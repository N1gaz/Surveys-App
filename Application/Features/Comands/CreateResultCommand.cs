using Application.Interfaces.ApplicationDatabaseContext;
using DomainModel.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
            private readonly IResultCreator _context;
            public CreateResultCommandHandler(IResultCreator context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateResultCommand request, CancellationToken cancellationToken)
            {
                return await _context.CreateResult(new Result { InterviewId = request.InterviewId, AnswerId = request.AnswerId });
            }
        }
    }
}
