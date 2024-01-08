using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Favtick.Core.Entities
{
    public class Condidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Adress { get; set; }
        public string ResumeName { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
