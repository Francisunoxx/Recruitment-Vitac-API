using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IDapperRepository idr;
        public QuestionRepository(IDapperRepository idr)
        {
            this.idr = idr;
        }

        public Task<IEnumerable<GetAllSections>> GetAllSections()
        {
            return this.idr.ExecuteIEnumerableStoredProcedure<GetAllSections>("usp_GetAllSections");
        }

        public Task<IEnumerable<GetAllSubSections>> GetAllSubSections()
        {
            return this.idr.ExecuteIEnumerableStoredProcedure<GetAllSubSections>("usp_GetAllSubSections");
        }

        public Task<IEnumerable<GetAllQuestions>> GetAllQuestions()
        {
            return this.idr.ExecuteIEnumerableStoredProcedure<GetAllQuestions>("usp_GetAllQuestions");
        }

        public Task<IEnumerable<GetAllSubQuestions>> GetAllSubQuestions()
        {
            return this.idr.ExecuteIEnumerableStoredProcedure<GetAllSubQuestions>("usp_GetAllSubQuestions");
        }

        public Task<IEnumerable<GetAllQuestionOptions>> GetAllQuestionOptions()
        {
            return this.idr.ExecuteIEnumerableStoredProcedure<GetAllQuestionOptions>("usp_GetAllOptions");
        }

        public Task<GetUrlBySection> GetUrlBySection(Section section)
        {
            return this.idr.ExecuteClassStoredProcedure<GetUrlBySection>("usp_GetUrlBySection", new
            {
                Section = section.Text
            });
        }
    }
}
