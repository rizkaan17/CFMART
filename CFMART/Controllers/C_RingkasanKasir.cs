using CFMART.Models.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CFMART.Controllers
{
    public class DashboardRingkasanKasir
    {
        private readonly ContextRingkasanKasir _context = new ContextRingkasanKasir();

        // 🌟 MODEL MENYATU DI SINI: Wadah data bersih khusus untuk baris DataGridView ringkasan
        public class OrderRingkasan
        {
            public int id_order { get; set; }
            public DateTime tanggal_order { get; set; }
            public double total_harga { get; set; }
            public string nama_kasir { get; set; }
        }

        /// <summary>
        /// Mengambil data angka-angka statistik dashboard harian kasir
        /// </summary>
        public Dictionary<string, object> AmbilAngkaStatistikKasir()
        {
            try
            {
                return _context.GetStatistikKasir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung statistik dashboard: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Dictionary<string, object> { { "total_transaksi", 0 }, { "total_pendapatan", 0.0 }, { "produk_terlaris", "-" } };
            }
        }

        // =======================================================
        // 🌟 PILAR POLYMORPHISM: METHOD OVERLOADING (Nama Sama, Parameter Beda)
        // =======================================================

        /// <summary>
        /// Bentuk 1: Tanpa Parameter - Mengambil seluruh data riwayat nota transaksi terbaru secara GLOBAL
        /// </summary>
        public List<OrderRingkasan> AmbilPesananTerbaru()
        {
            List<OrderRingkasan> listResult = new List<OrderRingkasan>();
            try
            {
                DataTable dataMentah = _context.GetPesananTerbaru();

                // Konversi baris tabel menjadi bentuk List objek berstandar OOP
                foreach (DataRow row in dataMentah.Rows)
                {
                    listResult.Add(new OrderRingkasan
                    {
                        id_order = Convert.ToInt32(row["id_order"]),
                        tanggal_order = row.Table.Columns.Contains("tanggal_order")
                            ? Convert.ToDateTime(row["tanggal_order"])
                            : Convert.ToDateTime(row["tgl_order"]),
                        total_harga = Convert.ToDouble(row["total_harga"]),
                        nama_kasir = row["nama_lengkap"]?.ToString() ?? "Kasir"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses riwayat transaksi terbaru: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listResult;
        }

        /// <summary>
        /// Bentuk 2: Pakai Parameter INT - Mengambil riwayat pesanan yang difilter langsung lewat database PostgreSQL
        /// </summary>
        public List<OrderRingkasan> AmbilPesananTerbaru(int idUserKasir)
        {
            List<OrderRingkasan> listResult = new List<OrderRingkasan>();
            try
            {
                // Memanggil fungsi bentuk 2 milik Context yang menggunakan parameter integer ID
                DataTable dataMentah = _context.GetPesananTerbaru(idUserKasir);

                foreach (DataRow row in dataMentah.Rows)
                {
                    listResult.Add(new OrderRingkasan
                    {
                        id_order = Convert.ToInt32(row["id_order"]),
                        tanggal_order = row.Table.Columns.Contains("tanggal_order")
                            ? Convert.ToDateTime(row["tanggal_order"])
                            : Convert.ToDateTime(row["tgl_order"]),
                        total_harga = Convert.ToDouble(row["total_harga"]),
                        nama_kasir = row["nama_lengkap"]?.ToString() ?? "Kasir"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses filter transaksi kasir: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listResult;
        }

        // =======================================================
    }
}