using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website2.Models
{
    public class NhaSanXuatBUS
    {
        
        public static IEnumerable<NhaSanXuat> DanhSach()
        {
            QLBHEntities2 db = new QLBHEntities2();
            IQueryable<NhaSanXuat> dsQuery =
                from ds in db.NhaSanXuats
                select ds;
            return dsQuery.ToList();
        }

        public static IEnumerable<NhaSanXuat> DanhSach_TinhTrang()
        {
            QLBHEntities2 db = new QLBHEntities2();
            IQueryable<NhaSanXuat> dsQuery =
                from ds in db.NhaSanXuats
                where ds.TinhTrang == true
                select ds;
            return dsQuery.ToList();
        }

        public static IEnumerable<SanPham> ChiTiet(int id)
        {
            QLBHEntities2 db = new QLBHEntities2();
            IQueryable<SanPham> ctQuery =
                from ct in db.SanPhams
                where ct.MaNhaSanXuat == id
                select ct;
            return ctQuery.ToList();
        }

        public static IEnumerable<SanPham> DanhSachSP_TinhTrang(int id)
        {
            QLBHEntities2 db = new QLBHEntities2();
            IQueryable<SanPham> ctQuery =
                from ct in db.SanPhams
                where ct.MaNhaSanXuat == id && ct.TinhTrang == true
                select ct;
            return ctQuery.ToList();
        }

        public static NhaSanXuat ChiTietNSX(int id)
        {
            QLBHEntities2 db = new QLBHEntities2();
            return db.NhaSanXuats.SingleOrDefault(m => m.MaNhaSanXuat == id);
        }
    }
}