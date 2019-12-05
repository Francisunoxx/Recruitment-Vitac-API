using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Question : IQuestion
    {
        public int QuestionId { get; set; }
        public int SectionId { get; set; }
        public string Quiz { get; set; }
    }
}
