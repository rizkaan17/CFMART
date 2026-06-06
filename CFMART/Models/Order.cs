using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Models
{
    public class Order
    {
        public int Id_Order { get; set; }
        public DateTime Tgl_Order { get; set; }
        public int User_Id_User { get; set; }
        public int Status_Order_Id_Status_Order { get; set; }
        public int Meja_Id_Meja { get; set; }
        public int Tipe_Pesanan_Id_Tipe_Pesanan { get; set; }
        public string? Status_Pembayaran { get; set; }
        public string? Nama_Pelanggan { get; set; }
        public int? Metode_Pembayaran_Id_Metode_Pembayaran { get; set; }
        public string? Nomor_Pelanggan { get; set; }
    }
}
