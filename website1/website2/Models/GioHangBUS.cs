using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace website2.Models
{
    public class GioHangBUS
    {
        public static IEnumerable<GioHang> DanhSach(int MaTaiKhoan)
        {
            QLBHEntities2 db = new QLBHEntities2();
            var dsQuery = 
                from ds in db.GioHangs
                where ds.MaTaiKhoan == MaTaiKhoan
                select ds;
            return dsQuery.ToList();
        }

        public static void Them(int MaSanPham, string TenSanPham, decimal Gia, int SoLuong, int MaTaiKhoan)
        {
            using (var db = new QLBHEntities2())
            {
                //var x = 
                //    from ds in db.GioHangs
                //    where ds.MaSanPham == MaSanPham && ds.MaTaiKhoan == MaTaiKhoan
                //    select ds;
                var x = db.GioHangs.SingleOrDefault(m => m.MaSanPham == MaSanPham && m.MaTaiKhoan == MaTaiKhoan);
                if(x != null)
                {
                    int SoLuongMoi = (int)x.SoLuong + SoLuong;
                    CapNhat(MaSanPham, TenSanPham, Gia, SoLuongMoi, MaTaiKhoan);
                }    
                else
                {
                    GioHang giohang = new GioHang();
                    {
                        giohang.MaSanPham = MaSanPham;
                        giohang.TenSanPham= TenSanPham;
                        giohang.MaTaiKhoan = MaTaiKhoan;
                        giohang.SoLuong = SoLuong;
                        giohang.Gia = Gia;
                        giohang.TongTien = Gia * SoLuong;
                    }
                    db.GioHangs.Add(giohang);   
                    db.SaveChanges();
                }    
            }
        }

        public static void CapNhat(int MaSanPham, string TenSanPham, decimal Gia, int SoLuong, int MaTaiKhoan)
        {
            using (var db = new QLBHEntities2())
            {
                var UpdateModel = db.GioHangs.SingleOrDefault(m => m.MaSanPham == MaSanPham && m.MaTaiKhoan == MaTaiKhoan);
                
                UpdateModel.MaSanPham = MaSanPham;
                UpdateModel.MaTaiKhoan = MaTaiKhoan;
                UpdateModel.TenSanPham = TenSanPham;
                UpdateModel.SoLuong = SoLuong;
                UpdateModel.Gia = Gia;
                UpdateModel.TongTien = Gia * SoLuong;
                db.SaveChanges();
            }    

        }

        
        public static decimal TongTien(int id)
        {
            QLBHEntities2 db = new QLBHEntities2();
            var dsQuery = DanhSach(id);
            decimal TongTienCuoi = 0;
            foreach(var item in dsQuery)
            {
                TongTienCuoi += (decimal)item.TongTien;
            }
           return TongTienCuoi;
        }

        public static void Xoa (int id)
        {
            QLBHEntities2 db ; db = new QLBHEntities2();
            var DeleteModel = db.GioHangs.Find(id);
            db.GioHangs.Remove(DeleteModel);
            db.SaveChanges ();
        }

        
    }
}