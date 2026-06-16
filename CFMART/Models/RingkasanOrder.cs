using System;

namespace CFMART.Models // 🌟 SINKRON: Masuk ke folder Models murni
{
    // ENCAPSULATION: Wadah data bersih khusus untuk baris DataGridView ringkasan
    public class OrderRingkasan
    {
        public int id_order { get; set; }
        public DateTime tanggal_order { get; set; }
        public double total_harga { get; set; }
        public string nama_kasir { get; set; } = "Kasir";
    }
}