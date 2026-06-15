using CFMART.Models;
using CFMART.Models.Context;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CFMART.Controllers
{
    public class TransaksiController
    {
        /// <summary>
        /// Menangani proses check-out / simpan seluruh isi keranjang belanja dari RAM ke PostgreSQL
        /// </summary>
        /// <param name="keranjang">List belanjaan dari DataGridView pesanan pelanggan</param>
        /// <param name="nomerMeja">Input nomer meja dari TextBox kasir</param>
        /// <returns>True jika semua data berhasil disimpan total ke database</returns>
        public bool SimpanTransaksiBaru(List<ItemKeranjang> keranjang, string nomerMeja)
        {
            // 1. Validasi awal: Cegah transaksi jika keranjang masih kosong melompong
            if (keranjang == null || keranjang.Count == 0)
            {
                MessageBox.Show("Keranjang belanja masih kosong! Silakan pilih produk terlebih dahulu.",
                                "Gagal Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Ambil ID Kasir yang sedang aktif dari global static session User
            User kasirAktif = ContextUser.user;
            int idKasir = (kasirAktif != null) ? kasirAktif.id_user : 2; // Fallback otomatis ke ID 2 (Sari) jika session kosong

            try
            {
                // 3. Hitung total harga keseluruhan nota dari isi list keranjang belanja RAM
                double totalHargaNota = 0;
                foreach (var item in keranjang)
                {
                    totalHargaNota += item.sub_total;
                }

                // 4. Hubungkan ke ContextTransaksi untuk mengeksekusi data ke PostgreSQL
                ContextTransaksi contextTransaksi = new ContextTransaksi();

                // Kirim bungkusan data matang ke level database
                bool sukses = contextTransaksi.InsertNotaDanDetail(idKasir, totalHargaNota, nomerMeja, keranjang);

                if (sukses)
                {
                    MessageBox.Show("Transaksi pesanan pelanggan berhasil disimpan!",
                                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return sukses;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses transaksi di level Controller: " + ex.Message,
                                "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
