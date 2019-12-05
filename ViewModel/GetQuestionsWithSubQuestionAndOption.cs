using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GetQuestionsWithSubQuestionAndOption : IQuestionItems
    {
        public bool HasSubSections { get; set; }
        public bool HasSubQuestions { get; set; }
        public bool HasOptions { get; set; }
        public bool HasVideo { get; set; }
        public GetAllSections Section { get; set; }
        public IEnumerable<GetQuestionsWithOptionsAndSubQuestion> Exam { get; set; }
    }
}
