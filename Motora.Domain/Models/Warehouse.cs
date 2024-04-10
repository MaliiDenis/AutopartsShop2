using System.Collections.Generic;

namespace Motora.Domain.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string Location { get; set; }

        // Навигационное свойство
        public virtual ICollection<WarehouseStock> Stocks { get; set; }

        public Warehouse()
        {
            Stocks = new HashSet<WarehouseStock>();
        }
    }

}