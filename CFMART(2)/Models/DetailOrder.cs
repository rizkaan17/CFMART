using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Models
{
    public class DetailOrder
    {
        public int Id_Detail_Order { get; set; }
        public int Quantity { get; set; }
        public string? Catatan { get; set; }
        public int Order_Id_Order { get; set; }
        public int Produk_Id_Produk { get; set; }
        public double Harga_Per_Item { get; set; }
    }
}