using Favtick.Core.Entities;
using Favtick.Core.Migrations;
using Favtick.Core.Repositories.Candidates;
using Favtick.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;


namespace Favtick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        public async Task<IActionResult> CreateCandidate(CandidateDto candidateDto)
        {
            //List<Skill> skills = candidateDto.Skills.Select(s=>s.)
            Candidate candidate = SaveAndMapCandidateResume(candidateDto);
            return Ok(await _candidateRepository.Create(candidate));
        }

        private static Candidate SaveAndMapCandidateResume(CandidateDto candidateDto)
        {
            SaveResumeToDIR(candidateDto);

            Candidate candidate = MapCandidateDtoToEntity(candidateDto);
            return candidate;
        }

        private static void SaveResumeToDIR(CandidateDto candidateDto)
        {
            var rootDirectory = "D:\\Download\\CandidateResumeDIR";
            var directoryPath = Path.Combine(rootDirectory, "resumes");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var filePath = Path.Combine(directoryPath, candidateDto.ResumeFile.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                candidateDto.ResumeFile.CopyTo(stream);
            }
        }


        private static Candidate MapCandidateDtoToEntity(CandidateDto candidateDto)
        {
            //List<Skill> skills = candidateDto.Skills.Select(skill => JsonConvert.DeserializeObject<Skill>(Uri.UnescapeDataString(skill))).ToList();
            List<Favtick.Core.Entities.Skill> skills = candidateDto.Skills
            .Select(skillDto => new Core.Entities.Skill
            {
                Id = skillDto.Id,
                Name = skillDto.Name,
            })
            .ToList();
            //foreach (var item in candidateDto.Skills)
            //{
            //    skills.Add(new Core.Entities.Skill()
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //    });
            //}

            Candidate candidate = new Candidate()
            {
                Id = candidateDto.Id,
                Skills = skills,
                Gender = candidateDto.Gender,
                Adress = candidateDto.Adress,
                Name = candidateDto.Name,
                ResumeName = candidateDto.ResumeFile.FileName,
            };
            return candidate;
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
