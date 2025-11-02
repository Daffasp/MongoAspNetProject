using Microsoft.AspNetCore.Mvc;
using ProjectMongoDB.Models;
using ProjectMongoDB.Services;

namespace ProjectMongoDB.Controllers
{
    public class PembeliController : Controller
    {
        private readonly PembeliService _pembeliService;

        public PembeliController(PembeliService pembeliService)
        {
            _pembeliService = pembeliService;
        }

        // ✅ Halaman utama (view)
        public async Task<IActionResult> Index()
        {
            var pembeliList = await _pembeliService.GetAsync();
            return View(pembeliList); // akan render Views/Pembeli/Index.cshtml
        }

        // ✅ Detail Pembeli
        public async Task<IActionResult> Details(string id)
        {
            var data = await _pembeliService.GetByIdAsync(id);
            if (data == null) return NotFound();
            return View(data);
        }

        // ✅ Tambah Pembeli (form)
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Pembeli pembeli)
        {
            // Log untuk debug
            Console.WriteLine($"=== CREATE DEBUG ===");
            Console.WriteLine($"Nama: {pembeli.Nama}");
            Console.WriteLine($"Email: {pembeli.Email}");
            Console.WriteLine($"Alamat: {pembeli.Alamat}");
            Console.WriteLine($"Jurusan: {pembeli.Jurusan}");
            Console.WriteLine($"ModelState Valid: {ModelState.IsValid}");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }
            }

            // Hapus validasi, langsung insert
            try
            {
                await _pembeliService.CreateAsync(pembeli);
                Console.WriteLine("✅ Data berhasil disimpan!");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR: {ex.Message}");
                return View(pembeli);
            }
        }

        // ✅ Edit Pembeli
        public async Task<IActionResult> Edit(string id)
        {
            var data = await _pembeliService.GetByIdAsync(id);
            if (data == null) return NotFound();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Pembeli pembeli)
        {
            if (ModelState.IsValid)
            {
                await _pembeliService.UpdateAsync(id, pembeli);
                return RedirectToAction(nameof(Index));
            }
            return View(pembeli);
        }

        // ✅ Hapus Pembeli
        public async Task<IActionResult> Delete(string id)
        {
            var data = await _pembeliService.GetByIdAsync(id);
            if (data == null) return NotFound();

            await _pembeliService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}