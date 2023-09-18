using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace website2.Models
{
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Tối thiểu 8 kí tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "mật khẩu phải có độ dài tối thiểu 8 kí tự, có kí tự hoa, số ")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "không trùng với mật khẩu mới")]
        public string ConfirmPassword { get; set; }
        
    }
}