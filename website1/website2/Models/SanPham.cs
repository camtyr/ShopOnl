﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace website2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class SanPham
    {
        public int MaSanPham { get; set; }
        public Nullable<int> MaLoaiSanPham { get; set; }
        public Nullable<int> MaNhaSanXuat { get; set; }
        [Required(ErrorMessage = "Nhập tên sản phẩm")]
        [DisplayName("Tên sản phẩm")]
        public string TenSanPham { get; set; }
        [DisplayName("Cấu hình")]
        public string CauHinh { get; set; }
        public string HinhChinh { get; set; }
        public string Hinh1 { get; set; }
        public string Hinh2 { get; set; }
        public string Hinh3 { get; set; }
        public string Hinh4 { get; set; }
        [Required(ErrorMessage = "Nhập giá sản phẩm")]
        [DisplayName("Giá")]
        public Nullable<decimal> Gia { get; set; }
        [DisplayName("Số lượng đã bán")]
        public Nullable<int> SoLuongDaBan { get; set; }
        [DisplayName("Tình trạng")]
        public Nullable<bool> TinhTrang { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual NhaSanXuat NhaSanXuat { get; set; }
    }
}
