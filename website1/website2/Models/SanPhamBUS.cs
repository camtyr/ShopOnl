using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace website2.Models
{
    public class SanPhamBUS
    {
        public static IEnumerable<SanPham> DanhSach()
        {
            QLBHEntities2 db = new QLBHEntities2();
            IQueryable<SanPham> dsQuery = 
                from ds in db.SanPhams
                select ds;
            return dsQuery;
        }

        public static IEnumerable<SanPham> DanhSach_TinhTrang()
        {
            QLBHEntities2 db = new QLBHEntities2();
            IQueryable<SanPham> dsQuery =
                from ds in db.SanPhams 
                join tt1 in db.LoaiSanPhams on ds.MaLoaiSanPham equals tt1.MaLoaiSanPham
                join tt2 in db.NhaSanXuats on ds.MaNhaSanXuat equals tt2.MaNhaSanXuat
                where ds.TinhTrang == true && tt1.TinhTrang == true && tt2.TinhTrang == true
                select ds;
            return dsQuery;
        }

        public static SanPham ChiTietSP(int id)
        {
            QLBHEntities2 db = new QLBHEntities2();
            return db.SanPhams.SingleOrDefault(m => m.MaSanPham == id);
        }
    }
}