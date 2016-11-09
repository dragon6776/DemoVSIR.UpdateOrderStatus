using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.UpdateOrderStatus.XinhCaNgay.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TokenKey { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

}