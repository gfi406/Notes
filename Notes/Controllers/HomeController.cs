using Microsoft.AspNetCore.Mvc;
using Notes.Services;
using System.Threading.Tasks;

namespace Notes.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteService;

        public HomeController(INoteService noteService)
        {
            _noteService = noteService;
        }

       
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
