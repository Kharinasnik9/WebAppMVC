using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models.Db;

namespace WebAppMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }

        // GET: /Users/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Users/Register
        [HttpPost]
        public async Task<IActionResult> Register(string FirstName, string LastName)
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                ModelState.AddModelError("", "Имя и фамилия обязательны для заполнения.");
                return View();
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName,
                JoinDate = DateTime.Now
            };

            await _repo.AddUser(user);
            return View(user);
        }
    }
}
