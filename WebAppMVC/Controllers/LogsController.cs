using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models.Db;

namespace WebAppMVC.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("/logs")]
        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetRequests();
            return View(logs);
        }
    }
}
