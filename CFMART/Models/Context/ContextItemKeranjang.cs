using System;

namespace CFMART.Models.Context
{
    // =========================================================================
    // ENCAPSULATION: Kelas ini membungkus data pesanan ke dalam satu unit.
    // Kita menggunakan properti (get; set;) untuk melindungi akses data,
    // dan menggunakan 'Computed Property' untuk logika bisnis sederhana.
    // =========================================================================
    public class ContextItemKeranjang
    {
        // Property untuk menyimpan identitas produk
        public int IdProduk { get; set; } 
        
        // Property Nama Produk (nullable string)
        public string? NamaProduk { get; set; }
        
        // Property Harga Satuan
        public int HargaSatuan { get; set; }
        
        // Property Jumlah Pesanan
        public int Jumlah { get; set; }

        // COMPUTED PROPERTY: 
        // Ini adalah contoh enkapsulasi logika. Kita tidak perlu menyimpan 
        // TotalHarga di database/variabel, tapi kita menghitungnya secara 
        // dinamis saat dipanggil. Ini mencegah error perhitungan (data tidak sinkron).
        public int TotalHarga => HargaSatuan * Jumlah;
    }
}
