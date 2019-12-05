using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ViewModel
{
    public class GetSubSectionsWithQuestions
    {
        public GetAllSubSections SubSection { get; set; }
        public IEnumerable<GetAllQuestions> Questions { get; set; }
    }
}
