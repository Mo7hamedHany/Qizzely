using AutoMapper;
using Quizzely.Core.DataTransferObjects;
using Quizzely.Core.Interfaces.Repositories;
using Quizzely.Core.Interfaces.Services;
using Quizzely.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Services.ExamServicee
{
    public class ExamService : IExamService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExamDto>> GetAllExamsAsync() {
            var exams = await _unitOfWork.Repository<Exam, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ExamDto>>(exams);
        }
       
        public async Task<ExamDto> GetExamByIdAsync(int id)
        {
            var exam = await _unitOfWork.Repository<Exam, int>().GetByIdAsync(id);
            return _mapper.Map<ExamDto>(exam);
        }

        public async Task<IEnumerable<McqDto?>> GetMcqQuestionsByExamId(int examId)
        {
            var questions = await _unitOfWork.Repository<McqQuestion, int>().GetAllAsync();

            var exam = await _unitOfWork.Repository<Exam, int>().GetByIdAsync(examId);

            var matchingQuestions = questions.Where(q => q.ExamId == examId).ToList();

            var mappedMcqs = _mapper.Map<IEnumerable<McqDto>>(matchingQuestions);

            foreach (var mcqDto in mappedMcqs)
            {
                mcqDto.ExamName = exam.Name;
            }

            return mappedMcqs;
        }

        public async Task<McqDto> GetSingleMcqQuestionById(int id)
        {
            var mcqQuestion = await _unitOfWork.Repository<McqQuestion, int>().GetByIdAsync(id);
            return _mapper.Map<McqDto>(mcqQuestion);
        }

        public async Task<TofDto> GetSingleTofQuestionById(int id)
        {
            var tofQuestion = await _unitOfWork.Repository<TofQuestion, int>().GetByIdAsync(id);
            return _mapper.Map<TofDto>(tofQuestion);
        }

        public async Task<IEnumerable<TofDto>> GetTofQuestionsByExamId(int examId)
        {
            var questions = await _unitOfWork.Repository<TofQuestion, int>().GetAllAsync();

            var exam = await _unitOfWork.Repository<Exam, int>().GetByIdAsync(examId);

            var matchedQuestions = questions.Where(q => q.ExamId == examId).ToList();

            var mappedTofs = _mapper.Map<IEnumerable<TofDto>>(matchedQuestions);

            foreach (var tof in mappedTofs)
            {
                tof.ExamName = exam.Name;
            }

            return mappedTofs;
        }
    }
}
