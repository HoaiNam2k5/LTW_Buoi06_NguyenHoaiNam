using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
namespace BTTL_01.Models
{
    public class TaiKhoan
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SoDienThoai { get; set; }
        public string MatKhau { get; set; }
    }
}
