using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.UpdateOrderStatus.XinhCaNgay.Models
{
    public class UpdateStatusResult
    {
        public string TokenKey { get; set; }
        public List<OrderItem> SuccessOrders { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}