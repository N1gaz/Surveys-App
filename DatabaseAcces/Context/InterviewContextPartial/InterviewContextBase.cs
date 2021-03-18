using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAcces.Context.InterviewContextPartial
{
    /// <summary>
    /// MS SQL Database context
    /// </summary>
    public partial class InterviewContext : DbContext
    {
        public InterviewContext(DbContextOptions<InterviewContext> options)
            : base(options)
        {
        }
        private DbSet<Survey> Surveys { get; set; }
        private DbSet<Question> Questions { get; set; }
        private DbSet<Answer> Answers { get; set; }
        private DbSet<Interview> Interviews { get; set; }
        private DbSet<Result> Results { get; set; }
    }
}
