using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces.ApplicationDatabaseContext
{
    /// <summary>
    /// Interface for IoC. That DbContext what can work with this app must implement it.
    /// </summary>
    public interface IInterviewContext
    { 
        /// <summary>
        /// Table Surveys interface.
        /// </summary>
        DbSet<Survey> Surveys { get; set; }
        /// <summary>
        /// Table Questions interface.
        /// </summary>
        DbSet<Question> Questions { get; set; }
        /// <summary>
        /// Table Answers interface.
        /// </summary>
        DbSet<Answer> Answers { get; set; }
        /// <summary>
        /// Table Interviews interface.
        /// </summary>
        DbSet<Interview> Interviews { get; set; }
        /// <summary>
        /// Table Results interface.
        /// </summary>
        DbSet<Result> Results { get; set; }
        /// <summary>
        /// Some requests need to save changes in database.
        /// </summary>
        Task<int> SaveChangesAsync();

    }
}
