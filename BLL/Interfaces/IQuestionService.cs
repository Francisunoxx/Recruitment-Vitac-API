using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IQuestionService
    {
        Task<GetQuestionsBySection> Serve_Questions_Without_SubSection_And_Options(Pagination pagination);
        Task<GetQuestionsWithSubSectionAndWithoutOptions> Serve_Questions_With_SubSection_And_Without_Options(Pagination pagination);
        Task<GetQuestionsWithoutSubSectionAndWithOptions> Serve_Questions_Without_SubSection_And_With_Options(Pagination pagination);
        Task<GetQuestionsWithSubQuestionAndOption> Serve_Questions_With_SubQuestion_Options(Pagination pagination);
        Task<GetUrlBySection> Serve_Url_By_Section(Section section);
    }
}
