using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website2.Models
{
    public class LoaiSanPhamBUS
    {
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            QLBHEntities2 db = new QLBHEntities2();
            IQueryable<LoaiSanPham> dsQuery = 
                from ds in db.LoaiSanPhams
                select ds;
            return dsQuery.ToList();
        }

        public static IEnumerable<LoaiSanPham> DanhSach_TinhTrang()
        {
            QLBHEntities2 db = new QLBHEntities2();
            IQueryable<LoaiSanPham> dsQuery =
                from ds in db.LoaiSanPhams
                where ds.TinhTrang == true
                select ds;
            return dsQuery.ToList();
        }

        public static IEnumerable<SanPham> ChiTiet(int id)
        {
            QLBHEntities2 db = new QLBHEntities2();
            IQueryable<SanPham> ctQuery = 
                from ct in db.SanPhams
                where ct.MaLoaiSanPham == id
                select ct;
            return ctQuery.ToList();
        }

        public static IEnumerable<SanPham> DanhSachSP_TinhTrang(int id)
        {
            QLBHEntities2 db = new QLBHEntities2();
            IQueryable<SanPham> ctQuery =
                from ct in db.SanPhams
                where ct.MaLoaiSanPham == id && ct.TinhTrang == true
                select ct;
            return ctQuery.ToList();
        }

        public static LoaiSanPham ChiTietLSP(int id)
        {
            QLBHEntities2 db = new QLBHEntities2();
            return db.LoaiSanPhams.SingleOrDefault(m => m.MaLoaiSanPham == id);
        }
    }
}