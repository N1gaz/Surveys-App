﻿using Application.Interfaces;
using Application.Interfaces.ApplicationDatabaseContext;
using DomainModel.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetQuestionByIdQuery : IRequest<Question>
    {
        public int Id { get; set; }

        public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, Question>
        {
            private readonly IInterviewContext _context;

            public GetQuestionByIdQueryHandler(IInterviewContext context)
            {
                _context = context;
            }

            public async Task<Question> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.Questions.FindAsync(request.Id);
            }
        }
    }
}