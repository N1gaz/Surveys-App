using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Answer> Answers { get; set; }
        DbSet<Interview> Interviews { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Result> Results { get; set; }
        DbSet<Survey> Surveys { get; set; }

        Task<int> SaveChangesAsync();
        int GetNextQuestionId(int questionId);
    }
}
