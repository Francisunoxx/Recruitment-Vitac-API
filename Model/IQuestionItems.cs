using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IQuestionItems
    {
        bool HasSubSections { get; set; }
        bool HasSubQuestions { get; set; }
        bool HasOptions { get; set; }
        bool HasVideo { get; set; }
    }
}
