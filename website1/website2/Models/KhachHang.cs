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

    public partial class KhachHang
    {
        public int ID { get; set; }
        [DisplayName("Tên người dùng")]
        public string TenKhachHang { get; set; }
        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        public string UserName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }

        public virtual Account Account { get; set; }
    }
}
