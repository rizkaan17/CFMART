using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Models
{
    public class Produk
    {
        public int Id_Produk { get; set; }
        public string? Jenis_Produk { get; set; }
        public double Harga { get; set; }
        public int Stok { get; set; }
        public byte[]? Foto_Produk { get; set; } // BLOB di ERD diwakili byte[] di C#
    }
}
