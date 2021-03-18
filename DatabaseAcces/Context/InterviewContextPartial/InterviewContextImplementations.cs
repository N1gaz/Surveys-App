using Application.Interfaces.ApplicationDatabaseContext;
using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAcces.Context.InterviewContextPartial
{
    public partial class InterviewContext : IQuestionsAccessable, IResultCreator
    {

        private int GetNextQuestionId(int curId)
        {
            var curQuestion = Questions.Find(curId);
            var result = Questions.
                Where(a => a.SurveyId == curQuestion.SurveyId && a.Number == curQuestion.Number + 1).
                FirstOrDefault();

            return result != null ? result.Id : 0;
        }

        public async Task<Question> GetQuestionById(int id)
        {
            var result = await Questions.FindAsync(id);

            if (result == null)
            {
                throw new ArgumentException("Невеный номер вопроса");
            }

            result.Answers = await Answers.Where(a => a.QuestionId == result.Id).ToListAsync();
            return result;
        }

        public async Task<int> CreateResult(Result result)
        {
            await Results.AddAsync(result);
            await SaveChangesAsync();
            return GetNextQuestionId(Answers.Find(result.AnswerId).QuestionId);
        }
    }
}
