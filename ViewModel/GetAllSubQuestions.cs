using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GetAllSubQuestions : IQuestion
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Quiz { get; set; }
        public IEnumerable<GetAllQuestionOptions> Options { get; set; }
    }
}
