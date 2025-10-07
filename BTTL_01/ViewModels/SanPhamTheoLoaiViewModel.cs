using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTTL_01.Models;

namespace BTTL_01.ViewModels
{
    public class SanPhamTheoLoaiViewModel
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public List<SanPham> DanhSachSanPham { get; set; }
        public List<Loai> DanhSachLoai { get; set; }
    }
}