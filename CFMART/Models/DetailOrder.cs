using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Models
{
    public class DetailOrder
    {
        public int id_detail_order { get; set; }
        public string? catatan { get; set; }
        public int order_id_order { get; set; }
        public int produk_id_produk { get; set; }
        public double sub_total { get; set; } // Nilai finansial akhir dijaga Trigger DB
        public string CatatanPesanan { get; set; }

        // Backing field untuk Enkapsulasi quantity belanja
        private int _quantity;

        public int quantity
        {
            get => _quantity;
            set => _quantity = (value <= 0) ? 1 : value; // Validasi: Minimal order harus 1 barang
        }
    }
}