using Microsoft.AspNetCore.Mvc;
using ProjectMongoDB.Models;
using ProjectMongoDB.Services;

namespace ProjectMongoDB.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("/Login")]
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginUser request)
        {
            var user = await _loginService.ValidateUserAsync(request.username, request.password);

            if (user == null)
            {
                ViewBag.Error = "Username atau password salah!";
                return View("Login");
            }

            // ✅ Login berhasil → redirect ke halaman Home
            return RedirectToAction("Index", "Home");
        }
    }
}
