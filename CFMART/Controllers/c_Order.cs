using System;
using System.Collections.Generic;
using System.Data;
using CFMART.Models;
using CFMART.Models.Context; // 🌟 KUNCI: Memanggil folder Context tempat query berada

namespace CFMART.Controllers
{
    public class OrderController
    {
        // Membuat objek context murni sesuai arsitektur MVC Fasilkom
        private readonly ContextTransaksi _context = new ContextTransaksi();

        // 🌟 1. Jembatan Simpan Nota Kasir
        public bool KirimPesanan(string namaPelanggan, List<ItemKeranjang> items, string statusTeks)
        {
            return _context.InsertNotaDanDetail(2, 0, "1", items);
        }

        // 🌟 2. Jembatan Kotak Kiri Dashboard (Menghilangkan Merah Pertama)
        public int AmbilTotalTransaksiHariIni()
        {
            return _context.GetTotalTransaksiHariIni();
        }

        // 🌟 3. Jembatan Kotak Tengah Dashboard
        public double AmbilPendapatanHariIni()
        {
            return _context.GetPendapatanHariIni();
        }

        // 🌟 4. Jembatan Kotak Kanan Dashboard (Menghilangkan Merah Kedua)
        public int AmbilTotalProdukTerlaris()
        {
            return _context.GetTotalProdukTerlaris();
        }

        // 🌟 5. Jembatan Tabel Riwayat Bawah (Menghilangkan Merah Ketiga)
        public DataTable AmbilRiwayatTransaksi()
        {
            return _context.GetRiwayatTransaksi();
        }
    }
}