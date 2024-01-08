using Favtick.Core.Entities;
using Favtick.Core.Migrations;
using Microsoft.EntityFrameworkCore;
using System;


namespace Favtick.Core.Repositories.Candidates
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly FavtickContext _favtickContext;

        public CandidateRepository(FavtickContext favtickContext)
        {
            _favtickContext = favtickContext;

        }

        public async Task<Candidate> Get(int id)
        {
            var data = await _favtickContext.Candidates
                .Include(candidate => candidate.Skills)
                .AsNoTracking()
                .FirstOrDefaultAsync(candidate => candidate.Id == id)
                .ConfigureAwait(false);
            return data;
        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            var data = await _favtickContext.Candidates.Include(x=>x.Skills).ToListAsync().ConfigureAwait(false);
            return data;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _favtickContext.Candidates.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

            _favtickContext.Candidates.Remove(data);
            await _favtickContext.SaveChangesAsync().ConfigureAwait(false);
            var deletedcandidate = await _favtickContext.Candidates.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            if (deletedcandidate == null)
            {
                return true;
            }
            return false;
        }
        public async Task<Candidate> Create(Candidate candidate)
        {
            await _favtickContext.AddAsync(candidate).ConfigureAwait(false);
            await _favtickContext.SaveChangesAsync();
            return candidate;
        }

        public Candidate Update(Candidate candidate)
        {
            _favtickContext.Candidates.Update(candidate);
            //await _favtickContext.SaveChangesAsync().ConfigureAwait(false);
            return candidate;
        }
    }
}
