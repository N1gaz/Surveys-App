using DomainModel.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces.ApplicationDatabaseContext
{
    /// <summary>
    /// Acces to DbContext for result creating
    /// </summary>
    public interface IResultCreator
    {
        Task<int> CreateResult(Result result);
    }
}
