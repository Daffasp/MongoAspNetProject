using Microsoft.AspNetCore.Mvc;
using ProjectMongoDB.Services;

namespace ProjectMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly MongoDBService _mongoService;

        public HomeController(MongoDBService mongoService)
        {
            _mongoService = mongoService;
        }

        public async Task<IActionResult> Index()
        {
            // Ambil data mahasiswa dari MongoDB
            var mahasiswaList = await _mongoService.GetAsync();

            // Kirim ke Views/Home/Home.cshtml
            return View("Home", mahasiswaList);
        }
    }
}
