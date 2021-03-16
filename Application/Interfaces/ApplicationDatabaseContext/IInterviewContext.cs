using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces.ApplicationDatabaseContext
{
    public interface IInterviewContext
    { 
        DbSet<Survey> Surveys { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }
        DbSet<Interview> Interviews { get; set; }
        DbSet<Result> Results { get; set; }
        Task<int> SaveChangesAsync();

    }
}
