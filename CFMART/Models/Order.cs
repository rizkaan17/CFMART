using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Models
{
    public class Order
    {
        public int id_order { get; set; }
        public DateTime tgl_order { get; set; }
        public int user_id_user { get; set; }
        public int meja_id_meja { get; set; }
        public int tipe_pesanan_id_tipe_pesanan { get; set; }
        public bool status_pembayaran { get; set; }
        public int metode_pembayaran_id_metode_pembayaran { get; set; }

        // Backing field untuk Enkapsulasi nama
        private string? _namaPelanggan;

        public string? nama_pelanggan
        {
            get => _namaPelanggan;
            set => _namaPelanggan = string.IsNullOrWhiteSpace(value) ? "Pelanggan CFMART" : value.Trim();
        }
    }
}