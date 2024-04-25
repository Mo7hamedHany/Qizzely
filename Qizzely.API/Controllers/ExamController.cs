using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizzely.Core.Interfaces.Services;

namespace Qizzely.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
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
    }
}
