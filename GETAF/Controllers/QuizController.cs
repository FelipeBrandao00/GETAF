using GETAF.Models.Context;
using GETAF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GETAF.Controllers
{
    public class QuizController : Controller
    {
        private readonly AppDbContext _context;
        public QuizController(AppDbContext context) { _context = context; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CriarQuiz([FromBody] QuizModel quizModel)
        {
            var quiz = quizModel.CriarQuiz(_context);
            return null;
        }

        public IActionResult ListarQuiz([FromBody] QuizModel quizModel)
        {
            return null;
        }

        public IActionResult UpdateQuiz([FromBody] QuizModel quizModel)
        {
            return null;
        }

        public IActionResult ExcluirQuiz([FromBody] QuizModel quizModel)
        {
            return null;
        }
    }
}
