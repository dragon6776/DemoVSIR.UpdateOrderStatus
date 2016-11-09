using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.UpdateOrderStatus.XinhCaNgay.Models
{
    public enum Status
    {
        /// <summary>
        /// Chưa tiếp nhận/Chưa duyệt
        /// </summary>
        Pending = 1,
        /// <summary>
        /// Đã tiếp nhận/Chờ lấy hàng
        /// </summary>
        Approved = 2,
        /// <summary>
        /// Đã lấy hàng
        /// </summary>
        PickedUp = 3,
        /// <summary>
        /// Đang giao hàng/Đang vận chuyển
        /// </summary>
        Shipping = 4,
        /// <summary>
        /// Đã giao hàng/Giao hàng thành công
        /// </summary>
        Delivered = 5,
        /// <summary>
        /// Đã hủy
        /// </summary>
        Cancelled = -1,
    }

    public class UpdateOrderStatus
    {
        /// <summary>
        /// Token key lấy từ hàm Login
        /// </summary>
        public string TokenKey { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// danh sách đơn hàng
        /// </summary>
        public List<OrderItem> Orders { get; set; }
    }

    public class OrderItem
    {
        /// <summary>
        /// Mã đơn hàng   :Yêu cầu nhập
        /// </summary>
        [Key]
        public string OrderCode { get; set; }

        /// <summary>
        /// Ngày tháng:     Yêu cầu nhập,  format: yyyy-MM-dd hh:mm:ss
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Mã trạng thái đơn hàng  :Yêu cầu nhập
        /// </summary>
        public int OrderStatusCode { get; set; }

        /// <summary>
        /// Mô tả trạng thái đơn hàng của viettelpost
        /// </summary>
        public string OrderStatusText { get; set; }

        /// <summary>
        /// Mô tả khác
        /// </summary>
        public string Description { get; set; }
    }

}