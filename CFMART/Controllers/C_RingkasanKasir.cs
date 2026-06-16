using CFMART.Models;
using CFMART.Models.Context;
using CFMART.Models;          // Memanggil folder Models tempat OrderRingkasan berada
using CFMART.Models.Context;  // Memanggil folder Context tempat ContextRingkasanKasir berada
using System;
using System.Collections.Generic;
using System.Data;

namespace CFMART.Controllers
{
    // 🌟 FIX: Nama class sekarang resmi menggunakan akhiran Controller agar tidak tabrakan dengan View!
    public class RingkasanKasirController
    {
        private readonly ContextRingkasanKasir _context = new ContextRingkasanKasir();

        /// <summary>
        /// Mengambil data angka-angka statistik dashboard harian kasir
        /// </summary>
        public Dictionary<string, object> AmbilAngkaStatistikKasir()
        {
            try
            {
                return _context.GetStatistikKasir();
            }
            catch
            {
                return new Dictionary<string, object>
                {
                    { "total_transaksi", 0 },
                    { "total_pendapatan", 0.0 },
                    { "produk_terlaris", "-" }
                };
            }
        }

        // =======================================================
        // 🌟 PILAR POLYMORPHISM: METHOD OVERLOADING
        // =======================================================

        /// <summary>
        /// Bentuk 1: Tanpa Parameter - Global
        /// </summary>
        public List<OrderRingkasan> AmbilPesananTerbaru()
        {
            List<OrderRingkasan> listResult = new List<OrderRingkasan>();
            try
            {
                DataTable dataMentah = _context.GetPesananTerbaru();

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
            catch
            {
                // Mengembalikan list kosong jika terjadi eror database
            }

            return listResult;
        }

        /// <summary>
        /// Bentuk 2: Pakai Parameter INT - Filter per Kasir
        /// </summary>
        public List<OrderRingkasan> AmbilPesananTerbaru(int idUserKasir)
        {
            List<OrderRingkasan> listResult = new List<OrderRingkasan>();
            try
            {
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
            catch
            {
                // Mengembalikan list kosong jika terjadi eror database
            }

            return listResult;
        }
    }
}