using DomainModel.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces.ApplicationDatabaseContext
{
    /// <summary>
    /// Interface for questions querries
    /// </summary>
    public interface IQuestionsAccessable
    {
        Task<Question> GetQuestionById(int id);
    }
}
