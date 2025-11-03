# 🧁 Bakery Management System 🚀

![Typing Animation](https://readme-typing-svg.herokuapp.com?font=Poppins&size=24&duration=3000&pause=1000&color=FF6FB5&width=700&lines=Bakery+Management+System;Built+with+ASP.NET+Core+%2B+MongoDB;Manage+Your+Bakery+Effortlessly+🍞)

[![Made with ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-9.0-blueviolet)](#)
[![MongoDB](https://img.shields.io/badge/MongoDB-NoSQL-success)](#)
[![Status](https://img.shields.io/badge/Status-Active-brightgreen)](#)

---

## 🍰 Tentang Project
**Bakery Management System** adalah aplikasi berbasis **ASP.NET Core** dan **MongoDB** yang dirancang untuk membantu toko bakery dalam mengelola operasional harian secara efisien.  
Mulai dari pencatatan produk, pelanggan, stok bahan, hingga laporan penjualan — semuanya terintegrasi dalam satu sistem yang modern, ringan, dan mudah digunakan.  

---

## ✨ Fitur Utama

| 🧩 Fitur | 💡 Deskripsi |
|----------|--------------|
| 🏠 **Dashboard Admin** | Menampilkan ringkasan data seperti total pembeli, produk, stok bahan, dan penjualan. |
| 👥 **Manajemen Pembeli** | CRUD (Create, Read, Update, Delete) data pelanggan bakery dengan tampilan tabel interaktif. |
| 🍞 **Manajemen Produk Bakery** | Kelola daftar produk, harga, stok, dan kategori produk dengan mudah. |
| 📈 **Laporan Penjualan** | Catat transaksi dan tampilkan laporan penjualan harian atau bulanan secara otomatis. |
| 🧺 **Manajemen Stok Bahan** | Pantau ketersediaan bahan baku untuk memastikan proses produksi berjalan lancar. |
| ⚙️ **Pengaturan Admin** | Ubah informasi toko, profil admin, dan konfigurasi sistem sesuai kebutuhan. |

---

## 🎨 Mockup / Desain Awal

> Berikut ini merupakan tampilan desain awal (mockup) sistem Bakery Management System:

![Mockup Preview](./images/mockup-bakery.png)

> 💡 *Desain dibuat menggunakan Balsamiq / Figma untuk menunjukkan alur dan struktur UI sebelum tahap pengembangan.*

---

## 🏗️ Struktur Project

```bash
BakeryManagementSystem/
│
├── Controllers/         # Mengatur alur logika API & halaman
├── Models/              # Menyimpan struktur data (Produk, Pembeli, dll)
├── Services/            # Berisi fungsi untuk komunikasi ke database MongoDB
├── Views/               # File tampilan (jika menggunakan Razor / MVC)
├── wwwroot/             # Asset statis (gambar, CSS, JS)
├── appsettings.json     # Konfigurasi koneksi MongoDB & environment
└── Program.cs           # Entry point utama aplikasi
