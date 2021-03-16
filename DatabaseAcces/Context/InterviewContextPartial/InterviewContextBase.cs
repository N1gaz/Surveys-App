﻿using Application.Interfaces.ApplicationDatabaseContext;
using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DatabaseAcces.Context.InterviewContextPartial
{
    /// <summary>
    /// MS SQL Database context
    /// </summary>
    public partial class InterviewContext : DbContext, IInterviewContext
    {
        public InterviewContext(DbContextOptions<InterviewContext> options)
            : base(options)
        {
        }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Result> Results { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
