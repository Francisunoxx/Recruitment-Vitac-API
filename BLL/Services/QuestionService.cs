using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository iqr;
        public QuestionService(IQuestionRepository iqr)
        {
            this.iqr = iqr;
        }

        public async Task<GetQuestionsBySection> Serve_Questions_Without_SubSection_And_Options(Pagination pagination)
        {
            var resultAllSections = this.iqr.GetAllSections();
            var resultAllQuestions = this.iqr.GetAllQuestions();

            await Task.WhenAll(resultAllSections, resultAllQuestions);

            var section = resultAllSections.Result.Where(x => x.Text == pagination.SectionToSearch).ToList()[0];
            var allQuestions = resultAllQuestions.Result.ToList().Where(x => x.SectionId == section.SectionId);


            GetQuestionsBySection questions = new GetQuestionsBySection()
            {
                HasSubSections = false,
                HasSubQuestions = false,
                HasOptions = false,
                HasVideo = false,
                Section = section,
                Exam = allQuestions
            };

            return questions;
        }

        public async Task<GetQuestionsWithSubSectionAndWithoutOptions> Serve_Questions_With_SubSection_And_Without_Options(Pagination pagination)
        {
            var resultAllSections = this.iqr.GetAllSections();
            var resultAllSubSections = this.iqr.GetAllSubSections();
            var resultAllQuestions = this.iqr.GetAllQuestions();
            var resultAllSubQuestions = this.iqr.GetAllSubQuestions();

            await Task.WhenAll(resultAllSections, resultAllQuestions, resultAllSubQuestions);

            var section = resultAllSections.Result.Where(x => x.Text == pagination.SectionToSearch).ToList()[0];
            var subSections = resultAllSubSections.Result.Where(x => x.SectionId == section.SectionId);

            List<GetSubSectionsWithQuestions> listSubSectionsWithQuestion = new List<GetSubSectionsWithQuestions>();

            foreach (var i in subSections)
            {
                GetAllSubSections subSection = i;
                var questions = resultAllQuestions.Result.Where(x => x.SectionId == subSection.SectionId && x.SubSectionId == subSection.Id);

                GetSubSectionsWithQuestions subSectionsWithQuestion = new GetSubSectionsWithQuestions()
                {
                    SubSection = subSection,
                    Questions = questions
                };

                listSubSectionsWithQuestion.Add(subSectionsWithQuestion);
            }

            GetQuestionsWithSubSectionAndWithoutOptions getQuestionsWithSubSection = new GetQuestionsWithSubSectionAndWithoutOptions()
            {
                HasSubSections = true,
                HasSubQuestions = false,
                HasOptions = false,
                HasVideo = false,
                Section = section,
                Exam = listSubSectionsWithQuestion
            };


            return getQuestionsWithSubSection;
        }

        public async Task<GetQuestionsWithoutSubSectionAndWithOptions> Serve_Questions_Without_SubSection_And_With_Options(Pagination pagination)
        {
            var resultAllSections = this.iqr.GetAllSections();
            var resultAllQuestions = this.iqr.GetAllQuestions();
            var resultAllOptions = this.iqr.GetAllQuestionOptions();

            await Task.WhenAll(resultAllSections, resultAllQuestions, resultAllOptions);

            var section = resultAllSections.Result.Where(x => x.Text == pagination.SectionToSearch).ToList()[0];
            var allQuestions = resultAllQuestions.Result.ToList().Where(x => x.SectionId == section.SectionId);
            var allOptions = resultAllOptions.Result.ToList();

            var counter = 0;
            var counterItem = 0;

            List<GetQuestionsWithOptionsAndWithoutSubQuestion> listQuestions = new List<GetQuestionsWithOptionsAndWithoutSubQuestion>();
            List<GetAllQuestionOptions> listAnswers;

            foreach (var q in allQuestions)
            {
                listAnswers = new List<GetAllQuestionOptions>();
                foreach (var o in allOptions)
                {
                    if (q.QuestionId == o.QuestionId)
                    {
                        counter++;
                        counterItem++;

                        listAnswers.Add(o);

                        if (counter == 4)
                        {
                            listQuestions.Add(new GetQuestionsWithOptionsAndWithoutSubQuestion()
                            {
                                QuestionId = q.QuestionId,
                                SectionId = q.SectionId,
                                SubSectionId = q.SubSectionId,
                                Quiz = q.Quiz,
                                Options = listAnswers
                            });

                            listAnswers = new List<GetAllQuestionOptions>();
                            counter = 0;

                            break;
                        }
                    }
                }
            }

            GetQuestionsWithoutSubSectionAndWithOptions getQuestionWithoutSubSectionAndWithOptions = new GetQuestionsWithoutSubSectionAndWithOptions()
            {
                HasSubSections = false,
                HasSubQuestions = false,
                HasOptions = true,
                HasVideo = false,
                Section = section,
                Exam = listQuestions
            };

            return getQuestionWithoutSubSectionAndWithOptions;
        }

        public async Task<GetQuestionsWithSubQuestionAndOption> Serve_Questions_With_SubQuestion_Options(Pagination pagination)
        {
            var resultAllSections = this.iqr.GetAllSections();
            var resultAllQuestions = this.iqr.GetAllQuestions();
            var resultAllSubQuestions = this.iqr.GetAllSubQuestions();
            var resultAllOptions = this.iqr.GetAllQuestionOptions();

            await Task.WhenAll(resultAllSections, resultAllQuestions, resultAllSubQuestions, resultAllOptions);

            var section = resultAllSections.Result.Where(x => x.Text == pagination.SectionToSearch).ToList()[0];
            var allQuestions = resultAllQuestions.Result.ToList().Where(x => x.SectionId == section.SectionId);
            var allSubQuestions = resultAllSubQuestions.Result.ToList();
            var allOptions = resultAllOptions.Result.ToList();

            var counter = 0;

            List<GetQuestionsWithOptionsAndSubQuestion> getQuestionsWithOptionsAndSubQuestion = new List<GetQuestionsWithOptionsAndSubQuestion>();
            List<GetAllSubQuestions> getAllSubQuestions = new List<GetAllSubQuestions>();
            List<GetAllQuestionOptions> getAllQuestionOptions = new List<GetAllQuestionOptions>();

            foreach (var q in allQuestions)
            {
                foreach (var sq in allSubQuestions)
                {
                    if (q.QuestionId == sq.QuestionId)
                    {
                        getAllSubQuestions.Add(new GetAllSubQuestions
                        {
                            Id = sq.Id,
                            QuestionId = sq.QuestionId,
                            Quiz = sq.Quiz,
                            Options = getAllQuestionOptions
                        });
                    }
                }

                foreach (var o in allOptions)
                {
                    if (q.QuestionId == o.QuestionId)
                    {
                        counter++;
                        getAllQuestionOptions.Add(o);
                    }

                    if (counter == 4)
                    {
                        counter = 0;
                        break;
                    }
                }


                getQuestionsWithOptionsAndSubQuestion.Add(new GetQuestionsWithOptionsAndSubQuestion
                {
                    QuestionId = q.QuestionId,
                    SectionId = q.SectionId,
                    SubSectionId = q.SubSectionId,
                    Quiz = q.Quiz,
                    SubQuestions = getAllSubQuestions
                });


                getAllSubQuestions = new List<GetAllSubQuestions>();
                getAllQuestionOptions = new List<GetAllQuestionOptions>();
            }


            GetQuestionsWithSubQuestionAndOption getQuestionWithSubQuestionAndOption = new GetQuestionsWithSubQuestionAndOption()
            {
                HasSubSections = false,
                HasSubQuestions = true,
                HasOptions = true,
                HasVideo = false,
                Section = section,
                Exam = getQuestionsWithOptionsAndSubQuestion
            };

            return getQuestionWithSubQuestionAndOption;
        }

        public async Task<GetUrlBySection> Serve_Url_By_Section(Section section)
        {
            var resultAllSections = this.iqr.GetAllSections();
            var resultUrlBySection = this.iqr.GetUrlBySection(section);

            await Task.WhenAll(resultAllSections, resultUrlBySection);

            var currentSection = resultAllSections.Result.Where(x => x.Text == section.Text).ToList()[0];

            GetUrlBySection getUrlBySection = new GetUrlBySection()
            {
                HasSubSections = false,
                HasSubQuestions = false,
                HasOptions = false,
                HasVideo = true,
                Section = currentSection,
                Header = resultUrlBySection.Result.Header,
                Url = resultUrlBySection.Result.Url
            };

            return getUrlBySection;
        }
    }
}
