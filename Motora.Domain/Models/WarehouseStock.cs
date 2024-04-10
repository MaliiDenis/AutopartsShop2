namespace Motora.Domain.Models
{
    public class WarehouseStock
    {
        public int WarehouseStockId { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Навигационные свойства
        public virtual Warehouse Warehouse { get; set; }
        public virtual Product Product { get; set; }
    }

}