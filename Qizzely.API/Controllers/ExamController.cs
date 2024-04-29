using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzely.Core.DataTransferObjects;
using Quizzely.Core.Interfaces.Services;

namespace Qizzely.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IEvaluationService _evaluationService;

        public ExamController(IExamService examService, IEvaluationService evaluationService)
        {
            _examService = examService;
            _evaluationService = evaluationService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllExams()
        {
            return Ok(await _examService.GetAllExamsAsync());
        }

        [HttpGet]
        public async Task<ActionResult> GetExam(int id)
        {
            return Ok(await _examService.GetExamByIdAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult> GetMcqQuestions(int examId)
        {
            return Ok(await _examService.GetMcqQuestionsByExamId(examId));
        }

        [HttpGet]
        public async Task<ActionResult> GetTofQuestions(int examId)
        {
            return Ok(await _examService.GetTofQuestionsByExamId(examId));
        }

        [HttpGet]
        public async Task<ActionResult> GetSingleMcqByID(int id)
        {
            return Ok(await _examService.GetSingleMcqQuestionById(id));
        }

        [HttpGet]
        public async Task<ActionResult> GetSingleTofByID(int id)
        {
            return Ok(await _examService.GetSingleTofQuestionById(id));
        }

        [HttpPost]
        public async Task<ActionResult> ExamEvaluation([FromBody] AnswerDto answer,int examId)
        {
            return Ok(await _evaluationService.ExamEvaluation(answer,examId));
        }
    }
}
