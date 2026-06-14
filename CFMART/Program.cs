using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CFMART.Models.Context;
using CFMART.Views; // Namespace untuk FormLogin jika diperlukan

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
        public static bool IsSudahBayar = false;

        // =======================================================
        // ENTRY POINT
        // =======================================================

        [STAThread]
        static void Main()
        {
            // Opsi 1: Jika menggunakan .NET terbaru (rekomendasi)
            // ApplicationConfiguration.Initialize();

            // Opsi 2: Metode klasik yang lebih kompatibel dengan berbagai versi
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new DashboardPelanggan());
        }
    }
}
