using Favtick.Core.Entities;

namespace Favtick.Core.Repositories.Candidates
{
    public interface ICandidateRepository
    {
        Task<Candidate> Create(Candidate candidate);
        Task<bool> Delete(int id);
        Task<Candidate> Get(int id);
        Task<IEnumerable<Candidate>> GetAll();
        Candidate Update(Candidate candidate);
    }
}