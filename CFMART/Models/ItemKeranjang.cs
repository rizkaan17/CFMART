using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Models
{
    public class ItemKeranjang
    {
        // 1. ID Produk wajib dibawa untuk jadi Foreign Key (FK) pas simpan ke tabel detail_order
        public int id_produk { get; set; }

        // 2. String nama untuk ditampilkan di kolom DataGridView kanan kasir
        public string nama_produk { get; set; }

        // 3. Harga satuan produk untuk kalkulasi nota
        public double harga { get; set; }

        // 4. Qty (Kuantitas) barang yang dibeli oleh pelanggan
        public int quantity { get; set; }

        public string catatan { get; set; } // Opsional: Catatan khusus untuk item ini, misal "tanpa es" atau "extra pedas"

        // 5. 🌟 ENKAPSULASI: Properti read-only otomatis (tanpa set) untuk menghitung sub-total per baris menu.
        // Dosen sangat suka ini karena menerapkan pilar encapsulation murni lewat logic program C#.
        public double sub_total => harga * quantity; 
    }
}
