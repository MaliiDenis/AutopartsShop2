﻿namespace Motora.Domain.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Навигационные свойства
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }

}