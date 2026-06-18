using CFMART.Models;
using CFMART.Models.Context;
using CFMART.Models;          // 🌟 Memanggil folder Models murni tempat ItemKeranjang berada
using CFMART.Models.Context;  // 🌟 Memanggil folder Context tempat ContextTransaksi berada
using System;
using System.Collections.Generic;
using System.Data;

namespace CFMART.Controllers
{
    // 🌟 SINKRON: Namanya sekarang resmi TransaksiController sesuai dengan isinya!
    public class TransaksiController
    {
        private readonly ContextTransaksi _context = new ContextTransaksi();

        // Jembatan Simpan Nota Kasir ke Database
        public bool KirimPesanan(string namaPelanggan, List<ItemKeranjang> items, string statusTeks, string catatanUmum)
        {
            return _context.InsertNotaDanDetail(2, 0, namaPelanggan, items, catatanUmum);
        }

        // Jembatan Kotak Kiri Dashboard (Total Nota Hari Ini)
        public int AmbilTotalTransaksiHariIni()
        {
            return _context.GetTotalTransaksiHariIni();
        }

        public bool KirimPesananPelanggan(string mejaTeks, string tipePesanan, string metodePembayaran, string catatanUmum, List<ItemKeranjang> keranjang)
        {
            return _context.InsertPesananPelanggan(mejaTeks, tipePesanan, metodePembayaran, catatanUmum, keranjang);
        }

        // Jembatan Kotak Tengah Dashboard (Omzet Uang Hari Ini)
        public double AmbilPendapatanHariIni()
        {
            return _context.GetPendapatanHariIni();
        }

        // Jembatan Kotak Kanan Dashboard (Kuantitas Produk Terlaris)
        public int AmbilTotalProdukTerlaris()
        {
            return _context.GetTotalProdukTerlaris();
        }

        // Jembatan Tabel Riwayat Bagian Bawah
        public DataTable AmbilRiwayatTransaksi()
        {
            return _context.GetRiwayatTransaksi();
        }
    }
}