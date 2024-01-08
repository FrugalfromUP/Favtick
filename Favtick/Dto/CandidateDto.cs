namespace Favtick.Dto
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Adress { get; set; }
        public string ResumeName { get; set; }
        public List<SkillDto> Skills { get; set; }
        public IFormFile ResumeFile { get; set; }
    }
}
