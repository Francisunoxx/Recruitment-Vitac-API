using BLL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SykesArray_Vitac.Controllers
{
    [RoutePrefix("api/v1/question")]
    public class QuestionController : ApiController
    {
        private readonly IQuestionService iqs;

        public QuestionController(IQuestionService iqs)
        {
            this.iqs = iqs;
        }

        /// <summary>
        /// Get all questions without subsection and options.
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [Route("without_sub_section_and_options")]
        [HttpPost]
        public async Task<IHttpActionResult> All_Questions_Without_SubSection_And_Options([FromBody] Pagination pagination)
        {
            return Ok(await this.iqs.Serve_Questions_Without_SubSection_And_Options(pagination));
        }

        /// <summary>
        /// Get all questions with subsection and without options.
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [Route("with_sub_section_and_without_options")]
        [HttpPost]
        public async Task<IHttpActionResult> All_Questions_With_SubSection_And_Without_Options([FromBody] Pagination pagination)
        {
            return Ok(await this.iqs.Serve_Questions_With_SubSection_And_Without_Options(pagination));
        }

        // <summary>
        /// Get all questions without subsection and with options.
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [Route("without_sub_section_and_with_options")]
        [HttpPost]
        public async Task<IHttpActionResult> All_Questions_Without_SubSection_And_With_Options([FromBody] Pagination pagination)
        {
            return Ok(await this.iqs.Serve_Questions_Without_SubSection_And_With_Options(pagination));
        }

        // <summary>
        /// Get all questions with subsection and options.
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [Route("with_sub_question_and_options")]
        [HttpPost]
        public async Task<IHttpActionResult> All_Questions_With_SubQuestion_And_Options([FromBody] Pagination pagination)
        {
            return Ok(await this.iqs.Serve_Questions_With_SubQuestion_Options(pagination));
        }

        // <summary>
        /// Get url by section.
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [Route("url_by_section")]
        [HttpPost]
        public async Task<IHttpActionResult> Url_By_Section([FromBody] Section section)
        {
            return Ok(await this.iqs.Serve_Url_By_Section(section));
        }
    }
}
