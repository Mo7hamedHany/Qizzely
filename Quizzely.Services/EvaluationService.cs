using Quizzely.Core.DataTransferObjects;
using Quizzely.Core.Interfaces.Repositories;
using Quizzely.Core.Interfaces.Services;
using Quizzely.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExamService _examService;

        public EvaluationService(IUnitOfWork unitOfWork, IExamService examService)
        {
            _unitOfWork = unitOfWork;
            _examService = examService;
        }

        public async Task<int> ExamEvaluation(AnswerDto answer, int examId)
        {
            int finalResult = 0;

            var mcqQuestions = await _examService.GetMcqQuestionsByExamId(examId);
            var tofQuestions = await _examService.GetTofQuestionsByExamId(examId);

            var listedMcq = mcqQuestions.ToList();
            var listedTof = tofQuestions.ToList();

            // Evaluate multiple-choice questions
            if (answer.McqAnswers != null && mcqQuestions.Count() == answer.McqAnswers.Count)
            {
                for (int i = 0; i < mcqQuestions.Count(); i++)
                {
                    if (answer.McqAnswers[i].HasValue && answer.McqAnswers[i].Value == listedMcq[i].CorrectAnswer)
                    {
                        finalResult++;
                    }
                }
            }
            else
            {
                // Handle case where McqAnswers length doesn't match question count
                // Throw exception or log an error here
                throw new Exception("Number of MCQ answers doesn't match the number of questions.");
            }

            // Evaluate true/false questions
            if (answer.TofAnswers != null && tofQuestions.Count() == answer.TofAnswers.Count)
            {
                for (int i = 0; i < tofQuestions.Count(); i++)
                {
                    if (answer.TofAnswers[i].HasValue && answer.TofAnswers[i].Value == listedTof[i].CorrectAnswer)
                    {
                        finalResult++;
                    }
                }
            }
            else
            {
                // Handle case where TofAnswers length doesn't match question count
                // Throw exception or log an error here
                throw new Exception("Number of True/False answers doesn't match the number of questions.");
            }

            return finalResult;
        }
    }

}
