using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GetQuestionsWithOptionsAndWithoutSubQuestion : IQuestion
    {
        public int QuestionId { get; set; }
        public int SectionId { get; set; }
        public int SubSectionId { get; set; }
        public string Quiz { get; set; }
        public IEnumerable<GetAllQuestionOptions> Options { get; set; }
    }
}
