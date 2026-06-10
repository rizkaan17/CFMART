using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFMART.Models
{
    public class User
    {
        public int Id_User { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int Role_Id_Role { get; set; }
        public Boolean Status_Karyawan { get; set; }
    }
}