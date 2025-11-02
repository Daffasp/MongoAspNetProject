using ProjectMongoDB.Services;
using ProjectMongoDB.Settings;

var builder = WebApplication.CreateBuilder(args);

// ✅ Dengarkan semua IP agar bisa diakses dari jaringan lain
builder.WebHost.UseUrls("http://0.0.0.0:5222");

// ✅ Konfigurasi MongoDB
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));

// ✅ Tambahkan service untuk MongoDB, Login, Produk, dan Pembeli
builder.Services.AddSingleton<MongoDBService>(); // ini buat legacy kalo ada yang masih pake
builder.Services.AddSingleton<PembeliService>(); // ⬅️ TAMBAH INI
builder.Services.AddSingleton<LoginService>();
builder.Services.AddSingleton<ProdukService>();
builder.Services.AddSingleton<BahanService>();
builder.Services.AddSingleton<ProjectMongoDB.Services.LaporanService>();

// ✅ Tambahkan layanan MVC (Controller + View)
builder.Services.AddControllersWithViews();

// ✅ Swagger (opsional, hanya untuk pengujian API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Swagger aktif hanya di Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ⚠️ Jangan pakai HTTPS di jaringan lokal
// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ✅ Routing default ke Home (DASHBOARD)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// ✅ Jalankan aplikasi
app.Run();