using System;
using System.Collections.Generic;
using System.Text;
using CFMART.Models.Context;

namespace CFMART.Models.Context
{
    public class ContextItemKeranjang
    {
        public string? NamaProduk { get; set; }
        public int HargaSatuan { get; set; }
        public int Jumlah { get; set; }
        public int TotalHarga => HargaSatuan * Jumlah;
    }
}
