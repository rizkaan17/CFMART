using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CFMART.Models;

namespace CFMART
{
    static class Program
    {
        // =========================================================================
        // WADAH DATA GLOBAL RAM SEMENTARA
        // =========================================================================
        public static List<ItemKeranjang> DaftarBelanjaan { get; set; } = new List<ItemKeranjang>();
        public static string TipePesanan { get; set; } = "";
        public static string MetodePembayaran { get; set; } = "";
        public static string CatatanPesanan = "";

        public static bool IsSudahBayar = false;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 🌟 LANGSUNG JALANKAN DASHBOARD PELANGGAN UNTUK TESTING
            // Kita tunjuk langsung folder path-nya: CFMART.Views.Pelanggan.DashboardPelanggan
            Application.Run(new DashboardPelanggan());
        }
    }
}