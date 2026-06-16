using System;
using System.Drawing;

namespace CFMART.Models
{
    // ENCAPSULATION: Menjaga integritas data produk di memori
    public class DataProdukCari
    {
        public string Nama { get; set; } = "Produk";
        public int Harga { get; set; }
        public Image? Gambar { get; set; }
    }
}