using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CFMART.Models.Context;
using CFMART.Views;

namespace CFMART
{
    static class Program
    {
        // =======================================================
        // DATA GLOBAL (Aksesibilitas antar Form)
        // =======================================================

        public static List<ContextItemKeranjang> DaftarBelanjaan = new List<ContextItemKeranjang>();

        public static List<DataProdukCari> KatalogProduk = new List<DataProdukCari>()
        {
            new DataProdukCari { Nama = "Lele Goreng", Harga = 12000, Gambar = null },
            new DataProdukCari { Nama = "Lele Bakar", Harga = 18000, Gambar = null },
            new DataProdukCari { Nama = "Mangut Lele", Harga = 22000, Gambar = null },
            new DataProdukCari { Nama = "Air Mineral", Harga = 5000, Gambar = null },
            new DataProdukCari { Nama = "Es Jeruk", Harga = 7000, Gambar = null },
            new DataProdukCari { Nama = "Es Teh", Harga = 5000, Gambar = null }
        };

        // Variabel status transaksi global
        public static string TipePesanan = "";
        public static string MetodePembayaran = "";

        // TAMBAHAN: Variabel global untuk catatan pesanan
        public static string CatatanPesanan = "";

        public static bool IsSudahBayar = false;

        // =======================================================
        // ENTRY POINT
        // =======================================================

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new DashboardPelanggan());
        }
    }
}