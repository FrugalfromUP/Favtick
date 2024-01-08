using Favtick.Core.Entities;
using Favtick.Core.Migrations;
using Favtick.Core.Repositories.Candidates;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace Favtick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository; 
        public CandidateController( ICandidateRepository candidateRepository)
        {
                _candidateRepository = candidateRepository;
        }
        // GET: api/<CandidateController>
       // [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> FetchAllCandidate()
        {
            var candidate = await _candidateRepository.GetAll();
            return Ok(candidate);
        }

        // GET api/<Candidat_candidateRepositoryeController>/
       // [Route("GetCandidate")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            return Ok(await _candidateRepository.Get(id).ConfigureAwait(false));
        }

        // POST api/<CandidateController>
       // [Route("CreateCandidate")]
        [HttpPost]
        public async Task<IActionResult> CreateCandidate(Candidate candidate)
        {
            return Ok(await _candidateRepository.Create(candidate));  

        }

        // PUT api/<CandidateController>/5
       // [Route("UpdateCandidate")]
        [HttpPut]
        public async Task<IActionResult> UpdateCandidateAsync(Candidate candidate)
        {
            var data = await _candidateRepository.Get(candidate.Id).ConfigureAwait(false);

            if(data != null)
            {
                return Ok( _candidateRepository.Update(candidate));
            }

            return NotFound();
        }

        // DELETE api/<CandidateController>/5'
      //  [Route("Delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _candidateRepository.Get(id).ConfigureAwait(false);
            if(data != null)
            {
                return Ok(await _candidateRepository.Delete(id).ConfigureAwait(false));
            }
            return NotFound();
        }
    }
}
