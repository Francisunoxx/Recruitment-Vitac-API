using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GetQuestionsBySection : IQuestionItems
    {
        public bool HasSubSections { get; set; }
        public bool HasSubQuestions { get; set; }
        public bool HasOptions { get; set; }
        public bool HasVideo { get; set; }
        public GetAllSections Section { get; set; }
        public IEnumerable<GetAllQuestions> Exam { get; set; }
    }
}
