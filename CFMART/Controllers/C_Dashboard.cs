using CFMART.Models.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CFMART.Controllers
{
    public class DashboardController
    {
        private readonly ContextDashboard _context = new ContextDashboard();

        /// <summary>
        /// Mengambil data angka-angka statistik ringkasan dashboard utama admin
        /// </summary>
        public Dictionary<string, object> AmbilAngkaStatistik()
        {
            try
            {
                return _context.GetStatistikDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat statistik dashboard admin: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Dictionary<string, object> { { "total_pesanan", 0 }, { "total_stok", 0 }, { "karyawan_aktif", 0 } };
            }
        }

        // =======================================================
        // 🌟 LETAK POLYMORPHISM: METHOD OVERLOADING (Nama Sama, Parameter Beda)
        // =======================================================

        /// <summary>
        /// Bentuk 1: Mengambil semua data pesanan secara global tanpa filter (Default Admin)
        /// </summary>
        public DataTable AmbilPesananTerbaru()
        {
            try
            {
                return _context.GetPesananTerbaru();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data pesanan terbaru: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Bentuk 2: Mengambil data pesanan khusus yang difilter berdasarkan ID Karyawan/Kasir tertentu
        /// </summary>
        public DataTable AmbilPesananTerbaru(int idUserKaryawan)
        {
            try
            {
                if (idUserKaryawan <= 0) return AmbilPesananTerbaru(); // Jika ID tidak valid, larikan ke bentuk 1
                return _context.GetPesananTerbaru(idUserKaryawan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memfilter data pesanan karyawan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }
}