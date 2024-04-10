using System.Collections.Generic;

namespace Motora.Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string SKU { get; set; } // Stock Keeping Unit
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        // Навигационные свойства
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductFeature> Features { get; set; }
        public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Product()
        {
            Features = new HashSet<ProductFeature>();
            WarehouseStocks = new HashSet<WarehouseStock>();
            OrderDetails = new HashSet<OrderDetail>();
        }
    }

}