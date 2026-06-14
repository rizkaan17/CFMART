using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Models
{
    public class Produk
    {
        public int id_produk { get; set; }
        public string jenis_produk { get; set; }
        public byte[]? foto_Produk { get; set; }

        // Backing fields untuk Enkapsulasi harga & stok
        private double _harga;
        private int _stok;

        public double harga
        {
            get => _harga;
            set => _harga = (value < 0) ? 0 : value; // Jika diinput minus, paksa set ke 0
        }

        public int stok
        {
            get => _stok;
            set => _stok = (value < 0) ? 0 : value; // Jika diinput minus, paksa set ke 0
        }
    }
}