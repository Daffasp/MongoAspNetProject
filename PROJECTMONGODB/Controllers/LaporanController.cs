using Microsoft.AspNetCore.Mvc;
using ProjectMongoDB.Models;
using ProjectMongoDB.Services;

namespace ProjectMongoDB.Controllers
{
    public class LaporanController : Controller
    {
        private readonly LaporanService _laporanService;

        public LaporanController(LaporanService laporanService)
        {
            _laporanService = laporanService;
        }

        // List
        public async Task<IActionResult> Index()
        {
            var data = await _laporanService.GetAsync();
            return View(data);
        }

        // Create (GET)
        public IActionResult Create()
        {
            return View(new LaporanPenjualan { Tanggal = DateTime.Today });
        }

        // Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LaporanPenjualan model)
        {
            if (!ModelState.IsValid) return View(model);
            await _laporanService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // Edit (GET)
        public async Task<IActionResult> Edit(string id)
        {
            var data = await _laporanService.GetByIdAsync(id);
            if (data == null) return NotFound();
            return View(data);
        }

        // Edit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, LaporanPenjualan model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            await _laporanService.UpdateAsync(id, model);
            return RedirectToAction(nameof(Index));
        }

        // Delete (GET)
        public async Task<IActionResult> Delete(string id)
        {
            var data = await _laporanService.GetByIdAsync(id);
            if (data == null) return NotFound();
            return View(data);
        }

        // Delete (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _laporanService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Details (opsional)
        public async Task<IActionResult> Details(string id)
        {
            var data = await _laporanService.GetByIdAsync(id);
            if (data == null) return NotFound();
            return View(data);
        }
    }
}
