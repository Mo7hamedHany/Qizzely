using Quizzely.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Core.Interfaces.Services
{
    public interface IExamService
    {
        Task<IEnumerable<ExamDto>> GetAllExamsAsync();

        Task<ExamDto?> GetExamByIdAsync(int id);

        Task<IEnumerable<McqDto>> GetMcqQuestionsByExamId (int examId);

        Task<IEnumerable<TofDto>> GetTofQuestionsByExamId(int examId);

        Task<McqDto> GetSingleMcqQuestionById(int id);

        Task<TofDto> GetSingleTofQuestionById(int id);
    }
}
