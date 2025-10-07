using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BTTL_01.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source=Agrimotor\\SQLEXPRESS;database=QL_Sach;User ID=sa; Password=123; Trusted_Connection=True;";
        SqlConnection con = new SqlConnection(strcon);

        public List<Loai> dsLoai = new List<Loai>();
        public List<SanPham> dsSanPham = new List<SanPham>();

        public DuLieu()
        {
            LoadLoai();
            LoadSanPham();
        }

        public void LoadLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_LOAI", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var loai = new Loai();
                loai.MaLoai = dr["MALOAI"].ToString();
                loai.TenLoai = dr["TENLOAI"].ToString();
                dsLoai.Add(loai);
            }
        }

        public void LoadSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_SANPHAM", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = dr["MASANPHAM"].ToString();
                sp.TenSP = dr["TENSP"].ToString();
                sp.Hinh = dr["HINH"].ToString();
                sp.Gia = Convert.ToDecimal(dr["GIA"]);
                sp.GhiChu = dr["GHICHU"].ToString();
                sp.MaLoai = dr["MALOAI"].ToString();
                dsSanPham.Add(sp);
            }
        }
        public List<Loai> GetLoaiSP()
        {
            List<Loai> ds = new List<Loai>();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_LOAI", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Loai l = new Loai();
                l.MaLoai = dr["MALOAI"].ToString();
                l.TenLoai = dr["TENLOAI"].ToString();
                ds.Add(l);
            }
            return ds;
        }
        // Lấy sản phẩm theo loại
        public List<SanPham> GetSanPhamByLoai(string maloai)
        {
            var list = new List<SanPham>();
            if (string.IsNullOrEmpty(maloai))
                return list;  

            using (SqlConnection cnn = new SqlConnection(strcon))
            {
                cnn.Open();
                string sql = "SELECT * FROM TBL_SANPHAM WHERE MALOAI = @MaLoai";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@MaLoai", maloai);

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var sp = new SanPham();
                        sp.MaSP = rd["MASANPHAM"].ToString();
                        sp.TenSP = rd["TENSP"].ToString();
                        sp.Hinh = rd["HINH"].ToString();
                        sp.Gia = rd.IsDBNull(rd.GetOrdinal("GIA")) ? 0 : Convert.ToDecimal(rd["GIA"]);
                        sp.GhiChu = rd["GHICHU"].ToString();
                        sp.MaLoai = rd["MALOAI"].ToString();
                        list.Add(sp);
                    }
                }
            }
            return list;
        }


    }
}