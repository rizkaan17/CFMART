using System;
using System.Drawing;

namespace CFMART.Models // 🌟 Pindah ke kasta Models murni
{
    // DTO (Data Transfer Object) khusus untuk menampung hasil cari di RAM
    public class DataProdukCari
    {
        public string Nama { get; set; } = string.Empty;
        public int Harga { get; set; }
        public Image? Gambar { get; set; }
    }
}