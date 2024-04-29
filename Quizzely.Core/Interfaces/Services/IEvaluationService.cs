using Quizzely.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.Interfaces.Services
{
    public interface IEvaluationService
    {
        public Task<int> ExamEvaluation(AnswerDto answer, int examId);
    }
}
