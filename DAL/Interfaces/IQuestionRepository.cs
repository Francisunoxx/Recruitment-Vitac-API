using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DAL.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<GetAllSections>> GetAllSections();
        Task<IEnumerable<GetAllSubSections>> GetAllSubSections();
        Task<IEnumerable<GetAllQuestions>> GetAllQuestions();
        Task<IEnumerable<GetAllSubQuestions>> GetAllSubQuestions();
        Task<IEnumerable<GetAllQuestionOptions>> GetAllQuestionOptions();
        Task<GetUrlBySection> GetUrlBySection(Section section);
    }
}
