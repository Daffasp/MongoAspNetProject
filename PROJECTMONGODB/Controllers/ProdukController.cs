using Microsoft.AspNetCore.Mvc;
using ProjectMongoDB.Models;
using ProjectMongoDB.Services;

namespace ProjectMongoDB.Controllers
{
    public class ProdukController : Controller
    {
        private readonly ProdukService _produkService;

        // ✅ Gunakan Dependency Injection
        public ProdukController(ProdukService produkService)
        {
            _produkService = produkService;
        }

        // ✅ Halaman utama - menampilkan semua produk dari MongoDB
        public async Task<IActionResult> Index()
        {
            var produkList = await _produkService.GetAsync();
            return View(produkList);
        }

        // ✅ Halaman tambah produk
        public IActionResult Create()
        {
            return View();
        }

        // ✅ Simpan produk baru ke MongoDB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produk produk)
        {
            if (ModelState.IsValid)
            {
                await _produkService.CreateAsync(produk);
                return RedirectToAction(nameof(Index));
            }
            return View(produk);
        }

        // ✅ Halaman edit produk
        public async Task<IActionResult> Edit(string id)
        {
            var produk = await _produkService.GetByIdAsync(id);
            if (produk == null)
            {
                return NotFound();
            }
            return View(produk);
        }

        // ✅ Update produk di MongoDB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Produk produk)
        {
            if (id != produk.Id)
            {
                return BadRequest();
            }

            await _produkService.UpdateAsync(id, produk);
            return RedirectToAction(nameof(Index));
        }

        // ✅ Hapus produk
        public async Task<IActionResult> Delete(string id)
        {
            var produk = await _produkService.GetByIdAsync(id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _produkService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // ✅ Detail produk (opsional)
        public async Task<IActionResult> Details(string id)
        {
            var produk = await _produkService.GetByIdAsync(id);
            if (produk == null)
            {
                return NotFound();
            }
            return View(produk);
        }
    }
}
